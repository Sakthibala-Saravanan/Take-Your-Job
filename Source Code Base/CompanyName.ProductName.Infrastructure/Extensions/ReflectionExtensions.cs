using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AspireSystems.ProductName.Infrastructure.Extensions
{
    public static class ReflectionExtensions
    {
        /// <summary>
        /// Gets properties of T
        /// </summary>
        public static IEnumerable<PropertyInfo> GetProperties<T>(BindingFlags binding, PropertyReflectionOptions options = PropertyReflectionOptions.All)
        {
            var properties = typeof(T).GetProperties(binding);

            bool all = (options & PropertyReflectionOptions.All) != 0;
            bool ignoreIndexer = (options & PropertyReflectionOptions.IgnoreIndexer) != 0;
            bool ignoreEnumerable = (options & PropertyReflectionOptions.IgnoreEnumerable) != 0;

            foreach (var property in properties)
            {
                if (!all)
                {
                    if (ignoreIndexer && IsIndexer(property))
                    {
                        continue;
                    }

                    if (ignoreIndexer && !property.PropertyType.Equals(typeof(string)) && IsEnumerable(property))
                    {
                        continue;
                    }
                }

                yield return property;
            }
        }

        /// <summary>
        /// Check if property is indexer
        /// </summary>
        private static bool IsIndexer(PropertyInfo property)
        {
            var parameters = property.GetIndexParameters();

            if (parameters != null && parameters.Length > 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Check if property implements IEnumerable
        /// </summary>
        private static bool IsEnumerable(PropertyInfo property)
        {
            return property.PropertyType.GetInterfaces().Any(x => x.Equals(typeof(System.Collections.IEnumerable)));
        }

        /// <summary>
        /// This method is used for converting the IEnumerable source into the Data Table
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>

        public static DataTable ToDataTable<T>(this IEnumerable<T> source)
        {
            DataTable table = new DataTable();

            //// get properties of T 
            var binding = BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty;
            var options = PropertyReflectionOptions.IgnoreEnumerable | PropertyReflectionOptions.IgnoreIndexer;

            var properties = ReflectionExtensions.GetProperties<T>(binding, options).ToList();

            //// create table schema based on properties 
            foreach (var property in properties)
            {
                if (property.PropertyType.IsEnum)
                    table.Columns.Add(property.Name, System.Type.GetType("System.Int32"));
                else if (property.PropertyType.IsClass)
                    table.Columns.Add(property.Name, System.Type.GetType("System.String"));
                else if (property.Name == "ActionPrivileges")
                    continue;
                else
                    table.Columns.Add(property.Name, Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);
            }

            //// create table data from T instances 
            object[] values = new object[properties.Count];

            foreach (T item in source)
            {
                for (int i = 0; i < properties.Count; i++)
                {
                    values[i] = properties[i].GetValue(item, null);
                }
                table.Rows.Add(values);
            }
            return table;
        }
        public static DataTable RemoveAuditColumns(this DataTable dataTable)
        {
            if (dataTable.Columns.IndexOf("Id") >= 0)
            {
                dataTable.Columns.RemoveAt(dataTable.Columns.IndexOf("Id"));
            }
            if (dataTable.Columns.IndexOf("Status") >= 0)
            {
                dataTable.Columns.RemoveAt(dataTable.Columns.IndexOf("Status"));
            }
            if (dataTable.Columns.IndexOf("CreatedAt") >= 0)
            {
                dataTable.Columns.RemoveAt(dataTable.Columns.IndexOf("CreatedAt"));
            }
            if (dataTable.Columns.IndexOf("UpdatedAt") >= 0)
            {
                dataTable.Columns.RemoveAt(dataTable.Columns.IndexOf("UpdatedAt"));
            }
            if (dataTable.Columns.IndexOf("UpdatedByUserId") >= 0)
            {
                dataTable.Columns.RemoveAt(dataTable.Columns.IndexOf("UpdatedByUserId"));
            }
            if (dataTable.Columns.IndexOf("CreatedByUserId") >= 0)
            {
                dataTable.Columns[dataTable.Columns.IndexOf("CreatedByUserId")].ColumnName = "UserId";
            }
            return dataTable;
        }
        public static DataTable RemoveDataColumn(this DataTable dataTable, string columnName)
        {
            if (dataTable.Columns.IndexOf(columnName) >= 0)
            {
                dataTable.Columns.RemoveAt(dataTable.Columns.IndexOf(columnName));
            }
            return dataTable;
        }
    }

    [Flags]
    public enum PropertyReflectionOptions : int
    {
        /// <summary>
        /// Take all.
        /// </summary>
        All = 0,

        /// <summary>
        /// Ignores indexer properties.
        /// </summary>
        IgnoreIndexer = 1,

        /// <summary>
        /// Ignores all other IEnumerable properties
        /// except strings.
        /// </summary>
        IgnoreEnumerable = 2
    }
}
