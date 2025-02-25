using UnityEngine;
using UInteractive;
using MapSystem;
using REO;
using VRInteractiveSystem;

public class S_1_PlayerTeleport : ObjectImplementMultyFncInterface
{
    [SerializeField] PlayerLocations playerLocations;
    [SerializeField] ShareInt trickIdx;

    ILocalPlayer localPlayer;
    IVRPlayer vrPlayer;

    public override void Init()
    {
        localPlayer = RoomEscapeOnline.Instance.LocalPlayer;
        vrPlayer = localPlayer.VrPlayer;        
    }

    public override void FncInit()
    {
        m_PlayActionList.Clear();

        m_PlayActionList.Add(TeleportPlayer);
        m_PlayActionList.Add(ActiveInput);
        m_PlayActionList.Add(DeactiveInput);        
    }

    public override void Reset()
    {
    }

    //함수 작성 이후 반드시 ActFinish() 호출
    void TeleportPlayer()
    {
        Transform tm = playerLocations.GetLocation(trickIdx.m_value);

        localPlayer.SetPosition(tm.position);

        ActFinish();
    }

    void ActiveInput()
    {
        vrPlayer.LeftHandGrab.GrabUp();
        vrPlayer.RightHandGrab.GrabUp();

        vrPlayer.Active();        
        ActFinish();
    }

    void DeactiveInput()
    {        
        vrPlayer.DeActive();        

        ActFinish();
    }
}