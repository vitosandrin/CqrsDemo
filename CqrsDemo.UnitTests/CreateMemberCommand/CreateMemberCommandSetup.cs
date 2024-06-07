using CqrsDemo.Application.Members.Commands;
using CqrsDemo.UnitTests.UnityOfWorkTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsDemo.UnitTests.CreateMemberCommand;

public class CreateMemberCommandSetup
{
    public readonly MemberCommandBase _memberCommandBase;
    public CreateMemberCommandSetup()
    {
        var uow = new UnityOfWorkSetup();
    }
}
