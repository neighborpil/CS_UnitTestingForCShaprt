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
        private Mock<IFileDownloader> _fileDownloader;
        private InstallerHelper _installerHelper;

        [SetUp]
        public void SetUp()
        {
            _fileDownloader = new Mock<IFileDownloader>();
            _installerHelper = new InstallerHelper(_fileDownloader.Object);
        }

        [Test]
        public void DownloadInstaller_DownloadFails_ReturnFalse()
        {
            //_fileDownloader.Setup(fd => fd.DownloadFile("http://example.com/customer/installer", null)).Throws<WebException>();
            // => more general way
            _fileDownloader.Setup(fd => 
                fd.DownloadFile(It.IsAny<string>(), It.IsAny<string>()))
                .Throws<WebException>();

            var result = _installerHelper.DownloadInstaller("customer", "installer");

            Assert.That(result, Is.False);
        }

        [Test]
        public void DownloadInstaller_DownloadCompletes_ReturnTrue()
        {
            var result = _installerHelper.DownloadInstaller("customer", "installer");

            Assert.That(result, Is.True);
        }

        //private Mock<IClient> _fakeClient;
        //private InstallerHelper _helper;

        //[SetUp]
        //public void Setup()
        //{
        //    _fakeClient = new Mock<IClient>();
        //    _helper = new InstallerHelper(_fakeClient.Object);
        //}

        //[Test]
        //public void DownloadInstaller_WebExceptionOccured_ReturnFalse()
        //{
        //    _fakeClient.Setup(c => c.DownloadFile("http://example.com/fileName/destination", "destination")).Returns(false);

        //    var result = _helper.DownloadInstaller("fileName", "destination");

        //    Assert.That(result, Is.EqualTo(false));
        //}

        //[Test]
        //public void DownloadInstaller_SuccessfullyDownloaded_ReturnTrue()
        //{
        //    var fakeClient = new Mock<IClient>();
        //    fakeClient.Setup(c => c.DownloadFile("http://example.com/fileName/destination", "destination")).Returns(true);
        //    var helper = new InstallerHelper(_fakeClient.Object);


        //    var result = helper.DownloadInstaller("fileName", "destination");

        //    Assert.That(result, Is.EqualTo(true));
        //}
    }
}
