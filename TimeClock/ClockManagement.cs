using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Net;
using System.Net.Cache;
using System.Configuration;

namespace TimeClock
{
    public class ClockManagement
    {
        private string _clockSource;

        public ClockManagement()
        {
            _clockSource = ConfigurationManager.AppSettings["InternetClockSource"];
        }

        public DateTime GetInternetTime()
        {
            DateTime returnTime = DateTime.MinValue;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_clockSource);
            request.Method = "GET";
            request.Accept = "text/html, application/xhtml+xml, */*";
            request.UserAgent = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.1; Trident/6.0)";
            request.ContentType = "application/x-www-form-urlencoded";
            request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                StreamReader stream = new StreamReader(response.GetResponseStream());
                string html = stream.ReadToEnd();
                string time = Regex.Match(html, @"(?<=\btime="")[^""]*").Value;
                double milliseconds = Convert.ToInt64(time) / 1000.0;
                returnTime = new DateTime(1970, 1, 1).AddMilliseconds(milliseconds).ToLocalTime();
            }

            return returnTime;
        }

        public DateTime GetComputerTime()
        {
            return DateTime.Now;
        }

        
    }
}
