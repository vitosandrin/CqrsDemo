using CqrsDemo.Domain.Abstractions;
using CqrsDemo.Domain.Entities;
using Moq;
using CqrsDemo.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsDemo.UnitTests.UnityOfWorkTests;

public class UnityOfWorkSetup
{
    public readonly IUnityOfWork _unitOfWork;

    public static Member _member1 = new("Member1", "Any", "member1@teste.com", true);
    public static Member _member2 = new("Member2", "Any", "member2@teste.com", false);
    public static List<Member> _memberList = new() { _member1, _member2 };
    public static Member _member2Updated = new("Member2", "Any", "member2#teste.com", true);
    public UnityOfWorkSetup(IUnityOfWork unitOfWork)
    {
        Mock<AppDbContext> contextMock = new();
        contextMock.Setup(m => m.SaveChanges()).Returns(1);

        Mock<IMemberRepository> memberMock = new();
        memberMock.Setup(m => m.GetMembers()).ReturnsAsync(_memberList);
        memberMock.Setup(m => m.GetMemberById(1)).ReturnsAsync(_member1);
        memberMock.Setup(m => m.AddMember(_member2)).ReturnsAsync(_member2);
        memberMock.Setup(m => m.UpdateMember(_member2));
        memberMock.Setup(m => m.DeleteMember(1)).ReturnsAsync(_member1);

        _unitOfWork = unitOfWork;
    }

}
