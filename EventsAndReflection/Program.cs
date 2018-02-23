using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibrary;

namespace EventsAndReflection
{
    class Program
    {
        private static IFileProcessor _fileProcessor;
        private static readonly PluginsReader PluginsReader = new PluginsReader();
        static void Main(string[] args)
        {
            var plugins = PluginsReader.GetPlugins();
            _fileProcessor = plugins.Any() ? plugins.First() : new FileProcessor();

            var filesProvider = new FilesProvider();
            filesProvider.OnFindBigFolder += LogBigFolder;
            filesProvider.CheckFiles(Directory.GetCurrentDirectory(), ProcessFileName);
            Console.ReadLine();
        }

        private static void ProcessFileName(string directory, string fileName)
        {
            _fileProcessor.ProcessFileName(directory, fileName);
        }

        private static void LogBigFolder(object sender, BigFolderEvent e)
        {
            Console.WriteLine($"!!!!!!!!!!!!!!!{e.FolderPath}");
        }
    }
}
