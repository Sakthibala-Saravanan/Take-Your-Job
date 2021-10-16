using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AspireSystems.TakeYourJob.BusinessService.Models
{
    public class ColumnInfo
    {
        /// <summary>
        /// Gets or sets the Property
        /// </summary>
        public PropertyInfo Property { get; set; }
        /// <summary>
        /// Gets or sets the Column
        /// </summary>
        public string Column { get; set; }
        /// <summary>
        /// Gets or sets the ColumnOrder
        /// </summary>
        public int ColumnOrder { get; set; }

    }
}
