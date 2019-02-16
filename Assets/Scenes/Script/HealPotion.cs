using My.Interface;
using UnityEngine;

public class HealPotion : MonoBehaviour
{
    public float HealHp;

    private void OnTriggerEnter(Collider other)
    {
        SetDamage(other.gameObject.GetComponent<ISetDamage>());
    }
    
    private void SetDamage(ISetDamage obj)
    {
        Debug.Log("Heal");
        if (obj != null)
        {
            Destroy(gameObject);
            obj.ApplyDamage(HealHp);
        }

    }
}