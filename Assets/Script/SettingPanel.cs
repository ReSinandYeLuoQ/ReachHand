using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingPanel : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioMixer audioMixer;

    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {

    }

    // 打开设置面板的方法
    public void OpenSettingPanel()
    {
        gameObject.SetActive(true);
    }

    // 关闭设置面板的方法
    public void OnCloseHandler()
    {
        gameObject.SetActive(false);
    }
    public void SetVolume(float value)
    {
        audioMixer.SetFloat("BGMVolume", value);
    }
}