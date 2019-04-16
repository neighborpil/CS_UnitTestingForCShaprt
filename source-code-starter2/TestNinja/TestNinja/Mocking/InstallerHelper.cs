using System.Net;

namespace TestNinja.Mocking
{
    public class InstallerHelper
    {
        private string _setupDestinationFile;

        private readonly IDownloader downloader;

        public InstallerHelper(IDownloader downloader)
        {
            this.downloader = downloader;
        }

        public bool DownloadInstaller(string customerName, string installerName)
        {
            try
            {
                var fileName = $"http://example.com/{customerName}/{installerName}";
                this.downloader.DownloadInstaller(fileName, installerName);

                return true;
            }
            catch (WebException)
            {
                return false; 
            }
        }
    }
}