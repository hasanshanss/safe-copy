using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace SafeCopy
{
    public class RemoveAndCopyService
    {
        public string Source { private set; get; }
        public string Target { private set; get; }

        public int AllFilesCount { private set; get; }
        public int FilesLeft { private set; get; }

        public RemoveAndCopyService(string source, string target)
        {
            Source = source;
            Target = target;

            UpdateFileAttributes(new DirectoryInfo(Source));
            UpdateFileAttributes(new DirectoryInfo(Target));

            CountFiles(Source);
        }
        public void RemoveAndCopy() => RemoveAndCopy(Source, Target);
        public void RemoveAndCopy(string source, string target)
        {
            Console.ForegroundColor = ConsoleColor.White;
            var targetDirectories = GetDirectoryNames(target);
            var sourceDirectories = GetDirectoryNames(source);
            var targetFiles = GetFileNames(target);
            var sourceFiles = GetFileNames(source);

            foreach (string directory in targetDirectories.Except(sourceDirectories).ToList())
            {
                Directory.Delete(Path.Combine(target, directory), true);
                targetDirectories.Remove(directory);
                Console.WriteLine(directory + " has been removed.");
            }

            foreach (string directory in sourceDirectories)
            {
                if (!Directory.Exists(Path.Combine(target, directory)))
                {
                    Directory.CreateDirectory(Path.Combine(target, directory));
                    Console.WriteLine(directory + " has been copied.");
                }
                
            }
            

            foreach (string file in targetFiles.Except(sourceFiles).ToList())
            {
                File.Delete(Path.Combine(target, file));
                targetFiles.Remove(file);
                Console.WriteLine(file + " has been removed.");
            }

            foreach (string file in sourceFiles)
            {
                if (!File.Exists(Path.Combine(target, file)))
                {
                    File.Copy(Path.Combine(source, file), Path.Combine(target, file));
                    Console.WriteLine(file + " has been copied.");
                    FilesLeft--;
                    float percentage = (float) (AllFilesCount - FilesLeft) * 100 / AllFilesCount;
                    Console.Title = $"Copying...{percentage:0.00}%";
                }
                    
            }

            foreach (string directory in sourceDirectories)
            {
                RemoveAndCopy(Path.Combine(source, directory), Path.Combine(target, directory));
            }

        }

        private List<string> GetFileNames(string source)
        {
            return Directory.GetFiles(source)
                            .AsEnumerable()
                            .Select(m => Path.GetFileName(m))
                            .ToList();
        }

        private List<string> GetDirectoryNames(string source)
        {
            return Directory.GetDirectories(source)
                            .AsEnumerable()
                            .Select(m => Path.GetFileName(m))
                            .ToList();
        }

        private void CountFiles(string sDir)
        {
          
            foreach (string d in Directory.GetDirectories(sDir))
            {
                AllFilesCount += Directory.GetFiles(d).Length;
                CountFiles(d);
            }


            FilesLeft = AllFilesCount;
        }


    


        private void UpdateFileAttributes(DirectoryInfo dInfo)
        {
            if (dInfo.Attributes >= FileAttributes.System)
                return;

            // Set Directory attribute
            dInfo.Attributes &= ~FileAttributes.ReadOnly;

            // get list of all files in the directory and clear 
            // the Read-Only flag

            foreach (FileInfo file in dInfo.GetFiles())
            {
                file.Attributes &= ~FileAttributes.ReadOnly;
            }

            // recurse all of the subdirectories
            foreach (DirectoryInfo subDir in dInfo.GetDirectories())
            {
                UpdateFileAttributes(subDir);
            }
        }

      

    }
}
