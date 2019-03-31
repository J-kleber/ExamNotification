using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamNotification.Data.Interfaces;

namespace ExamNotification.Data.Repositories
{
    public class RepositoryProvaTrabalho : RepositoryBase<ProvasTrabalhos>, IRepositoryProvaTrabalho                                             
    {
        public RepositoryProvaTrabalho(bool SaveChanges = true) : base(SaveChanges)
        {

        }
    }
}
