using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nilvera.Application.Features.Customers.ConvertJson;
using Nilvera.Application.Features.Customers.ConvertXML;
using Nilvera.Application.Features.Customers.CreateCustomer;
using Nilvera.Application.Features.Customers.GetCustomer;
using Nilvera.Application.Features.Customers.UpdateCustomer;
using Nilvera.Domain.Entities;

namespace NilveraApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator mediator;

        public CustomerController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// insert customer
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<int>> CreateCustomer(CreateCustomerCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        /// <summary>
        /// get customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await mediator.Send(new GetCustomerQuery(id));
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        /// <summary>
        /// delete customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteCustomer(int id)
        {
            return Ok(await mediator.Send(new DeleteCustomerCommand(id)));
        }

        /// <summary>
        /// update customer
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdateCustomer")]
        public async Task<ActionResult<int>> UpdateCustomer(UpdateCustomerCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        /// <summary>
        /// Get customer list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCustomerList")]
        public async Task<ActionResult<List<Customer>>> GetCustomerList()
        {
            return Ok(await mediator.Send(new GetCustomerListQuery()));
        }

        /// <summary>
        /// stringi jsona çevirir
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetJSON")]
        public async Task<ActionResult<Customer>> GetJSON()
        {
            return Ok(await mediator.Send(new ConvertJsonQuery()));
        }

        /// <summary>
        /// convert customer list to xml
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetXML")]
        public async Task<ActionResult<bool>> GetXML()
        {
            return Ok(await mediator.Send(new ConvertXMLQuery()));
        }
    }
}
