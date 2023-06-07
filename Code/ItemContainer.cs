using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using WolfRPG.Core;

namespace WolfRPG.Inventory
{
	public class ItemContainer
	{
		/// <summary>
		/// The amount of item slots
		/// </summary>
		public int Count => _inventorySlots.Count;
		
		private IRPGDatabase _rpgDatabase;
		private List<InventorySlot> _inventorySlots = new();
		
		
		public int Money { get; set; }
		
		public Action<ItemData, int> OnItemAdded { get; set; }
		public Action<ItemData, int> OnItemRemoved { get; set; } // TODO: Implement
		
		public Action<ItemData, int> OnItemUsed { get; set; }

		public ItemContainer()
		{
			_rpgDatabase = RPGDatabase.DefaultDatabase;
		}
		
		public ItemContainer(IRPGDatabase database)
		{
			_rpgDatabase = database;
		}

		public void UseItem(ItemData item)
		{
			var slot = _inventorySlots.FirstOrDefault(s => s.Guid == item.RpgObject?.Guid);
			if (slot == null)
			{
				Debug.LogError("Used item was not present in this inventory");
				return;
			}
			
			OnItemUsed?.Invoke(slot.ItemData, slot.SlotIndex);
		}

		/// <summary>
		/// Add an item to the first available slot in this inventory, or increase quantity if we already have it
		/// </summary>
		/// <param name="itemObject">The item</param>
		/// <param name="quantity">Quantity of item to add</param>
		public void AddItem(IRPGObject itemObject, int quantity = 1)
		{
			var slot = _inventorySlots.FirstOrDefault(s => s.Guid == itemObject.Guid);
			if (slot != null) // Already have this item
			{
				slot.Quantity += quantity;
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

				slot = new()
				{
					ItemData = itemData,
					Quantity = quantity
				};
				_inventorySlots.Add(slot);
			}

			var slotIndex = _inventorySlots.IndexOf(slot);
			OnItemAdded?.Invoke(slot.ItemData, slotIndex);
		}

		public void RemoveItem(IRPGObject itemObject, int quantity = 1)
		{
			var slot = _inventorySlots.FirstOrDefault(s => s.Guid == itemObject.Guid);
			if (slot == null)
			{
				return;
			}

			slot.Quantity -= quantity;
			if (slot.Quantity <= 0)
			{
				_inventorySlots.Remove(slot);
			}
			
			var slotIndex = _inventorySlots.IndexOf(slot);
			OnItemRemoved?.Invoke(slot.ItemData, slotIndex);
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