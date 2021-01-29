using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBackToSpawn : AbstractAIBehaviour
{
    public string behaviorHash;
    
    [SerializeField]
    private Vector2 Spawn;
    [SerializeField]
    private Transform body;

    // Start is called before the first frame update
    void Start()
    {
        Spawn = body.position;
    }

    public override int GetBehaviourHash()
    {
        return Animator.StringToHash(behaviorHash);
    }

    public override void onEnterState()
    {
        body.position = Spawn;
    }

    public override void onExitState()
    {
        
    }
}
