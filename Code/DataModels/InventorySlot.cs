namespace WolfRPG.Inventory
{
	public class InventorySlot
	{
		public string Guid => ItemData.RpgObject.Guid;
		public ItemData ItemData { get; set; }
		public int Quantity { get; set; }
		public int SlotIndex { get; set; }
	}
}