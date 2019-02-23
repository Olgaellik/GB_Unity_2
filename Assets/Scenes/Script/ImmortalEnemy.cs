using UnityEngine;

public class ImmortalEnemy : Enemy
{
    public override void ApplyDamage(float damage)
    {
        //base.ApplyDamage(damage);
        Debug.Log("immortal");
    }
}