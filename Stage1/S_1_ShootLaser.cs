using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace REO
{
    public class S_1_ShootLaser : MonoBehaviour
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
            //Destroy(GameObject.Find("LaserBeam"));
            //gameObject.transform.localRotation = Quaternion.Euler(0, -3.5f, 0);
            laser = new S_1_BouncingBeam(gameObject.transform.position, gameObject.transform.forward, material,0 , gameObject.transform);

            yield return new WaitForSeconds(3.0f);
        }

    }
}
