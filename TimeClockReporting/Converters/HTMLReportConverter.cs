using System.IO;
using System.Collections.Generic;
using System.Text;
using TimeClock.Reporting.Helpers;

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
            _Html.AppendLine($"<h2 style=\"width:50%; margin: 0 auto;\">{report.ReportName}</h2>");
            ConvertHeader(report.HeaderFields);
            ConvertBody(report.Fields);
            return WriteToFile(_Html.ToString());
        }

        protected override void ConvertHeader(Dictionary<string,string> headerFields)
        {
            _Html.AppendLine("<table>");
            _Html.AppendLine("<tr>");
            ConvertHeaderField(headerFields.GetEntry(ReportingConstants.HEADER_COMPANY_NAME));
            _Html.AppendLine("</tr>");
            _Html.AppendLine("<tr>");
            ConvertHeaderField(headerFields.GetEntry(ReportingConstants.HEADER_COMPANY_ADDRESS));
            _Html.AppendLine("</tr>");
            _Html.AppendLine("<tr>");
            ConvertHeaderField(headerFields.GetEntry(ReportingConstants.HEADER_COMPANY_CITY));
            ConvertHeaderField(headerFields.GetEntry(ReportingConstants.HEADER_COMPANY_STATE));
            ConvertHeaderField(headerFields.GetEntry(ReportingConstants.HEADER_COMPANY_ZIP));
            _Html.AppendLine("</tr>");
            _Html.AppendLine("<tr>");
            ConvertHeaderField(headerFields.GetEntry(ReportingConstants.HEADER_COMPANY_PHONE));
            _Html.AppendLine("</tr>");
            _Html.AppendLine("<tr>");
            ConvertHeaderField(headerFields.GetEntry(ReportingConstants.HEADER_COMPANY_FAX));
            _Html.AppendLine("</tr>");
            _Html.AppendLine("<tr>");
            ConvertHeaderField(headerFields.GetEntry(ReportingConstants.HEADER_COMPANY_WEBSITE));
            _Html.AppendLine("</tr>");
            _Html.AppendLine("</table>");
        }

        protected override void ConvertHeaderField(KeyValuePair<string, string> field)
        {
            _Html.AppendLine($"<td align=\"center\"><h5>{field.Value}</h5></td>");
        }

        protected override void ConvertBody(ReportingFields bodyFields)
        {
           
        }

        protected override void ConvertBodyField(KeyValuePair<string, string> field)
        {

        }

        protected override string WriteToFile(string data)
        {
            var file = Path.Combine(base.GetReportSaveLocation(), "report.html");
            using (StreamWriter writer = new StreamWriter(file, false))
            {
                writer.Write(data);
            }
            return file;
        }
    }
}
