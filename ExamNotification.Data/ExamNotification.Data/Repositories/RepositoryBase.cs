using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamNotification.Data.Interfaces;


namespace ExamNotification.Data.Repositories
{
    public abstract class RepositoryBase<T/*, TContext*/> : IRepositoryModel<T> , IDisposable 
        where T : class
       // where TContext : DbContext
    {

        //protected TContext _Contexto;

       

        private bool _SaveChanges = true;

        protected DbContext _Contexto;

        public RepositoryBase(/*TContext MyDataContext,*/bool SaveChanges = true)
        {
            //_Contexto = MyDataContext;
            _SaveChanges = SaveChanges;
            _Contexto = new ProjetoNotificacaoEntities();
        }

        public T Alterar(T objeto)
        {
            _Contexto.Entry(objeto).State = EntityState.Modified;
            if (_SaveChanges)
            {
                _Contexto.SaveChanges();
            }
            return objeto;
        }

        public void Excluir(T objeto)
        {
            _Contexto.Set<T>().Attach(objeto);
            _Contexto.Set<T>().Remove(objeto);

            if (_SaveChanges)
            {
                _Contexto.SaveChanges();
            }
           
        }

        public void Excluir(params object[] variavel)
        {
            var objeto = SelecionarPK(variavel);
            Excluir(objeto);
        }

        public T Incluir(T objeto)
        {
            _Contexto.Set<T>().Add(objeto);
            if (_SaveChanges)
            {
                _Contexto.SaveChanges();
            }
            return objeto;
        }

        public void SaveChanges()
        {
            _Contexto.SaveChanges();
        }

        public List<T> SelecioanarTodos()
        {
            return _Contexto.Set<T>().ToList();
        }

        public T SelecionarPK(params object[] variavel)
        {
            return _Contexto.Set<T>().Find(variavel);
        }

        public void Dispose()
        {
            _Contexto.Dispose();
        }
    }
}
