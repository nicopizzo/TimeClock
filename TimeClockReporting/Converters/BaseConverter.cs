using System.Collections.Generic;
using System.IO;
using System;
using TimeClock.Reporting.Helpers;

namespace TimeClock.Reporting.Converters
{
    public abstract class BaseConverter
    {
        protected abstract void ConvertHeader(Dictionary<string, string> headerFields);

        protected abstract void ConvertHeaderField(KeyValuePair<string, string> field);

        protected abstract void ConvertBody(ReportingFields bodyFields);

        protected abstract void ConvertBodyField(KeyValuePair<string, string> field);

        protected abstract string WriteToFile(string data);

        protected string GetReportSaveLocation()
        {
            string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Temp");

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            return dir;
        }
    }
}
