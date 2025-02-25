using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace REO
{
    public class S_1_ShootLaser1 : MonoBehaviour
    {
        public Material material;
        S_1_BouncingBeam laser;

        private void Update()
        {
            StartCoroutine("CustomUpdate");
        }

        private void OnDisable()
        {
            StopCoroutine("CustomUpdate");
        }

        IEnumerator CustomUpdate()
        {
            //Destroy(GameObject.Find("LaserBeam1"));
            //gameObject.transform.localRotation = Quaternion.Euler(0, 6f, 0);
            laser = new S_1_BouncingBeam(gameObject.transform.position, gameObject.transform.forward, material,1, gameObject.transform);

            yield return new WaitForSeconds(3.0f);
        }

    }
}
