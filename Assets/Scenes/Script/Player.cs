using System.Collections;
using System.Collections.Generic;
using My.Interface;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour , ISetDamage

{

	public float movementSpeed = 10;
	public float turningSpeed = 60;

	public static Player Instance;
	public float StartHp = 100;
	public Image HpBar;
	
	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			_hp = StartHp;
		}
	}

	void Update() {
		float horizontal = Input.GetAxis("Horizontal") * turningSpeed * Time.deltaTime;
		transform.Rotate(0, horizontal, 0);
         
		float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
		transform.Translate(0, 0, vertical);
	}


	private float _hp;
	public float CurrentHealth {
		get { return _hp; }
	}
	public void ApplyDamage(float damage)
	{
		_hp -= damage;
		HpBar.fillAmount = _hp / StartHp;
		if (_hp < 0)
		{
			Time.timeScale = 0;
			//Destroy(gameObject);
		}
		//throw new System.NotImplementedException();
	}
}
