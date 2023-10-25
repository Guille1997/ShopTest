using Microsoft.EntityFrameworkCore;
using webapi.Core;

namespace webapi.Data
{
    public class ItemRepository
    {
        private readonly SqlServerContext _context;

        public ItemRepository(SqlServerContext context)
        {
            _context = context;
        }

        public Response GetItems()
        {
            try
            {
                var items = _context.Item.ToList();
                return new Response { Code = 200, Message = "Items retrieved successfully", Data = items };
            }
            catch (Exception ex)
            {
                return new Response { Code = 500, Message = "An error occurred while retrieving items", ErrorMessage = ex.Message };
            }
        }

        public Response Get(int id)
        {
            try
            {
                var item = _context.Item.FirstOrDefault(i => i.Code == id);
                if (item != null)
                {
                    return new Response { Code = 200, Message = "Item retrieved successfully", Data = item };
                }
                else
                {
                    return new Response { Code = 404, Message = "Item not found" };
                }
            }
            catch (Exception ex)
            {
                return new Response { Code = 500, Message = "An error occurred while retrieving the item", ErrorMessage = ex.Message };
            }
        }

        public Response CreateItem(Item item)
        {
            try
            {
                _context.Item.Add(item);
                _context.SaveChanges();
                return new Response { Code = 201, Message = "Item created successfully", Data = item.Code };
            }
            catch (Exception ex)
            {
                return new Response { Code = 500, Message = "An error occurred while creating the item", ErrorMessage = ex.Message };
            }
        }

        public Response UpdateItem(int id, Item itemData)
        {
            try
            {
                var existingItem = _context.Item.FirstOrDefault(i => i.Code == id);

                if (existingItem != null)
                {
                    // Actualiza las propiedades del item existente con los datos proporcionados
                    existingItem.Description = itemData.Description;
                    existingItem.Price = itemData.Price;
                    existingItem.Image = itemData.Image;
                    existingItem.Stock = itemData.Stock;

                    _context.SaveChanges();

                    return new Response { Code = 200, Message = "Item updated successfully" };
                }
                else
                {
                    return new Response { Code = 404, Message = "Item not found" };
                }
            }
            catch (Exception ex)
            {
                return new Response { Code = 500, Message = "An error occurred while updating the item", ErrorMessage = ex.Message };
            }
        }

        public Response DeleteItem(int id)
        {
            try
            {
                var item = _context.Item.FirstOrDefault(i => i.Code == id);
                if (item != null)
                {
                    _context.Item.Remove(item);
                    _context.SaveChanges();
                    return new Response { Code = 200, Message = "Item deleted successfully" };
                }
                else
                {
                    return new Response { Code = 404, Message = "Item not found" };
                }
            }
            catch (Exception ex)
            {
                return new Response { Code = 500, Message = "An error occurred while deleting the item", ErrorMessage = ex.Message };
            }
        }
    }
}
