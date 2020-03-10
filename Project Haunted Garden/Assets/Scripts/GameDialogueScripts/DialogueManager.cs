using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI textD;
    public GameObject continueButton;
    public GameObject TextBox;
    public int index;
    public int level;
    public int x = 0;
    public float Textspeed;

    [TextArea]
    [Tooltip("Legend")]
    public string Notes = "Character list params: ALOE, IVY, LILY, NARRATOR";

    [System.Serializable]
    public class DialogueListPerLevel
    {
        public string Scene;
        public string[] dialogue;
    }

    public DialogueListPerLevel[] DialogueList;

    //Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Type());
    }

    IEnumerator Type()
    {
        if (x < DialogueList[level].dialogue.Length)
        {
            if (index < DialogueList[level].dialogue[x].Length)
            {
                foreach (char letter in DialogueList[level].dialogue[x].ToCharArray())
                {
                    textD.text += letter;
                    yield return new WaitForSeconds(Textspeed);
                }
            }
        }
    }

    void Update()
    {
        char NARRATOR = 'N'; char ALOE = 'A';char IVY = 'I';char LILY = 'L';
        if (x < DialogueList[level].dialogue.Length)
        {
            continueButton.SetActive(false);
            if (DialogueList[level].dialogue[x].ToCharArray()[0] == NARRATOR)
            {
                TextBox.GetComponent<Image>().color = new Color32(214, 210, 191, 255);
            }
            if (DialogueList[level].dialogue[x].ToCharArray()[0] == ALOE)
            {
                TextBox.GetComponent<Image>().color = new Color32(233, 252, 167, 217);
            }
            if (DialogueList[level].dialogue[x].ToCharArray()[0] == IVY)
            {
                TextBox.GetComponent<Image>().color = new Color32(13, 67, 231, 231);
            }
            if (DialogueList[level].dialogue[x].ToCharArray()[0] == LILY)
            {
                TextBox.GetComponent<Image>().color = new Color32(13, 67, 231, 231);
            }
            if (textD.text == DialogueList[level].dialogue[x])
            {
                continueButton.SetActive(true);
            }
        }
        /* 
        if (x < DialogueList[level].dialogue.Length)
        {
            continueButton.SetActive(false);
            if (index < DialogueList[level].dialogue[x].Length)
            {
                if (DialogueList[level].characters[x] == "ALOE")
                {
                    TextBox.GetComponent<Image>().color = new Color32(214, 210, 191, 255);
                }
                if (DialogueList[level].characters[x] == "IVY")
                {
                    TextBox.GetComponent<Image>().color = new Color32(233, 252, 167, 217);
                }
                if (DialogueList[level].characters[x] == "LILY")
                {
                    TextBox.GetComponent<Image>().color = new Color32(13, 67, 231, 231);
                }
                if (DialogueList[level].characters[x] == "NARRATOR")
                {
                    TextBox.GetComponent<Image>().color = new Color32(13, 67, 231, 231);
                }
                if (textD.text == DialogueList[level].dialogue[x])
                {
                    continueButton.SetActive(true);
                }
            }
        } */
    }

     public void nextLine()
   {
       continueButton.SetActive(false);
       if (index < DialogueList[level].dialogue[x].Length - 1)
       {
           index++;
           textD.text = "";
           x++;
           StartCoroutine(Type());
       }
       else
       {
           textD.text = "";
           continueButton.SetActive(false);
       }
   }
}
