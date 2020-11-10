using TaskManagementApp.Application.Interfaces;

namespace TaskManagementApp.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(ITaskRepository studentRepository)
        {
            Students = studentRepository;
        }
        public ITaskRepository Students { get; set; }
    }
}
