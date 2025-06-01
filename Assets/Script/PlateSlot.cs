using UnityEngine;

public class PlateSlot : MonoBehaviour
{
    // ������ (0-3)
    public int slotIndex;

    void OnMouseDown()
    {
        if (PlateController.Instance.selectedDish != null)
        {
            // ����Ʒ���ݴ��ݸ�����
            PlateController.Instance.PlaceDishOnSlot(
                slotIndex,
                PlateController.Instance.selectedDish.asdf
            );
        }
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // ����Ƿ�������Ч����,ȡ����Ʒ�ķ���
            RaycastHit2D hit = Physics2D.Raycast(
                Camera.main.ScreenToWorldPoint(Input.mousePosition),
                Vector2.zero
            );

            if (hit.collider == null)
            {
                if (PlateController.Instance.selectedDish != null)
                {
                    PlateController.Instance.selectedDish.DisableGlow();
                    PlateController.Instance.selectedDish = null;
                }
            }
        }
    }
}