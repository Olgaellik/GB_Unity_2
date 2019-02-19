using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using UnityEngine;
using UnityEditor;
using Debug = UnityEngine.Debug;


namespace Lesson6
{

	public class DataTest : MonoBehaviour
	
	{

	public enum ProviderTypes
	{
		TXT,
		XML, 
		PLAYER_PREFS,
		JSON
	}


		[SerializeField] 
		[ContextMenuItem("RunSave", nameof(RunSave))]
		[ContextMenuItem("RunLoad", nameof(RunLoad))]
		public ProviderTypes ProviderType;
		
		private DataManager _dataManager;

		public PlayerDataContainer ObjectToSave;
		public PlayerDataContainer ObjectToLoad;
		
		private void RunSave()

		{
			var path = Application.dataPath;
//			var playerData = new PlayerData
//			{
//				Name = "OlkaTest",
//				HP = 73.3f,
//				IsVisible = true
//			};
			
			_dataManager = new DataManager();

			switch (ProviderType)
			{
					case ProviderTypes.JSON:
						_dataManager.SetData<JsonData>();
						break;
					case ProviderTypes.TXT:
						_dataManager.SetData<StreamData>();
						break;
					case ProviderTypes.XML:
						_dataManager.SetData<XMLData>();
						break;
					case ProviderTypes.PLAYER_PREFS:
						_dataManager.SetData<PlayerPrefsData>();
						break;
			}

			_dataManager.SetOptions(path);
			Debug.Log(ObjectToSave);
			_dataManager.Save(ObjectToSave.Container);

			//var dataLoaded = _dataManager.Load();
			//Debug.Log(dataLoaded);
		}
		
		private void RunLoad()

		{
			var path = Application.dataPath;
            			
			_dataManager = new DataManager();

			switch (ProviderType)
			{
				case ProviderTypes.JSON:
					_dataManager.SetData<JsonData>();
					break;
				case ProviderTypes.TXT:
					_dataManager.SetData<StreamData>();
					break;
				case ProviderTypes.XML:
					_dataManager.SetData<XMLData>();
					break;
				case ProviderTypes.PLAYER_PREFS:
					_dataManager.SetData<PlayerPrefsData>();
					break;
			}

			_dataManager.SetOptions(path);
			var dataLoaded = _dataManager.Load();
			//ObjectToLoad = dataLoaded;
			ObjectToLoad.Container.CopyFrom(dataLoaded);
			Debug.Log(dataLoaded);
		}
	}
}
