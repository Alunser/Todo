using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Todo.Domain.TodoItens.Commands;

namespace Todo.Tests.CommandTests
{
    [TestClass]
    public class CreateTodoCommandTests
    {
        private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", "", DateTime.Now);
        private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Título da tarefa", "alunserAlbuquerque", DateTime.Now);

        public CreateTodoCommandTests()
        {
            _validCommand.Validate();
            _invalidCommand.Validate();
        }

        [TestMethod]
        public void Dado_um_commando_invalido()
        {
            Assert.AreEqual(_invalidCommand.Valid, false);
        }

        [TestMethod]
        public void Dado_um_commando_valido()
        {
            Assert.AreEqual(_validCommand.Valid, true);
        }
    }
}
