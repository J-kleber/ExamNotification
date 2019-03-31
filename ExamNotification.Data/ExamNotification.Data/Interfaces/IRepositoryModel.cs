using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamNotification.Data.Interfaces
{
    public interface IRepositoryModel<T> where T : class
    {

        List<T> SelecioanarTodos();
        T SelecionarPK(params object[] variavel);
        T Incluir(T objeto);
        T Alterar(T objeto);
        void Excluir(T objeto);
        void Excluir(params object[] variavel);
        void SaveChanges();

    }
}
