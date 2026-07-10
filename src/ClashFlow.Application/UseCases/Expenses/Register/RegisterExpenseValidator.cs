using ClashFlow.Communication.Requests;
using ClashFlow.Exception;
using FluentValidation;

namespace ClashFlow.Application.UseCases.Expenses.Register
{
    public class RegisterExpenseValidator: AbstractValidator<RequestRegisterExpense>
    {
        public RegisterExpenseValidator()
        {
            RuleFor(expense => expense.Title).NotEmpty().WithMessage(ResourceErrorMessages.TITLE_REQUIRED);
            RuleFor(expense => expense.Amount).GreaterThan(0).WithMessage(ResourceErrorMessages.AMOUNT_MUST_BE_GREATER_THAN_ZERO);
            RuleFor(expense => expense.Date).LessThanOrEqualTo(DateTime.UtcNow).WithMessage(ResourceErrorMessages.EXPENSES_CANNOT_FOR_THE_FURURE);
            RuleFor(expense => expense.PaymentType).IsInEnum().WithMessage(ResourceErrorMessages.PAYMENT_TYPE_INVALID);
        }
    }
}
