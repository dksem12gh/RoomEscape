using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace REO
{
    public class S_1_LightLenseEmission : MonoBehaviour
    {
       public void onLenseEmission()
        {
            MaterialPropertyBlock mpb = new MaterialPropertyBlock();            
            mpb.SetColor("_EmissionColor", new Color(0.2f, 0, 0.75f) * 1.0f);

            this.gameObject.GetComponent<MeshRenderer>().SetPropertyBlock(mpb, 0);
        }
    }
}
