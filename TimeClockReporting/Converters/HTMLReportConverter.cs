using System;

namespace TimeClockReporting.Converters
{
    public class HTMLReportConverter : BaseConverter, IConverter
    {

        public HTMLReportConverter(BaseReport report)
            : base(report)
        {

        }

        public string ConvertReport(BaseReport report)
        {
            throw new NotImplementedException();
        }
    }
}
