using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class CreateFood : MonoBehaviour
{
    public GameObject[] createFood;
    public ItemObject itemObject;


    bool isFood = false;
    bool isDelete = false;

    private void Start()
    {
        if (QuestManager.instance.GetQuestState(3))
        {
            deleteFoods();
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (!QuestManager.instance.GetQuestState(3))
        {
            if (gameManager.I.CheckTime(11, 12))
            {
                if (isFood) return;
                activateFoods();
            }

            else if (gameManager.I.CheckTime(17, 18))
            {
                if (isFood) return;
                activateFoods();
            }
            else
            {
                deleteFoods();
            }
        }
        else
        {
            if(isDelete) return;
            deleteFoods();
            isDelete = true;
        }
      
        

    }


    public void activateFoods()
    {
        foreach (GameObject foods in createFood)
        {
            foods.SetActive(true);
        }
        isFood = true;
    }
    

    private void deleteFoods()
    {
        foreach (GameObject foods in createFood)
        {
            foods.SetActive(false);
        }
    }
   
}
