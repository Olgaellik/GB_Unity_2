using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyController; 
using My.Helper;
using MyController;


public class WeaponController : BaseController
{
	[SerializeField]
	private Weapon _weapon;
	[SerializeField]
	private Ammunition _ammunition;
	private int _mouseButton = (int) Main.MouseButton.LeftButton;
	public Weapon SelectedWeapon              // Оружие, которое сейчас выбрано
	{
		get { return _weapon; }
	}
	public void Update()
	{
		if (!Enabled) return;
		if (Input.GetMouseButton(_mouseButton)) // Если зажата левая кнопка мыши
		{
			SelectedWeapon.Fire(_ammunition);
		}
	}
	
	
	public virtual void On(Weapon weapon, Ammunition ammunition)
	{
		if (Enabled) return;
		base.On();
		
		_weapon = weapon;
		_ammunition = ammunition;
		weapon.IsVisible = true;
		_weapon.gameObject.SetActive(true);
	}
	
	public override void Off()
	{
		if (!Enabled) return;
		base.Off();
				
		if (_weapon == null)
			return; 
		_weapon.IsVisible = false;
		_weapon.gameObject.SetActive(false);
		_weapon = null;
		_ammunition = null;
	}     
}
