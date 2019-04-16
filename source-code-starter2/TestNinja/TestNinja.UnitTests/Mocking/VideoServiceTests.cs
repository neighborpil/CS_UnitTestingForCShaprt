using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class VideoServiceTests
    {
        private Mock<IFileReader> _fileReader;
        private VideoService _videoService;

        [SetUp]
        public void SetUp()
        {
            _fileReader = new Mock<IFileReader>();
            _videoService = new VideoService(_fileReader.Object);

        }

        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            _fileReader.Setup(fr => fr.Read("video.txt")).Returns("");

            var result = _videoService.ReadVideoTitle();

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_AllItemsAreProceeded_ReturnNull()
        {
            var context = new VideoContext
            {
                Videos =
                {
                    new Video{Id = 1},
                    new Video{Id = 2},
                    new Video{Id = 3},
                }
            };
            var videoRepository = new Mock<IVideoRepository>();
            videoRepository.Setup(g => g.GetUnprocessedVideosAsCsv()).Returns(new List<Video>());
            var videoService = new VideoService(videoRepository.Object);

            var result = videoService.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo(""));
        }

        [Test]
        public void GetUnprocessedVideoAsCsv_AFewUnproceededVideos_ReturnAStringWithIdsOfUnprocessedVideos()
        {
            var videoRepository = new Mock<IVideoRepository>();
            var service = new VideoService(videoRepository.Object);
            videoRepository.Setup(g => g.GetUnprocessedVideosAsCsv()).Returns(new List<Video>
            {
                new Video {Id = 1},
                new Video {Id = 2},
                new Video {Id = 3},
            });

            var result = service.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo("1,2,3"));
        }

        [Test]
        public void GetUnproceededVideoAsCsv_VerifyProcess_Verified()
        {
            var repository = new Mock<IVideoRepository>();
            var service = new VideoService(repository.Object);
            repository.Setup(r => r.GetUnprocessedVideosAsCsv())
                .Returns(new List<Video>
                {
                    new Video {Id = 1},
                    new Video {Id = 2},
                    new Video {Id = 3},
                });

            service.GetUnprocessedVideosAsCsv();

            repository.Verify(r => r.GetUnprocessedVideosAsCsv());
        }
    }
}
