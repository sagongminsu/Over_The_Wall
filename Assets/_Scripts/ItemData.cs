using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Data
{
    int ID;
    string Name;
    string InteractionName;
    string Type;
}



public class ItemData : MonoBehaviour
{
    Data itemData = new Data();

    private void Start()
    {
        //Data ItemData = JsonUtility.FromJson<Data>(itemData);
    }
}
