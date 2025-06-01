using UnityEngine;

public class DishController : MonoBehaviour
{
    // �˵�Ψһ��ʶ���������ݸ����̣�
    public int asdf = 0;

    [Header("�Ӿ�Ч��")]
    public float hoverScale = 1.2f;
    public Color glowColor = Color.yellow;
    public float glowIntensity = 2f;
    // 8����ͬ�Ĳ���ͼ
    public Sprite[] dishSprites;

    private Vector3 originalScale;
    private bool isGlowing = false;
    private SpriteRenderer visualRenderer;

    [Range(0, 7)] public int qwer = 0;    // ���Ƶ�ǰ�˵���ͼѡ�� (0-7)

    void Start()
    {
        // ��ʼ�����
        visualRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        originalScale = transform.localScale;

        // ����GameManager������ͼ
        UpdateDishSprite();
    }

    // ����GameManager��qwer����������ͼ
    public void UpdateDishSprite()
    {
        int index = Mathf.Clamp(qwer, 0, 7);
        visualRenderer.sprite = dishSprites[index];
    }

    void OnMouseEnter()
    {
        // �����ͣʱ�Ŵ�
        transform.localScale = originalScale * hoverScale;
    }

    void OnMouseExit()
    {
        // ����뿪ʱ�ָ���С
        transform.localScale = originalScale;
    }

    void OnMouseDown()
    {
        // �л�����״̬
        isGlowing = !isGlowing;

        // ���·���Ч��
        if (isGlowing)
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