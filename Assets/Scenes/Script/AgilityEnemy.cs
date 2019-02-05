using UnityEngine;

public class AgilityEnemy : Enemy
{
    public override void ApplyDamage(float damage)
    {
        if (0 == Random.Range(0, 3))
        {
            base.ApplyDamage(damage);
        }
        else
        {
            Debug.Log("avoid");
        }
    }
}