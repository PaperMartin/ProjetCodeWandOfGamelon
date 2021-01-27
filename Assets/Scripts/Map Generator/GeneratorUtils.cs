using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct DoorConfiguration{
    public bool TopOpen;
    public bool BottomOpen;
    public bool LeftOpen;
    public bool RightOpen;

    public static bool CompareConfigs(DoorConfiguration FirstConfig, DoorConfiguration SecondConfig){

        if(FirstConfig.TopOpen != SecondConfig.TopOpen){
            return false;
        }
        
        if(FirstConfig.BottomOpen != SecondConfig.BottomOpen){
            return false;
        }

        if(FirstConfig.LeftOpen != SecondConfig.LeftOpen){
            return false;
        }

        if(FirstConfig.RightOpen != SecondConfig.RightOpen){
            return false;
        }
        
        return true;
    }
}