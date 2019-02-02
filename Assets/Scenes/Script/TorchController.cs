using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MyController
{
	public sealed class TorchController : BaseController
	{
		private Light _light;            // Ссылка на источник света
		public GameObject _flame;         // Ссылка на систему партиклей
		public float CurrentCharge;               //Текущая энергия факела
		public float MaxCharge = 5;              //Максимальная энергия  факела
		public float ChargePerSecond = 1;       //Энергия, которая расходуется
		public float RestoreCharge = 2;        //Скорость воссттановления энергии

		public Image _chargeBar; //Ссылка на UI энергии факела
		
		private void Awake()
		{
			_light = GameObject.Find("Torch").GetComponent<Light>();
			_flame = GameObject.Find("torch_Particle");
			_flame.SetActive(false);
			_chargeBar = GameObject.Find("ChargeBar").GetComponent<Image>(); 	
			CurrentCharge = MaxCharge;
			
		}
		public void Start()
		{
			SetActiveFlashlight(false); // При старте сцены выключаем фонарик
		}
		public void Update()
		{
			if (IsEnabled)
			{
				CurrentCharge -= Time.deltaTime * ChargePerSecond; //скорость расхода энергии
				if (CurrentCharge <= 0)
				{
					Off();
				}

			}
			else
			{
				CurrentCharge += Time.deltaTime * RestoreCharge; //скорость восстановления энергии
				if (CurrentCharge >= MaxCharge)
				{
					CurrentCharge = MaxCharge;
				}
			}
			_chargeBar.fillAmount = CurrentCharge/MaxCharge;   //Равномерное заполнение UI

		}
		private void SetActiveFlashlight(bool value)
		{
			_light.enabled = value;
			_flame.SetActive(value);
			
		}
		public override void On()
		{
			if (IsEnabled) return;          // Если контроллер включен, повторно не включаем
			base.On();
			SetActiveFlashlight(true);
		}
		public override void Off()
		{
			if (!IsEnabled) return;        // Если контроллер выключен, повторно не выключаем
			base.Off();
			SetActiveFlashlight(false);
		}
	}
}
