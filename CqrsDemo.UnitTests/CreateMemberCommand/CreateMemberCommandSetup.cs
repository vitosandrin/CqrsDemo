using CqrsDemo.Application.Members.Commands;
using CqrsDemo.UnitTests;
using FluentValidation;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsDemo.UnitTests;

public class CreateMemberCommandSetup
{
    public readonly UnityOfWorkSetup _uow;
    public CreateMemberCommandSetup()
    {
        _uow = new UnityOfWorkSetup();
    }
}
