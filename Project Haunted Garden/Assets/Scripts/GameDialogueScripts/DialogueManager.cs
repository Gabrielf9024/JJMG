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
    public string Notes = "Character list params: Player, NPC1, or NPC2";

    [System.Serializable]
    public class DialogueListPerLevel
    {
        public string[] characters;
        public string[] dialogue;
    }
    public DialogueListPerLevel[] DialogueList;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Type());
    }

    IEnumerator Type()
    {
        if (index < DialogueList[level].dialogue.Length)
        {
            foreach (char letter in DialogueList[level].dialogue[index].ToCharArray())
            {
                textD.text += letter;
                yield return new WaitForSeconds(Textspeed);
            }
        }
    }

    void Update()
    {
        if (index < DialogueList[level].dialogue.Length)
        {
            if (DialogueList[level].characters[x] == "Player")
            {
                TextBox.GetComponent<Image>().color = new Color32(214, 210, 191, 255);
            }
            if (DialogueList[level].characters[x] == "NPC1")
            {
                TextBox.GetComponent<Image>().color = new Color32(233, 252, 167, 217);
            }
            if (DialogueList[level].characters[x] == "NPC2")
            {
                TextBox.GetComponent<Image>().color = new Color32(13, 67, 231, 231);
            }
            if (textD.text == DialogueList[level].dialogue[index])
            {
                continueButton.SetActive(true);
            }
        }
    }

    public void nextLine()
    {
        continueButton.SetActive(false);
        if (index < DialogueList[level].dialogue[index].Length - 1)
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
