using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class MapRoom : ScriptableObject {
    [SerializeField]
    private GameObject RoomPrefab;
    
    public GameObject GetRoomPrefab(){
        return RoomPrefab;
    }
}