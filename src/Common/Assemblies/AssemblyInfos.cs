using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Common.Assemblies
{
    public sealed class AssemblyInfos
    {
        private readonly Assembly _assembly;
        private readonly AssemblyName _assemblyName;
        private static readonly Lazy<AssemblyInfos> s_lazy = new Lazy<AssemblyInfos>(() => new AssemblyInfos(null));

        public static AssemblyInfos Instance => s_lazy.Value;
        public readonly string AppCompanyName;
        public readonly string AppAuthor;
        public readonly string AppVersion;
        public readonly string AppName;
        public readonly DateTime AppDateTime;

        private AssemblyInfos(Assembly assembly)
        {
            _assembly = assembly ?? Assembly.GetExecutingAssembly();
            _assemblyName = _assembly.GetName();
            AppVersion = _assemblyName.Version.ToString();
            AppName = _assemblyName.Name;
            AppDateTime = GetAssemblyDate(_assembly);
            AppCompanyName = _assembly.GetCustomAttributes<AssemblyCompanyAttribute>()?.First()?.Company;
            AppAuthor = AppCompanyName;
        }

        /// <summary>
        /// Retrive the building datetime of the assemby.
        /// </summary>
        /// <param name="assembly">assembly to analyze</param>
        /// <returns>assembly date</returns>
        public static DateTime GetAssemblyDate(Assembly assembly)
        {
            return File.GetLastWriteTime((assembly ?? Assembly.GetExecutingAssembly()).Location);
        }

        public static string GetAssemblyName(Assembly assembly)
        {
            return (assembly ?? Assembly.GetExecutingAssembly()).GetName().Name;
        }
    }
}
