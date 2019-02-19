using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonData : IDataProvider

{
	private string path;

	public PlayerData Load()
	{
		if (!File.Exists(path)) return default(PlayerData);

		var playerData = new PlayerData();
		var str = File.ReadAllText(path);
		str = Crypto.CryptoXOR(str);
		playerData = JsonUtility.FromJson<PlayerData>(str);


		Debug.Log("Data Loaded");
		return playerData;

	}


	public void Save(PlayerData playerData)
	{
		var str = JsonUtility.ToJson(playerData);
		str = Crypto.CryptoXOR(str);
		File.WriteAllText(path, str);
		
		Debug.Log("Data saved");
	}

	public void SetOptions(string path)

	{
		this.path = Path.Combine(path + "/dataj.json");
	}
}