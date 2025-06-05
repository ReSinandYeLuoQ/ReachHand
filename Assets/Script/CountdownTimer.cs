using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public Text countdownText;  // ����UI�ı����
    public float countdownTime = 10f;  // ����ʱ��ʱ�䣨�룩
    private float currentTime;
    private bool isCountingDown = false;

    void Start()
    {
        if (countdownText == null)
        {
            Debug.LogError("δ���䵹��ʱ�ı������");
            return;
        }

        currentTime = countdownTime;
        UpdateCountdownText();
        StartCountdown();
    }

    void Update()
    {
        if (isCountingDown && currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            UpdateCountdownText();

            if (currentTime <= 0)
            {
                currentTime = 0;
                isCountingDown = false;
                OnCountdownEnd();
            }
        }
    }

    void UpdateCountdownText()
    {
        // ��ʾ��������ʱ
        countdownText.text = Mathf.CeilToInt(currentTime).ToString();
    }

    public void StartCountdown()
    {
        isCountingDown = true;
    }

    public void StopCountdown()
    {
        isCountingDown = false;
    }

    void OnCountdownEnd()
    {
        // ����ʱ����ʱִ�е��߼�
        Debug.Log("����ʱ������");
        // ���������������������س����������¼��ȣ�
    }
}