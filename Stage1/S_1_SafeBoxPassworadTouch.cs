using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_1_SafeBoxPassworadTouch : MonoBehaviour
{
    public Texture[] _numberTex;
    public int _num = 0;

    private void Awake()
    {
        _num = 0;
    }

    public void ResetNum()
    {
        _num = 0;

        MaterialPropertyBlock mpb = new MaterialPropertyBlock();

        mpb.SetColor("_EmissionColor", new Color(1.0f, 1.0f, 1.0f));
        mpb.SetTexture("_EmissionMap", _numberTex[0]);
    }

    public void TouchNumCount()
    {
        _num++;
        if (_num == 10)
            _num = 0;
        
        MaterialPropertyBlock mpb = new MaterialPropertyBlock();

        mpb.SetColor("_EmissionColor", new Color(1.0f, 1.0f, 1.0f));

        switch (_num)
        {
            case 0:
            mpb.SetTexture("_EmissionMap", _numberTex[0]);
            break;
            case 1:
            mpb.SetTexture("_EmissionMap", _numberTex[1]);
            break;
            case 2:
            mpb.SetTexture("_EmissionMap", _numberTex[2]);
            break;
            case 3:
            mpb.SetTexture("_EmissionMap", _numberTex[3]);
            break;
            case 4:
            mpb.SetTexture("_EmissionMap", _numberTex[4]);
            break;
            case 5:
            mpb.SetTexture("_EmissionMap", _numberTex[5]);
            break;
            case 6:
            mpb.SetTexture("_EmissionMap", _numberTex[6]);
            break;
            case 7:
            mpb.SetTexture("_EmissionMap", _numberTex[7]);
            break;
            case 8:
            mpb.SetTexture("_EmissionMap", _numberTex[8]);
            break;
            case 9:
            mpb.SetTexture("_EmissionMap", _numberTex[9]);
            break;
        }

    this.GetComponent<MeshRenderer>().SetPropertyBlock(mpb, 1);
    }
}
