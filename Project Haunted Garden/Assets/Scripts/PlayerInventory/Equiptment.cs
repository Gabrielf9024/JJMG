using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equiptment : MonoBehaviour
{
    public GameObject[] equiptment;
    public GameObject DisplayIcon;
    public GameObject IconLocation;
    public GameObject currentObject;
    public int index;
    public int size;

    void SelectIcon()
    {
        int currentIndex = index;
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                if (index + 1 < size)
                {
                    index = (index + 1);
                }
            }
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                if (index - 1 >= 0)
                {
                    index = (index - 1);
                }
            }
        }
        if (currentIndex != index)
        {
            GameObject.Destroy(currentObject);
            DisplayIcon = equiptment[index];
            currentObject = Instantiate(DisplayIcon, IconLocation.transform, false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        DisplayIcon = equiptment[0];
        currentObject = Instantiate(DisplayIcon, transform, false);
        size = equiptment.Length;
    }

    // Update is called once per frame
    void Update()
    {
        SelectIcon();
    }
}
