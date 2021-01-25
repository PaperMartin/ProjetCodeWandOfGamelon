using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : AbstractAIBehaviour
{
    public string behaviorHash;
    private bool active = false;

    public GameObject _angelController;

    private Rigidbody2D rb;
    public float speed;

    [HideInInspector]
    public Vector2 direction;
    [HideInInspector]
    public bool walkHorizontal;

    public override int GetBehaviourHash()
    {
        return Animator.StringToHash(behaviorHash);
    }

    public override void onEnterState()
    {
        active = true;
    }

    public override void onExitState()
    {
        active = false;
        Vector2 vec = new Vector2(0, 0);
        rb.velocity = vec;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        rb = _angelController.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       if(active == true)
        {
            if(walkHorizontal == true)
            {
                float gaucheOuDroite = Mathf.Sign(direction.x);
                Vector2 vec = new Vector2(1, 0);
                rb.velocity = gaucheOuDroite * vec * speed;
            }
            else
            {
                float hautOuBas = Mathf.Sign(direction.y);
                Vector2 vec = new Vector2(0, 1);
                rb.velocity = hautOuBas * vec * speed;
            }
        }
    }
}
