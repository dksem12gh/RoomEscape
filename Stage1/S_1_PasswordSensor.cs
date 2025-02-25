using UnityEngine;

public class S_1_PasswordSensor : MonoBehaviour
{
    public GameObject _sensor;
    public Texture _tex;

    public void PasswordSencerOn()
    {
        MaterialPropertyBlock mpb = new MaterialPropertyBlock();

        mpb.SetColor(Shader.PropertyToID("_Color"), Color.red);
        mpb.SetTexture("_EmissionMap", _tex);
        mpb.SetColor("_EmissionColor", Color.red * 2);
        
        _sensor.GetComponent<MeshRenderer>().SetPropertyBlock(mpb,1);
    }

    public void PasswordSencerSuccece()
    {
        MaterialPropertyBlock mpb = new MaterialPropertyBlock();

        mpb.SetColor(Shader.PropertyToID("_Color"), Color.green);
        mpb.SetTexture("_EmissionMap", _tex);
        mpb.SetColor("_EmissionColor", Color.green * 2);
        
        _sensor.GetComponent<MeshRenderer>().SetPropertyBlock(mpb, 1);
    }

    public void PasswordSencerOff()
    {
        MaterialPropertyBlock mpb = new MaterialPropertyBlock();

        mpb.SetColor(Shader.PropertyToID("_Color"), Color.red);
        mpb.SetTexture("_EmissionMap", _tex);
        mpb.SetColor("_EmissionColor", new Color(0.3f,0,0,1));
        
        _sensor.GetComponent<MeshRenderer>().SetPropertyBlock(mpb, 1);
    }
}