﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    public StoreScript store;
    // Start is called before the first frame update
    public void updateInfo()
    {
        Text displayText = transform.Find("Text").GetComponent<Text>();
        Image displayImage = transform.Find("Image").GetComponent<Image>();
        if (store)
        {
            displayText.text = store.ItemName;
            displayImage.sprite = store.ItemImage;

        }
        else
        {
            displayText.text = "";
            displayImage.sprite = null;
            displayImage.color = Color.clear;
        }
    }
    public void Use()
    {
        if (store)
        {
            Debug.Log("You clicked: " + store.ItemName);
        }
    }
    void Start()
    {
        updateInfo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
