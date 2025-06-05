using UnityEngine;
using UnityEngine.UI;

public class ButtonPanelController : MonoBehaviour
{
    public RectTransform book;
    public RectTransform largeImage;
    public static GameObject Instance ;

    // �����ٶ�
    public float animationSpeed = 5f;

    // ��ǰ״̬
    public bool isBookOpen = false;

    // Ŀ��λ��
    private Vector2 bookInitialPos;
    private Vector2 bookHiddenPos;
    private Vector2 imageInitialPos;
    private Vector2 imageVisiblePos;

    // ����״̬
    private bool isAnimating = false;

    void Start()
    {
        // ��¼��ʼλ��
        bookInitialPos = book.anchoredPosition;
        imageInitialPos = largeImage.anchoredPosition;

        // ��������λ�ã���������/�����ƶ�һ����Ļ�߶ȣ�
        float screenHeight = Screen.height;
        bookHiddenPos = bookInitialPos - new Vector2(0, screenHeight * 1.5f);
        imageVisiblePos = imageInitialPos + new Vector2(0, screenHeight * 1.5f);

        // ȷ����ʼ״̬��ȷ
        book.anchoredPosition = bookInitialPos;
        largeImage.anchoredPosition = imageInitialPos;
    }

    void Update()
    {
        // ������
        if (isAnimating)
        {
            if (isBookOpen)
            {
                // �鱾�½���ͼƬ����
                book.anchoredPosition = Vector2.Lerp(book.anchoredPosition, bookHiddenPos, animationSpeed * Time.deltaTime);
                largeImage.anchoredPosition = Vector2.Lerp(largeImage.anchoredPosition, imageVisiblePos, animationSpeed * Time.deltaTime);

                // ��鶯���Ƿ����
                if (Vector2.Distance(book.anchoredPosition, bookHiddenPos) < 0.1f &&
                    Vector2.Distance(largeImage.anchoredPosition, imageVisiblePos) < 0.1f)
                {
                    isAnimating = false;
                }
            }
            else
            {
                // �鱾������ͼƬ�½�
                book.anchoredPosition = Vector2.Lerp(book.anchoredPosition, bookInitialPos, animationSpeed * Time.deltaTime);
                largeImage.anchoredPosition = Vector2.Lerp(largeImage.anchoredPosition, imageInitialPos, animationSpeed * Time.deltaTime);

                // ��鶯���Ƿ����
                if (Vector2.Distance(book.anchoredPosition, bookInitialPos) < 0.1f &&
                    Vector2.Distance(largeImage.anchoredPosition, imageInitialPos) < 0.1f)
                {
                    isAnimating = false;
                }
            }
        }
    }

    // С���ӵ���¼�����
    public void OnBookClicked()
    {
        if (isAnimating) return;

        isBookOpen = true;
        isAnimating = true;
    }

    // �����ͼ����
    void LateUpdate()
    {
        if (isBookOpen && !isAnimating && Input.GetMouseButtonDown(0))
        {
            // ����Ƿ����˴�����ͼ
                isBookOpen = false;
                isAnimating = true;
        }
    }

    // �������Ƿ�����UI����

}