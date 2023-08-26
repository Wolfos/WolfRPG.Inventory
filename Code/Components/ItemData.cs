using Newtonsoft.Json;
using UnityEngine;
using WolfRPG.Core;
using WolfRPG.Core.Localization;

namespace WolfRPG.Inventory
{
	public class ItemData: IRPGComponent
	{
		[JsonIgnore]
		public IRPGObject RpgObject { get; set; }
		
		// Visual representation of the item in the game world
		[AssetReference(typeof(GameObject))]
		public AssetReference Prefab { get; set; }
			
		public LocalizedString Name { get; set; }
		public LocalizedString Description { get; set; }
		public ItemType Type { get; set; }
		public int BaseValue { get; set; }
		public bool CanUse { get; set; } // TODO: Is this value necessary? I feel like Type covers it
		public float Weight { get; set; }
	}
}