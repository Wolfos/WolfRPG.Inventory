using UnityEngine;
using WolfRPG.Core;

namespace WolfRPG.Inventory
{
	public class MeleeWeaponData: IRPGComponent
	{
		public float BaseDamage { get; set; }
		public float AttackDuration { get; set; }
		[AssetReference(typeof(AudioClip))]
		public AssetReference AttackSound { get; set; }
		[AssetReference(typeof(AudioClip))]
		public AssetReference HitSound { get; set; }
	}
}