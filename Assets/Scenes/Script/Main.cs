using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyController;
using My.Helper;
using My.Objects;



	public sealed class Main : MonoBehaviour
	{
		public static Main Instance
		{
			get { return _instance; }
		}

		private GameObject _controllersGameObject;
		private InputController _inputController;
		private TorchController _torchController;
		private static Main _instance;

		private WeaponController _weaponController;
		private ObjectManager _objectManager;

		public TeammatesController TeammatesController { get; private set; }
		public EnemyBotsController EnemyBotsController { get; private set; }
		
//		public PlayerModel PlayerModel { get; private set; }
//		public event Action<PlayerModel> PlayerChanged; 

		// public void SetPlayer(PlayerModel player)

//		{
//			PlayerModel = player;
//			PlayerChanged?.Invoke(player);
//		}

		public enum MouseButton
		{
			LeftButton,
			RightButton,
			CenterButton
		}
		
		void Start()
		{
			_instance = this;
			_controllersGameObject = new GameObject {name = "Controllers"};
			_inputController = _controllersGameObject.AddComponent<InputController>();
			_torchController = _controllersGameObject.AddComponent<TorchController>();
			_weaponController = _controllersGameObject.AddComponent<WeaponController>();
			TeammatesController = _controllersGameObject.AddComponent<TeammatesController>();
			EnemyBotsController = _controllersGameObject.AddComponent<EnemyBotsController>();
			_objectManager = GetComponent<ObjectManager>();
			if (_objectManager == null)
			{
				Debug.LogError("Not found ObjectManager");
			}

		
		}

		#region Property      

		/// <summary>
		/// Получить контроллер фонарика
		/// </summary>

		public TorchController GetTorchController
		{
			get { return _torchController; }
		}

		/// <summary>
		/// Получить контроллер ввода данных
		/// </summary>
		/// <returns></returns>

		public InputController GetInputController()
		{
			return _inputController;
		}
		
		public WeaponController GetWeaponsController()
		{
			return _weaponController;
		}
		
		public ObjectManager GetManagerObject()
		{
			return _objectManager;
		}

		#endregion



	}