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
        continueButton = dialoguePanel.transform.FindChild("Continue").GetComponent<Button>();//gets button from dialogue panel

        //continueButton.onClick.AddListener(delegate { })

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
        dialogueLines = new List<string>();//set dialogueLines to be a new empty list
        foreach (string line in lines)
        {
            dialogueLines.Add(line);
        }
        this.npcName = npcName;
        Debug.Log(dialogueLines.Count);
        //dialogueLines = new List<string>(lines.Length);//set dialogueLines to be a new empty list
        //dialogueLines.AddRange(lines);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
