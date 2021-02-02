using FluentValidation;
using QuotesAPI.Dtos.Quote;

namespace QuotesAPI.Validators.Quote
{
    public class CreateQuoteDtoValidator: AbstractValidator<QuoteCreateDto>
    {
        public CreateQuoteDtoValidator()
        {
            RuleFor(x => x.AuthorId)
                .NotEmpty();

            RuleFor(x => x.CategoryId)
                .NotEmpty();

        }
    }
}