using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AspireSystems.Service.ContextContracts;
using AspireSystems.Service.ModelContracts;
using AspireSystems.Service.Models;
using AspireSystems.Service.RepositoryContracts;
using Microsoft.EntityFrameworkCore;
using AspireSystems.Infrastructure.Helpers;
using AspireSystems.Diagnostics.Exceptions;
using System.Data.SqlClient;

namespace AspireSystems.Service.Repository
{
    public abstract class BaseRepositoryAsync<TEntity> : IBaseRepositoryAsync<TEntity> where TEntity : BaseModel
    {
        #region Members
        /// <summary>
        /// Entity Framework DbContext wrapper instance
        /// </summary>
        public readonly IBaseContext Context;


        /// <summary>
        /// Entity framework DbSet instance of current BaseModel entity
        /// </summary>
        protected virtual DbSet<TEntity> DbSet
        {
            get { return Context.SetEntity<TEntity>(); }
        }

        /// <summary>
        ///Base query on top of which further querying is done
        /// </summary>
        protected virtual IQueryable<TEntity> Query
        {

            get { return Context.SetQuery<TEntity>().Where(x => x.Status); }
        }



        #endregion Members

        #region Constructor

        /// <summary>
        /// Base repository instance
        /// </summary>
        /// <param name="_context"></param>
        /// <param name="rowFilterEvaluator"></param>
        /// <param name="provider"></param>
        protected BaseRepositoryAsync(IBaseContext _context)
        {
            Context = _context;

        }

        #endregion Constructor

        #region Public methods

        /// <summary>
        /// Repository scaffold to create a new BaseModel entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <throws>RepositoryException</throws>
        public virtual async Task<Guid> CreateAsync(TEntity entity)
        {
            // Set Entity State for composite/foreign-key related objects
            SetEntityStateForNavigationProperties(entity);

            // Add the transient object to context
            DbSet.Add(entity);

            // Populate audit field values before committing the changes
            CaptureAudit();

            // Commit context changes
            await Context.SaveChangesAsync();

            return entity.Id;
        }

