using CqrsDemo.Application.Members.Commands;
using CqrsDemo.UnitTests.;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsDemo.UnitTests;

public class CreateMemberCommandSetup
{
    public CreateMemberCommandSetup()
    {
        var uow = new UnityofWorkSetup();
    }
}
