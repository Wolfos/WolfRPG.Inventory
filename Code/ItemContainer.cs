using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using WolfRPG.Core;

namespace WolfRPG.Inventory
{
	public class ItemContainer
	{
		private IRPGDatabase _rpgDatabase;
		private List<InventorySlot> _inventorySlots = new();

		public ItemContainer()
		{
			_rpgDatabase = RPGDatabase.DefaultDatabase;
		}
		
		public ItemContainer(IRPGDatabase database)
		{
			_rpgDatabase = database;
		}

		/// <summary>
		/// Add an item to the first available slot in this inventory, or increase quantity if we already have it
		/// </summary>
		/// <param name="itemObject">The item</param>
		public void AddItem(IRPGObject itemObject)
		{
			var slot = _inventorySlots.FirstOrDefault(s => s.Guid == itemObject.Guid);
			if (slot != null) // Already have this item
			{
				slot.Quantity++;
			}
			else
			{
				if (itemObject.HasComponent(typeof(ItemData)) == false)
				{
					Debug.LogError("Object is not a valid item");
					return;
				}

				var itemData = itemObject.GetComponent<ItemData>();
				itemData.RpgObject = itemObject;
				
				_inventorySlots.Add(
					new InventorySlot
				{
					ItemData = itemData,
					Quantity = 1
				});
			}
		}
		
		/// <summary>
		/// Add an item to the first available slot in this inventory, or increase quantity if we already have it
		/// </summary>
		/// <param name="guid">The item's WolfRPG GUID</param>
		public void AddItem(string guid)
		{
			var rpgItem = _rpgDatabase.GetObjectInstance(guid);

			if (rpgItem == null)
			{
				Debug.LogError("Object was not found in database");
				return;
			}
			
			AddItem(rpgItem);
		}

		/// <summary>
		/// Returns an item from the specific inventory slot
		/// </summary>
		/// <param name="slot"></param>
		/// <returns>The item's ItemData component</returns>
		public ItemData GetItemBySlot(int slot)
		{
			return _inventorySlots[slot].ItemData;
		}

		/// <summary>
		/// Returns an item's quantity from a specific inventory slot
		/// </summary>
		/// <param name="slot"></param>
		/// <returns>The quantity of items in the slot</returns>
		public int GetQuantityFromSlot(int slot)
		{
			return _inventorySlots[slot].Quantity;
		}
	}
}