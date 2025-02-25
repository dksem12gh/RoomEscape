using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using REO;

public class S_1_LocalPlayerLight : MonoBehaviour
{



    public void LocalPlayerLightOn()
    {
        RoomEscapeOnline.Instance.LocalPlayer.Lighting.LightingOn();
    }

    public void LocalPlayerLightOff()
    {
        RoomEscapeOnline.Instance.LocalPlayer.Lighting.LightingOff();
    }
}
