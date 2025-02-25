using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace REO
{
    public class S_1_LightEmission : MonoBehaviour
    {
        public Texture _tex;

        bool lightOn = false;

        public void onEmissionMap()
        {
            if (lightOn) return;

            MaterialPropertyBlock mpb = new MaterialPropertyBlock();
            
            mpb.SetTexture("_EmissionMap", _tex);
            mpb.SetColor("_EmissionColor", Color.white * 7);

            this.gameObject.GetComponent<MeshRenderer>().SetPropertyBlock(mpb,0);
        }

        public void offEmissionMap()
        {
            MaterialPropertyBlock mpb = new MaterialPropertyBlock();

            mpb.SetTexture("_EmissionMap", _tex);
            mpb.SetColor("_EmissionColor", new Color(1,0,0));
            this.gameObject.GetComponent<MeshRenderer>().SetPropertyBlock(mpb,0);

            lightOn = true;

        }
    }
}
