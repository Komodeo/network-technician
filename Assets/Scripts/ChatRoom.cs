using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatRoom : MonoBehaviour
{
    private Text textArea;
    public TextAsset chatTextFile;
    private string displayText;
    private string fullTextFromFile;
    private List<string> eachLine;

    // Start is called before the first frame update
    void Start()
    {
        textArea = GetComponent<Text>();
        fullTextFromFile = chatTextFile.text;
        eachLine = new List<string>();
        eachLine.AddRange(fullTextFromFile.Split("\n"[0]));
    }

    // Update is called once per frame
    void Update()
    {
        DisplayChat(GameManager.chatNumber);
    }

    public static string MakeString(int val, List<string> list)
    {
        string[] sArr = new string[val + 1];
        for (int i = 0; i < val + 1; i++)
        {
            sArr[i] = list[i];
        }
        return string.Join("\n", sArr);
    }

    public void DisplayChat(int val)
    {
        displayText = MakeString(val, eachLine);
        textArea.text = displayText;
    }
}
