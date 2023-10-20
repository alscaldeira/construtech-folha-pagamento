using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projeto.Controle;
using Projeto.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Controle.Tests
{
    [TestClass()]
    public class ctlFuncionarioTests
    {
        [TestMethod()]
        public void buscarFuncionarioPorMatriculaTest()
        {
            mdlFuncionario _funcionario = new ctlFuncionario().buscarFuncionarioPorMatricula(1);
            Assert.IsNotNull(_funcionario);
            Assert.IsNotNull(_funcionario.matricula);
            Assert.IsNotNull(_funcionario.nome);
            Console.WriteLine(_funcionario.nome);
        }

        [TestMethod()]
        public void registrarPontoFuncionarioTest()
        {
            bool funcionou = new ctlFuncionario().registrarPontoFuncionario(1);
            Assert.IsTrue(funcionou);
        }
    }
}