using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderDisplay : MonoBehaviour
{
    public Text displayText; // ������ʾ�������UI�ı�

    void Start()
    {
        if (displayText == null)
        {
            Debug.LogError("displayTextδ��ֵ");
            return;
        }

        // ��������Ƿ����
        if (GameDataManager.Instance == null || GameDataManager.Instance.OrderData == null)
        {
            displayText.text = "δ�ҵ�����";
            Debug.LogError("No order data available!");
            return;
        }

        // ��ʾ�������������
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
                displayTextContent += $"�� {i + 1}: {string.Join("��", numbers)}\n";
            }
        }

        this.displayText.text = displayTextContent;
    }
}
