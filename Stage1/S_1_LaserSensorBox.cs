using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace UInteractive
{
    public class S_1_LaserSensorBox : MonoBehaviour
    {
        [SerializeField] PhotonView m_photonView = null;
        [SerializeField] Interactable m_activeInteractable = null;

        public ArrayIndexOnOffImplement[] _sensorOnOff;
        ArrayOnOffChecker _arrayOnOff = new ArrayOnOffChecker(2);

        //0 == right 1 == left
        public S_1_LaserSensorTime[] _colSensorTime;        

        public GameObject _leftLightSensor;
        public GameObject _rightLightSensor;

        public GameObject[] _boxSensor;

        public Material _greenMat;
        public Material _redMat;

        public Texture _redSensor;
        public Texture _greenMiniSensor;

        public AudioClip[] _laserSound;
        public AudioSource _laserAudioSource;

        float time = 0;
        bool[] beam = new bool[4];

        private void Awake()
        {
            for (int i = 0; i < _sensorOnOff.Length; i++)
            {
                _sensorOnOff[i].DataInit(_arrayOnOff, i);
            }

            beam[0] = false;
            beam[1] = false;
            beam[2] = false;
            beam[3] = false;

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

        private void Update()
        {
            StartCoroutine(LaserTimeCount(_colSensorTime[0].laser, _colSensorTime[1].laser));

            StartCoroutine(LightSensorCourtine(_greenMiniSensor,_boxSensor,time,_laserAudioSource,_laserSound[0]));

            StartCoroutine(LightSensor(_rightLightSensor, _redSensor, time, _colSensorTime[0].laser, 0, _sensorOnOff[0]));
            StartCoroutine(LightSensor(_leftLightSensor, _redSensor, time, _colSensorTime[1].laser, 1, _sensorOnOff[1]));
        }

        public void stopLaserSensor()
        {
            StopCoroutine("LightSensorCourtine");            
        }

        IEnumerator LaserTimeCount(bool leftBox , bool rightBox)
        {
            if (leftBox && rightBox)
            {
                time += Time.deltaTime;
                if (time >= 5)
                    time = 5;
            }
            else if (!leftBox && !rightBox)
            {
                time -= Time.deltaTime * 2f;
                if (time <= 0)
                    time = 0;
            }
            else
            {
                time -= Time.deltaTime * 2f;
                if (time <= 0)
                    time = 0;
            }

            yield return new WaitForSeconds(0.5f);
        }

        IEnumerator LightSensorCourtine(Texture mtex ,GameObject[] sensor,float time, AudioSource audioSource, AudioClip clip)
        {
            MaterialPropertyBlock mpbChildOn = new MaterialPropertyBlock();
            mpbChildOn.SetColor(Shader.PropertyToID("_Color"), Color.green);
            mpbChildOn.SetTexture("_EmissionMap", mtex);
            mpbChildOn.SetColor("_EmissionColor", Color.green);

            if (time >= 0 && time < 1)
            {
                sensor[0].GetComponent<MeshRenderer>().SetPropertyBlock(null, 1);
                sensor[1].GetComponent<MeshRenderer>().SetPropertyBlock(null, 1);
                sensor[2].GetComponent<MeshRenderer>().SetPropertyBlock(null, 1);
                sensor[3].GetComponent<MeshRenderer>().SetPropertyBlock(null, 1);
                beam[0] = false;
                beam[1] = false;
                beam[2] = false;
                beam[3] = false;
            }
            else if (time >= 1 && time < 2)
            {
                sensor[0].GetComponent<MeshRenderer>().SetPropertyBlock(mpbChildOn, 1);
                sensor[1].GetComponent<MeshRenderer>().SetPropertyBlock(null, 1);
                sensor[2].GetComponent<MeshRenderer>().SetPropertyBlock(null, 1);
                sensor[3].GetComponent<MeshRenderer>().SetPropertyBlock(null, 1);
                audioSource.clip = clip;
                if (!audioSource.isPlaying && beam[0] == false)
                {
                    audioSource.Play();
                    beam[0] = true;
                }

                beam[1] = false;
                beam[2] = false;
                beam[3] = false;
            }
            else if (time >= 2 && time < 3)
            {                
                sensor[0].GetComponent<MeshRenderer>().SetPropertyBlock(mpbChildOn, 1);
                sensor[1].GetComponent<MeshRenderer>().SetPropertyBlock(mpbChildOn, 1);
                sensor[2].GetComponent<MeshRenderer>().SetPropertyBlock(null, 1);
                sensor[3].GetComponent<MeshRenderer>().SetPropertyBlock(null, 1);
                audioSource.clip = clip;
                if (beam[1] == false)
                {
                    audioSource.Play();
                    beam[1] = true;
                }

                beam[2] = false;
                beam[3] = false;
            }
            else if (time >= 3 && time < 4)
            {
                sensor[0].GetComponent<MeshRenderer>().SetPropertyBlock(mpbChildOn, 1);
                sensor[1].GetComponent<MeshRenderer>().SetPropertyBlock(mpbChildOn, 1);
                sensor[2].GetComponent<MeshRenderer>().SetPropertyBlock(mpbChildOn, 1);
                sensor[3].GetComponent<MeshRenderer>().SetPropertyBlock(null, 1);
                audioSource.clip = clip;
                if (beam[2] == false)
                {
                    audioSource.Play();
                    beam[2] = true;
                }
                
                beam[3] = false;
            }
            else if (time >= 4 && time < 5)
            {
                sensor[0].GetComponent<MeshRenderer>().SetPropertyBlock(mpbChildOn, 1);
                sensor[1].GetComponent<MeshRenderer>().SetPropertyBlock(mpbChildOn, 1);
                sensor[2].GetComponent<MeshRenderer>().SetPropertyBlock(mpbChildOn, 1);
                sensor[3].GetComponent<MeshRenderer>().SetPropertyBlock(mpbChildOn, 1);
                audioSource.clip = clip;
                if (beam[3] == false)
                {
                    audioSource.Play();
                    beam[3] = true;
                }
            }
            else if (time >= 5)
            {
                sensor[0].GetComponent<MeshRenderer>().SetPropertyBlock(mpbChildOn, 1);
                sensor[1].GetComponent<MeshRenderer>().SetPropertyBlock(mpbChildOn, 1);
                sensor[2].GetComponent<MeshRenderer>().SetPropertyBlock(mpbChildOn, 1);
                sensor[3].GetComponent<MeshRenderer>().SetPropertyBlock(mpbChildOn, 1);
                //audioSource[3].PlayOneShot(clip);
            }

            yield return new WaitForSeconds(1.0f);
        }


        IEnumerator LightSensor(GameObject sensor , Texture tex ,float time , bool onOff , int checker,ArrayIndexOnOffImplement implement)
        {
            MaterialPropertyBlock mpb = new MaterialPropertyBlock();
            mpb.SetColor(Shader.PropertyToID("_Color"), Color.red);
            mpb.SetTexture("_EmissionMap", tex);
            mpb.SetColor("_EmissionColor", Color.red * 2);

            if (onOff)
            {
                sensor.GetComponent<MeshRenderer>().SetPropertyBlock(mpb, 1);
            }
            else
            {
                sensor.GetComponent<MeshRenderer>().SetPropertyBlock(null, 1);

                _arrayOnOff.Off(checker);
                implement.ActImplement(1);
            }

            if (time >= 5)
            {
                mpb.SetColor(Shader.PropertyToID("_Color"), Color.green);
                mpb.SetTexture("_EmissionMap", tex);
                mpb.SetColor("_EmissionColor", Color.green * 1.0f);

                sensor.GetComponent<MeshRenderer>().SetPropertyBlock(mpb, 1);

                _arrayOnOff.Off(checker);
                implement.ActImplement(0);
            }

            yield return new WaitForSeconds(1.0f);
        }

        public void enalbeBoxScript()
        {
            this.gameObject.GetComponent<S_1_LaserSensorBox>().enabled = false;
        }
    }
}
