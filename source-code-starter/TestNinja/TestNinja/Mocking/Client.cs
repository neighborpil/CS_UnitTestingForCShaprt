using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public class CustomWebClient : IClient
    {
        private WebClient client;

        public CustomWebClient()
        {
            this.client = new WebClient();
        }

        public bool DownloadFile(string fileName, string destinationFile)
        {
            try
            {
                client.DownloadFile(fileName, destinationFile);
                return true;
            }
            catch (WebException)
            {
                return false;
            }
        }
    }

    public interface IClient
    {
        bool DownloadFile(string fileName, string destinationFile);
    }
}
