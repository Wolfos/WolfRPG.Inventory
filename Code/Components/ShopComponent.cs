using WolfRPG.Core;

namespace WolfRPG.Inventory
{
	public class ShopItem
	{
		[DBReference(1)] // category 1 = items
		public RPGObjectReference Item { get; set; }

		public int Quantity { get; set; } = 1;
	}
	
	public class ShopComponent: IRPGComponent
	{
		public ShopItem[] ShopInventory { get; set; }
		public int BarteringMoney { get; set; }
		[DBReference(3)] // category 3 = shops
		public RPGObjectReference PriceList { get; set; }
	}
	
	public class ItemPrice
	{
		[DBReference(1)] // category 1 = items
		public RPGObjectReference Item { get; set; }

		public int Price { get; set; } = 1;
	}

	public class PriceList : IRPGComponent
	{
		public ItemPrice[] ItemPrices { get; set; }

		public int GetPrice(string itemGuid)
		{
			foreach (var item in ItemPrices)
			{
				if (item.Item.Guid == itemGuid)
				{
					return item.Price;
				}
			}

			return -1; // Let caller decide default price, so we don't have to retrieve the whole item here
		}
	}
}