using ClashFlow.Application.UseCases.Expenses.Register;
using ClashFlow.Communication.Requests;
using ClashFlow.Communication.Response;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        [HttpPost]
        public IActionResult Register([FromBody] RequestRegisterExpense request)
        {
            try
            {
                var useCase = new RegisterExpenseUseCase();

                var response = useCase.Execute(request);

                return Created(string.Empty, response);
            }
            catch(ArgumentException ex) 
            {
                var errorResponse = new ResponseError(ex.Message);                

                return BadRequest(errorResponse);
            }
            catch
            {
                var errorResponse = new ResponseError("ubknown error");
                
                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
    }
}
