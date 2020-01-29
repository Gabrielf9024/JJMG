using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI textD;
    //public string[] sentence;
    private int index;
    public float speed;
    public int levelNumber;
    public bool isPlayer;

    public GameObject continueButton;
    public GameObject TextBox;

    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Type());
    }

    IEnumerator Type()
    {
        foreach(char letter in sentenceList()[index].ToCharArray())
        {
            textD.text += letter;
            yield return new WaitForSeconds(speed);
        }
    }

    // Update is called once per frame
     void Update()
    {
        if (isPlayer)
        {
            TextBox.GetComponent<Image>().color = new Color32(255, 255, 225, 100);
        }
        else
        {
            TextBox.GetComponent<Image>().color = new Color32(214, 210, 191, 255);
        }
        if (textD.text == sentenceList()[index])
        {
            continueButton.SetActive(true);
        }
    }   
    
    public void nextLine()
    {
        continueButton.SetActive(false);
        if (index < sentenceList().Length - 1)
        {
            index++;
            textD.text = "";
            isPlayer = !isPlayer;
            StartCoroutine(Type());
        }
        else
        {
            textD.text = "";
            continueButton.SetActive(false);
        }
    }
    public string[] sentenceList()
    {
        if (levelNumber == 1)
        {
            string[] text = {"Hello world will you help me do this assigment", "else i eill comittadfjjsdlk kwejkahkjdfneidm "};
            return text;
        }
        if (levelNumber == 2)
        {
            string[] text = { "ldskfalksdfkjhkajsdfkjakjshdfkjaksdhkfj", "adfasdfasdfasdfasdfasdfasd","dfasdfasdfasdfasdfasdfas" };
            return text;
        }
        if (levelNumber == 3)
        {
            string[] text = { "ldskfalksdfkjhkajsdfkjakjshdfkjaksdhkfj", "adfasdfasdfasdfasdfasdfasd", "dfasdfasdfasdfasdfasdfas" };
            return text;
        }
        if (levelNumber == 4)
        {
            string[] text = { "ldskfalksdfkjhkajsdfkjakjshdfkjaksdhkfj", "adfasdfasdfasdfasdfasdfasd", "dfasdfasdfasdfasdfasdfas" };
            return text;
        }
        if (levelNumber == 5)
        {
            string[] text = { "dddd", "sss", "aaa" };
            return text;
        }
        return null;
    }

}
