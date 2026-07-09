using ClashFlow.Communication.Requests;
using ClashFlow.Exception;
using FluentValidation;

namespace ClashFlow.Application.UseCases.Expenses.Register
{
    public class RegisterExpenseValidator: AbstractValidator<RequestRegisterExpense>
    {
        public RegisterExpenseValidator()
        {
            RuleFor(expense => expense.Title).NotEmpty().WithMessage(Resource.TITLE_REQUIRED);
            RuleFor(expense => expense.Amount).GreaterThan(0).WithMessage(Resource.AMOUNT_MUST_BE_GREATER_THAN_ZERO);
            RuleFor(expense => expense.Date).LessThanOrEqualTo(DateTime.UtcNow).WithMessage(Resource.EXPENSES_CANNOT_FOR_THE_FURURE);
            RuleFor(expense => expense.PaymentType).IsInEnum().WithMessage(Resource.PAYMENT_TYPE_INVALID);
        }
    }
}
