using Microsoft.AspNetCore.Mvc;
using webapi.Business;
using webapi.Core;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly ItemServices _itemServices;

        public ItemController(ItemServices itemServices)
        {
            _itemServices = itemServices;
        }

        [HttpGet]
        public IActionResult GetItems()
        {
            var items = _itemServices.GetItems();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = _itemServices.GetItem(id);
            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateItem([FromBody] Item item)
        {
            var response = _itemServices.CreateItem(item);
            if (response.Code == 201)
            {
                return CreatedAtAction("Get", new { id = response.Data }, response);
            }
            return BadRequest(new { Code = response.Code, Message = response.Message, ErrorMessage = response.ErrorMessage });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateItem(int id, [FromBody] Item item)
        {
            var response = _itemServices.UpdateItem(item ,id);
            if (response.Code == 200)
            {
                return Ok(response);
            }
            return BadRequest(new { Code = response.Code, Message = response.Message, ErrorMessage = response.ErrorMessage });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {
            var response = _itemServices.DeleteItem(id);
            if (response.Code == 200)
            {
                return Ok(response);
            }
            return BadRequest(new { Code = response.Code, Message = response.Message, ErrorMessage = response.ErrorMessage });
        }
    }
}
