using System.Collections;
using System.Collections.Generic;
using My.Interface;
using My.Objects;
using UnityEngine;

public class Enemy : BaseObjectScene, ISetDamage
{
    [SerializeField] private float _hp = 100; // Количество жизней
    private bool _isDead = false; // Флаг смерти
    private float step = 2f;

    private float _maxHp;

    protected override void Awake()
    {
        base.Awake();
        _maxHp = _hp;
    }

    public void Update()
    

    {
        if (_isDead) 
        {
            Color color = GetMaterial.color;
            if (color.a > 0) 
            {
                color.a -= step / 100;
                Color = color;
            }

            if (color.a < 1)
            {
                Destroy(InstanceObject.GetComponent<Collider>());
                Destroy(InstanceObject, 3f);
            }

            Destroy(InstanceObject, 5f);
        }
    }

    public virtual void ApplyDamage(float damage)
    {
        if (_hp > 0) // Если жизней больше 0, получаем урон
        {
            _hp -= damage;
        }
        //Color =   Color.Lerp(Color.red,Color.white, _hp/_maxHp);

        if (_hp <= 0) // Если жизней меньше 0, окрашиваемся в красный цвет и говорим себе, что умерли
        {
            _hp = 0;
            Color = Color.black;
            _isDead = true;
        }
    }
}