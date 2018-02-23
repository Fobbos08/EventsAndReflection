using SharedLibrary;
using System;
using System.IO;
using System.Linq;

namespace CustomPlugin
{
    public class CustomFileProcessor : IFileProcessor
    {
        private readonly string[] _extensions = {"PNG", "BMP", "JPG", "JPEG"};
        public void ProcessFileName(string directory, string fileName)
        {
            var extension = Path.GetExtension(fileName)?.Replace(".", "");
            if (extension != null && _extensions.Contains(extension.ToUpper()))
                Console.WriteLine($"{directory}/{fileName}");
        }
    }
}
