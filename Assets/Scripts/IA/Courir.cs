using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Courir : AbstractAIBehaviour 
{
    public string behaviorHash;

    public override int GetBehaviourHash()
    {
        return Animator.StringToHash(behaviorHash);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
