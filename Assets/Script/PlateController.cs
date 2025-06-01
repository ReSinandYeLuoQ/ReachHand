using UnityEngine;

public class PlateController : MonoBehaviour
{
    public static PlateController Instance;

    // �洢�ĸ����������
    public int[] slotData = new int[4];

    // ��ǰѡ�еĲ�
    public DishController selectedDish;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
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
        if (slotIndex >= 0 && slotIndex < 4)
        {
            slotData[slotIndex] = dishData;
            Debug.Log($"Slot {slotIndex + 1} �����˲�Ʒ: {dishData}");

            // ȡ����Ʒ��ѡ��״̬
            if (selectedDish != null)
            {
                selectedDish.DisableGlow();
                selectedDish = null;
            }
        }
    }
}