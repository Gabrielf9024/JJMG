using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI textD;
    public GameObject continueButton;
    public GameObject TextBox;
    public GameObject Background;
    public int index;
    public int level;
    public int x = 0;
    public float Textspeed;
    private bool SetBack;

    private bool assigned;
    private string leftPerson;
    private string RightPerson;

    [Header("Character")]
    public GameObject leftPersonImage;
    public GameObject RightPersonImage;
    public Sprite Ivy;
    public Sprite Aloe;
    public Sprite Lily;



    [TextArea]
    [Tooltip("Legend")]
    public string Notes = "Character list params: ALOE, IVY, LILY, NARRATOR";

    [System.Serializable]
    public class DialogueListPerLevel
    {
        public string Scene;
        public Sprite Background;
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
        if (SetBack == false)
        {
            Background.GetComponent<Image>().sprite = DialogueList[level].Background;
        }
        char NARRATOR = 'N'; char ALOE = 'A';char IVY = 'I';char LILY = 'L';
        if (x < DialogueList[level].dialogue.Length)
        {
            continueButton.SetActive(false);
            if (DialogueList[level].dialogue[x].ToCharArray()[0] == NARRATOR)
            {
                TextBox.GetComponent<Image>().color = new Color32(214, 210, 191, 255);
                AssignImages(true);
            }
            if (DialogueList[level].dialogue[x].ToCharArray()[0] == ALOE)
            {
                TextBox.GetComponent<Image>().color = new Color32(233, 252, 167, 217);
                if (assigned == false && leftPerson != "ALOE")
                {
                    assigned = true;
                    leftPerson = "ALOE";
                }
                if (leftPerson != "ALOE")
                {
                    RightPerson = "ALOE";
                }
                AssignImages(false);
            }
            if (DialogueList[level].dialogue[x].ToCharArray()[0] == IVY)
            {
                TextBox.GetComponent<Image>().color = new Color32(13, 67, 231, 231);
                if (assigned == false && leftPerson != "IVY")
                {
                    assigned = true;
                    leftPerson = "IVY";
                }
                if (leftPerson != "IVY")
                {
                    RightPerson = "IVY";
                }
                AssignImages(false);
            }
            if (DialogueList[level].dialogue[x].ToCharArray()[0] == LILY)
            {
                TextBox.GetComponent<Image>().color = new Color32(13, 67, 231, 231);
                if (assigned == false && leftPerson != "LILY")
                {
                    assigned = true;
                    leftPerson = "LILY";
                }
                if (leftPerson != "LILY")
                {
                    RightPerson = "LILY";
                }
                AssignImages(false);
            }
            if (textD.text == DialogueList[level].dialogue[x])
            {
                continueButton.SetActive(true);
            }
        }
    }

    public void AssignImages(bool narrator)
    {
        if (narrator == false)
        {
            if (leftPerson != null)
            {
                leftPersonImage.SetActive(true);
                if (leftPerson == "LILY")
                {
                    leftPersonImage.GetComponent<Image>().sprite = Lily;
                }
                if (leftPerson == "IVY")
                {
                    leftPersonImage.GetComponent<Image>().sprite = Ivy;
                }
                if (leftPerson == "ALOE")
                {
                    leftPersonImage.GetComponent<Image>().sprite = Aloe;
                }
            }
            else
            {
                leftPersonImage.SetActive(false);
            }
            
            if (RightPerson != null) {
                RightPersonImage.SetActive(true);
                if (RightPerson == "LILY")
                {
                    RightPersonImage.GetComponent<Image>().sprite = Lily;
                }
                if (RightPerson == "IVY")
                {
                    RightPersonImage.GetComponent<Image>().sprite = Ivy;
                }
                if (RightPerson == "ALOE")
                {
                    RightPersonImage.GetComponent<Image>().sprite = Aloe;
                }
            }
            else
            {
                RightPersonImage.SetActive(false);
            }
        }
        else
        {
            RightPersonImage.SetActive(false);
            leftPersonImage.SetActive(false);
        }
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
