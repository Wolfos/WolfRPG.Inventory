using UnityEngine;
using WolfRPG.Core;

namespace WolfRPG.Inventory
{
	public class ItemReference
	{
		[DBReference(1)] public RPGObjectReference ItemObject { get; set; }
		public int Quantity { get; set; } = 1;
		public bool Equipped { get; set; }
	}
	
	public class LoadoutComponent: IRPGComponent
	{
		public ItemReference[] StartingInventory { get; set; }
	}
}