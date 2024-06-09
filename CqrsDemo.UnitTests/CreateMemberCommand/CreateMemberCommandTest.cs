using Azure.Core;
using CqrsDemo.Application.Members.Commands;
using CqrsDemo.Application.Members.Commands.Notifications;
using CqrsDemo.Domain.Entities;
using CqrsDemo.Domain.Validation;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CqrsDemo.UnitTests;

public class CreateMemberCommandTest(CreateMemberCommandSetup createMemberCommandSetup) : IClassFixture<CreateMemberCommandSetup>
{
    private readonly Member _member = createMemberCommandSetup._uow._member1;
    [Fact]
    public void CreateMemberCommand_FirstNameIsEmpty_ReturnsErrorMessage()
    {
        var command = new CreateMemberCommand
        {
            Email = _member.Email,
            FirstName = "",
            LastName = _member.LastName,
            IsActive = _member.IsActive
        };

        var exception = Assert.Throws<DomainValidation>(() => new Member("", "email@email.com", "LastnName", true));
        Assert.Equal("Invalid name. FirstName is required", exception.Message);
    }

    [Fact]
    public void CreateMemberCommand_ReturnsSucess()
    {
        var member = new CreateMemberCommand
        {
            Email = _member.Email,
            FirstName = _member.FirstName,
            LastName = _member.LastName,
            IsActive = _member.IsActive
        };

        Assert.Equal(_member.FirstName, member.FirstName);
    }

    [Fact]
    public void UpdateMemberCommand_ReturnSucess()
    {
        var member = new UpdateMemberCommand
        {
            Email = _member.Email,
            FirstName = _member.FirstName,
            LastName = _member.LastName,
            IsActive = _member.IsActive
        };

        Assert.Equal(_member.FirstName, member.FirstName);
    }
}