using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using My.Helper;
using My.Objects;
using MyController;

public abstract class Weapon : BaseObjectScene
{

	[SerializeField] protected Transform _gun;
	[SerializeField] protected float _force = 10;
	[SerializeField] protected float _rechargeTime = 0.2f;
	
	protected Timer _recharge = new Timer(); // Выделяем память под таймер
	protected bool _fire = true; // Флаг, разрешающий стрелять

	//public string ArrowID;

	public abstract void Fire(Ammunition ammunition);
	

	protected virtual void Update()
	{

		_recharge.Update(); // Производим подсчеты времени
		if (_recharge.IsEvent()) // Если закончили отсчет, разрешаем стрелять
		{
			_fire = true;
		}
	}
}
