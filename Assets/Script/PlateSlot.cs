using UnityEngine;

public class PlateSlot : MonoBehaviour
{
    // 区域编号 (0-3)
    public int slotIndex;

    void OnMouseDown()
    {
        if (PlateController.Instance.selectedDish != null)
        {
            // 将菜品数据传递给餐盘
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
            // 检测是否点击到有效物体,取消菜品的发光
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