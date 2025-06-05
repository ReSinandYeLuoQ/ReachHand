using UnityEngine;

public class PlateSlot : MonoBehaviour
{
    public GameObject book;
    ButtonPanelController buttonPanelController;
    void Start()
    {
        buttonPanelController = book.GetComponent<ButtonPanelController>();
    }
    void OnMouseDown()
    {
        if (PlateController.Instance.selectedDish != null&& buttonPanelController.isBookOpen==false)
        {
            // ����Ʒ���ݴ��ݸ�����
            PlateController.Instance.PlaceDishOnSlot(
                GameManager.platenum,
                PlateController.Instance.selectedDish.dishkindnow
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