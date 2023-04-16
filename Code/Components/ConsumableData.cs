using WolfRPG.Core;
using WolfRPG.Core.Statistics;

namespace WolfRPG.Inventory
{
	public class ConsumableData: IRPGComponent
	{
		public AttributeStatusEffect[] AttributeStatusEffects { get; set; }
		public SkillStatusEffect[] SkillStatusEffects { get; set; }
	}
}