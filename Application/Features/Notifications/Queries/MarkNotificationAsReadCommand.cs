using Application.Abstractions.Messaging;

namespace Application.Features.Notifications.Commands;

public record MarkNotificationAsReadCommand(Ulid Id) : ICommand<Ulid>;
