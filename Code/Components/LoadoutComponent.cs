using UnityEngine;
using WolfRPG.Core;

namespace WolfRPG.Inventory
{
	public class LoadoutComponent: IRPGComponent
	{
		[HideInInspector] public ItemContainer ItemContainer { get; set; }
		public string[] StartingInventory { get; set; }
	}
}