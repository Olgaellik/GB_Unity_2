using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsData : IDataProvider

{
    private const string PLAYER_DATA_NAME_KEY = "PLAYER_DATA_NAME_KEY";
    private const string PLAYER_DATA_HP_KEY = "PLAYER_DATA_HP_KEY";
    private const string PLAYER_DATA_ISVISIBLE_KEY = "PLAYER_DATA_ISVISIBLE_KEY";
    
    public PlayerData Load()
    {
var playerData = new PlayerData();
        if (PlayerPrefs.HasKey(PLAYER_DATA_NAME_KEY)) playerData.Name = PlayerPrefs.GetString(PLAYER_DATA_NAME_KEY);
        playerData.HP = PlayerPrefs.GetFloat(PLAYER_DATA_HP_KEY, 100f);
        playerData.IsVisible = bool.Parse(PlayerPrefs.GetString(PLAYER_DATA_ISVISIBLE_KEY, false.ToString()));
        
        Debug.Log("Data Loaded");
        return playerData;
    }

    public void Save(PlayerData playerData)
    {
        PlayerPrefs.SetString(PLAYER_DATA_NAME_KEY, playerData.Name);
        PlayerPrefs.SetFloat(PLAYER_DATA_HP_KEY, playerData.HP);
        PlayerPrefs.SetString(PLAYER_DATA_ISVISIBLE_KEY, playerData.IsVisible.ToString());

        Debug.Log("Data Saved");
        PlayerPrefs.Save();
    }

    public void SetOptions(string path)
    
    {
        
    }

}
