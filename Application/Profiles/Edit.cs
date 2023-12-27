using Application.Core;
using Application.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Profiles
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public string DisplayName { get; set; }
            public string Bio { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.DisplayName).NotEmpty(); 
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IUserAccessor _userAccessor;
            private readonly DataContext _context;

            public Handler(DataContext context, IUserAccessor userAccessor)
            {
                _context = context;
                _userAccessor = userAccessor;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var currentUsername = _userAccessor.GetUsername();

                var profile = await _context.Users.FirstOrDefaultAsync(x => x.UserName == currentUsername);

                if (profile == null)
                    return null;
                
                profile.DisplayName = request.DisplayName ?? profile.DisplayName;
                profile.Bio = request.Bio ?? profile.Bio;

                _context.Entry(profile).State = EntityState.Modified;

                var success = await _context.SaveChangesAsync() > 0;

                if (success)
                    return Result<Unit>.Success(Unit.Value);
                else
                    return Result<Unit>.Failure("Problem editting user profile");
            }
        }
    }
}