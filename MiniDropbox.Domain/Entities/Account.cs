using System.Collections.Generic;

namespace MiniDropbox.Domain
{
    public class Account : IEntity
    {

        private readonly IList<Role> _roles = new List<Role>();

        public virtual IEnumerable<Role> Roles
        {
            get { return _roles; }
        }

        public virtual void AddRole(Role role)
        {
            if (!_roles.Contains(role))
            {
                _roles.Add(role);
            }
        }

        public virtual long Id { get; set; }
        public virtual bool IsArchived { get; set; }

        public virtual string Name { get; set; }

        public virtual IList<File> Files = new List<Role>();

        public virtual string HashConfirmation { get; set; }

        public bool IsConfirm { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

       
    }
}