using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ExitGameButton : MonoBehaviour
{
    void Start()
    {
        // ��ȡ��ť���
        Button button = GetComponent<Button>();
        // ��ӵ���¼�������
        button.onClick.AddListener(ExitGame);
    }

    void ExitGame()
    {
        // �ڱ༭����ֹͣ����
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // �ڷ����汾���˳�Ӧ�ó���
        Application.Quit();
#endif
    }
}