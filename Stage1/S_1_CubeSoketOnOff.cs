using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace UInteractive
{
    public class S_1_CubeSoketOnOff : MonoBehaviour
    {
        [SerializeField] PhotonView m_photonView = null;

        ArrayOnOffChecker _arrayOnOff = new ArrayOnOffChecker(1);
        public ArrayIndexOnOffImplement _socketOnOff;

        [SerializeField] Interactable m_activeInteractable = null;

        private void Awake()
        {
            _socketOnOff.DataInit(_arrayOnOff, 0);

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
            _socketOnOff.ActImplement(0);

        }
        public void Socket01Off()
        {
            _arrayOnOff.Off(0);
            _socketOnOff.ActImplement(1);
        }
    }
}
