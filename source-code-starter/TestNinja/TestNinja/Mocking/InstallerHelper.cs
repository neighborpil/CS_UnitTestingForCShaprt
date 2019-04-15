using System;
using System.Net;

namespace TestNinja.Mocking
{
    public class InstallerHelper
    {
        private readonly IFileDownloader fileDownloader;
        private string _setupDestinationFile;

        public InstallerHelper(IFileDownloader fileDownloader)
        {
            this.fileDownloader = fileDownloader;
        }

        public bool DownloadInstaller(string customerName, string installerName)
        {
            try
            {
                fileDownloader.DownloadFile(
                    string.Format("http://example.com/{0}/{1}",
                        customerName,
                        installerName),
                    _setupDestinationFile);

                return true;
            }
            catch (WebException)
            {
                return false;
            }
        }

        //private string _setupDestinationFile;

        //private IClient client;

        //public InstallerHelper(IClient client)
        //{
        //    this.client = client ?? throw new ArgumentNullException(nameof(client));
        //}

        //public bool DownloadInstaller(string customerName, string installerName)
        //{
        //    string fileName = $"http://example.com/{customerName}/{installerName}";

        //    var isDownloaded = client.DownloadFile(fileName, _setupDestinationFile);
        //    return isDownloaded;
        //}
    }
}