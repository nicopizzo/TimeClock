using System.Collections.Generic;

namespace TimeClock.Reporting.Converters
{
    public abstract class BaseConverter
    {
        protected abstract void ConvertHeader(Dictionary<string, string> headerFields);

        protected abstract void ConvertHeaderField(KeyValuePair<string, string> field);

        protected abstract void ConvertBody(Dictionary<string, string> bodyFields);

        protected abstract void ConvertBodyField(KeyValuePair<string, string> field);
    }
}
