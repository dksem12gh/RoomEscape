using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace UInteractive
{
    public class S_1_SafeBoxSenser : MonoBehaviour
    {
        //배터리 불 센서
        public GameObject _sensor;
        public Texture _sensorTex;
        //초기화용
        public GameObject[] _numberPad;
        //처음 초기화 텍스트
        public Texture[] _numberTex;

        [SerializeField] PhotonView m_photonView = null;

        public ArrayIndexOnOffImplement[] _passworadOnOff;

        //랜덤숫자 받기
        public S_1_ScarRandomhint _scarNum;
        public S_1_SafeBoxPassworadTouch[] _touchPad;
        ArrayOnOffChecker _arrayOnOff = new ArrayOnOffChecker(4);

        //
        [SerializeField] Interactable m_activeInteractable = null;

        private void Awake()
        {
            for (int i = 0; i < _passworadOnOff.Length; i++)
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

        public void BatteryInsertSenserOn()
        {
            MaterialPropertyBlock mpb = new MaterialPropertyBlock();
            MaterialPropertyBlock mpbPad = new MaterialPropertyBlock();            
            
            mpbPad.SetTexture("_EmissionMap", _numberTex[0]);
            mpbPad.SetColor("_EmissionColor", new Color(1.0f, 1.0f, 1.0f));
            
            mpb.SetTexture("_EmissionMap", _sensorTex);
            mpb.SetColor("_EmissionColor", Color.red );

            for (int i = 0; i < _numberPad.Length; i++)
            {
                _numberPad[i].GetComponent<MeshRenderer>().SetPropertyBlock(mpbPad, 1);
            }

            _sensor.GetComponent<MeshRenderer>().SetPropertyBlock(mpb, 1);
        }

        public void BatteryInsertSenserOff()
        {
            MaterialPropertyBlock mpb = new MaterialPropertyBlock();
            MaterialPropertyBlock mpbPad = new MaterialPropertyBlock();
            
            mpbPad.SetTexture("_EmissionMap", _numberTex[0]);
            mpbPad.SetColor("_EmissionColor", new Color(0.01f, 0.01f, 0.01f));
            
            mpb.SetTexture("_EmissionMap", _sensorTex);
            mpb.SetColor("_EmissionColor", new Color(0.01f,0.01f,0.01f));

            for (int i = 0; i < _numberPad.Length; i++)
            {
                _numberPad[i].GetComponent<MeshRenderer>().SetPropertyBlock(mpbPad, 1);
            }

            _sensor.GetComponent<MeshRenderer>().SetPropertyBlock(mpb, 1);

            SafeBoxNumberStartCheck();
        }

        public void SuccessNumberSenserOn()
        {
            MaterialPropertyBlock mpb = new MaterialPropertyBlock();
            
            mpb.SetTexture("_EmissionMap", _sensorTex);
            mpb.SetColor("_EmissionColor", Color.green * 1);

            _sensor.GetComponent<MeshRenderer>().SetPropertyBlock(mpb, 1);
        }

        public void SafeBoxNumber01Check()
        {
            if(_touchPad[0]._num == _scarNum._scarNumber[0])
            {
                Debug.Log("세이프박스 01정답");
                _arrayOnOff.On(0);
                _passworadOnOff[0].ActImplement(0);
            }
            else
            {
                Debug.Log("세이프박스 01 틀림");
                _arrayOnOff.Off(0);
                _passworadOnOff[0].ActImplement(1);
            }
        }
        public void SafeBoxNumber02Check()
        {
            if (_touchPad[1]._num == _scarNum._scarNumber[1])
            {
                Debug.Log("세이프박스 02정답");
                _arrayOnOff.On(1);
                _passworadOnOff[1].ActImplement(0);
            }
            else
            {
                Debug.Log("세이프박스 02 틀림");
                _arrayOnOff.Off(1);
                _passworadOnOff[1].ActImplement(1);
            }
        }
        public void SafeBoxNumber03Check()
        {
            if (_touchPad[2]._num == _scarNum._scarNumber[2])
            {
                Debug.Log("세이프박스 03정답");
                _arrayOnOff.On(2);
                _passworadOnOff[2].ActImplement(0);
            }
            else
            {
                Debug.Log("세이프박스 03 틀림");
                _arrayOnOff.Off(2);
                _passworadOnOff[2].ActImplement(1);
            }
        }
        public void SafeBoxNumber04Check()
        {
            if (_touchPad[3]._num == _scarNum._scarNumber[3])
            {
                Debug.Log("세이프박스 04정답");
                _arrayOnOff.On(3);
                _passworadOnOff[3].ActImplement(0);
            }
            else
            {
                Debug.Log("세이프박스 04 틀림");
                _arrayOnOff.Off(3);
                _passworadOnOff[3].ActImplement(1);
            }
        }
        public void SafeBoxNumberStartCheck()
        {
            SafeBoxNumber01Check();
            SafeBoxNumber02Check();
            SafeBoxNumber03Check();
            SafeBoxNumber04Check();
        }
    }    
}
