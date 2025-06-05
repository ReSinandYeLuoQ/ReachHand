using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public Text countdownText;  // 引用UI文本组件
    public float countdownTime = 10f;  // 倒计时总时间（秒）
    private float currentTime;
    private bool isCountingDown = false;

    void Start()
    {
        if (countdownText == null)
        {
            Debug.LogError("未分配倒计时文本组件！");
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
        // 显示整数倒计时
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
        // 倒计时结束时执行的逻辑
        Debug.Log("倒计时结束！");
        // 可以添加其他操作（如加载场景、触发事件等）
    }
}