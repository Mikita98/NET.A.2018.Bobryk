using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserURL
{
    public class URLParser : IParser<IEnumerable<string>, List<URL>>
    {
        /// <summary>
        /// Returns a list of URL need to parse
        /// </summary>
        /// <param name="adresses"></param>
        /// <returns></returns>
        public List<URL> Parse(IEnumerable<string> adresses)
        {
            List<URL> list = new List<URL>();
            
            foreach(string @string in adresses)
            {
                list.Add(Parse(@string));
            }

            return list;
        }

        private URL Parse(string adress)
        {
            CheckURL(adress);

            Uri siteUri = new Uri(adress);

            URL url = new URL();

            url.Segments = GetSegments(siteUri.Segments);
            if (siteUri.Query != "")
            {
                url.Parameters = GetParameters(siteUri.Query);
            }
            url.HostName = siteUri.Host;

            return url;
        }

        private List<string> GetSegments(string[] segments)
        {
            if (segments == null)
            {
                throw new ArgumentNullException("Segments can't be null!");
            }

            if (segments.Length > 1)
            {
                List<string> list = new List<string>();
                string segment = "";

                for (int i = 1; i < segments.Length; i++)
                {
                    segment = segments[i];
                    segment.Trim('/');
                    list.Add(segment);
                }

                return list;
            }
            else
            {
                return null;
            }

        }

        private Dictionary<string, string> GetParameters(string query)
        {
            query = query.Substring(1);
            string[] querus = query.Split('&');
            Dictionary<string, string> dict = new Dictionary<string, string>();
            string[] dictionary;

            for (int i = 0; i < querus.Length; i++)
            {
                dictionary = querus[i].Split('=');

                dict.Add(dictionary[0], dictionary[1]);
            }

            return dict;
        }

        private bool CheckURL(string url)
        {
            Provider providers = new Provider();

            URLProvider provider = new URLProvider();

            providers.Add(provider);

            return providers.Validate(url);
        }
    }
}
