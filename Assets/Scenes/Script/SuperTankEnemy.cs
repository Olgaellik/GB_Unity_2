public class SuperTankEnemy : Enemy
{
    public override void ApplyDamage(float damage)
    {
        // любой урон пприводит к единице
        damage = 1;
        base.ApplyDamage(damage);	
    }
}