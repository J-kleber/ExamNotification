using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamNotification.Data;
using ExamNotification.Data.Repositories;

namespace ExamNotification.Controller.Controladoras
{
    public class ControlDisciplina
    {
        public void Incluir(Disciplinas oDisciplina)
        {
            RepositoryDisciplina _Repository = new RepositoryDisciplina();
            _Repository.Incluir(oDisciplina);
            _Repository.Dispose();
        }

        public void Alterar(Disciplinas oDisciplina)
        {
            RepositoryDisciplina _Repository = new RepositoryDisciplina();
            _Repository.Alterar(oDisciplina);
            _Repository.Dispose();
        }

        public void Excluir(Disciplinas oDisciplina)
        {
            RepositoryDisciplina _Repository = new RepositoryDisciplina();
            _Repository.Excluir(oDisciplina);
            _Repository.Dispose();
        }

        public Disciplinas SelecionarPK(params object[] variavel)
        {
            RepositoryDisciplina _Repository = new RepositoryDisciplina();
            return _Repository.SelecionarPK(variavel);
        }

        public List<Disciplinas> SelecionarTodos()
        {
            RepositoryDisciplina _Repository = new RepositoryDisciplina();
            return _Repository.SelecioanarTodos();
        }
    }
}
