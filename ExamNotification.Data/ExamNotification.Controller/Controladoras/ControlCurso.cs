using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamNotification.Data;
using ExamNotification.Data.Repositories;

namespace ExamNotification.Controller.Controladoras
{
    public class ControlCurso
    {
        public void Incluir(Curso oCurso)
        {
            RepositoryCurso _Repository = new RepositoryCurso();
            _Repository.Incluir(oCurso);
            _Repository.Dispose();
        }

        public void Alterar(Curso oCurso)
        {
            RepositoryCurso _Repository = new RepositoryCurso();
            _Repository.Alterar(oCurso);
            _Repository.Dispose();
        }

        public void Excluir(Curso oCurso)
        {
            RepositoryCurso _Repository = new RepositoryCurso();
            _Repository.Excluir(oCurso);
            _Repository.Dispose();
        }

        public Curso SelecionarPK(params object[] variavel)
        {
            RepositoryCurso _Repository = new RepositoryCurso();
            return _Repository.SelecionarPK(variavel);
           
        }

        public List<Curso> SelecionarTodos()
        {
            RepositoryCurso _Repository = new RepositoryCurso();
            return _Repository.SelecioanarTodos();
        }
    }
}
