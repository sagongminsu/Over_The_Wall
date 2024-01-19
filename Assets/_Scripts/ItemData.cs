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
        // Resources 폴더 내의 JSON 파일 로드
        TextAsset jsonFile = Resources.Load<TextAsset>("ItemData");

        if (jsonFile != null)
        {
            // JSON 파일의 내용을 문자열로 변환
            string jsonString = jsonFile.text;

            // JSON 문자열을 C# 객체로 역직렬화
            ItemData itemData = JsonUtility.FromJson<ItemData>(jsonString);

            // 역직렬화된 데이터 사용
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