using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int hp = 2;

    public DamageEvent OnDamage;
    public DamageEvent OnDeath;

    private bool selfSwitchA;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoseHealth(GameObject culprit, int damage)
    {
        hp -= damage;
        DamageInfo damageInfo = new DamageInfo();
        damageInfo.Damage = damage;
        damageInfo.Enemy = culprit;
        OnDamage.Invoke(damageInfo);
        if (hp == 0)
        {
            Death(damageInfo);
        }
    }

    void Death(DamageInfo damage)
    {
        OnDeath.Invoke(damage);
    }
}

[System.Serializable]
public class DamageEvent : UnityEvent<DamageInfo>{

}