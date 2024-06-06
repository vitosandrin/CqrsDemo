using CqrsDemo.Application.Members.Commands.Notifications;
using CqrsDemo.Domain.Abstractions;
using CqrsDemo.Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsDemo.Application.Members.Commands;

public class CreateMemberCommand : MemberCommandBase
{
    public class CreateMemberCommandHandler : IRequestHandler<CreateMemberCommand, Member>
    {
        private readonly IUnityOfWork _unitOfWork;
        private readonly IValidator<CreateMemberCommand> _validator;
        private readonly IMediator _mediator;
        public CreateMemberCommandHandler(IUnityOfWork unitOfWork,
                                          IValidator<CreateMemberCommand> validator,
                                          IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
            _mediator = mediator;
        }
        public async Task<Member> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);

            var newMember = new Member(request.FirstName, request.LastName, request.Email, request.IsActive);

            await _unitOfWork.MemberRepository.AddMember(newMember);
            await _unitOfWork.CommitAsync();

            await _mediator.Publish(new MemberCreatedNotification(newMember), cancellationToken);

            return newMember;
        }
    }

}