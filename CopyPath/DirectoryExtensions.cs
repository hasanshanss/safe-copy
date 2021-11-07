using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CopyPath
{
    public static class DirectoryExtensions
    {
        public static IEnumerable<FileInfo> GetFilesByExtensions(this DirectoryInfo dirInfo, params string[] extensions)
        {
            if (extensions == null || extensions.Length == 0)
                return dirInfo.GetFiles();

            return dirInfo.EnumerateFiles().Where(f => extensions.Contains(f.Extension));
        }
    }
}
