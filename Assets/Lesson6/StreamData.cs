using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class StreamData : IDataProvider

{
	private string path;

	public PlayerData Load()
	{
		if (!File.Exists(path)) return default(PlayerData);

		var playerData = new PlayerData();
		using (var sr = new StreamReader(path))
		{
			while (!sr.EndOfStream)
			{
				playerData.Name = sr.ReadLine();


				if (!float.TryParse(sr.ReadLine(), out playerData.HP))
				{
					playerData.HP = 100f;
					Debug.LogWarning($"PlayerData.HP is not a float! {path}");
				}

				if (!bool.TryParse(sr.ReadLine(), out playerData.IsVisible))
				{
					playerData.IsVisible = true;
					Debug.LogWarning($"PlayerData.IsVisible is not a bool! {path}");
				}
			}

			Debug.Log("Data Loaded");
			return playerData;
		}
	}


	public void Save(PlayerData playerData)
	{
		using (var sw = new StreamWriter(path))
		{
			sw.WriteLine(playerData.Name);
			sw.WriteLine(playerData.HP);
			sw.WriteLine(playerData.IsVisible);
		}

		Debug.Log("Data saved");
	}

	public void SetOptions(string path)

	{
		this.path = Path.Combine(path + "/data.txt");
	}
}
