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

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        bool walkHorizontal = false;
        if (Mathf.Abs(direction.x) >= Mathf.Abs(direction.y))
        {
            if (pathfinder.CanWalkLeft() || pathfinder.CanWalkRight())
            {
                walkHorizontal = true;
            }
        }
        Vector2 DirectionFinal = Vector2.zero;

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
    }
}
