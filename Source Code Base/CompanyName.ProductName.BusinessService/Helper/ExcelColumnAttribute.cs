using System;
using System.Collections.Generic;
using System.Text;

namespace AspireSystems.TakeYourJob.BusinessService.Helper
{
    [AttributeUsage(AttributeTargets.All)]
    public class ExcelColumnAttribute : System.Attribute
    {
        public string ColumnName { get; set; }

        public ExcelColumnAttribute(string column)
        {
            ColumnName = column;
        }
    }
}
