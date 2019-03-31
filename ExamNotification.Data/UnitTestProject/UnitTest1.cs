using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExamNotification.Data;
using ExamNotification.Data.Repositories;
namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        /*[TestMethod]
        public void IncluirCurso()
        {
            Curso oCurso = new Curso();
            oCurso.Nome = "Sistemas de Informação";
            oCurso.Duracao = 4;
            RepositoryCurso _Repository = new RepositoryCurso();
            _Repository.Incluir(oCurso);
            _Repository.Dispose();
        }*/

        [TestMethod]
        public void alterarCurso()
        {
            Curso oCurso = new Curso();
            oCurso.Codigo = 1;
            oCurso.Nome = "Sistemas de Informação";
            oCurso.Duracao = "kk";
            RepositoryCurso _Repository = new RepositoryCurso();
            _Repository.Alterar(oCurso);
            _Repository.Dispose();
        }
    }
}
