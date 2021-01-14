using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GeneratorData : ScriptableObject
{
    [SerializeField]
    private List<RoomList> RoomLists;
    [SerializeField]
    private Vector2 MapSize;
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

    public Vector2 GetMapSize(){
        return MapSize;
    }
    
    public Vector2 GetRoomSize(){
        return RoomSize;
    }
}

