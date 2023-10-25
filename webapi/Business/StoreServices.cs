using webapi.Data;
using webapi.Core;

namespace webapi.Business
{
    public class StoreServices
    {
        private readonly StoreRepository _storeRepository;

        public StoreServices(StoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public IEnumerable<Store> GetStores()
        {
            return _storeRepository.GetStores().Data as IEnumerable<Store>;
        }

        public Store GetStore(int id)
        {
            return _storeRepository.Get(id).Data as Store;
        }

        public Response CreateStore(Store store)
        {
            return _storeRepository.CreateStore(store);
        }

        public Response UpdateStore(Store store, int id)
        {
            return _storeRepository.UpdateStore(id, store);
        }

        public Response DeleteStore(int id)
        {
            return _storeRepository.DeleteStore(id);
        }
    }
}
