using Todo.Domain.Core.Interfaces.Commands;
using Todo.Domain.Core.Interfaces.Commands.Results;

namespace Todo.Domain.Core.Interfaces.Handlers
{
    public interface IHandler<T> where T: ICommand
    {
        ICommandResult Handle(T command);
    }
}