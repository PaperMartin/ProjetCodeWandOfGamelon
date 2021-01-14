using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class RoomList : ScriptableObject{
    public DoorConfiguration config;
    [SerializeField]
    private List<MapRoom> Rooms;

    //TODO
    private MapRoom GetRandomRoom(){
        return null;
    }
}