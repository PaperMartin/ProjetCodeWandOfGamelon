using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GeneratorData : ScriptableObject
{
    [SerializeField]
    private int DungeonLength;
    [SerializeField]
    private List<RoomList> RoomLists;
    [SerializeField]
    private Vector2Int MapSize;
    [SerializeField]
    private Vector2 RoomSize;

    public MapRoom PullRandomRoom(DoorConfiguration DoorConfig){
        foreach(RoomList roomList in RoomLists){
            if (DoorConfiguration.CompareConfigs(DoorConfig, roomList.config)){
                return roomList.GetRandomRoom();
            }
        }
        return null;
    }

    public int GetLevelLength(){
        return DungeonLength;
    }

    public Vector2Int GetMapSize(){
        return MapSize;
    }
    
    public Vector2 GetRoomSize(){
        return RoomSize;
    }
}
