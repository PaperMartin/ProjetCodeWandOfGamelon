using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTargetToPlayer : MonoBehaviour
{
    [SerializeField]
    private Walk walk;
    [SerializeField]
    private Pathfinder pathfinder;

    private Transform player;
    [SerializeField]
    private float CooldownBeforeRecalculation = 1f;

    private float CurrentCooldown;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        CurrentCooldown = CooldownBeforeRecalculation;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentCooldown -= Time.deltaTime;
        if (CurrentCooldown <= 0)
        {
            RecalculateDirection();
            CurrentCooldown = CooldownBeforeRecalculation;
        }
    }

    private void RecalculateDirection()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        bool walkHorizontal = false;
        Vector2 DirectionFinal = Vector2.zero;

        if (Mathf.Abs(direction.x) >= Mathf.Abs(direction.y))
        {
            if (pathfinder.CanWalkLeft() || pathfinder.CanWalkRight())
            {
                walkHorizontal = true;
            }
        }

        if (walkHorizontal == true)
        {
            if (direction.x >= 0 && pathfinder.CanWalkRight())
            {
                DirectionFinal.x = 1;
            }
            else
            {
                DirectionFinal.x = -1;
            }
        }
        else
        {
            if (direction.y >= 0 && pathfinder.CanWalkUp())
            {
                DirectionFinal.y = 1;
            }
            else
            {
                DirectionFinal.y = -1;
            }
        }

        walk.direction = DirectionFinal;
        walk.walkHorizontal = walkHorizontal;
    }
}
