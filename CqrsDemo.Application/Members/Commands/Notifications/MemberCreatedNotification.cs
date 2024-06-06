using CqrsDemo.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsDemo.Application.Members.Commands.Notifications;
public class MemberCreatedNotification(Member member) : INotification
{
    public Member Member { get; } = member;
}