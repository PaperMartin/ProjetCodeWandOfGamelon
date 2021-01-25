using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int hp = 2;

    public UnityEvent OnDamage;
    public UnityEvent OnDeath;

    private bool selfSwitchA;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void LoseHealth()
    {
        hp -= 1;
        OnDamage.Invoke();
        if (hp == 0)
        {
            Death();
        }
    }

    void Death()
    {
        OnDeath.Invoke();
    }
}
