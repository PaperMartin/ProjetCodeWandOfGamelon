using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratedMap
{
    private Vector2 roomSize;
    private MapRoom[,] map;

    public Vector2Int MapSize { get ; private set ;}

    public MapRoom GetRoomAtPosition(Vector2Int pos){
        return map[pos.x, pos.y];
    }

    public Vector2 GetRoomSize(){
        return roomSize;
    }

    public void SetMap(MapRoom[,] NewMap){
        map = NewMap;
    }

    public void SetRoomSize(Vector2 RoomSize){
        roomSize = RoomSize;
    }
}
