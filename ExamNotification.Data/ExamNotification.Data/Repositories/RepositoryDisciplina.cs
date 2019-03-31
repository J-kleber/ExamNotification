using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamNotification.Data.Interfaces;

namespace ExamNotification.Data.Repositories
{
    public class RepositoryDisciplina : RepositoryBase<Disciplinas>, IRepositoryDisciplina
    {
        public RepositoryDisciplina(bool SaveChanges = true) : base(SaveChanges)
        {

        }
    }
}
