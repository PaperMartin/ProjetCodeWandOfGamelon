using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public abstract class AbstractAIBehaviour : MonoBehaviour
{

    public UnityEvent EnterStateEvent;

    public UnityEvent ExitStateEvent;

    // Must return the short hash value of the Animator state corresponding to this behaviour.
    abstract public int GetBehaviourHash();

    virtual public void onEnterState() 
    {
        //Debug.Log("on enter state");
    }

    virtual public void onExitState()
    {
        //Debug.Log("on exit state");
    }

    // OnEnable()
    // OnDisable()
    // enable = true/false;
}