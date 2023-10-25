using Microsoft.EntityFrameworkCore;
using webapi.Core;

namespace webapi.Data
{
    public class StoreRepository
    {
        private readonly SqlServerContext _context;

        public StoreRepository(SqlServerContext context)
        {
            _context = context;
        }

        public Response GetStores()
        {
            try
            {
                var stores = _context.Set<Store>().ToList();
                return new Response { Code = 200, Message = "Stores retrieved successfully", Data = stores };
            }
            catch (Exception ex)
            {
                return new Response { Code = 500, Message = "An error occurred while retrieving stores", ErrorMessage = ex.Message };
            }
        }

        public Response Get(int id)
        {
            try
            {
                var store = _context.Set<Store>().Find(id);
                if (store != null)
                {
                    return new Response { Code = 200, Message = "Store retrieved successfully", Data = store };
                }
                else
                {
                    return new Response { Code = 404, Message = "Store not found" };
                }
            }
            catch (Exception ex)
            {
                return new Response { Code = 500, Message = "An error occurred while retrieving the store", ErrorMessage = ex.Message };
            }
        }

        public Response CreateStore(Store store)
        {
            try
            {
                _context.Set<Store>().Add(store);
                _context.SaveChanges();
                return new Response { Code = 201, Message = "Store created successfully", Data = store.ID };
            }
            catch (Exception ex)
            {
                return new Response { Code = 500, Message = "An error occurred while creating the store", ErrorMessage = ex.Message };
            }
        }

        public Response UpdateStore(int id, Store storeData)
        {
            try
            {
                var existingStore = _context.Set<Store>().Find(id);

                if (existingStore != null)
                {
                    // Actualiza las propiedades de la tienda existente con los datos proporcionados
                    existingStore.Branch = storeData.Branch;
                    existingStore.Address = storeData.Address;

                    _context.SaveChanges();

                    return new Response { Code = 200, Message = "Store updated successfully" };
                }
                else
                {
                    return new Response { Code = 404, Message = "Store not found" };
                }
            }
            catch (Exception ex)
            {
                return new Response { Code = 500, Message = "An error occurred while updating the store", ErrorMessage = ex.Message };
            }
        }

        public Response DeleteStore(int id)
        {
            try
            {
                var store = _context.Set<Store>().Find(id);
                if (store != null)
                {
                    _context.Set<Store>().Remove(store);
                    _context.SaveChanges();
                    return new Response { Code = 200, Message = "Store deleted successfully" };
                }
                else
                {
                    return new Response { Code = 404, Message = "Store not found" };
                }
            }
            catch (Exception ex)
            {
                return new Response { Code = 500, Message = "An error occurred while deleting the store", ErrorMessage = ex.Message };
            }
        }
    }
}
