using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Xml;

namespace Epam.Task5.BackupSystem
{
    public class FilesState 
    {
        public string PathToCatalog; //folder with user files
        public readonly string PathForLog = @"E:\history\"; //change history
        public FileSystemWatcher watcher;
        // private static XmlDocument document; //xml-history of changes
        public FilesState(string pathToCatalog)
        {
            if (!Directory.Exists(pathToCatalog))
            {
                throw new DirectoryNotFoundException(pathToCatalog);
            }

            PathToCatalog = pathToCatalog;

                Run();

                #region WriteStartElementInXmlFile
                //writes file change history to xml-file
                try
                {
                    var xmlWriter = new XmlTextWriter(PathForLog + "history.xml", Encoding.UTF8)
                    {
                        Formatting = Formatting.Indented,
                        Indentation = 4
                    };
                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("History");
                    xmlWriter.WriteEndElement();
                    xmlWriter.Close();
                }
                catch (XmlException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                #endregion

                Console.WriteLine("Directory is controllable, select other menu item if you want stop it...");        
        }
        public FilesState(string pathToCatalog, string pathForLog)
        {
            //launch file tracking
            if (!Directory.Exists(pathToCatalog))
            {
                throw new DirectoryNotFoundException(pathToCatalog);
            }
            if (!Directory.Exists(pathForLog))
            {
                throw new DirectoryNotFoundException(pathForLog);
            }
            PathToCatalog = pathToCatalog;
            PathForLog = pathForLog;
            Run();
            Console.WriteLine("directory is controllable...");
        }
        private void Run()
        {
            //Add methods for file watcher
           watcher = new FileSystemWatcher(PathToCatalog);

            watcher.Changed += FileWatcherOnChanged;
            watcher.Created += FileWatcherOnCreated;
            watcher.Deleted += FileWatcherOnDeleted;
            watcher.Renamed += FileWatcherOnRenamed;

            watcher.Filter = "*.txt";
            watcher.EnableRaisingEvents = true;

        }
        public void Stop()
        {
            watcher.EnableRaisingEvents = false;
        }
        private void FileWatcherOnRenamed(object sender, RenamedEventArgs renamedEventArgs)
        {
            Console.WriteLine("File renamed");
            //copy files in directory for log
            CopyFolder(PathToCatalog, PathForLog);
        }

        private void FileWatcherOnDeleted(object sender, FileSystemEventArgs fileSystemEventArgs)
        {
            Console.WriteLine("File deleted");
            CopyFolder(PathToCatalog, PathForLog);
        }

        private void FileWatcherOnCreated(object sender, FileSystemEventArgs fileSystemEventArgs)
        {
            Console.WriteLine("File created");
            CopyFolder(PathToCatalog, PathForLog);

        }

        private void FileWatcherOnChanged(object sender, FileSystemEventArgs fileSystemEventArgs)
        {
            Console.WriteLine("File changed");
            CopyFolder(PathToCatalog, PathForLog);

        }
        private void CopyFolder(string sourceFolder, string destFolder)
        {
            try
            {
                if (!Directory.Exists(destFolder))
                    Directory.CreateDirectory(destFolder);
                string date = $"{DateTime.Now.Day}_{DateTime.Now.Month}_{DateTime.Now.Year}_{DateTime.Now.Hour}_{DateTime.Now.Minute}_{DateTime.Now.Second}";

                DirectoryInfo di = Directory.CreateDirectory(Path.Combine(destFolder, date));

                string[] files = Directory.GetFiles(sourceFolder);

                foreach (string file in files)
                    File.Copy(file, Path.Combine(di.FullName, Path.GetFileName(file)));

                string[] folders = Directory.GetDirectories(sourceFolder);

                foreach (string folder in folders)
                    CopyFolder(folder, Path.Combine(Path.Combine(destFolder, date), Path.GetFileName(folder)));
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "возможно была предотвращена повторная запись в историю изменений");
            }
        }
        public void BackupFiles(string date)
        {
            if (!Directory.Exists(PathForLog))
                Directory.CreateDirectory(PathForLog);

            Delete(PathToCatalog);
            CopyFolder(Path.Combine( PathForLog, date), PathToCatalog);
        }
        public void Delete(string from)
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(from);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
            string[] folders = Directory.GetDirectories(from);
        }
    }

}
