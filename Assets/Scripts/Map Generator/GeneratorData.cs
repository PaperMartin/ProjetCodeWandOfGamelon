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
    [SerializeField]
    private MapRoom StartRoomTop;
    [SerializeField]
    private MapRoom StartRoomBottom;
    [SerializeField]
    private MapRoom StartRoomLeft;
    [SerializeField]
    private MapRoom StartRoomRight;

    [SerializeField]
    private MapRoom EndRoomTop;
    [SerializeField]
    private MapRoom EndRoomBottom;
    [SerializeField]
    private MapRoom EndRoomLeft;
    [SerializeField]
    private MapRoom EndRoomRight;

    public MapRoom PullRandomRoom(DoorConfiguration DoorConfig)
    {
        foreach (RoomList roomList in RoomLists)
        {
            if (DoorConfiguration.CompareConfigs(DoorConfig, roomList.config))
            {
                return roomList.GetRandomRoom();
            }
        }
        return null;
    }

    public MapRoom PullStartRoom(DoorConfiguration DoorConfig)
    {
        if (DoorConfig.TopOpen == true)
        {
            return StartRoomTop;
        }
        if (DoorConfig.BottomOpen == true)
        {
            return StartRoomBottom;
        }
        if (DoorConfig.LeftOpen == true)
        {
            return StartRoomLeft;
        }
        if (DoorConfig.RightOpen == true)
        {
            return StartRoomRight;
        }
        return null;
    }

    public MapRoom PullEndRoom(DoorConfiguration DoorConfig)
    {
        if (DoorConfig.TopOpen == true)
        {
            return EndRoomTop;
        }
        if (DoorConfig.BottomOpen == true)
        {
            return EndRoomBottom;
        }
        if (DoorConfig.LeftOpen == true)
        {
            return EndRoomLeft;
        }
        if (DoorConfig.RightOpen == true)
        {
            return EndRoomRight;
        }
        return null;
    }

    public int GetLevelLength()
    {
        return DungeonLength;
    }

    public Vector2Int GetMapSize()
    {
        return MapSize;
    }

    public Vector2 GetRoomSize()
    {
        return RoomSize;
    }
}
