using Cinemachine;
using System;
using System.Collections;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public DayNightCycle dayNightCycle;
    public PlayerConditions playerConditions;

    public Action<bool> ToggleInven;

    public float defaultMouseSensitivity = 1.0f;
    public KeyCode OpenInven;
    public bool Open;
    public bool isPause;
    public bool isLoad = false;

    public bool NewGame = true;

    private float currentMouseSensitivity;

    public static gameManager I;

    void Awake()
    {
        if (I != null && I != this)
        {
            Destroy(gameObject);
            return;
        }

        I = this;

        NewGame = true;

        currentMouseSensitivity = defaultMouseSensitivity;

        DontDestroyOnLoad(gameObject);

        Application.targetFrameRate = 60;
    }


    private void Update()
    {
        //if (isPause == false)
        //{
        //    if (Input.GetKeyDown(OpenInven))
        //    {
        //        Open = !Open;
        //        ToggleInven?.Invoke(Open);
        //        if (Open)
        //        {
        //            Time.timeScale = 0;
        //            Cursor.lockState = CursorLockMode.None;
        //        }
        //        else if (!Open)
        //        {
        //            Time.timeScale = 1;
        //            Cursor.lockState = CursorLockMode.Locked;
        //        }
        //    }
        //}
        
    }

    public bool CheckTime(int startTime, int endTime)
    {
     
            // dayNightCycle.Hours가 null이 아닌지 확인
            if (dayNightCycle.Hours >= startTime && dayNightCycle.Hours <= endTime)
            {
                return true;
            }
            else
            {
                return false;
            }
    }

    public void SaveGame()
    {
        PlayerData playerData = new PlayerData
        {
            // time이 1140f 이상 1439f 이하에서 저장시 day++
            currentHours = dayNightCycle.Hours >= 1140f ? 0 : dayNightCycle.Hours,
            health = playerConditions.health.curValue,
            stamina = playerConditions.playerSO.Stamina.curValue,
            days = dayNightCycle.Hours >= 1140f ? dayNightCycle.Days + 1 : dayNightCycle.Days,
        };

        string jsonData = JsonUtility.ToJson(playerData);
        PlayerPrefs.SetString("SavedGameData", jsonData);
        PlayerPrefs.Save();

        Debug.Log("Game saved!");
    }
    public void LoadGame()
    {
        if(PlayerPrefs.HasKey("SavedGameData"))
        {
            isLoad = true;

        }
    }
    public void Load()
    {
        if (PlayerPrefs.HasKey("SavedGameData"))
        {
            string jsonData = PlayerPrefs.GetString("SavedGameData");
            PlayerData playerData = JsonUtility.FromJson<PlayerData>(jsonData);

            dayNightCycle.SetHours(360);
            dayNightCycle.Days = playerData.days;

            playerConditions.health.curValue = playerData.health;
            playerConditions.playerSO.Stamina.curValue = playerData.stamina;
            NewGame = false;

            Debug.Log("게임 로드 완료!");
        }
        else
        {
            Debug.Log("저장된 게임 데이터를 찾을 수 없습니다.");
        }
    }
    public void SetMouseSensitivity(float sensitivity)
    {
        currentMouseSensitivity = sensitivity;
    }

    public float GetMouseSensitivity()
    {
        return currentMouseSensitivity;
    }

    public void DeleteSavedGame()
    {
        if (PlayerPrefs.HasKey("SavedGameData"))
        {
            PlayerPrefs.DeleteKey("SavedGameData");
            Debug.Log("Saved game data deleted!");
        }
        else
        {
            Debug.Log("No saved game data found to delete.");
        }
    }

    
}
