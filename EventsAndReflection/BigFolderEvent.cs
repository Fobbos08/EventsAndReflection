using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndReflection
{
    public class BigFolderEvent : EventArgs
    {
        public string FolderPath { get; private set; }
        public BigFolderEvent(string path)
        {
            FolderPath = path;
        }
    }
}
