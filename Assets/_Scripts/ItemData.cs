using System;
using System.Collections.Generic;
using UnityEngine;


public class JsonLoader : MonoBehaviour
{
    [System.Serializable]
    public class ItemData
    {
        [System.Serializable]
        public class Item
        {
            public string ID;
            public string Name;
            public string InteractionName;
            public string Type;
        }
        
        public List<Item> ItemList;
    }
    private void Awake()
    {
        // Resources ���� ���� JSON ���� �ε�
        TextAsset jsonFile = Resources.Load<TextAsset>("ItemData");

        if (jsonFile != null)
        {
            // JSON ������ ������ ���ڿ��� ��ȯ
            string jsonString = jsonFile.text;

            // JSON ���ڿ��� C# ��ü�� ������ȭ
            ItemData itemData = JsonUtility.FromJson<ItemData>(jsonString);

            // ������ȭ�� ������ ���
            foreach (var item in itemData.ItemList)
            {
                Debug.Log($"ID: {item.ID}, Name: {item.Name}, Type: {item.Type}");
            }
        }
        else
        {
            Debug.LogError("JSON file not found!");
        }
    }
}