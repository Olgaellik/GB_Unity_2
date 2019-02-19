using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : IDataProvider

{
    private IDataProvider dataProvider;

    public void SetData<T>() where T : IDataProvider, new()

    {
        dataProvider = new T();
    }

    public PlayerData Load()
    {
        if (dataProvider == null) return default(PlayerData);
        return dataProvider.Load();
    }
    
    public void Save(PlayerData playerData)
    
    {
        dataProvider?.Save(playerData);
    }

    public void SetOptions(string path)
    
    {
        dataProvider?.SetOptions(path);
    }
}
