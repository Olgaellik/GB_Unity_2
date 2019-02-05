using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyController;
using My.Helper;
using My.Objects;


	/// <summary>
	/// Точка входа в программу
	/// </summary>

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
			_objectManager = GetComponent<ObjectManager>();
			if (_objectManager == null)
			{
				Debug.LogError("Not found ObjectManager");
			}

			//_objectManager = _controllersGameObject.AddComponent<ObjectManager>();
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