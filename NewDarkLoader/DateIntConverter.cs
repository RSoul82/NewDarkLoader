using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace NewDarkLoader
{
    class DateIntConverter
    {
        private static DateTime epoch()
        {
            return new DateTime(1970, 1, 1, 0, 0, 0);
        }
        /// <summary>
        /// Converts a hex date string (which has already been read from ini) to a normal date, e.g. 15/03/2013, returns as string.
        /// </summary>
        /// <param name="dateHexString">Already been read from ini.</param>
        /// <param name="dateFormat">'Day month year' or 'month day year'.</param>
        /// <returns></returns>
        public static string dateStringFromHexString(string dateHexString, string dateFormat)
        {
            DateTime newDate = dateFromHexString(dateHexString);
            return newDate.ToString(dateFormat);
        }

        /// <summary>
        /// Converts a dateTime (selected from form control) to a hex date to be stored in NewDarkLoader.ini
        /// </summary>
        /// <param name="selectedDate"></param>
        /// <returns></returns>
        public static string dateToHexString(DateTime selectedDate)
        {
            TimeSpan difference = selectedDate - epoch();
            int diffSec = (int)difference.TotalSeconds;
            return diffSec.ToString("X");
        }

        /// <summary>
        /// Converts a hex date string (which has already been read from ini) to a normal date, e.g. 15/03/2013, returns as DateTime.
        /// </summary>
        /// <param name="dateHexString">Already been read from ini.</param>
        /// <returns></returns>
        public static DateTime dateFromHexString(string dateHexString)
        {
            DateTime epoch1970 = epoch();
            int seconds = Int32.Parse(dateHexString, System.Globalization.NumberStyles.HexNumber);
            DateTime newDate = epoch1970.AddSeconds(seconds);
            return newDate;
        }

        public static string dateStringToHexString(string dateString)
        {
            DateTimeConverter dTc = new DateTimeConverter();
            DateTime convertedDate = (DateTime)dTc.ConvertFrom(dateString);
            TimeSpan difference = convertedDate - epoch();
            int diffSec = (int)difference.TotalSeconds;
            string back = diffSec.ToString("X");

            return back;
        }

        public static DateTime oldDateIntToDateTime(string oldDateInt)
        {
            DateTime startDate = new DateTime(1899, 12, 30);
            int daysFromStart = Convert.ToInt32(oldDateInt);
            DateTime relative = startDate.AddDays(daysFromStart);
            return relative;
        }
    }
}
