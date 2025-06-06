using UnityEngine;
using UnityEngine.UI;

public class PanelToggleController : MonoBehaviour
{
    [SerializeField] private GameObject panel; // 需要显示/隐藏的Panel
    private Button toggleButton; // 关联的按钮组件
    private bool isPanelVisible = false; // 记录Panel当前状态

    private void Start()
    {
        // 获取按钮组件并添加点击事件监听
        toggleButton = GetComponent<Button>();
        if (toggleButton != null)
        {
            toggleButton.onClick.AddListener(TogglePanel);
        }
        else
        {
            Debug.LogError("未找到Button组件，请确保此脚本挂载在按钮对象上！");
        }

        // 初始化Panel状态
        if (panel != null)
        {
            panel.SetActive(isPanelVisible);
        }
        else
        {
            Debug.LogError("未指定Panel对象，请在Inspector中设置Panel！");
        }
    }

    // 点击按钮时调用的方法
    private void TogglePanel()
    {
        isPanelVisible = !isPanelVisible; // 切换状态
        if (panel != null)
        {
            panel.SetActive(isPanelVisible); // 更新Panel显示状态
        }
    }

    private void OnDestroy()
    {
        // 确保移除事件监听，防止内存泄漏
        if (toggleButton != null)
        {
            toggleButton.onClick.RemoveListener(TogglePanel);
        }
    }
}