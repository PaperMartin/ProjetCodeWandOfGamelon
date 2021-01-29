using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelController : MonoBehaviour
{

    private AngelActions _angelActions;

    public Vector2 direction;

    public bool walkHorizontal;
    public bool isWalking;

    public Animator _AnimAnimator;
    public Animator _AIAnimator;

    public Animator upAttack;
    public Animator rightAttack;
    public Animator downAttack;
    public Animator leftAttack;

    public AudioClip gameOverSound;
    private AudioSource source;
    public AudioSource SESource;
    public AudioClip hitSound;
    public AudioClip attackSound;

    private Rigidbody2D rb;

    public Walk _walk;

    //"NESO" pour "Nord, Est, Sud, Ouest". Cette valeur sert d'indicateur pour savoir dans quel sens le personnage est tourné.
    [HideInInspector]
    public int NESOValue;

    private void Awake()
    {
        _angelActions = new AngelActions();
        _AIAnimator.SetBool("IsWalking", false);
        source = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
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
        _angelActions.Base.Attack.performed += _ => Attacking();
    }

    
    void Update()
    {
        direction = _angelActions.Base.Walk.ReadValue<Vector2>();


        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            walkHorizontal = true;
            isWalking = true;
            _AIAnimator.SetBool("IsWalking", true);
            _AnimAnimator.SetBool("IsWalking", true);

            if (direction.x > 0)
            {
                NESOValue = 1;
                _AnimAnimator.SetFloat("DirY", 0f);
                _AnimAnimator.SetFloat("DirX", 1f);
            }
            else
            {
                NESOValue = 3;
                _AnimAnimator.SetFloat("DirY", 0f);
                _AnimAnimator.SetFloat("DirX", -1f);
            }
        }

        if (Mathf.Abs(direction.y) > Mathf.Abs(direction.x))
        {
            walkHorizontal = false;
            isWalking = true;
            _AIAnimator.SetBool("IsWalking", true);
            _AnimAnimator.SetBool("IsWalking", true);

            if (direction.y > 0)
            {
                NESOValue = 0;
                _AnimAnimator.SetFloat("DirY", 1f);
                _AnimAnimator.SetFloat("DirX", 0f);
            }
            else
            {
                NESOValue = 2;
                _AnimAnimator.SetFloat("DirY", -1f);
                _AnimAnimator.SetFloat("DirX", 0f);
            }

        }

        if (Mathf.Abs(direction.y) == 0 && Mathf.Abs(direction.x) == 0)
        {
            isWalking = false;
            _AIAnimator.SetBool("IsWalking", false);
            _AnimAnimator.SetBool("IsWalking", false);
        }

        _walk.direction = direction;
        _walk.walkHorizontal = walkHorizontal;



    }

    public void Attacking()
    {
        _AIAnimator.SetTrigger("IsAttacking");

        SESource.clip = attackSound;
        SESource.Play();

        if (NESOValue == 0)
        {
            upAttack.SetTrigger("IsAttacking");
        }

        if (NESOValue == 1)
        {
            rightAttack.SetTrigger("IsAttacking");
        }

        if (NESOValue == 2)
        {
            downAttack.SetTrigger("IsAttacking");
        }

        if (NESOValue == 3)
        {
            leftAttack.SetTrigger("IsAttacking");
        }
    }

    public void KillPlease()
    {
        _AIAnimator.SetBool("IsAlive", false);
        source.clip = gameOverSound;
        source.Play();
        source.loop = false;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    public void IsBeingHit()
    {
        SESource.clip = hitSound;
        SESource.Play();
    }
}
