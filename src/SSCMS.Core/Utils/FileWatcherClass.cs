using System;
using System.IO;
using SSCMS;
using SSCMS.Utils;

namespace SSCMS.Core.Utils
{
    public class FileWatcherClass
    {
        public const string Site = nameof(Site);
        public const string Channel = nameof(Channel);
        public const string TableColumn = nameof(TableColumn);

        private FileSystemWatcher _fileSystemWatcher;
        private readonly string _cacheFilePath;

        public FileWatcherClass(ISettingsManager settingsManager, string cacheName)
        {
            _cacheFilePath = PathUtils.Combine(settingsManager.WebRootPath, DirectoryUtils.SiteFilesDirectoryName, DirectoryUtils.SiteFiles.TemporaryFiles, "Cache", $"{cacheName}.txt");

            FileDependency();
        }

        public void UpdateCacheFile()
        {
            FileUtils.WriteText(_cacheFilePath, "cache chaged:" + DateUtils.GetDateAndTimeString(DateTime.Now));
        }

        public delegate void FileChange(object sender, EventArgs e);

        //The OnFileChange event is fired when the file changes.
        public event FileChange OnFileChange;

        public event FileChange OnFileDeleted;

        private void FileDependency()
        {
            //Validate file.
            var fileInfo = new FileInfo(_cacheFilePath);
            if (!fileInfo.Exists)
            {
                FileUtils.WriteText(_cacheFilePath, string.Empty);
            }

            //Get path from full file name.
            var path = Path.GetDirectoryName(_cacheFilePath);

            //Get file name from full file name.
            var fileName = Path.GetFileName(_cacheFilePath);

            //Initialize new FileSystemWatcher.
            _fileSystemWatcher = new FileSystemWatcher
            {
                Path = path,
                Filter = fileName,
                EnableRaisingEvents = true
            };
            _fileSystemWatcher.Changed += FileSystemWatcher_Changed;
            _fileSystemWatcher.Deleted += FileSystemWatcher_Deleted;
        }

        private void FileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            OnFileChange?.Invoke(sender, e);
        }

        private void FileSystemWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            OnFileDeleted?.Invoke(sender, e);
        }
    }
}
