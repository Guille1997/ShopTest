using System.Collections.Generic;
using webapi.Core;
using webapi.Data;  // Asegúrate de agregar el espacio de nombres adecuado para tu repositorio

namespace webapi.Business
{
    public class ItemServices
    {
        private readonly ItemRepository _itemRepository;

        public ItemServices(ItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public IEnumerable<Item> GetItems()
        {
            return _itemRepository.GetItems().Data as IEnumerable<Item>;
        }

        public Item GetItem(int id)
        {
            return _itemRepository.Get(id).Data as Item;
        }

        public Response CreateItem(Item item)
        {
            return _itemRepository.CreateItem(item);
        }

        public Response UpdateItem(Item item, int id)
        {
            return _itemRepository.UpdateItem(id, item);
        }

        public Response DeleteItem(int id)
        {
            return _itemRepository.DeleteItem(id);
        }
    }
}
