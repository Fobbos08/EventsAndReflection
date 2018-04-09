using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndReflection
{
    public class MaxFilesCountException : Exception
    {
        public int FilesCount { get; }

        public MaxFilesCountException(int filesCount) : base($"More than {filesCount} files")
        {
            FilesCount = filesCount;
        }
        public MaxFilesCountException(int filesCount, string message) : base(message)
        {
            FilesCount = filesCount;
        }
    }
}
