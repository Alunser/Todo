using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Todo.Domain.TodoItens;

namespace Todo.Tests.EntityTests
{
    [TestClass]
    public class TodoItemTests
    {
        private readonly TodoItem _validTodo = new TodoItem("Título da tarefa", "alunserAlbuquerque", DateTime.Now);

        [TestMethod]
        public void Dado_um_novo_todo_o_mesmo_nao_pode_ser_concluido()
        {
            Assert.AreEqual(_validTodo.Done, false);
        }
    }
}