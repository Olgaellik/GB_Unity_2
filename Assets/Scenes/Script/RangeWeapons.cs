using UnityEngine;

public class RangeWeapons : Weapon
{
	public Animator fireanimator;
	public override void Fire(Ammunition ammunition)
	{
		Debug.Log("try fire1");
		if (!_fire) return;
		fireanimator.SetTrigger("firetrrigger");
		

		Debug.Log("try fire2");
		if (!ammunition) return;
// Создаем пулю                                   
		Arrow temparrow = Instantiate(ammunition, _gun.position, _gun.rotation) as Arrow;
// Всегда проверяйте существование объекта, прежде чем к нему обратиться!

		Debug.Log("try fire3");
		if (!temparrow) return;
// Добавляем ускорение к пуле
		Debug.Log("try fire4");
		temparrow.GetRigidbody.AddForce(_gun.forward * _force);
		temparrow.Name = "Arrow"; // Задаем имя пуле
		_fire = false; // Сообщаем, что произошел выстрел
		
		_recharge.Start(_rechargeTime); // Запускаем таймер
	}
}
