using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;

namespace AutoSet
{
    internal static class EmbeddedDependencies
    {
        private const string ResourcePrefix = "AutoSet.Dependencies.";
        private static string directory;
        private static HashSet<string> embeddedNames;

        public static void Initialize()
        {
            var executable = Assembly.GetExecutingAssembly();
            var resources = executable.GetManifestResourceNames()
                .Where(name => name.StartsWith(ResourcePrefix, StringComparison.Ordinal) &&
                               name.EndsWith(".dll", StringComparison.OrdinalIgnoreCase))
                .ToArray();
            if (resources.Length == 0) return; // Local Visual Studio builds use installed Tekla DLLs.
            embeddedNames = new HashSet<string>(
                resources.Select(name => name.Substring(ResourcePrefix.Length, name.Length - ResourcePrefix.Length - 4)),
                StringComparer.OrdinalIgnoreCase);

            var version = executable.GetName().Version.ToString();
            directory = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "AutoSet", "Dependencies", version);
            Directory.CreateDirectory(directory);

            foreach (var resource in resources)
            {
                var fileName = resource.Substring(ResourcePrefix.Length);
                var destination = Path.Combine(directory, fileName);
                byte[] contents;
                using (var stream = executable.GetManifestResourceStream(resource))
                using (var memory = new MemoryStream())
                {
                    if (stream == null) throw new InvalidDataException("Missing embedded dependency: " + fileName);
                    stream.CopyTo(memory);
                    contents = memory.ToArray();
                }

                if (File.Exists(destination) && Matches(destination, contents)) continue;
                var temporary = destination + "." + Guid.NewGuid().ToString("N") + ".tmp";
                try
                {
                    File.WriteAllBytes(temporary, contents);
                    if (File.Exists(destination)) File.Delete(destination);
                    File.Move(temporary, destination);
                }
                finally
                {
                    if (File.Exists(temporary)) File.Delete(temporary);
                }
            }

            AppDomain.CurrentDomain.AssemblyResolve += Resolve;
        }

        private static bool Matches(string path, byte[] expected)
        {
            using (var file = File.OpenRead(path))
            using (var hash = SHA256.Create())
            using (var expectedStream = new MemoryStream(expected))
            {
                if (file.Length != expected.Length) return false;
                var actualHash = hash.ComputeHash(file);
                var expectedHash = hash.ComputeHash(expectedStream);
                return actualHash.SequenceEqual(expectedHash);
            }
        }

        private static Assembly Resolve(object sender, ResolveEventArgs args)
        {
            var name = new AssemblyName(args.Name).Name;
            if (!embeddedNames.Contains(name)) return null;
            var path = Path.Combine(directory, name + ".dll");
            return File.Exists(path) ? Assembly.LoadFrom(path) : null;
        }
    }
}
