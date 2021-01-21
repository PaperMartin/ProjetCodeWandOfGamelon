using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class RoomList : ScriptableObject{
    public DoorConfiguration config;
    [SerializeField]
    private List<MapRoom> Rooms;

    //TODO
    public MapRoom GetRandomRoom(){
        return Rooms[Random.Range(0, Rooms.Count)];
    }
}