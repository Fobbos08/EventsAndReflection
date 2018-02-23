using SharedLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndReflection
{
    public class FileProcessor : IFileProcessor
    {
        public void ProcessFileName(string directory, string fileName)
        {
            var extension = Path.GetExtension(fileName)?.Replace(".", "");
            if (extension == ".png")
                Console.WriteLine($"{directory}/{fileName}");
        }
    }
}
