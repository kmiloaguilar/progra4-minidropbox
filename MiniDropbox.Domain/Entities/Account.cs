using System.Collections.Generic;

namespace MiniDropbox.Domain
{
    public class Account : IEntity
    {
        public virtual long Id { get; set; }

        public virtual string Name { get; set; }

        public virtual IList<File> Files { get; set; }
    }
}