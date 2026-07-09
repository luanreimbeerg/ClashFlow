using ClashFlow.Communication.Requests;
using ClashFlow.Communication.Response;

namespace ClashFlow.Application.UseCases.Expenses.Register
{
    public class RegisterExpenseUseCase
    {
        public ResponseResgisterExpense Execute(RequestRegisterExpense request)
        {
            Validate(request);

            return new ResponseResgisterExpense();
        }

        private void Validate(RequestRegisterExpense request) 
        {
            var titleIsEmpty = string.IsNullOrWhiteSpace(request.Title);
            if (titleIsEmpty) 
            {
                throw new ArgumentException("the title is required");
            }

            if (request.Amount <= 0)
            {
                throw new ArgumentException("the Amount must be greater than zero");
            }

            var result = DateTime.Compare(request.Date, DateTime.UtcNow);

            if (result > 0)
            {
                throw new ArgumentException("expenses cannout be for the future");
            }

            var paymentTypeUsValid = Enum.IsDefined(typeof(PaymentType), request.PaymentType);

            if (paymentTypeUsValid == false) 
            {
                throw new ArgumentException("payment Type is not valid");
            }
        }
    }
}
