using RepositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Interfaces
{
    interface ITransactionRepository
    {
        IEnumerable<Transaction> GetAll();
        Transaction Get(string recordId);
    }
}
