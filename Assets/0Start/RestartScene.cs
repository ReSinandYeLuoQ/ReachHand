using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
    public void RestartToThirdScene()
    {
        // ��������Ϊ 2 �ĳ�������������������
        SceneManager.LoadScene(2);
    }
}