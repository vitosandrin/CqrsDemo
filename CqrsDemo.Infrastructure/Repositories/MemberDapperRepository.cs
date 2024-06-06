using CqrsDemo.Domain.Abstractions;
using CqrsDemo.Domain.Entities;
using Dapper;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsDemo.Infrastructure.Repositories;
public class MemberDapperRepository(IDbConnection dbConnection) : IMemberDapperRepository
{
    private readonly IDbConnection _dbConnection = dbConnection;

    public async Task<Member> GetMemberById(int id)
    {
        string query = "SELECT * FROM Members WHERE Id = @Id";
        return await _dbConnection.QueryFirstOrDefaultAsync<Member>(query, new { Id = id });
    }

    public async Task<IEnumerable<Member>> GetMembers()
    {
        string query = "SELECT * FROM Members";
        return await _dbConnection.QueryAsync<Member>(query);
    }
}