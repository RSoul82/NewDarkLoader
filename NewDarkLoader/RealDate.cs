using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewDarkLoader
{
    class RealDate
    {
        /// <summary>
        /// File Modified dates seem to be off by 1 hour due to daylight saving bug. This corrects them.
        /// </summary>
        /// <param name="fileModifiedDate">This is read from the file's properties.</param>
        /// <returns></returns>
        public static DateTime GetRealDate(DateTime fileModifiedDate)
        {
            //DateTime now = DateTime.Now;
            //TimeSpan localOffset = now - now.ToUniversalTime();
            return fileModifiedDate;// +localOffset;
        }
    }
}
