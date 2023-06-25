using WolfRPG.Core;

namespace WolfRPG.Inventory
{
	public class ShopComponent: IRPGComponent
	{
		public string[] StartingInventory { get; set; }
		public int BarteringMoney { get; set; }
	}
}