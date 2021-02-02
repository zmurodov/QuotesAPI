using FluentValidation;
using QuotesAPI.Dtos.User;

namespace QuotesAPI.Validators.User
{
    public class UserCreateDtoValidation : AbstractValidator<UserCreateDto>
    {
        public UserCreateDtoValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty();
            
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();
        }
    }
}