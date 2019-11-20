using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreGameManager : MonoBehaviour
{
    public List<StoreScript> list = new List<StoreScript>();
    public GameObject player;
    public GameObject StorePanel;
    public static StoreGameManager instance;

    void UpdateItemSlots()
    {
        int index = 0;
        foreach(Transform child in StorePanel.transform)
        {
            StoreManager slot = child.GetComponent<StoreManager>();
            if (index < list.Count)
            {
                slot.store = list[index];
            }
            else
            {
                slot.store = null;
            }
            slot.updateInfo();
            index++;
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        UpdateItemSlots();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
