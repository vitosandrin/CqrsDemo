using CqrsDemo.Domain.Abstractions;
using CqrsDemo.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsDemo.Application.Members.Commands;
public sealed class UpdateMemberCommand : MemberCommandBase
{
    public int Id { get; set; }
    public class UpdateMemberCommandHandler(IUnityOfWork unitOfWork) :
                 IRequestHandler<UpdateMemberCommand, Member>
    {
        private readonly IUnityOfWork _unitOfWork = unitOfWork;
        public async Task<Member> Handle(UpdateMemberCommand request, CancellationToken cancellationToken)
        {
            var existingMember = await _unitOfWork.MemberRepository.GetMemberById(request.Id);

            if (existingMember is null) throw new InvalidOperationException("Member not found");

            existingMember.Update(request.FirstName, request.LastName, request.Email, request.IsActive);
            _unitOfWork.MemberRepository.UpdateMember(existingMember);
            await _unitOfWork.CommitAsync();

            return existingMember;
        }
    }
}