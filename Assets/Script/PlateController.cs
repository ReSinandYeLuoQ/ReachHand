using UnityEngine;

public class PlateController : MonoBehaviour
{
    public static PlateController Instance;

    // 存储四个区域的数据


    // 当前选中的菜
    public DishController selectedDish;

    ButtonPanelController buttonPanelController;
    public GameObject book;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        buttonPanelController = book.GetComponent<ButtonPanelController>();
    }

    public void SelectDish(DishController dish)
    {
        // 取消之前选中的菜
        if (selectedDish != null && selectedDish != dish)
        {
            selectedDish.DisableGlow();
        }

        selectedDish = dish;
    }

    // 当餐盘区域被点击时调用
    public void PlaceDishOnSlot(int slotIndex, int dishData)
    {
        if (slotIndex >= 0 && slotIndex < 4 && buttonPanelController.isBookOpen == false)
        {
            switch (GameManager.platenum)
            {
                case (1):
                    GameManager.slotData1[slotIndex] = dishData;
                    Debug.Log($"Slot {slotIndex + 1} 放置了菜品: {dishData}");
                    break;
                case (2):
                    GameManager.slotData2[slotIndex] = dishData;
                    Debug.Log($"Slot {slotIndex + 1} 放置了菜品: {dishData}");
                    break;
                case (3):
                    GameManager.slotData3[slotIndex] = dishData;
                    Debug.Log($"Slot {slotIndex + 1} 放置了菜品: {dishData}");
                    break;
                case (4):
                    GameManager.slotData4[slotIndex] = dishData;
                    Debug.Log($"Slot {slotIndex + 1} 放置了菜品: {dishData}");
                    break;
            }
            

            // 取消菜品的选中状态
            if (selectedDish != null)
            {
                selectedDish.DisableGlow();
                selectedDish = null;
            }
        }
    }
}