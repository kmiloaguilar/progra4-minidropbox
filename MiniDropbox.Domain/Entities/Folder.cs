using System.Collections.Generic;

namespace MiniDropbox.Domain.Entities
{
    public class Folder : IEntity
    {
        private readonly IList<File> _files = new List<File>();
        private readonly string _folderName;
        private readonly IList<Folder> _subfolders = new List<Folder>();

        public Folder(string folderName)
        {
            _folderName = folderName;
            _subfolders = new List<Folder>();
            _files = new List<File>();
        }

        public Folder()
        {
            _subfolders = new List<Folder>();
            _files = new List<File>();
        }

        public virtual string FolderName
        {
            get { return _folderName; }
        }

        public virtual IEnumerable<Folder> Subfolders
        {
            get { return _subfolders; }
        }

        public virtual IEnumerable<File> Files
        {
            get { return _files; }
        }

        public virtual long Id { get; set; }
        public virtual bool IsArchived { get; set; }

        public void AddSubFolder(Folder folder)
        {
            if (!_subfolders.Contains(folder))
            {
                _subfolders.Add(folder);
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