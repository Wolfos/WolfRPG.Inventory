using UnityEngine.UIElements;
using WolfRPG.Core.Localization;

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

			var localizationKey = $"ItemCategory{(int) item.Type}";
			this.Query<Label>("Type").First().text = LocalizationFile.Get(localizationKey);
			this.Query<Label>("Weight").First().text = item.Weight.ToString("F1"); // F1 = 123.4
			this.Query<Label>("Value").First().text = item.BaseValue.ToString();
		}
	}
}