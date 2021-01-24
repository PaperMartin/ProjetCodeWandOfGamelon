using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBackToSpawn : AbstractAIBehaviour
{
    public string behaviorHash;
    
    private Vector2 Spawn;

    // Start is called before the first frame update
    void Start()
    {
        Spawn = transform.position;
    }

    public override int GetBehaviourHash()
    {
        return Animator.StringToHash(behaviorHash);
    }

    public override void onEnterState()
    {
        transform.position = Spawn;
    }

    public override void onExitState()
    {
        
    }
}
