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
    public float Textspeed;

    [System.Serializable]
    public class DialogueListPerLevel
    {
        public bool  isplayer;
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
            if (DialogueList[level].isplayer)
            {
                TextBox.GetComponent<Image>().color = new Color32(214, 210, 191, 255);
            }
            else
            {
                TextBox.GetComponent<Image>().color = new Color32(200, 110, 141, 255);
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
            DialogueList[level].isplayer = !DialogueList[level].isplayer;
            StartCoroutine(Type());
        }
        else
        {
            textD.text = "";
            continueButton.SetActive(false);
        }
    }
}
