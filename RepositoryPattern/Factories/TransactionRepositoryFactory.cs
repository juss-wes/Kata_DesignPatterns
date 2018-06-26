using RepositoryPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Factories
{
    public class TransactionRepositoryFactory
    {
        public enum RepositorySource
        {
            Database,
            FlatFile
        }
        public static ITransactionRepository GetRepository(RepositorySource repositorySource)
        {
            switch (repositorySource)
            {
                case RepositorySource.Database:
                    return new Repositories.TransactionsFromDatabaseRepository();
                case RepositorySource.FlatFile:
                    return new Repositories.TransactionsFromFileRepository();
                default:
                    throw new Exception("Unpossible repository type encountered!");
            }
        }
    }
}
