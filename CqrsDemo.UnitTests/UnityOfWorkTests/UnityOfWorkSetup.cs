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
using FluentValidation;
using CqrsDemo.Application.Members.Commands;
using Microsoft.EntityFrameworkCore;

namespace CqrsDemo.UnitTests;
public class UnityOfWorkSetup
{
    public readonly IUnityOfWork _unitOfWork;
    public readonly IMediator _mediator;
    public readonly List<INotification> _notifications;

    public readonly Member _member1 = new("Member1", "Any", "member1@teste.com", true);
    public readonly Member _member2 = new("Member2", "Any", "member2@teste.com", false);
    public readonly Member _member2Updated = new("Member2", "Any", "member2#teste.com", true);
    public UnityOfWorkSetup()
    {
        var mediatorMock = new Mock<IMediator>();
        var notifications = new List<INotification>();
        var notificationHandlerMock = new Mock<INotificationHandler<INotification>>();
        notificationHandlerMock.Setup(f => f.Handle(It.IsAny<INotification>(), It.IsAny<CancellationToken>()))
                      .Callback((INotification n, CancellationToken c) =>
                      {
                          notifications.Add(n);
                      })
                      .Returns(Task.CompletedTask);

        mediatorMock.Setup(f => f.Publish(It.IsAny<INotification>(), It.IsAny<CancellationToken>()))
            .Callback((INotification n, CancellationToken c) =>
            {
                notificationHandlerMock.Object.Handle(n, c);
            })
            .Returns(Task.CompletedTask);

        var options = new DbContextOptionsBuilder<AppDbContext>().Options;
        var contextMock = new Mock<AppDbContext>(options);
        contextMock.Setup(m => m.SaveChanges()).Returns(1);

        Mock<IMemberRepository> memberMock = new();
        memberMock.Setup(m => m.GetMemberById(1)).ReturnsAsync(_member1);
        memberMock.Setup(m => m.AddMember(_member2)).ReturnsAsync(_member2);
        memberMock.Setup(m => m.UpdateMember(_member2));
        memberMock.Setup(m => m.DeleteMember(1)).ReturnsAsync(_member1);

        _unitOfWork = new UnityOfWork(contextMock.Object, memberMock.Object);
        _mediator = mediatorMock.Object;
    }

}
