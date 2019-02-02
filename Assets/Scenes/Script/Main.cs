using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyController;

namespace MyController
{
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

		void Start()
		{
			_instance = this;
			_controllersGameObject = new GameObject {name = "Controllers"};
			_inputController = _controllersGameObject.AddComponent<InputController>();
			_torchController = _controllersGameObject.AddComponent<TorchController>();
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

		#endregion


		

	}
}