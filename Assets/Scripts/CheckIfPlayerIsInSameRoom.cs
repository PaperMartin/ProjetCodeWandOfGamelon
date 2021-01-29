using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfPlayerIsInSameRoom : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    [SerializeField]
    private float RoomWidth;
    [SerializeField]
    private float RoomLength;

    private void Update()
    {
        Vector2 OwnPos = CalculateRoom(transform.position);
        Vector2 PlayerPos = CalculateRoom(GameObject.FindGameObjectWithTag("Player").transform.position);

        if (OwnPos == PlayerPos)
        {
            animator.SetBool("IsPlayerInSameRoom", true);
        }
        else
        {
            animator.SetBool("IsPlayerInSameRoom", false);
        }

    }
    private Vector2 CalculateRoom(Vector2 WorldPos)
    {
        WorldPos.x += RoomWidth / 2;
        WorldPos.y += RoomLength / 2;
        WorldPos.x /= RoomWidth;
        WorldPos.y /= RoomLength;
        WorldPos.x = Mathf.Floor(WorldPos.x);
        WorldPos.y = Mathf.Floor(WorldPos.y);
        return WorldPos;
    }
}
