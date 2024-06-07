using CqrsDemo.Domain.Abstractions;
using CqrsDemo.Domain.Entities;
using Moq;
using CqrsDemo.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CqrsDemo.Infrastructure.Repositories;
using MediatR;

namespace CqrsDemo.UnitTests;

public class UnityOfWorkSetup
{
    public readonly IUnityOfWork _unitOfWork;

    public readonly IMediator _mediator;

    public static Member _member1 = new("Member1", "Any", "member1@teste.com", true);
    public static Member _member2 = new("Member2", "Any", "member2@teste.com", false);
    public static List<Member> _memberList = new() { _member1, _member2 };
    public static Member _member2Updated = new("Member2", "Any", "member2#teste.com", true);
    public UnityOfWorkSetup()
    {
        Mock<AppDbContext> contextMock = new();
        Mock<Mediator> mediatorMock = new();
        contextMock.Setup(m => m.SaveChanges()).Returns(1);

        Mock<IMemberRepository> memberMock = new();
        memberMock.Setup(m => m.GetMembers()).ReturnsAsync(_memberList);
        memberMock.Setup(m => m.GetMemberById(1)).ReturnsAsync(_member1);
        memberMock.Setup(m => m.AddMember(_member2)).ReturnsAsync(_member2);
        memberMock.Setup(m => m.UpdateMember(_member2));
        memberMock.Setup(m => m.DeleteMember(1)).ReturnsAsync(_member1);
        _unitOfWork = new UnityOfWork(contextMock.Object);
        _mediator = mediatorMock.Object;
    }

}
