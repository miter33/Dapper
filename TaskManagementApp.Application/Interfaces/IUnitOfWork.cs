using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagementApp.Application.Interfaces
{
    public interface IUnitOfWork
    {
        ITaskRepository Students { get; }
    }
}
