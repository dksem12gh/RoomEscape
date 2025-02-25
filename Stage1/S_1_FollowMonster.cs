using UInteractive;
using UnityEngine;
using System.Collections;

namespace REO
{    
    public class S_1_FollowMonster : ObjectImplementMultyFncInterface
    {
        Coroutine coroutine;

        public override void Init()
        {
        }

        public override void FncInit()
        {
            m_PlayActionList.Clear();
            m_PlayActionList.Add(StartFollow);
            m_PlayActionList.Add(Finish);
        }

        public override void Reset()
        {
        }


        public void StartFollow()
        {
            coroutine = StartCoroutine(Follow(RoomEscapeOnline.Instance.LocalPlayer.VrPlayer.Head));

            // 함수 작성 이후 반드시 ActFinish() 호출.
            ActFinish();
        }

        IEnumerator Follow(Transform tr)
        {
            while (true)
            {
                this.transform.position = tr.position;
                this.transform.rotation = tr.rotation;

                yield return null;
            }
        }


        public void Finish()
        {
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
                coroutine = null;
            }
        }
    }
}
