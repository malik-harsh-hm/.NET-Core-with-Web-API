using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DotNetCore.Models
{
    public interface ICommand { }

    public interface ICommand<TResult> { }
}
