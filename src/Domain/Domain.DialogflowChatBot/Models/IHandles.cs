using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DotNetCore.Models
{
    // TODO: Rename to IHandlesQuery in sprint 144
    public interface IHandles<in TQuery, out TResult> : IHandler where TQuery : IQuery<TResult>
    {
        TResult Handle(TQuery query);
    }

    // TODO: Rename to IHandlesCommand in sprint 144
    public interface IHandles<in TCommand> : IHandler where TCommand : ICommand
    {
        void Handle(TCommand command);
    }

    public interface IHandlesAsync<in TCommand> : IHandler where TCommand : ICommand
    {
        Task HandleAsync(TCommand command);
    }

    public interface IHandlesAsync<in TQuery, TResult> : IHandler where TQuery : IQuery<TResult>
    {
        Task<TResult> HandleAsync(TQuery query);
    }

    public interface IHandlesCommand<in TCommand, out TResult> : IHandler where TCommand : ICommand<TResult>
    {
        TResult Handle(TCommand command);
    }
}
