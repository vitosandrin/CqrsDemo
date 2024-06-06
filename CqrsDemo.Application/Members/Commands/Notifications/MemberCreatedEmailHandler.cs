using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsDemo.Application.Members.Commands.Notifications;
public class MemberCreatedEmailHandler(ILogger<MemberCreatedEmailHandler>? logger) : INotificationHandler<MemberCreatedNotification>
{
    private readonly ILogger<MemberCreatedEmailHandler>? _logger = logger;

    public Task Handle(MemberCreatedNotification notification, CancellationToken cancellationToken)
    {

        // Send a confirmation email
        _logger.LogInformation($"Confirmation email sent for : {notification.Member.LastName}");

        //lógica para enviar email   

        return Task.CompletedTask;
    }
}