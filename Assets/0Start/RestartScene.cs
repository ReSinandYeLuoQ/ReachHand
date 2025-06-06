using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
    public void RestartToThirdScene()
    {
        // 加载索引为 2 的场景（即第三个场景）
        SceneManager.LoadScene(2);
    }
}