using System;
using System.Collections.Generic;
using System.Text;

namespace TimeClock.Reporting.Converters
{
    public class HTMLReportConverter : BaseConverter, IConverter
    {

        private StringBuilder _Html;

        public HTMLReportConverter()
        {
            _Html = new StringBuilder();
        }

        public string ConvertReport(IReport report)
        {
            _Html.AppendLine($"<h2>{report.ReportName}</h2>");
            ConvertHeader(report.HeaderFields);
            ConvertBody(report.Fields);
            return _Html.ToString();
        }

        protected override void ConvertHeader(Dictionary<string,string> headerFields)
        {
            foreach(var header in headerFields)
            {
                ConvertHeaderField(header);
            }
        }

        protected override void ConvertHeaderField(KeyValuePair<string, string> field)
        {
            _Html.AppendLine($"<h5>{field.Value}</h5>");
        }

        protected override void ConvertBody(Dictionary<string,string> bodyFields)
        {
           
        }

        protected override void ConvertBodyField(KeyValuePair<string, string> field)
        {

        }
    }
}