        /// <summary>
        /// Repository scaffold to update a BaseModel entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <throws>RepositoryException</throws>
        public virtual async Task UpdateAsync(TEntity entity)
        {
            Context.DbContext.ChangeTracker.AutoDetectChangesEnabled = false;
            // Fetch the existing entity
            var existingEntity = Query.FirstOrDefault(c => c.Id.Equals(entity.Id));
            CloneObject(existingEntity);
            if (existingEntity != null)
            {
                // Update modified values
                CopyPropertiesTo(entity, existingEntity);

                // Attach changes to context
                Context.SetModified(existingEntity);

                // Populate audit fields before committing the changes
                CaptureAudit();

                // Commit context changes
                await Context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Repository scaffold to update a BaseModel entity status
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <throws>RepositoryException</throws>
        public virtual async Task RetrieveAsync(TEntity entity)
        {
            Context.DbContext.ChangeTracker.AutoDetectChangesEnabled = false;
            // Fetch the existing entity
            var existingEntity = Context.SetEntity<TEntity>().FirstOrDefault(c => c.Id.Equals(entity.Id) && !c.Status);
            CloneObject(existingEntity);
            if (existingEntity != null)
            {
                // Update modified values
                CopyPropertiesTo(entity, existingEntity);

                // Attach changes to context
                Context.SetModified(existingEntity);

                // Populate audit fields before committing the changes
                CaptureAudit();

                // Commit context changes
                await Context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Repository scaffold to hard delete a BaseModel entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <throws>RepositoryException</throws>
        public virtual async Task DeleteAsync(TEntity entity)
        {
            // Fetch the existing entity
            var deletedTEntity = Query.FirstOrDefault(x => x.Id == entity.Id);
            if (deletedTEntity != null)
            {
                // Mark entity as deleted
                Context.SetDeleted(deletedTEntity);
                // Commit context changes
                await Context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Repository scaffold to soft delete a BaseModel entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <throws>RepositoryException</throws>
        public virtual async Task SoftDeleteAsync(TEntity entity)
        {
            // Fetch the existing entity
            var deletedTEntity = Query.FirstOrDefault(x => x.Id == entity.Id);
            if (deletedTEntity != null)
            {
                // Set status to false
                deletedTEntity.Status = false;
                // Mark entity as modified
                Context.SetModified(deletedTEntity);
                // Commit context changes
                await Context.SaveChangesAsync();
            }
        }



        /// <summary>
        /// Repository scaffold to fetch BaseModel entity by a search condition predicate
        /// This fetch is Tenant agnostic.
        /// </summary>
        /// <param name="searchCondition"></param>
        /// <returns></returns>
        /// <throws>RepositoryException</throws>
        public virtual Task<Dictionary<Guid, TEntity>> SearchUnrestrictedAsync(ISearchCondition<TEntity> searchCondition)
        {
            // Get base tenant agnostic query
            var entities = Query.AsNoTracking();

            if (searchCondition != null)
            {
                // Include search condition predicate
                entities = Query.Where(searchCondition.Predicate);
            }
            // Execute query and convert results to a dictionary 
            var result = entities.ToDictionary(x => x.Id, x => x);

            return Task.FromResult(result);
        }

        /// <summary>
        /// Repository scaffold to fetch BaseModel entity by Id (Guid) with EF tracking settings
        /// This fetch is restricted by Tenant.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <throws>RepositoryException</throws>
        public virtual Task<TEntity> FetchAsync(Guid id, bool isTracked = true)
        {
            // For already existing entity validations
            if (!isTracked)
            {
                // Get the untracked entity from context
                var result = Query.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
                return result;
            }
            // Fetch the existing entity by Id
            return FetchEntityByIdAsync(id);
        }

        public void AddQuery(string query, List<SqlParameter> parameters)
        {
           Context.DbContext.Database.ExecuteSqlCommand(query, parameters);
        }
     #endregion Public methods

        #region Private methods

        /// <summary>
        /// Fetch existing entity with change tracking
        /// This action is restricted by tenant
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private Task<TEntity> FetchEntityByIdAsync(Guid id)
        {
            // Query includes tenant check
            var result = Query.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        /// <summary>
        /// Populate audit fields
        /// </summary>
        protected void CaptureAudit()
        {
            var userId = string.IsNullOrEmpty(UserIdentity.UserId) ? Guid.Empty : Guid.Parse(UserIdentity.UserId);

            // Get added entities list from EF Context
            var addedEntries = this.Context.DbContext.ChangeTracker.Entries<BaseModel>()
                .Where(a => a.State == EntityState.Added)
                .Select(e => e.Entity);

            // Get modified entities list from EF Context
            var modifiedEntries = this.Context.DbContext.ChangeTracker.Entries<BaseModel>()
                .Where(u => u.State == EntityState.Modified)
                .Select(e => e.Entity);

            foreach (var added in addedEntries)
            {


                if (added.Id == Guid.Empty)
                {
                    added.Id = Guid.NewGuid();
                }

                // Set create audit fields
                if (userId == Guid.Empty && added.CreatedByUserId != Guid.Empty)
                {
                    userId = added.CreatedByUserId;
                }
                added.CreatedByUserId = userId;
                if(added.CreatedAt == null || added.CreatedAt == DateTime.MinValue)
                added.CreatedAt = DateTime.UtcNow;
                added.Status = true;
            }

            foreach (var modified in modifiedEntries)
            {
                // Set update audit fields
                modified.UpdatedByUserId = userId;
                modified.UpdatedAt = DateTime.UtcNow;
            }
        }

        private void CopyPropertiesTo(object modifiedEntity, object entityFromDb)
        {
            // Check if source and destination objects are valid
            if (modifiedEntity == null || entityFromDb == null)
                throw new RepositoryException("Source or/and Destination Objects are null");

            // Get destination object type
            var typeDest = entityFromDb.GetType();

            // Iterate the Properties of the source instance and  
            //  populate them from their desination counterparts
            foreach (var srcProp in typeDest.GetProperties())
            {
                if (!srcProp.CanRead)
                {
                    continue;
                }
                var targetProperty = typeDest.GetProperty(srcProp.Name);
                if (targetProperty == null)
                {
                    continue;
                }
                if (!targetProperty.CanWrite)
                {
                    continue;
                }
                if (targetProperty.GetSetMethod(true) != null && targetProperty.GetSetMethod(true).IsPrivate)
                {
                    continue;
                }
                if ((targetProperty.GetSetMethod(true).Attributes & MethodAttributes.Static) != 0)
                {
                    continue;
                }
                if (!targetProperty.PropertyType.IsAssignableFrom(srcProp.PropertyType))
                {
                    continue;
                }
                if (targetProperty.Module.ScopeName == "EntityProxyModule")
                {
                    continue;
                }
                var sourceProperty = modifiedEntity.GetType().GetProperty(srcProp.Name); //Sometimes source may not have certain properties.
                if (sourceProperty == null)
                    continue;
                if (srcProp.Name.Equals("CreatedAt") || srcProp.Name.Equals("CreatedByUserId") || srcProp.Name.Equals("UpdatedAt") || srcProp.Name.Equals("ModifiedByUserId"))
                {
                    var sourceValue = srcProp.GetValue(entityFromDb, null);
                    targetProperty.SetValue(entityFromDb, sourceValue, null);
                }
                else
                {
                    var sourceValue = srcProp.GetValue(modifiedEntity, null);
                    targetProperty.SetValue(entityFromDb, sourceValue, null);
                }
            }
        }

        private bool IsManyToManyRelation(PropertyInfo property)
        {
            var attributes = property.GetCustomAttributes(typeof(ManyToManyAttribute), false);

            if (attributes != null && attributes.Any())
                return true;

            return false;
        }

        private void SetNavigationProperties(object modifiedEntity, object entityFromDb, string childentity = null, object existing = null)
        {
            var entityType = modifiedEntity.GetType();

            string ChildentityTypeName = entityType.Name;
            if (childentity != null)
            {
                ChildentityTypeName = childentity;
            }

            var navProperties = entityType.GetProperties()
                     .Where(p => (typeof(IEnumerable).IsAssignableFrom(p.PropertyType) && p.PropertyType != typeof(string) && p.Name != ChildentityTypeName) || (p.PropertyType.Namespace == entityType.Namespace && p.Name != ChildentityTypeName))
                     .Select(p => entityType.GetProperty(p.Name))
                     .ToList();

            foreach (var navProp in navProperties)
            {
                var isManyToManyRelation = IsManyToManyRelation(navProp);

                var sourcevalues = navProp.GetValue(modifiedEntity);

                if (sourcevalues == null || existing == null)
                    continue;
                var source = sourcevalues as IEnumerable;
                if (source != null)
                {
                    var destinationValues = (IEnumerable<object>)navProp.GetValue(existing);

                    var collectionType = sourcevalues.GetType();

                    if (!typeof(IList).IsAssignableFrom(collectionType))
                        continue;

                    var newValues = (IList)Activator.CreateInstance(collectionType);

                    foreach (var item in source)
                    {
                        var typeDest = item.GetType();
                        var propertyToCompare = typeDest.GetProperty("Id");

                        if (propertyToCompare == null)
                            break;

                        var sourceValue = propertyToCompare.GetValue(item, null);

                        bool entityExists = false;

                        if (destinationValues != null)
                        {
                            foreach (var destinationItem in destinationValues.ToList())
                            {
                                var destinationValue = propertyToCompare.GetValue(destinationItem, null);

                                if (sourceValue.Equals(destinationValue))
                                {
                                    CopyPropertiesTo(item, destinationItem);
                                    newValues.Add(destinationItem);
                                    Context.DbContext.Entry(destinationItem).State = isManyToManyRelation ? EntityState.Unchanged : EntityState.Modified;
                                    entityExists = true;
                                    break;
                                }
                            }
                        }
                        if (!entityExists)
                        {
                            Context.DbContext.Entry(item).State = isManyToManyRelation ? EntityState.Unchanged : EntityState.Added;
                            newValues.Add(item);
                        }
                    }
                    if (destinationValues != null)
                    {
                        foreach (var destinationItem in destinationValues.ToList())
                        {
                            var typeDest = destinationItem.GetType();
                            var typeDests = destinationItem.GetType();
                            var childsourcevalues = typeDests.GetProperties()
                     .Where(p => (typeof(IEnumerable).IsAssignableFrom(p.PropertyType) && p.PropertyType != typeof(string) && p.Name != ChildentityTypeName) || (p.PropertyType.Namespace == entityType.Namespace && p.Name != ChildentityTypeName))
                     .Select(p => typeDests.GetProperty(p.Name))
                     .ToList();

                            foreach (var entity in childsourcevalues)
                            {
                                var destination = entity.GetValue(destinationItem);
                                if (destination != null)
                                    Context.DbContext.Entry(destination).State = EntityState.Modified;
                            }
                            var propertyToCompare = typeDest.GetProperty("Id");

                            if (propertyToCompare == null)
                                break;

                            var sourceValue = propertyToCompare.GetValue(destinationItem, null);

                            bool entityExists;

                            foreach (var newValue in newValues)
                            {
                                var destinationValue = propertyToCompare.GetValue(newValue, null);
                                if (sourceValue.Equals(destinationValue))
                                {
                                    entityExists = true;
                                    break;
                                }
                            }
                        }
                    }
                    navProp.SetValue(entityFromDb, newValues);
                }
                else
                {

                    //Set originalEntity prop value to modifiedEntity value
                    if (sourcevalues == null)
                        continue;
                    var entityTypeChild = sourcevalues.GetType();
                    var childsourcevalues = entityTypeChild.GetProperties()
                       .Where(p => (typeof(IEnumerable).IsAssignableFrom(p.PropertyType) && p.PropertyType != typeof(string) && p.Name != ChildentityTypeName) || (p.PropertyType.Namespace == entityType.Namespace && p.Name != ChildentityTypeName))
                       .Select(p => entityTypeChild.GetProperty(p.Name))
                       .ToList();

                    var destinationValues = navProp.GetValue(entityFromDb);
                    if (destinationValues != null)
                    {
                        Context.DbContext.Entry(destinationValues).State = EntityState.Modified;
                        CopyPropertiesTo(sourcevalues, destinationValues);
                        navProp.SetValue(entityFromDb, destinationValues);
                        if (childsourcevalues.Any())
                        {
                            SetNavigationProperties(sourcevalues, destinationValues, entityType.Name);

                        }

                    }
                }
            }

        }


        private void SetEntityStateForNavigationProperties(TEntity entity)
        {
            var entityType = entity.GetType();

            var navProperties = entityType.GetProperties().Select(p => entityType.GetProperty(p.Name)).ToList();

            foreach (var navProp in navProperties)
            {
                var attributes = navProp.GetCustomAttributes(typeof(ManyToManyAttribute), false);

                if (Check.IsNotNullOrEmptyIEnumerable(attributes))
                {
                    var sourcevalues = navProp.GetValue(entity);
                    var source = sourcevalues as IEnumerable;
                    if (source != null)
                    {
                        foreach (var item in source)
                        {
                            // Many to many navigation property
                            if (Context.DbContext.Entry(item).State == EntityState.Detached)
                            {
                                Context.DbContext.Entry(item).State = EntityState.Unchanged;
                            }
                        }
                    }
                }
            }
        }

        private void CloneObject(object o)
        {
            Type t = o.GetType();
            PropertyInfo[] properties = t.GetProperties();

            Object p = t.InvokeMember("", BindingFlags.CreateInstance,
                null, o, null);

            foreach (PropertyInfo pi in properties)
            {
                if (pi.CanWrite)
                {
                    pi.SetValue(p, pi.GetValue(o, null), null);
                }
            }
        }

        #endregion Private methods
    }
}
