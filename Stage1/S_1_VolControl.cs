using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UInteractive.Implement;

namespace REO
{
    public class S_1_VolControl : MonoBehaviour
    {
        [SerializeField] private Volume volume;
        [SerializeField] private float _time;

        Bloom bloom;
        float time = 0;

        public void LerpProgress()
        {
            StartCoroutine("BloomThreshold");
        }

        IEnumerator BloomThreshold()
        {            
            while (bloom.threshold.value > 0)
            {
                time += Time.deltaTime / _time;

                bloom.threshold.value = Mathf.Lerp(0.9f, 0.1f, time);

                yield return null;
            }
        }


        private void Awake()
        {
            volume.profile.TryGet(out bloom);
            bloom.threshold.value = 0.9f;
        }
    }
}
