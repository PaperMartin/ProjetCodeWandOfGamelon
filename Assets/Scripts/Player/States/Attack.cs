using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : AbstractAIBehaviour
{
    public string behaviorHash;
    private bool active = false;

    public float attackTime;
    private float attackTimeCounter;

    public GameObject _angelController;

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
        
    }

    void Attacking()
    {
        int var = _angelController.GetComponent<AngelController>().NESOValue;
    }
}
