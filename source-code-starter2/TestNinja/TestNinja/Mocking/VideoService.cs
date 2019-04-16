using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace TestNinja.Mocking
{
    public class VideoService
    {
        private readonly IFileReader fileReader;

        public VideoService(IFileReader fileReader = null, IVideoRepository videoRepository = null)
        {
            this.fileReader = fileReader ?? new FileReader();
            this.videoRepository = videoRepository ?? new VideoRepository();
        }

        public VideoService(IVideoRepository videoRepository = null)
        {
            this.fileReader = new FileReader();
            this.videoRepository = videoRepository ?? new VideoRepository();
        }

        public string ReadVideoTitle()
        {
            var str = fileReader.Read("video.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);
            return video == null ? "Error parsing the video." : video.Title;
        }

        private IVideoRepository videoRepository;
        public string GetUnprocessedVideosAsCsv()
        {
            var videos = videoRepository.GetUnprocessedVideosAsCsv();
            var videoIds = new List<int>();
            foreach (var v in videos)
                videoIds.Add(v.Id);

            return String.Join(",", videoIds);
        }
    }

    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsProcessed { get; set; }
    }

    public class VideoContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
    }
}