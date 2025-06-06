using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueSystem : MonoBehaviour
{
    [Header("UI Components")]
    public Image dialogueBox;
    public Text dialogueText;
    public float typingSpeed = 0.1f;

    public Image newDialogueBox;
    public Text newDialogueText;
    public float newTypingSpeed = 0.1f;

    [Header("Character Portraits")]
    public Image character1Portrait;
    public Image character2Portrait;
    public Image character3Portrait;

    [Header("Dialogue Content")]
    [TextArea(3, 10)]
    public string[] dialogues1 = {
        "角色1: \n需要对：",
        "角色2: \n需要对：",
        "角色3: \n需要对：",
    };

    private int currentDialogueSet = 0;
    private int currentIndex = 0;
    private bool isTyping = false;
    private Coroutine typingCoroutine;
    private string[][] allDialogues;

    void Start()
    {
        GameDataManager.Initialize();

        allDialogues = new string[1][] { dialogues1 };
        GameDataManager.Instance.InitializeOrder(allDialogues[0].Length); // 修改为初始化正确的组数

        if (dialogueBox == null || dialogueText == null || newDialogueBox == null || newDialogueText == null)
        {
            Debug.LogError("UI组件未初始化");
            enabled = false;
            return;
        }

        dialogueBox.gameObject.SetActive(false);
        newDialogueBox.gameObject.SetActive(false);
        StartDialogue();
    }

    void Update()
    {
        if (dialogueBox == null || !dialogueBox.gameObject.activeSelf) return;

        if (Input.GetMouseButtonDown(0))
        {
            if (isTyping)
            {
                if (typingCoroutine != null)
                {
                    StopCoroutine(typingCoroutine);
                }
                dialogueText.text = ProcessTimeMark(allDialogues[currentDialogueSet][currentIndex - 1]);
                isTyping = false;
                typingCoroutine = null;
            }
            else
            {
                ShowNextDialogue();
            }
        }
    }

    void StartDialogue()
    {
        currentDialogueSet = 0;
        currentIndex = 0;
        dialogueBox.gameObject.SetActive(true);
        ShowNextDialogue();
    }

    void ShowNextDialogue()
    {
        while (currentIndex < allDialogues[currentDialogueSet].Length &&
               string.IsNullOrEmpty(ProcessTimeMark(allDialogues[currentDialogueSet][currentIndex])))
        {
            currentIndex++;
        }

        if (currentIndex >= allDialogues[currentDialogueSet].Length)
        {
            if (currentDialogueSet < allDialogues.Length - 1)
            {
                currentDialogueSet++;
                currentIndex = 0;
                ShowNextDialogue();
            }
            else
            {
                EndDialogue();
            }
            return;
        }

        string currentLine = allDialogues[currentDialogueSet][currentIndex];
        string speaker = GetSpeaker(currentLine);
        UpdateSpeakerUI(speaker);

        // 生成并存储随机数
        List<int> randomNumbers = GenerateRandomNumbers();
        GameDataManager.Instance.AddRandomNumbers(randomNumbers);

        if (currentLine.Contains("需要对："))
        {
            currentLine = $"{speaker}: \n{GetDialoguePrefix(currentLine)}{randomNumbers[0]}、{randomNumbers[1]}、{randomNumbers[2]}、{randomNumbers[3]}";
        }

        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            typingCoroutine = null;
        }
        typingCoroutine = StartCoroutine(TypeText(currentLine));
        currentIndex++;

        newDialogueBox.gameObject.SetActive(true);
        newDialogueText.text = $"{randomNumbers[0]}、{randomNumbers[1]}、{randomNumbers[2]}、{randomNumbers[3]}";
    }

    IEnumerator TypeText(string fullText)
    {
        try
        {
            isTyping = true;
            dialogueText.text = "";
            string processedText = ProcessTimeMark(fullText);

            if (string.IsNullOrEmpty(processedText))
            {
                yield return new WaitForEndOfFrame();
                ShowNextDialogue();
                yield break;
            }

            foreach (char c in processedText.ToCharArray())
            {
                dialogueText.text += c;
                yield return new WaitForSeconds(typingSpeed);
            }
        }
        finally
        {
            isTyping = false;
            typingCoroutine = null;
        }
    }

    private string ProcessTimeMark(string originalText)
    {
        if (string.IsNullOrEmpty(originalText)) return "";

        if (originalText.StartsWith("#", StringComparison.Ordinal)) return "";
        return originalText.Replace("{time}",
            System.DateTime.Now.ToString("yyyy年MM月dd日HH时mm分ss秒"));
    }

    void EndDialogue()
    {
        dialogueBox.gameObject.SetActive(false);
        if (character1Portrait != null) character1Portrait.gameObject.SetActive(false);
        if (character2Portrait != null) character2Portrait.gameObject.SetActive(false);
        if (character3Portrait != null) character3Portrait.gameObject.SetActive(false);
        newDialogueBox.gameObject.SetActive(false);

        // 跳转到第二个场景
        SceneManager.LoadScene("Scene2"); // 确保场景名称正确
    }

    private string GetSpeaker(string line)
    {
        if (string.IsNullOrEmpty(line)) return "";
        int colonIndex = line.IndexOf(':');
        if (colonIndex <= 0) return "";
        return line.Substring(0, colonIndex).Trim();
    }

    private void UpdateSpeakerUI(string speaker)
    {
        if (character1Portrait != null)
            character1Portrait.gameObject.SetActive(speaker == "角色1");
        if (character2Portrait != null)
            character2Portrait.gameObject.SetActive(speaker == "角色2");
        if (character3Portrait != null)
            character3Portrait.gameObject.SetActive(speaker == "角色3");
    }

    private List<int> GenerateRandomNumbers()
    {
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };
        List<int> randomNumbers = new List<int>();
        System.Random random = new System.Random();

        for (int i = 0; i < 4; i++)
        {
            int index = random.Next(numbers.Count);
            randomNumbers.Add(numbers[index]);
            numbers.RemoveAt(index);
        }

        return randomNumbers;
    }

    private string GetDialoguePrefix(string line)
    {
        if (line.Contains("需要对：")) return "需要对：";
        return "";
    }
}
