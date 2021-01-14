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

    private void PullRandomRoom(){

    }
}

