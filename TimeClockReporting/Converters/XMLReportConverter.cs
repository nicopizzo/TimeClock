using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeClock.Reporting.Helpers;

namespace TimeClock.Reporting.Converters
{
    public class XMLReportConverter : BaseConverter, IConverter
    {

        private StringBuilder _XML;

        public XMLReportConverter()
        {
            _XML = new StringBuilder(); 
        }

        public string ConvertReport(IReport report)
        {
            throw new NotImplementedException();
        }

        protected override void ConvertBody(ReportingFields bodyFields)
        {
            throw new NotImplementedException();
        }

        protected override void ConvertBodyField(KeyValuePair<string, string> field)
        {
            throw new NotImplementedException();
        }

        protected override void ConvertHeader(Dictionary<string, string> headerFields)
        {
            
        }

        protected override void ConvertHeaderField(KeyValuePair<string, string> field)
        {
            throw new NotImplementedException();
        }

        protected override string WriteToFile(string data)
        {
            throw new NotImplementedException();
        }
    }
}
