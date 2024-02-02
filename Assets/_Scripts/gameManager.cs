using UnityEngine;

public class gameManager : MonoBehaviour
{
    public DayNightCycle dayNightCycle;
    public PlayerConditions playerConditions;


    public static gameManager I;

    void Awake()
    {
        I = this;
    }
    public bool CheckTime(int startTime, int endTime)
    {
        if(dayNightCycle.Hours >= startTime && dayNightCycle.Hours <= endTime )
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
            // 시간이 1140f 이상 1439f 이하인 경우 day 값을 증가시켜 저장
            currentHours = dayNightCycle.Hours >= 1140f ? 0 : dayNightCycle.Hours,
            health = playerConditions.health.curValue,
            stamina = playerConditions.stamina.curValue,
            days = dayNightCycle.Hours >= 1140f ? dayNightCycle.Days + 1 : dayNightCycle.Days,
        };

        string jsonData = JsonUtility.ToJson(playerData);
        PlayerPrefs.SetString("SavedGameData", jsonData);
        PlayerPrefs.Save();

        Debug.Log("Game saved!");
    }
    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("SavedGameData"))
        {
            string jsonData = PlayerPrefs.GetString("SavedGameData");
            PlayerData playerData = JsonUtility.FromJson<PlayerData>(jsonData);

            dayNightCycle.SetHours(playerData.currentHours);
            playerConditions.health.curValue = playerData.health;
            playerConditions.stamina.curValue = playerData.stamina;

            Debug.Log("Game loaded!");
        }
        else
        {
            Debug.Log("No saved game data found.");
        }
    }


}
