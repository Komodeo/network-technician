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
        displayText = eachLine[0] + "\n" + eachLine[1];
        textArea.text = displayText;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
