using WolfRPG.Character;
using WolfRPG.Core;

namespace WolfRPG.Inventory
{
	public class EquipmentPart
	{
		public CharacterCustomizationPart Part { get; set; }
		public int Index { get; set; }
	}
	
	public class EquipmentData: IRPGComponent
	{
		public EquipmentSlot EquipmentSlot { get; set; }
		
		// All visual equipment pieces are defined in the character prefab, this defines which pieces get activated by this equipment item
		// Most clothing items are composed of multiple parts. For example, a pair of pants would affect hips, left leg, and right leg
		public EquipmentPart[] EquipmentParts { get; set; } 
	}
}