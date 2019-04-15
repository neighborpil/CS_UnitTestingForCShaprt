using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public interface IFileReader
    {
        string Read(string path);
    }

    public class FileReader : IFileReader
    {   // 메소드명 우클릭 => Refactor => Extract => Extract Interface로 손쉽게 인터페이스 생성 가능
        public string Read(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
