using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsDemo.Domain.Abstractions;

public interface IMemberRepository
{
    Task<IEnumerable<Member>> GetMembers();
    Task<Member> GetMemberById(int memberId);
    Task<Member> AddMember(Member member);
    void UpdateMember(Member member);
    Task<Member> DeleteMember(int memberId);
}