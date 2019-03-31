using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamNotification.Data.Interfaces;

namespace ExamNotification.Data.Repositories
{
    public class RepositoryCurso : RepositoryBase<Curso>, IRepositoryCurso
    {
        public RepositoryCurso(bool SaveChanges = true) : base(SaveChanges)
        {

        }
    }
}
