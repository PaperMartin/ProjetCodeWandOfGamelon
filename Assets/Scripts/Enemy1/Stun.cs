using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stun : AbstractAIBehaviour
{

    public string behaviorHash;
    [SerializeField]
    private Rigidbody2D rbody2D;
    [SerializeField]
    private float StunMoveSpeed;

    Vector2 MoveDir;

    private bool IsActiveState;

    // Start is called before the first frame update
    void Start()
    {

    }

    public override int GetBehaviourHash()
    {
        return Animator.StringToHash(behaviorHash);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (IsActiveState == true){
            rbody2D.velocity =  MoveDir * StunMoveSpeed;
        }
    }

    public override void onEnterState()
    {
        IsActiveState = true;
    }

    public override void onExitState()
    {
        IsActiveState = false;
    }

    public void UpdateMoveDir()
    {

    }
}
