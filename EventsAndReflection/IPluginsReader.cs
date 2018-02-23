using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibrary;

namespace EventsAndReflection
{
    public interface IPluginsReader
    {
        ICollection<IFileProcessor> GetPlugins();
    }
}
