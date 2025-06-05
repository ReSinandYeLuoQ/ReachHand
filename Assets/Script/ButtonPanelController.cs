using UnityEngine;
using UnityEngine.UI;

public class ButtonPanelController : MonoBehaviour
{
    public RectTransform book;
    public RectTransform largeImage;
    public static GameObject Instance ;

    // 动画速度
    public float animationSpeed = 5f;

    // 当前状态
    public bool isBookOpen = false;

    // 目标位置
    private Vector2 bookInitialPos;
    private Vector2 bookHiddenPos;
    private Vector2 imageInitialPos;
    private Vector2 imageVisiblePos;

    // 动画状态
    private bool isAnimating = false;

    void Start()
    {
        // 记录初始位置
        bookInitialPos = book.anchoredPosition;
        imageInitialPos = largeImage.anchoredPosition;

        // 计算隐藏位置（假设向下/向上移动一个屏幕高度）
        float screenHeight = Screen.height;
        bookHiddenPos = bookInitialPos - new Vector2(0, screenHeight * 1.5f);
        imageVisiblePos = imageInitialPos + new Vector2(0, screenHeight * 1.5f);

        // 确保初始状态正确
        book.anchoredPosition = bookInitialPos;
        largeImage.anchoredPosition = imageInitialPos;
    }

    void Update()
    {
        // 处理动画
        if (isAnimating)
        {
            if (isBookOpen)
            {
                // 书本下降，图片上升
                book.anchoredPosition = Vector2.Lerp(book.anchoredPosition, bookHiddenPos, animationSpeed * Time.deltaTime);
                largeImage.anchoredPosition = Vector2.Lerp(largeImage.anchoredPosition, imageVisiblePos, animationSpeed * Time.deltaTime);

                // 检查动画是否完成
                if (Vector2.Distance(book.anchoredPosition, bookHiddenPos) < 0.1f &&
                    Vector2.Distance(largeImage.anchoredPosition, imageVisiblePos) < 0.1f)
                {
                    isAnimating = false;
                }
            }
            else
            {
                // 书本上升，图片下降
                book.anchoredPosition = Vector2.Lerp(book.anchoredPosition, bookInitialPos, animationSpeed * Time.deltaTime);
                largeImage.anchoredPosition = Vector2.Lerp(largeImage.anchoredPosition, imageInitialPos, animationSpeed * Time.deltaTime);

                // 检查动画是否完成
                if (Vector2.Distance(book.anchoredPosition, bookInitialPos) < 0.1f &&
                    Vector2.Distance(largeImage.anchoredPosition, imageInitialPos) < 0.1f)
                {
                    isAnimating = false;
                }
            }
        }
    }

    // 小册子点击事件处理
    public void OnBookClicked()
    {
        if (isAnimating) return;

        isBookOpen = true;
        isAnimating = true;
    }

    // 检测贴图外点击
    void LateUpdate()
    {
        if (isBookOpen && !isAnimating && Input.GetMouseButtonDown(0))
        {
            // 检查是否点击了大型贴图
                isBookOpen = false;
                isAnimating = true;
        }
    }

    // 检查鼠标是否点击了UI对象

}