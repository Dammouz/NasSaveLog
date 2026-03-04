using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Common.Assemblies
{
    public sealed class AssemblyInfos
    {
        private static readonly Lazy<AssemblyInfos> s_lazy = new(() => new AssemblyInfos(null));
        public static AssemblyInfos Instance => s_lazy.Value;

        public readonly string AppCompanyName;
        public readonly string AppAuthor;
        public readonly string AppVersion;
        public readonly string AppName;
        public readonly DateTime AppDateTime;

        private AssemblyInfos(Assembly assembly)
        {
            var innerAssembly = assembly ?? Assembly.GetExecutingAssembly();
            var innerAssemblyName = innerAssembly.GetName();
            AppVersion = innerAssemblyName.Version?.ToString();
            AppName = innerAssemblyName.Name;
            AppDateTime = GetAssemblyDate(innerAssembly);
            AppCompanyName = innerAssembly.GetCustomAttributes<AssemblyCompanyAttribute>().First().Company;
            AppAuthor = AppCompanyName;
        }

        /// <summary>
        /// Retrieve the building datetime of the assembly.
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
