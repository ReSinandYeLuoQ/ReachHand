using UnityEngine;

public class DishController : MonoBehaviour
{
    // �˵�Ψһ��ʶ���������ݸ����̣�
    public int dishkindnow = 0;

    [Header("�Ӿ�Ч��")]
    public float hoverScale = 1.2f;
    public Color glowColor = Color.yellow;
    public float glowIntensity = 2f;
    // 8����ͬ�Ĳ���ͼ
    public Sprite[] dishSprites;

    private Vector3 originalScale;
    private bool isGlowing = false;
    private SpriteRenderer visualRenderer;
    ButtonPanelController buttonPanelController;
    public GameObject book;

    [Range(0, 7)] public int dishkind = 0;    // ���Ƶ�ǰ�˵���ͼѡ�� (0-7)

    void Start()
    {
        buttonPanelController = book.GetComponent<ButtonPanelController>();
        // ��ʼ�����
        visualRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        originalScale = transform.localScale;

        // ����GameManager������ͼ
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

    // ����GameManager��qwer����������ͼ
    public void UpdateDishSprite()
    {
        int index = Mathf.Clamp(dishkind, 0, 7);
        visualRenderer.sprite = dishSprites[index];
    }

    void OnMouseDown()
    {
        // �л�����״̬
        isGlowing = !isGlowing;

        // ���·���Ч��
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

    // �ⲿ����ȡ������
    public void DisableGlow()
    {
        isGlowing = false;
        visualRenderer.material.SetColor("_EmissionColor", Color.black);
    }
}