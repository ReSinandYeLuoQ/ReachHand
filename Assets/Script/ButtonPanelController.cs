using UnityEngine;
using UnityEngine.UI;

public class ButtonPanelController : MonoBehaviour
{
    public GameObject panel; 
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>(); 
        if (button != null)
        {
            button.onClick.AddListener(TogglePanel);
        }
        else
        {
            Debug.LogError("Button component not found on this GameObject!");
        }
    }

    void TogglePanel()
    {
        if (panel != null)
        {
            panel.SetActive(!panel.activeSelf); 
        }
        else
        {
            Debug.LogError("Panel GameObject not assigned!");
        }
    }
}