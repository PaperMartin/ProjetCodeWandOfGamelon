using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelController : MonoBehaviour
{

    private AngelActions _angelActions;

    public Vector2 direction;

    public bool walkHorizontal;
    public bool isWalking;

    private Animator _animator;

    //"NESO" pour "Nord, Est, Sud, Ouest". Cette valeur sert d'indicateur pour savoir dans quel sens le personnage est tourné.
    [HideInInspector]
    public int NESOValue;

    private void Awake()
    {
        _angelActions = new AngelActions();
        _animator = GetComponent<Animator>();
        _animator.SetBool("IsWalking", false);
    }

    private void OnDisable()
    {
        _angelActions.Disable();
    }

    private void OnEnable()
    {
        _angelActions.Enable();
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        direction = _angelActions.Base.Walk.ReadValue<Vector2>();

        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            walkHorizontal = true;
            isWalking = true;
            _animator.SetBool("IsWalking", true);

            if (direction.x > 0)
            {
                NESOValue = 1;
            }
            else
            {
                NESOValue = 3;
            }
        }

        if (Mathf.Abs(direction.y) > Mathf.Abs(direction.x))
        {
            walkHorizontal = false;
            isWalking = true;
            _animator.SetBool("IsWalking", true);

            if(direction.y > 0)
            {
                NESOValue = 0;
            }
            else
            {
                NESOValue = 2;
            }

        }

        if (Mathf.Abs(direction.y) == 0 && Mathf.Abs(direction.x) == 0)
        {
            isWalking = false;
            _animator.SetBool("IsWalking", false);
        }



    }
}
