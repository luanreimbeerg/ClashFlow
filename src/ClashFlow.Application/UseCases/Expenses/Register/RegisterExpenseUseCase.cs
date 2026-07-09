using ClashFlow.Communication.Requests;
using ClashFlow.Communication.Response;
using ClashFlow.Exception.ExceptionsBase;

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
            var validator = new RegisterExpenseValidator();
            var result = validator.Validate(request);

            if(result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
            
        }
    }
}
