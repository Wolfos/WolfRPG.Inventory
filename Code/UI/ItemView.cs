using UnityEngine.UIElements;

namespace WolfRPG.Inventory
{
	public class ItemView: VisualElement
	{
		public ItemView(VisualTreeAsset layout, ItemData item, int quantity)
		{
			Add(layout.Instantiate());
			SetItem(item, quantity);
		}
		
		public void SetItem(ItemData item, int quantity)
		{
			if (quantity > 1)
			{
				this.Query<Label>("Name").First().text = $"<b>{quantity}</b> {item.Name.Get()}";
			}
			else
			{
				this.Query<Label>("Name").First().text = item.Name.Get();
			}

			this.Query<Label>("Type").First(); // TODO: Types
			this.Query<Label>("Weight").First(); // TODO: Weight
			this.Query<Label>("Value").First().text = item.BaseValue.ToString();
		}
	}
}