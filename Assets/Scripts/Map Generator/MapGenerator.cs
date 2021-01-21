using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField]
    private GeneratorData data;

    private List<Vector2Int> Directions = new List<Vector2Int>();

    private void Start()
    {
        GenerateMap();
    }

    private void GenerateMap()
    {
        GeneratedMap generatedMap = new GeneratedMap();
        generatedMap.SetRoomSize(data.GetRoomSize());
        List<Vector2Int> RoomPositions = GeneratePath(data.GetMapSize());
        TempSpawnPath(RoomPositions);

    }

    private List<Vector2Int> GeneratePath(Vector2Int MapSize)
    {
        Directions.Clear();
        Directions.Add(Vector2Int.up);
        Directions.Add(Vector2Int.down);
        Directions.Add(Vector2Int.left);
        Directions.Add(Vector2Int.right);

        List<Vector2Int> Path = new List<Vector2Int>();
        Vector2Int StartPosition = new Vector2Int(Random.Range(0, MapSize.x), Random.Range(0, MapSize.y));
        Path.Add(StartPosition);
        PickNextPathPart(Path);
        return Path;
    }

    private List<DoorConfiguration> GenerateDoorConfig(List<Vector2Int> path)
    {
        List<DoorConfiguration> doorconfig = new List<DoorConfiguration>();
        for (int i = 0; i < path.Count; i++)
        {
            DoorConfiguration CurrentConfig = new DoorConfiguration();
            if (i != 0)
            {
                if (path[i - 1].x > path[i].x)
                {
                    CurrentConfig.RightOpen = true;
                }
                if (path[i - 1].x < path[i].x)
                {
                    CurrentConfig.LeftOpen = true;
                }
                if (path[i - 1].y > path[i].y)
                {
                    CurrentConfig.TopOpen = true;
                }
                if (path[i - 1].y < path[i].y)
                {
                    CurrentConfig.BottomOpen = true;
                }
            }

            if (i != path.Count - 1)
            {
                if (path[i + 1].x > path[i].x)
                {
                    CurrentConfig.RightOpen = true;
                }
                if (path[i + 1].x < path[i].x)
                {
                    CurrentConfig.LeftOpen = true;
                }
                if (path[i + 1].y > path[i].y)
                {
                    CurrentConfig.TopOpen = true;
                }
                if (path[i + 1].y < path[i].y)
                {
                    CurrentConfig.BottomOpen = true;
                }
            }

            doorconfig.Add(CurrentConfig);
        }

        return doorconfig;
    }

    //temp function
    private void TempSpawnPath(List<Vector2Int> path)
    {
        foreach (Vector2Int room in path)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = new Vector3(room.x * 2, room.y * 2, 0);
        }
    }

    private bool PickNextPathPart(List<Vector2Int> path)
    {
        if (path.Count == data.GetLevelLength())
        {
            return true;
        }
        Vector2Int CurrentPosition = path[path.Count - 1];
        ShuffleDirections();
        Vector2Int Pos1 = CurrentPosition + Directions[0];
        Vector2Int Pos2 = CurrentPosition + Directions[1];
        Vector2Int Pos3 = CurrentPosition + Directions[2];
        Vector2Int Pos4 = CurrentPosition + Directions[3];

        //Try continuing path with pos 1
        if (Pos1.x >= 0 && Pos1.x <= data.GetMapSize().x - 1 && Pos1.y >= 0 && Pos1.y <= data.GetMapSize().y - 1 && !path.Contains(Pos1))
        {
            path.Add(Pos1);
            if (PickNextPathPart(path))
            {
                //Return true if path is viable
                return true;
            }
            else
            {
                path.Remove(Pos1);
            }
        }

        //Try continuing path with pos 2
        if (Pos2.x >= 0 && Pos2.x <= data.GetMapSize().x - 1 && Pos2.y >= 0 && Pos2.y <= data.GetMapSize().y - 1 && !path.Contains(Pos2))
        {
            path.Add(Pos2);
            if (PickNextPathPart(path))
            {
                return true;
            }
            else
            {
                path.Remove(Pos2);
            }
        }

        //Try continuing path with pos 3
        if (Pos3.x >= 0 && Pos3.x <= data.GetMapSize().x - 1 && Pos3.y >= 0 && Pos3.y <= data.GetMapSize().y - 1 && !path.Contains(Pos3))
        {
            path.Add(Pos3);
            if (PickNextPathPart(path))
            {
                return true;
            }
            else
            {
                path.Remove(Pos3);
            }
        }

        //Try continuing path with pos 4
        if (Pos4.x >= 0 && Pos4.x <= data.GetMapSize().x - 1 && Pos4.y >= 0 && Pos3.y <= data.GetMapSize().y - 1 && !path.Contains(Pos4))
        {
            path.Add(Pos4);
            if (PickNextPathPart(path))
            {
                return true;
            }
            else
            {
                path.Remove(Pos4);
            }
        }

        //Return false if no viable path
        return false;
    }

    private void ShuffleDirections()
    {
        for (int i = 0; i < Directions.Count; i++)
        {
            Vector2Int temp = Directions[i];
            int randomIndex = Random.Range(i, Directions.Count);
            Directions[i] = Directions[randomIndex];
            Directions[randomIndex] = temp;
        }


    }
}