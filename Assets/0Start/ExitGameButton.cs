using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ExitGameButton : MonoBehaviour
{
    void Start()
    {
        // 获取按钮组件
        Button button = GetComponent<Button>();
        // 添加点击事件监听器
        button.onClick.AddListener(ExitGame);
    }

    void ExitGame()
    {
        // 在编辑器中停止播放
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // 在发布版本中退出应用程序
        Application.Quit();
#endif
    }
}