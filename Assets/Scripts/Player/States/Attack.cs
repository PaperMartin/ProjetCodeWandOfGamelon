using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : AbstractAIBehaviour
{
    public string behaviorHash;
    private bool active = false;
    
    public GameObject _angelController;

    public Animator _animator;

    public float attackDuration;
    public int attackValue;

    public AttackCollider haut;
    public AttackCollider droite;
    public AttackCollider bas;
    public AttackCollider gauche;

    public override int GetBehaviourHash()
    {
        return Animator.StringToHash(behaviorHash);
    }

    public override void onEnterState()
    {
        active = true;
        Attacking();
    }

    public override void onExitState()
    {
        active = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo animatorStateInfo = _animator.GetCurrentAnimatorStateInfo(0);
        if(animatorStateInfo.IsName("Attack") && animatorStateInfo.normalizedTime > attackDuration)
        {
            _animator.SetTrigger("EndState");
        }
    }

    void Attacking()
    {
        int var = _angelController.GetComponent<AngelController>().NESOValue;

        if(var == 0)
        {
            foreach (GameObject enemy in haut.enemiesList)
            {
                if(enemy != null)
                {
                    enemy.GetComponent<Health>().LoseHealth(this.gameObject, attackValue);
                }
            }
        }

        if (var == 1)
        {
            foreach (GameObject enemy in droite.enemiesList)
            {
                if (enemy != null)
                {
                    enemy.GetComponent<Health>().LoseHealth(this.gameObject, attackValue);
                }
            }
        }

        if (var == 2)
        {
            foreach (GameObject enemy in bas.enemiesList)
            {
                if (enemy != null)
                {
                    enemy.GetComponent<Health>().LoseHealth(this.gameObject, attackValue);
                }
            }
        }

        if (var == 3)
        {
            foreach (GameObject enemy in gauche.enemiesList)
            {
                if (enemy != null)
                {
                    enemy.GetComponent<Health>().LoseHealth(this.gameObject, attackValue);
                }
            }
        }
    }
}
