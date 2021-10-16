namespace AspireSystems.Service.Attributes
{
    using System;

    /// <summary>
    ///   Entity Identifier Attribute Properties
    /// </summary>
    public sealed class EntityIdentifierAttribute : Attribute
    {
        /// <summary>
        ///   Gets or sets the Name
        /// </summary>
        public string Name { get; set; }
    }
}
