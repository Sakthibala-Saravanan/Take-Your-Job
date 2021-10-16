using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using AspireSystems.TakeYourJob.BusinessService.Models;

namespace AspireSystems.TakeYourJob.BusinessService.Helper
{
    public class ExcelReaderHelper
    {
        public static List<ColumnInfo> GetColumns<T>(IExcelDataReader reader, Func<CustomAttributeData, bool> excelFileColumns)
        {
            var columns = typeof(T).GetProperties().Where(x => x.CustomAttributes.Any(excelFileColumns)).Select(p => new ColumnInfo()
            {
                Property = p,
                Column = p.GetCustomAttributes<ExcelColumnAttribute>().First().ColumnName,
                ColumnOrder = GetOrder(reader, p.GetCustomAttributes<ExcelColumnAttribute>().First().ColumnName)
            }).ToList();
            return columns;
        }

        public static int GetOrder(IExcelDataReader reader, string columnName)
        {
            for (int col = 0; col <= reader.FieldCount-1; col++)
            {
                var cellValue = reader.GetValue(col);
                if (cellValue != null)
                {
                    if (columnName == cellValue.ToString())
                    {
                        return col;
                    }
                }
            }
            //return new int();
            return -1;
        }

        public static int? TryParseInt(string Value)
        {
            var intValue = new int();
            if (int.TryParse(Value, out intValue))
            {
                return intValue;
            }
            return null;
        }

        public static decimal? TryParseDecimal(string Value)
        {
            var decimalValue = new decimal();
            if (decimal.TryParse(Value, out decimalValue))
            {
                return decimalValue;
            }
            return null;
        }

        public static DateTime? TryParseDateTime(object Value)
        {
            var dateTimeValue = new DateTime();
            if (DateTime.TryParse(Convert.ToString(Value), out dateTimeValue))
            {
                return dateTimeValue;
            }
            return null;
        }

        public static double? TryParseDouble(object Value)
        {
            var doubleValue = new double();
            if (double.TryParse(Convert.ToString(Value), out doubleValue))
            {
                return doubleValue;
            }
            return null;
        }
        public static long? TryParseLong(object Value)
        {
            var longValue = new long();
            if (long.TryParse(Convert.ToString(Value), out longValue))
            {
                return longValue;
            }
            return null;
        }

    }
}
