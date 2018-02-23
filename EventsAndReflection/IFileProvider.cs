using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndReflection
{
    public interface IFileProvider
    {
        void CheckFiles(string currentDirectory, FilesProvider.ProcessFileName processFileName);
    }
}
