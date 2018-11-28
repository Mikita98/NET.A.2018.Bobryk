using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace ParserURL
{
    /// <summary>
    /// Implements IProvider for validate URL
    /// </summary>
    public class URLProvider : IProvider
    {
        static Logger logger = LogManager.GetCurrentClassLogger();

        public bool Validate(string url)
        {
            bool result = true;
            try
            {
                Uri siteUri = new Uri(url);
            }
            catch (UriFormatException)
            {
                result = false;
                logger.Info("Unexpected format!");
            }
            catch (ArgumentNullException)
            {
                result = false;
                logger.Info("Unexpected format!");
            }

            return result;
        }

        public void Remove(IProvider provider)
        {
            throw new NotImplementedException();
        }
    

        public void Add(IProvider provider)
        {
            throw new NotImplementedException();
        }

        private void Log()
        {

        }
    }
 }

