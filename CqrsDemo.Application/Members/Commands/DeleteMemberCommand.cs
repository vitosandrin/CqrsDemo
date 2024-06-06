using CqrsDemo.Domain.Abstractions;
using CqrsDemo.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsDemo.Application.Members.Commands;
public sealed class DeleteMemberCommand : IRequest<Member>
{
    public int Id { get; set; }

    public class DeleteMemberCommandHandler(IUnityOfWork unitOfWork) : IRequestHandler<DeleteMemberCommand, Member>
    {
        private readonly IUnityOfWork _unitOfWork = unitOfWork;
        public async Task<Member> Handle(DeleteMemberCommand request,
                     CancellationToken cancellationToken)
        {
            var deletedMember = await _unitOfWork.MemberRepository.DeleteMember(request.Id);

            if (deletedMember is null)
                throw new InvalidOperationException("Member not found");

            await _unitOfWork.CommitAsync();
            return deletedMember;
        }
    }
}