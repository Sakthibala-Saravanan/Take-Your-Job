using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using AspireSystems.TakeYourJob.Infrastructure.Constants;

namespace AspireSystems.TakeYourJob.Infrastructure.Helpers
{
    public static class DateTimeHelper
    {
        public static double TotalSeconds(this DateTime date)
        {
            var minDate = new DateTime(1900, 01, 01);
            return (date - minDate).TotalSeconds;
        }
        public static DateTime ToAspireSystemsLocal(this DateTime date, HttpContext context)
        {
            DateTime localDate = new DateTime(date.Ticks, DateTimeKind.Local);
            if (context.Request.Headers.ContainsKey("Timezone-Offset"))
            {
                var offSet = context.Request.Headers["Timezone-Offset"];
                int offsetMinutes = Convert.ToInt32(offSet);

                return localDate.AddMinutes(-1 * offsetMinutes);
            }
            return localDate;
        }
        public static DateTime? ToAspireSystemsLocal(this DateTime? date, HttpContext context)
        {
            if (date != null)
            {
                DateTime localDate = new DateTime(date.Value.Ticks, DateTimeKind.Local);
                if (context.Request.Headers.ContainsKey("Timezone-Offset"))
                {
                    var offSet = context.Request.Headers["Timezone-Offset"];
                    int offsetMinutes = Convert.ToInt32(offSet);

                    return localDate.AddMinutes(-1 * offsetMinutes);
                }
                return localDate;
            }
            else
            {
                return date;
            }
        }

        public static DateTime ToAspireSystemsUTC(this DateTime date, HttpContext context)
        {
            DateTime localDate = new DateTime(date.Ticks, DateTimeKind.Local);
            if (context.Request.Headers.ContainsKey("Timezone-Offset"))
            {
                var offSet = context.Request.Headers["Timezone-Offset"];
                int offsetMinutes = Convert.ToInt32(offSet);

                return localDate.AddMinutes(offsetMinutes);
            }
            return localDate;
        }
    }

    public static class StringHelper
    {
        public static string FirstCharacterToUpperCase(this string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                return input.First().ToString().ToUpper() + input.Substring(1);
            }
            else { return string.Empty; }
        }
    }
}
