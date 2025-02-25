using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace REO
{
    public class S_1_MonsterAnimationPlay : MonoBehaviour
    {
        public Animator monsterAnimator;

        public AudioClip[] monsterSounds;
        public AudioSource audioSource;

        private void Awake()
        {
            MonsterBreathStart();
        }

        private void OnDisable()
        {
            MonsterBreathStop();
        }

        private void OnTriggerEnter(Collider other)
        {
            int num = Random.Range(0, 2);

            MonsterBreathStop();

            if (num == 0)
            {
                monsterAnimator.SetTrigger("PrisonAttack");

                StartCoroutine("DelayTime", 0.9f);
            }
            else
            {
                audioSource.clip = monsterSounds[1];
                audioSource.Play();
                monsterAnimator.SetTrigger("PrisonAttack_2");
            }

            MonsterBreathStart();

            gameObject.GetComponent<BoxCollider>().enabled = false;
        }

        public void triggerColOn()
        {
            gameObject.GetComponent<BoxCollider>().enabled = true;
        }

        public void MonsterBreathStop()
        {
            StopCoroutine("MonsterBreath");
        }

        public void MonsterBreathStart()
        {
            StartCoroutine("MonsterBreath");
        }

        IEnumerator MonsterBreath()
        {
            yield return new WaitUntil(() => audioSource.isPlaying == false);

            audioSource.clip = monsterSounds[2];
            audioSource.Play();            

            yield return new WaitForSeconds(Random.Range(30, 40));

            StartCoroutine("MonsterBreath");
        }

        IEnumerator DelayTime(float time)
        {
            yield return new WaitForSeconds(time);
            audioSource.clip = monsterSounds[0];
            audioSource.Play();
        }
    }
}
