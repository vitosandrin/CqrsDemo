using CqrsDemo.Domain.Abstractions;
using CqrsDemo.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsDemo.Application.Members.Queries;

public class GetMembersQuery : IRequest<IEnumerable<Member>>
{
    public class GetMembersQueryHandler(IMemberDapperRepository memberDapperRepository) : IRequestHandler<GetMembersQuery, IEnumerable<Member>>
    {
        private readonly IMemberDapperRepository _memberDapperRepository = memberDapperRepository;
        public async Task<IEnumerable<Member>> Handle(GetMembersQuery request, CancellationToken cancellationToken)
        {
            var members = await _memberDapperRepository.GetMembers();
            return members;
        }
    }
}