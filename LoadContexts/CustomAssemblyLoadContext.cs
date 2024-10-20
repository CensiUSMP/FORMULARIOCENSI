using System;
using System.IO;
using System.Runtime.Loader;
using System.Reflection;

namespace FORMULARIOCENSI.LoadContexts
{
    public class CustomAssemblyLoadContext : AssemblyLoadContext
    {
        public CustomAssemblyLoadContext() : base(isCollectible: true) { }

        protected override IntPtr LoadUnmanagedDll(string unmanagedDllName)
        {
            string dllName = "wkhtmltox.dll";
            var path = Path.Combine(Directory.GetCurrentDirectory(), "lib", dllName);
            if (File.Exists(path))
            {
                return LoadUnmanagedDllFromPath(path);
            }
            return IntPtr.Zero;
        }

        protected override Assembly Load(AssemblyName assemblyName)
        {
            return null;
        }

        public IntPtr LoadUnmanagedLibrary(string libraryName)
        {
            return LoadUnmanagedDll(libraryName);
        }
    }
}