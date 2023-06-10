using UnityEngine;
using WolfRPG.Core;

namespace WolfRPG.Inventory
{
	public class LoadoutComponent: IRPGComponent
	{
		public string[] StartingInventory { get; set; }
	}
}