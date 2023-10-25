using Microsoft.AspNetCore.Mvc;
using webapi.Business;
using webapi.Core;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly StoreServices _storeServices;

        public StoreController(StoreServices storeServices)
        {
            _storeServices = storeServices;
        }

        [HttpGet]
        public IActionResult GetStores()
        {
            var stores = _storeServices.GetStores();
            return Ok(stores);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var store = _storeServices.GetStore(id);
            return Ok(store);
        }

        [HttpPost]
        public IActionResult CreateStore([FromBody] Store store)
        {
            var response = _storeServices.CreateStore(store);
            if (response.Code == 201)
            {
                return CreatedAtAction("Get", new { id = response.Data }, response);
            }
            return BadRequest(new { Code = response.Code, Message = response.Message, ErrorMessage = response.ErrorMessage });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStore(int id, [FromBody] Store store)
        {
            var response = _storeServices.UpdateStore(store, id);
            if (response.Code == 200)
            {
                return Ok(response);
            }
            return BadRequest(new { Code = response.Code, Message = response.Message, ErrorMessage = response.ErrorMessage });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStore(int id)
        {
            var response = _storeServices.DeleteStore(id);
            if (response.Code == 200)
            {
                return Ok(response);
            }
            return BadRequest(new { Code = response.Code, Message = response.Message, ErrorMessage = response.ErrorMessage });
        }
    }
}
