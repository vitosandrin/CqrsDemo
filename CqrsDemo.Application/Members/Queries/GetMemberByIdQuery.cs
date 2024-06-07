using CqrsDemo.Domain.Abstractions;
using CqrsDemo.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsDemo.Application.Members.Queries;

public class GetMemberByIdQuery : IRequest<Member>
{
    public int Id { get; set; }

    public class GetMemberByIdQueryHandler(IMemberDapperRepository memberDapperRepository) : IRequestHandler<GetMemberByIdQuery, Member>
    {
        private readonly IMemberDapperRepository _memberDapperRepository = memberDapperRepository;
        public async Task<Member> Handle(GetMemberByIdQuery request, CancellationToken cancellationToken)
        {
            var member = await _memberDapperRepository.GetMemberById(request.Id);
            return member;
        }
    }
}