using FluentValidation;

namespace ApplicationServices.DTOs.Models
{
    public class UserModel
    {
        public string UserName { get; set; } = null!;

        public string User { get; set; } = null!;

        public string Position { get; set; }

        public int Phone { get; set; }

        public string Gmail { get; set; } = null!;

        public string TypeContact { get; set; }
    }

    public class AddValidator : AbstractValidator<UserModel>
    {
        public AddValidator()
        {
            _ = RuleFor(b => b.UserName)
                .NotEmpty()
                .Custom((userName, context) =>
                {
                    if (userName.Length > 50)
                        context.AddFailure($"Username:{userName} not valid!, Maximum length is 50 characters ");
                });

            _ = RuleFor(b => b.User)
                .NotEmpty()
                .MaximumLength(50)
                .Custom((user, context) =>
                {
                    if (user.Length > 20)
                        context.AddFailure($"User:{user} not valid!, Maximum length is 20 characters ");
                });

            _ = RuleFor(b => b.Position)
                .NotEmpty()
                .MaximumLength(20)
                .Custom((positio, context) =>
                {
                    if (positio.Length > 20)
                        context.AddFailure($"Position:{positio} not valid!, Maximum length is 20 characters ");
                });

            _ = RuleFor(b => b.TypeContact)
                .NotEmpty()
                .MaximumLength(20)
                .Custom((type, context) =>
                {
                    if (type.Length > 20)
                        context.AddFailure($"TypeContact:{type} not valid!, Maximum length is 20 characters ");
                });

            _ = RuleFor(b => b.Gmail)
                .NotEmpty()
                .MaximumLength(30)
                .EmailAddress();

            _ = RuleFor(b => b.Phone)
                .NotEmpty();


        }
    }
}
