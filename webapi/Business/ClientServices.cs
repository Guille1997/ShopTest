using webapi.Data;
using webapi.Core;

namespace webapi.Business
{
    public class ClientServices
    {
        private readonly ClientRepository _clientRepository;

        public ClientServices(ClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public IEnumerable<Client> GetClients()
        {
            return _clientRepository.GetClients().Data as IEnumerable<Client>;
        }

        public Client GetClient(int id)
        {
            return _clientRepository.Get(id).Data as Client;
        }

        public Response CreateClient(Client client)
        {
            return _clientRepository.CreateClient(client);
        }

        public Response UpdateClient(Client client, int id)
        {
            return _clientRepository.UpdateClient(id, client);
        }

        public Response DeleteClient(int id)
        {
            return _clientRepository.DeleteClient(id);
        }
    }
}
