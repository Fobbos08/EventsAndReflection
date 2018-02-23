using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using SharedLibrary;

namespace EventsAndReflection
{
    public class PluginsReader : IPluginsReader
    {
        public ICollection<IFileProcessor> GetPlugins()
        {
            var dllFileNames = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.dll");

            ICollection<Assembly> assemblies = new List<Assembly>(dllFileNames.Length);
            foreach (string dllFile in dllFileNames)
            {
                var an = AssemblyName.GetAssemblyName(dllFile);
                var assembly = Assembly.Load(an);
                assemblies.Add(assembly);
            }

            var pluginType = typeof(IFileProcessor);
            ICollection<Type> pluginTypes = new List<Type>();
            foreach (var assembly in assemblies)
            {
                if (assembly == null) continue;
                var types = assembly.GetTypes();
                foreach (var type in types)
                {
                    if (type.IsInterface || type.IsAbstract)
                    {
                        continue;
                    }
                    if (type.GetInterface(pluginType.FullName) != null)
                    {
                        pluginTypes.Add(type);
                    }
                }
            }

            ICollection<IFileProcessor> plugins = new List<IFileProcessor>(pluginTypes.Count);
            foreach (var type in pluginTypes)
            {
                var plugin = (IFileProcessor)Activator.CreateInstance(type);
                plugins.Add(plugin);
            }

            return plugins;
        }
    }
}
