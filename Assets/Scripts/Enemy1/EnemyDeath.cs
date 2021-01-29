using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : AbstractAIBehaviour
{
    public string behaviorHash;
    public GameObject body;
    public float TimeBeforeDeath = 1f;

    public override int GetBehaviourHash()
    {
        return Animator.StringToHash(behaviorHash);
    }

    public override void onEnterState()
    {
        Destroy(body,TimeBeforeDeath);
    }
}
