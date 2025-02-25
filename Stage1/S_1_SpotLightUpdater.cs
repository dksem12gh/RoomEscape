using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable CS0649

public class S_1_SpotLightUpdater : MonoBehaviour
{
    const string  spotAngleStr = "_spotAngle";
    const string  spotPosStr   = "_spotPos";
    const string  spotDirStr   = "_spotDir";

    public float spotFloat = 0;

    [SerializeField]Light m_light;

    void Update()
    {
        Shader.SetGlobalFloat( spotAngleStr, m_light.spotAngle * spotFloat);
        Shader.SetGlobalVector( spotPosStr, m_light.transform.position);
        Shader.SetGlobalVector( spotDirStr, m_light.transform.forward);
    }

    public float onSpot()
    {
        Debug.Log("합체/손보임");
        return spotFloat = 0.5f;
    }
    public float offSpot()
    {
        return spotFloat = 0.0f;
    }
}
