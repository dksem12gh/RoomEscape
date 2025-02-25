using UnityEngine;
using UInteractive;
using MapSystem;
using REO;
using VRInteractiveSystem;

public class S_1_BadScenePlayerDisable : ObjectImplementMultyFncInterface
{
    ILocalPlayer localPlayer;
    IVRPlayer vrPlayer;

    public override void FncInit()
    {
        m_PlayActionList.Clear();

        m_PlayActionList.Add(DeactiveInput);
        m_PlayActionList.Add(ActiveInput);
    }

    public override void Init()
    {
        localPlayer = RoomEscapeOnline.Instance.LocalPlayer;
        vrPlayer = localPlayer.VrPlayer;
    }

    public override void Reset()
    {        
    }

    void ActiveInput()
    {
        vrPlayer.Active();
        ActFinish();
    }

    void DeactiveInput()
    {
        vrPlayer.DeActive();        

        ActFinish();
    }
}
