using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using USerializableObject;
using System.Threading;

namespace REO
{
    public class S_1_NarationPlayerState : SwitchNarationPlayer, INarationPlayerCondition
    {
        [SerializeField] private NarationSpeaker m_Speaker = null;

        [SerializeField] private SerializableObject<INarationPlayer> _Trick01Check;
        [SerializeField] private SerializableObject<INarationPlayer> _Trick02Check;
        [SerializeField] private SerializableObject<INarationPlayer> _Trick03Check;
        [SerializeField] private SerializableObject<INarationPlayer> _Trick04Check;        

        public bool[] _trickClear = new bool[4];

        private void Awake()
        {
            _trickClear[0] = false;
            _trickClear[1] = false;
            _trickClear[2] = false;
            _trickClear[3] = false;
        }

        private void Reset()
        {
            m_Speaker = GameObject.FindObjectOfType<NarationSpeaker>();
        }

        protected override bool TryGetSatisfiedNarationPlayer(out INarationPlayer outPlayer)
        {
            bool willPlay = false;
            outPlayer = null;
            AudioSource _audioSource = GetComponent<AudioSource>();

            /*_trickClear[0] = StageSharedDataComponent.Instance.TryGetValue("S1_Trick01", out var t1);
            _trickClear[1] = StageSharedDataComponent.Instance.TryGetValue("S1_Trick02", out var t2);
            _trickClear[2] = StageSharedDataComponent.Instance.TryGetValue("S1_Trick03", out var t3);
            _trickClear[3] = StageSharedDataComponent.Instance.TryGetValue("S1_Trick04", out var t4);*/
            
            //1완료전
            if (!_trickClear[0] & !_trickClear[1] & !_trickClear[2] & !_trickClear[3])
            {
                // casting 이후, 처리
                m_Speaker.PushAndPlay(_Trick01Check.Ref);
                willPlay = true;
            }
            //2완료전
            else if (_trickClear[0] & !_trickClear[1] & !_trickClear[2] & !_trickClear[3])
            {
                // casting 이후, 처리
                m_Speaker.PushAndPlay(_Trick02Check.Ref);
                willPlay = true;
            }
            //3완료전
            else if (_trickClear[0] & _trickClear[1] & !_trickClear[2] & !_trickClear[3])
            {
                // casting 이후, 처리
                m_Speaker.PushAndPlay(_Trick03Check.Ref);
                willPlay = true;
            }
            //4완료전
            else if (_trickClear[0] & _trickClear[1] & _trickClear[2] & !_trickClear[3])
            {
                // casting 이후, 처리
                m_Speaker.PushAndPlay(_Trick04Check.Ref);
                willPlay = true;
            }
            //완료
            else if (_trickClear[0] & _trickClear[1] & _trickClear[2] & _trickClear[3])
            {
                // casting 이후, 처리
                // 
                willPlay = true;
            }

            //조건체크                                    \

            return willPlay;            
        }
        
        public void S1_Trick01Clear()
        {
            //StageSharedDataComponent.Instance.Add("S1_Trick01", true);
            _trickClear[0] = true;
        }
        public void S1_Trick01False()
        {
            //StageSharedDataComponent.Instance.Add("S1_Trick01", false);
            _trickClear[0] = false;
        }

        public void S1_Trick02Clear()
        {
            //StageSharedDataComponent.Instance.Add("S1_Trick02", true);
            _trickClear[1] = true;
        }
        public void S1_Trick02False()
        {
            //StageSharedDataComponent.Instance.Add("S1_Trick02", false);
            _trickClear[1] = false;
        }

        public void S1_Trick03Clear()
        {
            //StageSharedDataComponent.Instance.Add("S1_Trick03", true);
            _trickClear[2] = true;
        }
        public void S1_Trick03False()
        {
            //StageSharedDataComponent.Instance.Add("S1_Trick03", false);
            _trickClear[2] = false;
        }
        public void S1_Trick04Clear()
        {
            //StageSharedDataComponent.Instance.Add("S1_Trick04", true);
            _trickClear[3] = true;
        }
        public void S1_Trick04False()
        {
            //StageSharedDataComponent.Instance.Add("S1_Trick04", false);
            _trickClear[3] = false;
        }
    }
}
