using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public static DialogueSystem Instance { get; set; }
    public GameObject dialoguePanel;
    public string npcName;
    public List<string> dialogueLines = new List<string>();

    Button continueButton;
    Text dialogueText, nameText;//comma allows multiple variables of the same type to be defined
    int dialogueIndex;//keeps track of which line of text should be displayed

    // Start is called before the first frame update
    void Awake()
    {
        continueButton = dialoguePanel.transform.Find("Continue").GetComponent<Button>();//gets button from dialogue panel
        dialogueText = dialoguePanel.transform.Find("Text").GetComponent<Text>();
        nameText = dialoguePanel.transform.Find("Name").GetChild(0).GetComponent<Text>();

        continueButton.onClick.AddListener(delegate/*delegate?*/ { ContinueDialogue(); });
        dialoguePanel.SetActive(false);

        if(Instance != null && Instance != this)//if an Instance exists that is not the instance we want
        {
            Destroy(gameObject);// delete it
        }
        else//an instance does NOT exist
        {
            Instance = this;
        }
    }

    public void AddNewDialogue(string[] lines, string npcName)
    {
        dialogueIndex = 0;//resets dialogue index to start at the beginning of a list of text
        dialogueLines = new List<string>();//set dialogueLines to be a new empty list
        foreach (string line in lines)
        {
            dialogueLines.Add(line);
        }
        this.npcName = npcName;
        Debug.Log(dialogueLines.Count);
        CreateDialogue();
        //dialogueLines = new List<string>(lines.Length);//set dialogueLines to be a new empty list
        //dialogueLines.AddRange(lines);
    }

    //this function handles enabling the dialoguePanel as well as assigning the text values to the elements inside of the panel
    public void CreateDialogue()
    {
        dialogueText.text = dialogueLines[dialogueIndex];//assigns new dialogue text
        nameText.text = npcName;// assigns new name
        dialoguePanel.SetActive(true);//open dialogue panel
    }

    //increases dialogue index and displays the next line of text
    public void ContinueDialogue()
    {
        if(dialogueIndex < dialogueLines.Count - 1)//if dialogueIndex is not on the last line of text
        {
            dialogueIndex++;
            dialogueText.text = dialogueLines[dialogueIndex];
        }
        else//seen all text that there is to see
        {
            dialoguePanel.SetActive(false);//close dialogue panel
        }
    }
}
