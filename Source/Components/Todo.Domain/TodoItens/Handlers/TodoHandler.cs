using Flunt.Notifications;
using Todo.Domain.Core.Commads.Results;
using Todo.Domain.Core.Interfaces.Commands.Results;
using Todo.Domain.Core.Interfaces.Handlers;
using Todo.Domain.TodoItens.Commands;
using Todo.Domain.TodoItens.Interfaces.Repositories;

namespace Todo.Domain.TodoItens.Handlers
{
    public class TodoHandler : Notifiable
        , IHandler<CreateTodoCommand>
        , IHandler<UpdateTodoCommand>
        , IHandler<MarkTodoAsDoneCommand>
        , IHandler<MarkTodoAsUndoneCommand>
    {
        private readonly ITodoRepository _todoRepository;

        public TodoHandler(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public ICommandResult Handle(CreateTodoCommand command)
        {
            command.Validate();

            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

            var todo = new TodoItem(command.Title, command.User, command.Date);

            _todoRepository.Create(todo);

            return new GenericCommandResult(true, "Tarefa salva", todo);
        }
        
        public ICommandResult Handle(UpdateTodoCommand command)
        {
            command.Validate();

            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

            var todo = _todoRepository.GetById(command.Id, command.User);

            todo.UpdateTile(command.Title);

            _todoRepository.Update(todo);

            return new GenericCommandResult(true, "Tarefa salva", todo);
        }

        public ICommandResult Handle(MarkTodoAsDoneCommand command)
        {
            command.Validate();

            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

            var todo = _todoRepository.GetById(command.Id, command.User);

            todo.MaskAsDone();

            _todoRepository.Update(todo);

            return new GenericCommandResult(true, "Tarefa salva", todo);
        }

        public ICommandResult Handle(MarkTodoAsUndoneCommand command)
        {
            command.Validate();

            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

            var todo = _todoRepository.GetById(command.Id, command.User);

            todo.MaskAsUndone();

            _todoRepository.Update(todo);

            return new GenericCommandResult(true, "Tarefa salva", todo);
        }
    }
}