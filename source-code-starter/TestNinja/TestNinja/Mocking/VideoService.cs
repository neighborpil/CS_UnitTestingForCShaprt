using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace TestNinja.Mocking
{
    /*
    # Dependency Injection 방법 3가지
     1. Injecting via method parameter
     2. Injecting via property
     3. Injecting via constructor
    */
    public class VideoService
    {

        #region Injecting by method parameter

        public string ReadVideoTitle(IFileReader fileReader)
        {
            //var str = new FileReader().Read("video.txt");
            var str = fileReader.Read("video.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);
            if (video == null)
                return "Error parsing the video.";
            return video.Title;
        }

        #endregion

        #region Injecting by property

        public IFileReader FileReader { get; set; }

        public VideoService()
        {
            FileReader = new FileReader(); // 생성자에서 실제 개체를 연결하고, Teststing에서 FileReader를 교체한다
        }

        public string ReadVideoTitleViaPropertyr()
        {
            //var str = new FileReader().Read("video.txt");
            var str = FileReader.Read("video.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);
            if (video == null)
                return "Error parsing the video.";
            return video.Title;
        }

        #endregion

        #region 3. Injecting via constructor

        private IFileReader _fileReader;

        //public VideoService() // 터질 경우에는 이와 같이 기본 생성자를 생성 해주는 것도 좋다
        //{
        //    _fileReader = new FileReader();
        //}


        public VideoService(IFileReader fileReader = null)
        {
            _fileReader = fileReader ?? new FileReader();
        }

        public string ReadVideoTitleViaConstructor()
        {
            var str = _fileReader.Read("video.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);
            if (video == null)
                return "Error parsing the video.";
            return video.Title;
        }

        #endregion

        private IVideoRepository _repository;
        public VideoService(IFileReader fileReader = null, IVideoRepository repository = null)
        {
            _fileReader = fileReader ?? new FileReader();
            _repository = repository ?? new VideoRepository();
        }

        // 테스트 메소드의 갯수는?
        // [] => ""
        // [{}, {}, {}] => "1,2,3"
        public string GetUnprocessedVideosAsCsv()
        {
            var videoIds = new List<int>();


            var videos = _repository.GetUnprocessedVideos();

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