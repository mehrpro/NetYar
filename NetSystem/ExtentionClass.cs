using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace NetSystem
{
    public static class ExtentionClass
    {
        public static DateTime GCalender(this DateTime datetime)
        {
            DateTime dt = DateTime.Parse(datetime.ToString(), new CultureInfo("fa-IR"));
            return dt;
        }

        public static string PersianShortDate(this DateTime dateTime)
        {
            PersianCalendar jc = new PersianCalendar();
            var result = jc.GetYear(dateTime.Date) + "/" + jc.GetMonth(dateTime) + "/" + jc.GetDayOfMonth(dateTime);
            return result;
        }


    }
}
