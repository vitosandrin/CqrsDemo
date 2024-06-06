using CqrsDemo.Domain.Entities;
using MediatR;

namespace CqrsDemo.Application.Members.Commands;

public abstract class MemberCommandBase : IRequest<Member>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Gender { get; set; }
    public string? Email { get; set; }
    public bool? IsActive { get; set; }
}