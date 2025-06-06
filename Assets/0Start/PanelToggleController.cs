using UnityEngine;
using UnityEngine.UI;

public class PanelToggleController : MonoBehaviour
{
    [SerializeField] private GameObject panel; // ��Ҫ��ʾ/���ص�Panel
    private Button toggleButton; // �����İ�ť���
    private bool isPanelVisible = false; // ��¼Panel��ǰ״̬

    private void Start()
    {
        // ��ȡ��ť�������ӵ���¼�����
        toggleButton = GetComponent<Button>();
        if (toggleButton != null)
        {
            toggleButton.onClick.AddListener(TogglePanel);
        }
        else
        {
            Debug.LogError("δ�ҵ�Button�������ȷ���˽ű������ڰ�ť�����ϣ�");
        }

        // ��ʼ��Panel״̬
        if (panel != null)
        {
            panel.SetActive(isPanelVisible);
        }
        else
        {
            Debug.LogError("δָ��Panel��������Inspector������Panel��");
        }
    }

    // �����ťʱ���õķ���
    private void TogglePanel()
    {
        isPanelVisible = !isPanelVisible; // �л�״̬
        if (panel != null)
        {
            panel.SetActive(isPanelVisible); // ����Panel��ʾ״̬
        }
    }

    private void OnDestroy()
    {
        // ȷ���Ƴ��¼���������ֹ�ڴ�й©
        if (toggleButton != null)
        {
            toggleButton.onClick.RemoveListener(TogglePanel);
        }
    }
}