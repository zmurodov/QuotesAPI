using FluentValidation;
using QuotesAPI.Dtos.Category;

namespace QuotesAPI.Validators.Category
{
    public class CategoryCreateDtoValidation : AbstractValidator<CategoryCreateDto>
    {
        public CategoryCreateDtoValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty();
        }
    }
}