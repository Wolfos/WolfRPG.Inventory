using WolfRPG.Core;
using WolfRPG.Core.Statistics;

namespace WolfRPG.Inventory
{
	public class ConsumableData: IRPGComponent
	{
		[DBReference(4)] // category 4 = status effects
		public RPGObjectReference StatusEffect { get; set; }
	}
}