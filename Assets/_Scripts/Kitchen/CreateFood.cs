using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class CreateFood : MonoBehaviour
{
    public GameObject[] createFood;
    public ItemObject itemObject;
    
   


    // Update is called once per frame
    void Update()
    {
        
        if (gameManager.I.CheckTime(11, 12))
        {         
           activateFoods();
        }

        else if (gameManager.I.CheckTime(17, 18))
        {
            activateFoods();
        }
       
        else
        {
            deleteFoods();
        }


    }
    private void activateFoods()
    {
        // �迭�� �� ��Ҹ� ��ȸ�ϸ鼭 Ȱ��ȭ
        foreach (GameObject foods in createFood)
        {
            foods.SetActive(true);
        }
    }
    

    private void deleteFoods()
    {
        foreach (GameObject foods in createFood)
        {
            foods.SetActive(false);
        }
    }
   
}
