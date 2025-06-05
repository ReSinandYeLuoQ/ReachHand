using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static int[] slotData1 = new int[4];
    public static int[] slotData2 = new int[4];
    public static int[] slotData3 = new int[4];
    public static int[] slotData4 = new int[4];
    public static int platenum = 1;

    public static bool clanow;//教室
    public static bool shinow;//食堂
    public static bool pinnow;//评价


    public static int day;
    public static int[] studentnum ={2,2,3,4,5};
    public int A;

    [Tooltip("淡入淡出时间（秒）")]
    public float fadeDuration = 1.0f;

    [Tooltip("是否在开始时隐藏黑屏")]
    public bool startHidden = true;

    private bool isFading = false;
    public Image black;


    void Start()
    {
        // 初始化黑屏状态
        if (black != null)
        {
            if (startHidden)
            {
                SetAlpha(0f);
            }
            else
            {
                SetAlpha(1f);
            }
        }
        else
        {
            Debug.LogError("黑屏图像未分配！请检查BlackScreenManager组件");
        }
    }

    public void FadeIn(System.Action onComplete = null)
    {
        if (!isFading && black != null)
        {
            StartCoroutine(FadeTo(1f, onComplete));
        }
    }

    // 淡出黑屏（屏幕恢复）
    public void FadeOut(System.Action onComplete = null)
    {
        if (!isFading && black != null)
        {
            StartCoroutine(FadeTo(0f, onComplete));
        }
    }
    private IEnumerator FadeTo(float targetAlpha, System.Action onComplete)
    {
        isFading = true;
        float startAlpha = black.color.a;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / fadeDuration);
            SetAlpha(newAlpha);
            yield return null;
        }

        // 确保最终达到目标值
        SetAlpha(targetAlpha);
        isFading = false;

        // 调用完成回调
        onComplete?.Invoke();
    }

    // 直接设置黑屏的透明度（0-1）
    public void SetAlpha(float alpha)
    {
        if (black != null)
        {
            Color color = black.color;
            color.a = Mathf.Clamp01(alpha);
            black.color = color;
        }
    }

    // 快速切换到黑屏（无过渡）
    public void SetBlack()
    {
        SetAlpha(1f);
    }

    // 快速切换到透明（无过渡）
    public void SetClear()
    {
        SetAlpha(0f);
    }
}