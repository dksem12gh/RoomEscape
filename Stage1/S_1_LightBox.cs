using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace REO
{
    
    public class S_1_LightBox : MonoBehaviour
    {
        public MeshRenderer _lightBoxMat;        
        public MeshRenderer[] _xrayPictureMat;

        public Texture _lightTex;
        public Texture _xrayTex;

        public void LightBoxOff()
        {
            MaterialPropertyBlock mpb = new MaterialPropertyBlock();
            mpb.SetColor(Shader.PropertyToID("_Color"), new Color(0.1f, 0.1f, 0.1f));
            mpb.SetTexture("_EmissionMap", _lightTex);
            mpb.SetColor("_EmissionColor", new Color(0.1f,0.1f,0.1f));

            _lightBoxMat.SetPropertyBlock(mpb);

            mpb.SetTexture("_EmissionMap", _xrayTex);

            _xrayPictureMat[0].SetPropertyBlock(mpb);
            _xrayPictureMat[1].SetPropertyBlock(mpb);            
        }

        public void LightingBoxOn()
        {
            MaterialPropertyBlock mpb = new MaterialPropertyBlock();
            mpb.SetColor(Shader.PropertyToID("_Color"), Color.white);
            mpb.SetTexture("_EmissionMap", _lightTex);
            mpb.SetColor("_EmissionColor", Color.white * 1.41f);
            _lightBoxMat.SetPropertyBlock(mpb);

            mpb.SetColor(Shader.PropertyToID("_Color"), Color.white);
            mpb.SetTexture("_EmissionMap", _xrayTex);
            mpb.SetColor("_EmissionColor", new Color(0.2f,0.6f,0.7f) * 2);
            _xrayPictureMat[0].SetPropertyBlock(mpb);

            mpb.SetColor(Shader.PropertyToID("_Color"), Color.white);
            mpb.SetColor("_EmissionColor", new Color(0.2f, 0.6f, 0.7f) * 2);
            _xrayPictureMat[1].SetPropertyBlock(mpb);
        }

        public void LightingXRay01()
        {
            MaterialPropertyBlock mpb = new MaterialPropertyBlock();
            mpb.SetColor(Shader.PropertyToID("_Color"), Color.white);
            mpb.SetTexture("_EmissionMap", _xrayTex);
            mpb.SetColor("_EmissionColor", new Color(0.2f, 0.6f, 0.7f) * 2);
            _xrayPictureMat[0].SetPropertyBlock(mpb);
        }
        public void LightingXRay02()
        {
            MaterialPropertyBlock mpb = new MaterialPropertyBlock();
            mpb.SetColor(Shader.PropertyToID("_Color"), Color.white);
            mpb.SetColor("_EmissionColor", new Color(0.2f, 0.6f, 0.7f) * 2);
            _xrayPictureMat[1].SetPropertyBlock(mpb);
        }
    }
}
