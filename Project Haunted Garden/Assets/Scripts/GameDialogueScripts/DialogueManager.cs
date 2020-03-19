﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

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
        public Sprite[] emotions;
    }

    public DialogueListPerLevel[] DialogueList;

    //Start is called before the first frame update
    void Start()
    {
        level = saveDialogue.Instance.LevelIndex;
        StartCoroutine(Type());
    }

    IEnumerator Type()
    {
        Debug.Log(DialogueList[level].dialogue.Length +"   "+ x);
        if (x < DialogueList[level].dialogue.Length)
        {
            foreach (char letter in DialogueList[level].dialogue[x].ToCharArray())
            {
                textD.text += letter;
                yield return new WaitForSeconds(Textspeed);
            }
        }
        else if (x == DialogueList[level].dialogue.Length)
        {
            level++;
            SaveLevels();
            if (level == 4)
            {
                LoadLevelOne();
            }
            else if (level == 6)
            {
                LoadLevelTwo();
            }
            else if (level == 8)
            {
                LoadLevelThree();
            }
            else if (level == 10)
            {
                LoadLevelFour();
            }
            else if (level == 12)
            {
                LoadLevelEnding();
            }
            else
            {
                LoadDialogue();
            }
        }
    }

    void Update()
    {
        char NARRATOR = 'N'; char ALOE = 'A';char IVY = 'I';char LILY = 'L';
        if (level != 12)
        {
            if (x < DialogueList[level].dialogue.Length)
            {
                if (SetBack == false)
                {
                    Background.GetComponent<Image>().sprite = DialogueList[level].Background;
                }
                RightPersonImage.SetActive(false);
                leftPersonImage.SetActive(false);
                continueButton.SetActive(false);

                if (DialogueList[level].dialogue[x].ToCharArray()[0] == NARRATOR)
                {
                    TextBox.GetComponent<Image>().color = new Color32(214, 210, 191, 255);
                    RightPersonImage.SetActive(false);
                    leftPersonImage.SetActive(false);
                }
                if (DialogueList[level].dialogue[x].ToCharArray()[0] == ALOE)
                {
                    leftPersonImage.SetActive(true);
                    TextBox.GetComponent<Image>().color = new Color32(219, 170, 167, 255);
                    leftPersonImage.GetComponent<Image>().sprite = DialogueList[level].emotions[x];
                }
                if (DialogueList[level].dialogue[x].ToCharArray()[0] == IVY)
                {
                    RightPersonImage.SetActive(true);
                    TextBox.GetComponent<Image>().color = new Color32(167, 151, 134, 255);
                    RightPersonImage.GetComponent<Image>().sprite = DialogueList[level].emotions[x];
                }
                if (DialogueList[level].dialogue[x].ToCharArray()[0] == LILY)
                {
                    RightPersonImage.SetActive(true);
                    TextBox.GetComponent<Image>().color = new Color32(0, 255, 255, 255);
                    RightPersonImage.GetComponent<Image>().sprite = DialogueList[level].emotions[x];
                }
                if (textD.text == DialogueList[level].dialogue[x])
                {
                    continueButton.SetActive(true);
                }
            }
        }
    }
    public void SaveLevels()
    {
        saveDialogue.Instance.LevelIndex = level;
    }
    public void LoadDialogue()
    {
        SceneManager.LoadScene(5);
    }
    public void LoadLevelOne()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadLevelTwo()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadLevelThree()
    {
        SceneManager.LoadScene(3);
    }
    public void LoadLevelFour()
    {
        SceneManager.LoadScene(4);
    }
    public void LoadLevelEnding()
    {
        SceneManager.LoadScene(6);
    }
    public void nextLine()
   {
       continueButton.SetActive(false);
       if (x < DialogueList[level].dialogue.Length)
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
