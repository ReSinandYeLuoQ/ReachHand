using UnityEngine;

public class PlateController : MonoBehaviour
{
    public static PlateController Instance;

    // �洢�ĸ����������


    // ��ǰѡ�еĲ�
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
        // ȡ��֮ǰѡ�еĲ�
        if (selectedDish != null && selectedDish != dish)
        {
            selectedDish.DisableGlow();
        }

        selectedDish = dish;
    }

    // ���������򱻵��ʱ����
    public void PlaceDishOnSlot(int slotIndex, int dishData)
    {
        if (slotIndex >= 0 && slotIndex < 4 && buttonPanelController.isBookOpen == false)
        {
            switch (GameManager.platenum)
            {
                case (1):
                    GameManager.slotData1[slotIndex] = dishData;
                    Debug.Log($"Slot {slotIndex + 1} �����˲�Ʒ: {dishData}");
                    break;
                case (2):
                    GameManager.slotData2[slotIndex] = dishData;
                    Debug.Log($"Slot {slotIndex + 1} �����˲�Ʒ: {dishData}");
                    break;
                case (3):
                    GameManager.slotData3[slotIndex] = dishData;
                    Debug.Log($"Slot {slotIndex + 1} �����˲�Ʒ: {dishData}");
                    break;
                case (4):
                    GameManager.slotData4[slotIndex] = dishData;
                    Debug.Log($"Slot {slotIndex + 1} �����˲�Ʒ: {dishData}");
                    break;
            }
            

            // ȡ����Ʒ��ѡ��״̬
            if (selectedDish != null)
            {
                selectedDish.DisableGlow();
                selectedDish = null;
            }
        }
    }
}