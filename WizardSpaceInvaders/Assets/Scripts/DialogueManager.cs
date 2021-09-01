using System.Collections;
using System.Collections.Generic;
using System.Globalization;
//using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    Queue<string> lines;
    public Dialogue dialogue;
    public Text DialogueText;
    public Text NameText;
    void Start()
    {
        lines = new Queue<string>();
        StartDialogue(dialogue);
    }
    public void StartDialogue(Dialogue d)
    {
        //Debug.Log("Dialogue Started");
        lines.Clear();
        foreach(string s in d.DialogueLines)
        {
            lines.Enqueue(s);
        }
        NameText.text = d.CharacterName;
        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if (lines.Count == 0)
        {
            EndDialogue();
            return;
        }
        DialogueText.text = lines.Dequeue();
    }

    public void EndDialogue()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
