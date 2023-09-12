using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace IronMountain.SaveSystem
{
    public static class SaveSystem
    {
        private static readonly string Root = Application.persistentDataPath;
    
        public static void SaveFile(string directory, string file, string data)
        {
            if (string.IsNullOrEmpty(file)) return;
            directory ??= string.Empty;
            
            string path = Path.Combine(Root, directory, file);
            string directoryPath = Path.GetDirectoryName(path);
            
            if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);

            string pathToFileBuffer = path + "_buffer";
            string pathToFileCopy = path + "_copy";

            File.WriteAllText(pathToFileBuffer, data);

            if (File.Exists(path)) {
                if (File.Exists(pathToFileCopy)) File.Delete(pathToFileCopy);
                File.Move(path, pathToFileCopy);
            }

            File.Move(pathToFileBuffer, path);

            if (File.Exists(pathToFileBuffer)) File.Delete(pathToFileBuffer);
            if (File.Exists(pathToFileCopy)) File.Delete(pathToFileCopy);
        }

        public static string LoadFile(string directory, string file) 
        {
            if (string.IsNullOrEmpty(file)) return null;
            directory ??= string.Empty;
            string fullPath = Path.Combine(Root, directory, file);
            string directoryPath = Path.GetDirectoryName(fullPath);
            if (!Directory.Exists(directoryPath)) return null;
            if (File.Exists(fullPath)) return File.ReadAllText(fullPath);
            return !File.Exists(fullPath + "_copy") ? null : File.ReadAllText(fullPath + "_copy");
        }

        public static bool FileExists(string directory, string file) 
        {
            if (string.IsNullOrEmpty(file)) return false;
            directory ??= string.Empty;
            return File.Exists(Path.Combine(Root, directory, file));
        }

        public static void SaveTexture(string directory, string file, Texture2D texture)
        {
            if (string.IsNullOrEmpty(file)) return;
            directory ??= string.Empty;
            
            string path = Path.Combine(Root, directory, file);
            string directoryPath = Path.GetDirectoryName(path);
        
            if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);

            string pathToFileBuffer = path + "_buffer";
            string pathToFileCopy = path + "_copy";

            byte[] bytes = texture.EncodeToPNG();
            File.WriteAllBytes(pathToFileBuffer, bytes);

            if (File.Exists(path)) {
                if (File.Exists(pathToFileCopy)) File.Delete(pathToFileCopy);
                File.Move(path, pathToFileCopy);
            }

            File.Move(pathToFileBuffer, path);

            if (File.Exists(pathToFileBuffer)) File.Delete(pathToFileBuffer);
            if (File.Exists(pathToFileCopy)) File.Delete(pathToFileCopy);
        }
        
        public static bool RenameTexture(string directory, string oldFilename, string newFilename)
        {
            if (string.IsNullOrEmpty(oldFilename) || string.IsNullOrEmpty(newFilename)) return false;
            directory ??= string.Empty;
            string pathToDirectory = Path.Combine(Root, directory);
            if (!Directory.Exists(pathToDirectory)) Directory.CreateDirectory(pathToDirectory);
            string pathToOldFile = Path.Combine(pathToDirectory, oldFilename);
            string pathToNewFile = Path.Combine(pathToDirectory, newFilename);
            if (File.Exists(pathToOldFile) && !File.Exists(pathToNewFile)) 
            {
                File.Move(pathToOldFile, pathToNewFile);
                return File.Exists(pathToNewFile);
            }
            return false;
        }
        
        public static Texture2D LoadTexture(string directory, string file) 
        {
            if (string.IsNullOrEmpty(file)) return null;
            directory ??= string.Empty;
            string fullPath = Path.Combine(Root, directory, file);
            string directoryPath = Path.GetDirectoryName(fullPath);
            if (!Directory.Exists(directoryPath)) return null;
            if (File.Exists(fullPath))
            {
                Texture2D texture = new Texture2D(1,1) { name = file };
                texture.LoadImage(File.ReadAllBytes(fullPath));
                return texture;
            }
            if (File.Exists(fullPath + "_copy"))
            {
                Texture2D texture = new Texture2D(1,1) { name = file };
                texture.LoadImage(File.ReadAllBytes(fullPath + "_copy"));
                return texture;
            }
            return null;
        }
    
        public static void DeleteFile(string directory, string file) 
        {
            if (string.IsNullOrEmpty(file)) return;
            directory ??= string.Empty;
            string fullPath = Path.Combine(Root, directory, file);
            string directoryPath = Path.GetDirectoryName(fullPath);
            if (!Directory.Exists(directoryPath)) return;
            if (File.Exists(fullPath)) File.Delete(fullPath);
        }

        public static DirectoryInfo[] GetDirectoryInfo(string directory)
        {
            directory ??= string.Empty;
            string pathToDirectory = Path.Combine(Root, directory);
            if (!Directory.Exists(pathToDirectory)) Directory.CreateDirectory(pathToDirectory);
            return new DirectoryInfo(pathToDirectory).GetDirectories();
        }
    
        public static string[] GetFilesIn(string directory, params FileType[] fileTypeFilters)
        {
            directory ??= string.Empty;
            string pathToDirectory = Path.Combine(Root, directory);
            if (!Directory.Exists(pathToDirectory)) Directory.CreateDirectory(pathToDirectory);
            return Directory.GetFiles(pathToDirectory);
        }
        
        public static string[] GetFilesOfTypeIn(string directory, params FileType[] fileTypeFilters)
        {
            directory ??= string.Empty;
            string pathToDirectory = Path.Combine(Root, directory);
            if (!Directory.Exists(pathToDirectory)) Directory.CreateDirectory(pathToDirectory);
            string[] files = Directory.GetFiles(pathToDirectory);
            List<string> filteredFiles = FileTypeUtilities.KeepFilesOfType(files.ToList(), fileTypeFilters);
            return filteredFiles.ToArray();
        }

        public static bool DeleteDirectory(string directory)
        {
            if (string.IsNullOrEmpty(directory)) return false;
            string pathToDirectory = Path.Combine(Root, directory);
            if (!Directory.Exists(pathToDirectory)) return false;
            Directory.Delete(pathToDirectory, true);
            return !Directory.Exists(pathToDirectory);
        }
    }
}