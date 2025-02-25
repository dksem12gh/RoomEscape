using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UInteractive.Pun2;
using Photon.Pun;

namespace UInteractive
{
    public class S_1_PasswordLockCheck : EventSolutionData
    {
        [SerializeField] PhotonView m_photonView = null;

        public S_1_PasswordLockRotate[] _passworadLockValue;
        public ArrayIndexOnOffImplement[] _passworadOnOff;
        [SerializeField] Interactable m_activeInteractable = null;

        ArrayOnOffChecker _arrayOnOff = new ArrayOnOffChecker(4);

        public override int[] Data
        { 
            get => m_solution; 
            set => m_solution = value; 
        }

        private void Awake()
        {
           for( int i = 0 ; i <_passworadOnOff.Length; i++)
            {
                _passworadOnOff[i].DataInit(_arrayOnOff, i);
            }

            if (true == PhotonNetwork.IsMasterClient)
                _arrayOnOff.OnSuccess += SuccessEvent;
        }

        void SuccessEvent()
        {
            m_photonView.RPC("SuccessReceive", RpcTarget.All);
        }

        [PunRPC]
        void SuccessReceive()
        {
            if (null != m_activeInteractable)
                m_activeInteractable.Interact();
        }
        public void PassworadCheck01()
        {

            //m_solution[0] ~ 4 link연결한 랜덤값 받아오기
            if (_passworadLockValue[0].number != 9)
            {
                _arrayOnOff.Off(0);
                _passworadOnOff[0].ActImplement(1);                          
            }            
            else
            {
                _arrayOnOff.On(0);
                _passworadOnOff[0].ActImplement(0);

                Debug.Log("처음번호 정답!");                
            }
        }
        public void PassworadCheck02()
        {
            if (_passworadLockValue[1].number != 8)
            {
                _arrayOnOff.Off(1);
                _passworadOnOff[1].ActImplement(1);
            }
            else
            {
                _arrayOnOff.On(1);
                _passworadOnOff[1].ActImplement(0);

                Debug.Log("두번째번호 정답!");                
            }
        }

        public void PassworadCheck03()
        {
            if (_passworadLockValue[2].number != 1)
            {
                _arrayOnOff.Off(2);
                _passworadOnOff[2].ActImplement(1);                
            }
            else
            {
                _arrayOnOff.On(2);
                _passworadOnOff[2].ActImplement(0);

                Debug.Log("세번째번호 정답!");                
            }
        }

        public void PassworadCheck04()
        {
            if (_passworadLockValue[3].number != 2)
            {
                _arrayOnOff.Off(3);
                _passworadOnOff[3].ActImplement(1);                
            }
            else
            {
                _arrayOnOff.On(3);
                _passworadOnOff[3].ActImplement(0);

                Debug.Log("네번째번호 정답!");                
            }
        }
    }
}
