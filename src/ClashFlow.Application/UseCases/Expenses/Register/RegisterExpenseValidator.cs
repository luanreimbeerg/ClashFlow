using ClashFlow.Communication.Requests;
using FluentValidation;

namespace ClashFlow.Application.UseCases.Expenses.Register
{
    public class RegisterExpenseValidator: AbstractValidator<RequestRegisterExpense>
    {
        public RegisterExpenseValidator()
        {
            RuleFor(expense => expense.Title).NotEmpty().WithMessage("the title is required");

            RuleFor(expense => expense.Amount).GreaterThan(0).WithMessage("the Amount must be greater than zero");

            RuleFor(expense => expense.Date).LessThanOrEqualTo(DateTime.UtcNow).WithMessage("expenses cannout be for the future");

            RuleFor(expense => expense.PaymentType).IsInEnum().WithMessage("payment Type is not valid");
        }
    }
}
