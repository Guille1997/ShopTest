using Microsoft.AspNetCore.Mvc;
using webapi.Business;
using webapi.Core;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ClientServices _clientServices;

        public ClientController(ClientServices clientServices)
        {
            _clientServices = clientServices;
        }

        [HttpGet]
        public IActionResult GetClients()
        {
            var clients = _clientServices.GetClients();
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var client = _clientServices.GetClient(id);
            return Ok(client);
        }

        [HttpPost]
        public IActionResult CreateClient([FromBody] Client client)
        {
            var response = _clientServices.CreateClient(client);
            if (response.Code == 201)
            {
                return CreatedAtAction("Get", new { id = response.Data }, response);
            }
            return BadRequest(new { Code = response.Code, Message = response.Message, ErrorMessage = response.ErrorMessage });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateClient(int id,[FromBody] Client client)
        {
            var response = _clientServices.UpdateClient(client, id);
            if (response.Code == 200)
            {
                return Ok(response);
            }
            return BadRequest(new { Code = response.Code, Message = response.Message, ErrorMessage = response.ErrorMessage });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteClient(int id)
        {
            var response = _clientServices.DeleteClient(id);
            if (response.Code == 200)
            {
                return Ok(response);
            }
            return BadRequest(new { Code = response.Code, Message = response.Message, ErrorMessage = response.ErrorMessage });
        }
    }
}
