using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    public string targetSceneName = "2"; 

    private void Start()
    {
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(SwitchScene);
        }
        else
        {
            Debug.LogError("Button component not found on this GameObject!");
        }
    }

    void SwitchScene()
    {
        SceneManager.LoadScene(targetSceneName); 
    }
}
