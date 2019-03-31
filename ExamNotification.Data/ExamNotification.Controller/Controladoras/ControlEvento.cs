using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamNotification.Data;
using ExamNotification.Data.Repositories;

namespace ExamNotification.Controller.Controladoras
{
    public class ControlEvento
    {
        public void Incluir(ProvasTrabalhos oProvaTrabalho)
        {
            RepositoryProvaTrabalho _Repository = new RepositoryProvaTrabalho();
            _Repository.Incluir(oProvaTrabalho);
            _Repository.Dispose();
        }

        public void Alterar(ProvasTrabalhos oProvaTrabalho)
        {
            RepositoryProvaTrabalho _Repository = new RepositoryProvaTrabalho();
            _Repository.Alterar(oProvaTrabalho);
            _Repository.Dispose();
        }

        public void Excluir(ProvasTrabalhos oProvaTrabalho)
        {
            RepositoryProvaTrabalho _Repository = new RepositoryProvaTrabalho();
            _Repository.Excluir(oProvaTrabalho);
            _Repository.Dispose();
        }

        public ProvasTrabalhos SelecionarPK(params object[] variavel)
        {
            RepositoryProvaTrabalho _Repository = new RepositoryProvaTrabalho();
            return _Repository.SelecionarPK(variavel);
        }

        public List<ProvasTrabalhos> SelecionarTodos()
        {
            RepositoryProvaTrabalho _Repository = new RepositoryProvaTrabalho();
            return _Repository.SelecioanarTodos();
        }
    }
}
