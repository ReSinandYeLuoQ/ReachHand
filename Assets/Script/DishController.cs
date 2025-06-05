using UnityEngine;

public class DishController : MonoBehaviour
{
    // 菜的唯一标识（将被传递给餐盘）
    public int dishkindnow = 0;

    [Header("视觉效果")]
    public float hoverScale = 1.2f;
    public Color glowColor = Color.yellow;
    public float glowIntensity = 2f;
    // 8个不同的菜贴图
    public Sprite[] dishSprites;

    private Vector3 originalScale;
    private bool isGlowing = false;
    private SpriteRenderer visualRenderer;
    ButtonPanelController buttonPanelController;
    public GameObject book;

    [Range(0, 7)] public int dishkind = 0;    // 控制当前菜的贴图选择 (0-7)

    void Start()
    {
        buttonPanelController = book.GetComponent<ButtonPanelController>();
        // 初始化组件
        visualRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        originalScale = transform.localScale;

        // 根据GameManager设置贴图
        UpdateDishSprite();
    }

    private void Update()
    {
        if(dishkind== dishkindnow)
        {
            transform.localScale = originalScale * hoverScale;
        }
        else
        {
            transform.localScale = originalScale;
        }
    }

    // 根据GameManager的qwer变量更新贴图
    public void UpdateDishSprite()
    {
        int index = Mathf.Clamp(dishkind, 0, 7);
        visualRenderer.sprite = dishSprites[index];
    }

    void OnMouseDown()
    {
        // 切换发光状态
        isGlowing = !isGlowing;

        // 更新发光效果
        if (isGlowing && buttonPanelController.isBookOpen == false)
        {
            visualRenderer.material.SetColor("_EmissionColor", glowColor * glowIntensity);
            PlateController.Instance.SelectDish(this);
        }
        else
        {
            visualRenderer.material.SetColor("_EmissionColor", Color.black);
        }
    }

    // 外部调用取消发光
    public void DisableGlow()
    {
        isGlowing = false;
        visualRenderer.material.SetColor("_EmissionColor", Color.black);
    }
}