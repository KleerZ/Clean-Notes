using MediatR;

namespace Notes.Application.Users.Commands.CreateUser;

public class CreateUserCommand: IRequest<Guid>
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
}