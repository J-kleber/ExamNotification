using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamNotification.Data;
using ExamNotification.Data.Repositories;

namespace ExamNotification.Controller.Controladoras
{
    public class ControlAluno
    {
        public void Incluir(Alunos oAluno)
        {
            RepositoryAluno _Repository = new RepositoryAluno();
            _Repository.Incluir(oAluno);
            _Repository.Dispose();
        }

        public void Alterar(Alunos oAluno)
        {
            RepositoryAluno _Repository = new RepositoryAluno();
            _Repository.Alterar(oAluno);
            _Repository.Dispose();
        }

        public void Excluir(Alunos oAluno)
        {
            RepositoryAluno _Repository = new RepositoryAluno();
            _Repository.Excluir(oAluno);
            _Repository.Dispose();
        }

        public Alunos SelecionarPK(params object[] variavel)
        {
            RepositoryAluno _Repository = new RepositoryAluno();
            return _Repository.SelecionarPK(variavel);
        }

        public List<Alunos> SelecionarTodos()
        {
            RepositoryAluno _Repository = new RepositoryAluno();
            return _Repository.SelecioanarTodos();
        }
    }
}
