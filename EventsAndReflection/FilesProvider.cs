using System;
using System.IO;
using System.Collections;
using System.Linq;

namespace EventsAndReflection
{
    public class FilesProvider : IFileProvider
    {
        private const int BigFolderCount = 3;

        public event EventHandler<BigFolderEvent> OnFindBigFolder;

       private void GenerateEvent(string path)
       {
           var bigFolderEventnt = new BigFolderEvent(path);
           OnFindBigFolder?.Invoke(this, bigFolderEventnt);
       }

        public delegate void ProcessFileName(string directory, string fileName);

        public void CheckFiles(string currentDirectory, ProcessFileName processFileName)
        {
            try
            {
                var directories = Directory.GetDirectories(currentDirectory);
                var files = Directory.GetFiles(currentDirectory);

                if (files.Length >= BigFolderCount)
                {
                    GenerateEvent(currentDirectory);
                }

                foreach (var file in files)
                {
                    processFileName(currentDirectory, file);
                }

                if (directories.Any())
                {
                    foreach (var directory in directories)
                    {
                        CheckFiles(directory, processFileName);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
