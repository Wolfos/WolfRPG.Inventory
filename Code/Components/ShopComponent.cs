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
	}
}