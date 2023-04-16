using Unity.Plastic.Newtonsoft.Json;
using WolfRPG.Core;
using WolfRPG.Core.Localization;

namespace WolfRPG.Inventory
{
	public class ItemData: IRPGComponent
	{
		[JsonIgnore]
		public IRPGObject RpgObject { get; set; }
		public LocalizedString Name { get; set; }
		public LocalizedString Description { get; set; }
		public ItemType Type { get; set; }
		public int BaseValue { get; set; }
		public bool CanEquip { get; set; }
		public bool CanUse { get; set; }
		public float Weight { get; set; }
	}
}