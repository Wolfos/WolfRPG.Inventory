using UnityEngine;
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
		
		// All visual equipment pieces (except weapons) are defined in the character prefab, this defines which pieces get activated by this equipment item
		// Most clothing items are composed of multiple parts. For example, a pair of pants would affect hips, left leg, and right leg
		public EquipmentPart[] EquipmentParts { get; set; }
		
		[DBReference(4)] // category 4 = status effects
		public RPGObjectReference StatusEffect { get; set; }

		// Use the prefab set in ItemData
		public bool UsePrefab { get; set; }
		
		public bool OverrideAnimations { get; set; }
		[AssetReference(typeof(AnimatorOverrideController))]
		public AssetReference AnimationSet { get; set; }
	}
}