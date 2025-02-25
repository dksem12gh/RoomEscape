using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace UInteractive
{
    public class S_1_SocketArrayOnOff : MonoBehaviour
    {
        [SerializeField] PhotonView m_photonView = null;

        ArrayOnOffChecker _arrayOnOff = new ArrayOnOffChecker(4);
        public ArrayIndexOnOffImplement[] _socketOnOff;

        [SerializeField] Interactable m_activeInteractable = null;

        private void Awake()
        {
            for (int i = 0; i < _socketOnOff.Length; i++)
            {
                _socketOnOff[i].DataInit(_arrayOnOff, i);
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


        public void Socket01On()
        {
            _arrayOnOff.On(0);
            _socketOnOff[0].ActImplement(0);

        }
        public void Socket01Off()
        {
            _arrayOnOff.Off(0);
            _socketOnOff[0].ActImplement(1);
        }

        public void Socket02On()
        {
            _arrayOnOff.On(1);
            _socketOnOff[1].ActImplement(0);
        }
        public void Socket02Off()
        {
            _arrayOnOff.Off(1);
            _socketOnOff[1].ActImplement(1);
        }
        public void Socket03On()
        {
            _arrayOnOff.On(2);
            _socketOnOff[2].ActImplement(0);
        }
        public void Socket03Off()
        {
            _arrayOnOff.Off(2);
            _socketOnOff[2].ActImplement(1);
        }
        public void Socket04On()
        {
            _arrayOnOff.On(3);
            _socketOnOff[3].ActImplement(0);
        }
        public void Socket04Off()
        {
            _arrayOnOff.Off(3);
            _socketOnOff[3].ActImplement(1);
        }
    }
}
