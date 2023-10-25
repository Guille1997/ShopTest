using Microsoft.EntityFrameworkCore;
using webapi.Core;

namespace webapi.Data
{
    public class ClientRepository
    {
        private readonly SqlServerContext _context;

        public ClientRepository(SqlServerContext context)
        {
            _context = context;
        }

        public Response GetClients()
        {
            try
            {
                var clients = _context.Client.ToList();
                return new Response { Code = 200, Message = "Clients retrieved successfully", Data = clients };
            }
            catch (Exception ex)
            {
                return new Response { Code = 500, Message = "An error occurred while retrieving clients", ErrorMessage = ex.Message };
            }
        }

        public Response Get(int id)
        {
            try
            {
                var client = _context.Client.FirstOrDefault(c => c.ID == id);
                if (client != null)
                {
                    return new Response { Code = 200, Message = "Client retrieved successfully", Data = client };
                }
                else
                {
                    return new Response { Code = 404, Message = "Client not found" };
                }
            }
            catch (Exception ex)
            {
                return new Response { Code = 500, Message = "An error occurred while retrieving the client", ErrorMessage = ex.Message };
            }
        }

        public Response CreateClient(Client client)
        {
            try
            {
                _context.Client.Add(client);
                _context.SaveChanges();
                return new Response { Code = 201, Message = "Client created successfully", Data = client.ID };
            }
            catch (Exception ex)
            {
                return new Response { Code = 500, Message = "An error occurred while creating the client", ErrorMessage = ex.Message };
            }
        }

        public Response UpdateClient(int id, Client clientData)
        {
            try
            {
                var existingClient = _context.Client.FirstOrDefault(c => c.ID == id);

                if (existingClient != null)
                {
                    // Actualiza las propiedades del cliente existente con los datos proporcionados
                    existingClient.Name = clientData.Name;
                    existingClient.LastName = clientData.LastName;
                    existingClient.Address = clientData.Address;

                    _context.SaveChanges();

                    return new Response { Code = 200, Message = "Client updated successfully" };
                }
                else
                {
                    return new Response { Code = 404, Message = "Client not found" };
                }
            }
            catch (Exception ex)
            {
                return new Response { Code = 500, Message = "An error occurred while updating the client", ErrorMessage = ex.Message };
            }
        }


        public Response DeleteClient(int id)
        {
            try
            {
                var client = _context.Client.FirstOrDefault(c => c.ID == id);
                if (client != null)
                {
                    _context.Client.Remove(client);
                    _context.SaveChanges();
                    return new Response { Code = 200, Message = "Client deleted successfully" };
                }
                else
                {
                    return new Response { Code = 404, Message = "Client not found" };
                }
            }
            catch (Exception ex)
            {
                return new Response { Code = 500, Message = "An error occurred while deleting the client", ErrorMessage = ex.Message };
            }
        }
    }
}
