using DomainDrivenDatabaseDeployer;
using MiniDropbox.Domain;
using NHibernate;

namespace MiniDropbox.DatabaseDeployer
{
    public class AccountSeeder : IDataSeeder
    {
        private readonly ISession _session;

        public AccountSeeder(ISession session)
        {
            _session = session;
        }

        public void Seed()
        {
            
            var account = new Account
                {
                   

                };

            _session.Save(account);
        }
    }
}