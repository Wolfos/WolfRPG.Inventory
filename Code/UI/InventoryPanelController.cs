using UnityEngine;
using UnityEngine.UIElements;

namespace WolfRPG.Inventory
{
    // No this doesn't follow the MVC pattern, it's called Controller because the uxml is already called InventoryPanel ;)
    [RequireComponent(typeof(UIDocument))]
    public class InventoryPanelController : MonoBehaviour
    {
        [SerializeField] private VisualTreeAsset itemLayout;
        
        private UIDocument _uiDocument;
        private ScrollView _itemList;

        private void Awake()
        {
            _uiDocument = GetComponent<UIDocument>();

            var root = _uiDocument.rootVisualElement;
            _itemList = root.Query<ScrollView>("ItemList").First();
        }

        public void Show(ItemContainer itemContainer)
        {
            gameObject.SetActive(true);

            for (int i = 0; i < itemContainer.Count; i++)
            {
                var item = itemContainer.GetItemBySlot(i);
                var itemView = new ItemView(itemLayout, item, itemContainer.GetQuantityFromSlot(i));
                
                _itemList.Add(itemView);
            }
        }
    }
}