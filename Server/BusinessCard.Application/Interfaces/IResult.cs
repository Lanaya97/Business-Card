using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCard.Application.Interfaces
{
    public interface IResult
    {
        IReadOnlyCollection<IResultError> Errors { get; }
        string Message { get; }
        bool Succeeded { get; }
    }

    public interface IResult<out T> : IResult
    {
        T Data { get; }
    }

    public interface IResultError
    {
        string Error { get; }
        string Code { get; }
    }
}
