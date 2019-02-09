using System.Collections;
using System.Collections.Generic;
using My.Interface;
using UnityEngine;
using MyController;

public class Arrow : Ammunition {

	// Время жизни пули
	[SerializeField] private float _timeToDestruct = 10;
	[SerializeField] private float _damage = 20;     // Урон пули
	[SerializeField] private float _mass = 0.01f;    // Масса пули
	[SerializeField] public GameObject exp; 
	// Текущий урон, который может нанести пуля
	
	private float _currentDamage;
	
	
	protected override void Awake()
	{
		base.Awake();
		// Если пуля не встретит ничего, то через заданное время пуля самоуничтожится
		
		Destroy(InstanceObject, _timeToDestruct);       
		_currentDamage = _damage;
		GetRigidbody.mass = _mass;
	}
	// Если пуля встретила препятствие
	
	private void OnCollisionEnter(Collision collision)    
	{  // Если столкнулись с другой пулей, то ничего не делаем
		if (collision.collider.tag == "Bullet") return;
		// Вызываем функцию нанесения урона
		
		var obj =(GameObject) Instantiate(exp, transform.parent);
		//obj.transform.position = transform.position;
		obj.transform.position = collision.contacts[0].point;
		//Debug.Log(transform.position);
		
		SetDamage(collision.gameObject.GetComponent<ISetDamage>());
		// Тут можно дописать функционал: например, на месте столкновения создавать частицы (искры, пыль) и с помощью декалей вставлять дырки от пуль
		
		Destroy(InstanceObject);          // Удаляем пулю
	}

	private void SetDamage(ISetDamage obj)
	{
		if(obj !=null)
			obj.ApplyDamage((_currentDamage));

	}
}
