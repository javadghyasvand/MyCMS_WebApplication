using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace MyCMS_WebApplication
{
    public static class PersianConvertorDate
    {
        public static string ToShamsi(this DateTime time)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(time) + "/" + pc.GetMonth(time).ToString("00") + "/" + pc.GetDayOfMonth(time).ToString("00");
        }
    }
}