using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public interface IDownloader
    {
        void DownloadInstaller(string address, string fileName);
    }

    public class FileDownloader : IDownloader
    {
        private readonly WebClient client;

        public FileDownloader()
        {
            this.client = new WebClient();
        }

        public void DownloadInstaller(string address, string fileName)
        {
            client.DownloadFile(address, fileName);
        }
    }
}
