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
        string Read(string message);
    }

    public class FileReader : IFileReader
    {
        public string Read(string fileName)
        {
            var str = File.ReadAllText(fileName);
            return str;
        }
    }
}
