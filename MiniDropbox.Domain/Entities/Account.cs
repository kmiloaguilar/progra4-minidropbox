using System.Collections.Generic;

namespace MiniDropbox.Domain
{
    public class Account : IEntity
    {
        public virtual string BucketName { get; set; }
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual bool IsAdmin { get; set; }
        public virtual long Id { get; set; }
        public virtual bool IsArchived { get; set; }
    }
}