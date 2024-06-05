using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsDemo.Domain.Abstractions;

public interface IUnityOfWork
{
    IMemberRepository MemberRepository { get; }
    Task CommitAsync();
}
