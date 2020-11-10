using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TaskManagementApp.Application.Interfaces;

namespace TaskManagementApp.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly IConfiguration configuration;

        public TaskRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<int> Add(Core.Entities.Student entity)
        {
            var sql = "INSERT INTO Students (Name, Surname) VALUES (@Name, @Surname)";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var affectedRows = await connection.ExecuteAsync(sql, entity);
                return affectedRows;
            }
        }

        public async Task<int> Delete(int id)
        {
            var sql = "DELETE FROM Students WHERE Id = @id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var affectedRows = await connection.ExecuteAsync(sql, new { id = id });
                return affectedRows;
            }
        }

        public async Task<Core.Entities.Student> Get(int id)
        {
            var sql = "SELECT * FROM Students WHERE Id = @id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Core.Entities.Student>(sql, new { id = id });
                return result.FirstOrDefault();
            }
        }

        public async Task<IEnumerable<Core.Entities.Student>> GetAll()
        {
            var sql = "SELECT * FROM Students";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Core.Entities.Student>(sql);
                return result;
            }
        }

        public async Task<int> Update(Core.Entities.Student entity)
        {
            var sql = "UPDATE Students SET Name = @Name, Surname = @Surname WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var affectedRows = await connection.ExecuteAsync(sql, entity);
                return affectedRows;
            }
        }
    }
}
