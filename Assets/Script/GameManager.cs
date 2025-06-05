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

    public static bool clanow;//����
    public static bool shinow;//ʳ��
    public static bool pinnow;//����


    public static int day;
    public static int[] studentnum ={2,2,3,4,5};
    public int A;

    [Tooltip("���뵭��ʱ�䣨�룩")]
    public float fadeDuration = 1.0f;

    [Tooltip("�Ƿ��ڿ�ʼʱ���غ���")]
    public bool startHidden = true;

    private bool isFading = false;
    public Image black;


    void Start()
    {
        // ��ʼ������״̬
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
            Debug.LogError("����ͼ��δ���䣡����BlackScreenManager���");
        }
    }

    public void FadeIn(System.Action onComplete = null)
    {
        if (!isFading && black != null)
        {
            StartCoroutine(FadeTo(1f, onComplete));
        }
    }

    // ������������Ļ�ָ���
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

        // ȷ�����մﵽĿ��ֵ
        SetAlpha(targetAlpha);
        isFading = false;

        // ������ɻص�
        onComplete?.Invoke();
    }

    // ֱ�����ú�����͸���ȣ�0-1��
    public void SetAlpha(float alpha)
    {
        if (black != null)
        {
            Color color = black.color;
            color.a = Mathf.Clamp01(alpha);
            black.color = color;
        }
    }

    // �����л����������޹��ɣ�
    public void SetBlack()
    {
        SetAlpha(1f);
    }

    // �����л���͸�����޹��ɣ�
    public void SetClear()
    {
        SetAlpha(0f);
    }
}