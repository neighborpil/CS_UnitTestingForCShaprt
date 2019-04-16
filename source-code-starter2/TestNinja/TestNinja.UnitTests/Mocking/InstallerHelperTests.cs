using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class InstallerHelperTests
    {
        private InstallerHelper _installerHelper;
        private Mock<IDownloader> _downloader;

        [SetUp]
        public void Setup()
        {
            _downloader = new Mock<IDownloader>();
            _installerHelper = new InstallerHelper(_downloader.Object);
        }

        [Test]
        public void DownloadInstaller_SuccessDownload_ReturnTrue()
        {
            _downloader.Setup(d => 
                d.DownloadInstaller(It.IsAny<string>(), It.IsAny<string>()));

            var result = _installerHelper.DownloadInstaller("customerName", "installerName");

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void DownloadInstaller_ThrowException_ReturnFalse()
        {
            _downloader.Setup(d =>
                    d.DownloadInstaller(It.IsAny<string>(), It.IsAny<string>()))
                .Throws<WebException>();

            var result = _installerHelper.DownloadInstaller("customerName", "installerName");

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void DownloadInstaller_WhenCalled_VerifyInvocation()
        {
            _downloader.Setup(d =>
                    d.DownloadInstaller(It.IsAny<string>(), It.IsAny<string>()))
                .Throws<WebException>();

            var result = _installerHelper.DownloadInstaller("customerName", "installerName");

            _downloader.Verify(d => d.DownloadInstaller(It.IsAny<string>(), It.IsAny<string>()));
        }
    }
}
