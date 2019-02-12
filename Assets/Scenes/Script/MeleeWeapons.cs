using UnityEngine;

public class MeleeWeapons : Weapon
{
    public Animator fireanimator;
    public float Damage;
    public override void Fire(Ammunition ammunition)
    {        
        if (!_fire) return;
        Debug.Log("Melee Attack");
        fireanimator.SetTrigger("attack");
        _fire = false;

        _recharge.Start(_rechargeTime); // Запускаем таймер
        Player.Instance.ApplyDamage(Damage);
    }
}