using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using CqrsDemo.Domain.Entities;

namespace CqrsDemo.Domain.Abstractions;

public interface IMemberDapperRepository
{
    Task<IEnumerable<Member>> GetMembers();
    Task<Member> GetMemberById(int id);
}