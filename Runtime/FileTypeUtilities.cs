using System.Collections.Generic;
using System.IO;

namespace IronMountain.SaveSystem
{
    public static class FileTypeUtilities
    {
        public static readonly Dictionary<FileType, string> Extensions = new ()
        {
            { FileType.Txt, ".txt" },
            { FileType.Json, ".json" },
            { FileType.PNG, ".png" },
        };
        
        public static List<string> KeepFilesOfType(List<string> files, FileType[] fileTypeFilters)
        {
            List<string> filteredFiles = new List<string>();
            List<string> validExtensions = new List<string>();
            foreach (FileType filter in fileTypeFilters)
            {
                validExtensions.Add(Extensions[filter]);
            }
            foreach (string file in files)
            {
                string extension = Path.GetExtension(file);
                if (!validExtensions.Contains(extension)) continue;
                filteredFiles.Add(file);
            }
            return filteredFiles;
        } 
    }
}
