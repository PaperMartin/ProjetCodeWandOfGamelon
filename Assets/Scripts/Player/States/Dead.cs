using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dead : AbstractAIBehaviour
{
    private bool active;
    public string behaviorHash;

    public Animator _Animator;

    public float gameOverTime;
    private float gameOverTimeCounter = 0.5f;


    public override int GetBehaviourHash()
    {
        return Animator.StringToHash(behaviorHash);
    }

    public override void onEnterState()
    {
        gameOverTimeCounter = gameOverTime;
        active = true;
        _Animator.SetBool("IsDead", true);
        
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
        if(active == true)
        {
            gameOverTimeCounter -= Time.deltaTime;

            if (gameOverTimeCounter < 0)
            {
                SceneManager.LoadScene("Accueil");
            }


        }

        
    }
}
