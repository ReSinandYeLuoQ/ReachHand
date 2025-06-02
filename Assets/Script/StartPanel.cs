using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPanel : MonoBehaviour
{
    public GameObject Settingspanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayHandler()
    {
        SceneManager.LoadScene("Round1");
    }
    public void OnSettingspanelHandler()
    {
        Settingspanel.SetActive(true);
    }
}
