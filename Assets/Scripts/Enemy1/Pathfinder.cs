using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    public bool CanWalkUp(){
        return CheckDirection(Vector2.up);
    }

    public bool CanWalkDown(){
        return CheckDirection(Vector2.down);
    }

    public bool CanWalkLeft(){
        return CheckDirection(Vector2.left);
    }

    public bool CanWalkRight(){
        return CheckDirection(Vector2.right);
    }

    private bool CheckDirection(Vector2 direction){
        RaycastHit2D hit = Physics2D.Raycast(transform.position,direction,1f);
        if (hit.transform.tag == "Map"){
            return false;
        }
        else return true;
    }
}
