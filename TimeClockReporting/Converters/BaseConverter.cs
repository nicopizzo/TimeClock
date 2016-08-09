using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeClockReporting.Converters
{
    public class BaseConverter
    {
        protected BaseReport Report;

        protected BaseConverter(BaseReport report)
        {
            Report = report;
        }

    }
}
