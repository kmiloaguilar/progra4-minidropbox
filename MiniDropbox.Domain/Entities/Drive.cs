using System.Collections.Generic;

namespace MiniDropbox.Domain.Entities
{
    public class Drive : IEntity
    {
        private readonly string _bucketName;
        private readonly IList<File> _files;
        private readonly IList<Folder> _folders;

        public Drive()
        {
            _files = new List<File>();
            _folders = new List<Folder>();
        }

        public Drive(string bucketName)
        {
            _bucketName = bucketName;
            _files = new List<File>();
            _folders = new List<Folder>();
        }

        public virtual string BucketName
        {
            get { return _bucketName; }
        }

        public virtual IEnumerable<Folder> Folders
        {
            get { return _folders; }
        }

        public virtual IEnumerable<File> Files
        {
            get { return _files; }
        }

        public virtual long Id { get; set; }
        public virtual bool IsArchived { get; set; }

        public void AddFolder(Folder folder)
        {
            if (!_folders.Contains(folder))
            {
                _folders.Add(folder);
            }
        }

        public void AddFile(File file)
        {
            if (!_files.Contains(file))
            {
                _files.Add(file);
            }
        }
    }
}