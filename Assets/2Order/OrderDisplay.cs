using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderDisplay : MonoBehaviour
{
    public Text displayText; // 用于显示随机数的UI文本

    void Start()
    {
        if (displayText == null)
        {
            Debug.LogError("displayText未赋值");
            return;
        }

        // 检查数据是否可用
        if (GameDataManager.Instance == null || GameDataManager.Instance.OrderData == null)
        {
            displayText.text = "未找到订单";
            Debug.LogError("No order data available!");
            return;
        }

        // 显示所有随机数集合
        DisplayAllRandomNumbers();
    }

    void DisplayAllRandomNumbers()
    {
        OrderData orderData = GameDataManager.Instance.OrderData;
        string displayTextContent = "\n";

        for (int i = 0; i < orderData.GetSetCount(); i++)
        {
            List<int> numbers = orderData.GetRandomNumbers(i);
            if (numbers != null)
            {
                displayTextContent += $"组 {i + 1}: {string.Join("、", numbers)}\n";
            }
        }

        this.displayText.text = displayTextContent;
    }
}
