using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTargetToRandomDirection : MonoBehaviour
{
    [SerializeField]
    private Walk walk;
    [SerializeField]
    private Pathfinder pathfinder;
    [SerializeField]
    private float DirectionChangeCooldown = 1f;

    private enum directions
    {
        up,
        down,
        left,
        right
    }

    private List<directions> directionList = new List<directions>();
    
    private float CurrentCooldown;

    // Start is called before the first frame update
    void Start()
    {
        directionList.Add(directions.up);
        directionList.Add(directions.down);
        directionList.Add(directions.left);
        directionList.Add(directions.right);
        CurrentCooldown = DirectionChangeCooldown;
        ChangeDirection();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentCooldown -= Time.deltaTime;
        if (CurrentCooldown <= 0){
            ChangeDirection();
            CurrentCooldown = DirectionChangeCooldown;
        }
    }

    private void ChangeDirection()
    {
        ShuffleDirections(directionList);
        Vector2 NewDirection = Vector2.zero;
        foreach (directions direction in directionList)
        {
            switch (direction)
            {
                case directions.up:
                    {
                        if (pathfinder.CanWalkUp())
                        {
                            walk.direction = Vector2.up;
                            walk.walkHorizontal = false;
                            return;
                        }
                        break;
                    }
                case directions.down:
                    {
                        if (pathfinder.CanWalkDown())
                        {
                            walk.direction = Vector2.down;
                            walk.walkHorizontal = false;
                            return;
                        }
                        break;
                    }
                case directions.left:
                    {
                        if (pathfinder.CanWalkLeft())
                        {
                            walk.direction = Vector2.left;
                            walk.walkHorizontal = true;
                            return;
                        }
                        break;
                    }
                case directions.right:
                    {
                        if (pathfinder.CanWalkRight())
                        {
                            walk.direction = Vector2.right;
                            walk.walkHorizontal = true;
                            return;
                        }
                        break;
                    }

                default: break;
            }
        }
    }

    private void ShuffleDirections(List<directions> Directions)
    {
        for (int i = 0; i < Directions.Count; i++)
        {
            directions temp = Directions[i];
            int randomIndex = Random.Range(i, Directions.Count);
            Directions[i] = Directions[randomIndex];
            Directions[randomIndex] = temp;
        }


    }
}
