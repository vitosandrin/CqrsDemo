using CqrsDemo.Application.Members.Commands;
using CqrsDemo.UnitTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsDemo.UnitTests;

public class CreateMemberCommandSetup
{
    public readonly CreateMemberCommand _createMemberCommand;
    public CreateMemberCommandSetup()
    {
        var uow = new UnityOfWorkSetup();
        var _createMemberCommand = new CreateMemberCommand(uow._unitOfWork, uow._mediator);
    }
}
