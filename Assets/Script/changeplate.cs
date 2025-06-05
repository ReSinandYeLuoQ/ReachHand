using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class changeplate : MonoBehaviour
{
    public GameObject THIS;
    public float speed = 100f;
    public GameObject book;
    public GameObject plate;
    public bool isMovingup;
    public bool isMovingon;
    ButtonPanelController buttonPanelController;
    public Vector3 uptargetPosition;
    public Vector3 ontargetPosition;
    void Start()
    {
        buttonPanelController = book.GetComponent<ButtonPanelController>();
        Vector3 uptargetPosition = plate.transform.position;
        Vector3 ontargetPosition = plate.transform.position - Vector3.up * 20;
    }
    private void Update()
    {
       
    }
    void OnMouseDown()
    {
        Debug.Log("gettik");
        if (GameManager.platenum== GameManager.studentnum[GameManager.day])
        {
            GameManager.shinow = false;
            GameManager.pinnow = true;//切换
        }
        if (buttonPanelController.isBookOpen == false)
        {
            StartCoroutine(MoveObject());
            // 将菜品数据传递给餐盘
            
        }
    }
    IEnumerator MoveObject()
    {
        Vector3 startPos = plate.transform.position;
        Vector3 targetPos = startPos + Vector3.down * 50;
        float elapsedTime = 0f;
        while (elapsedTime < 1f)
        {
            plate.transform.position = Vector3.Lerp(startPos, targetPos, elapsedTime / 1f);
            elapsedTime += Time.deltaTime;
        }
        GameManager.platenum = GameManager.platenum + 1;
        plate.transform.position = targetPos;  // 确保精确到达目标位置
        Vector3 startPos2 = plate.transform.position;
        Vector3 targetPos2 = startPos2 + Vector3.up * 50;
        float elapsedTime2 = 0f;
        while (elapsedTime2 < 1f)
        {
            plate.transform.position = Vector3.Lerp(startPos2, targetPos2, elapsedTime2 / 1f);
            elapsedTime2 += Time.deltaTime;
            yield return null;
        }
    }
}
