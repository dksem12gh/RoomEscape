using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapSystem;
using System;

public class S_1_Timer : TimeUpdateProcedureAbstract
{
    public Sprite[] _numberTex;

    float m_limitTime;

    SpriteRenderer[] m_childObj = new SpriteRenderer[4];

    public override void Init(float limitTime)
    {
        m_limitTime = limitTime;

        for (int i = 0; i < m_childObj.Length; i++)
        {
            m_childObj[i] = this.transform.GetChild(i).GetComponent<SpriteRenderer>();
        }
    }

    public override void OnUpdate(float timeProgress)
    {
        float sceonds = Mathf.FloorToInt((m_limitTime - timeProgress) % 60);
        float minutes = Mathf.FloorToInt((m_limitTime - timeProgress) / 60);

        double[] f0 = new double[4];

        f0[3] = (sceonds % 10) / 1;
        f0[2] = Math.Truncate((sceonds % 100) / 10);
        f0[1] = (minutes % 10) / 1;
        f0[0] = Math.Truncate((minutes % 100) / 10);

        for (int i = 0; i < m_childObj.Length; i++)
        {
            if (m_childObj[i] != null)
            {
                ChangeNumber(f0[i], i);
            }
        }

        //m_text = time.ToString("hh':'mm':'ss");
    }
    
    void ChangeNumber(double time, int idx)
    {
        switch (time)
        {
            case 0:
                m_childObj[idx].GetComponent<SpriteRenderer>().sprite = _numberTex[0];
                break;
            case 1:
                m_childObj[idx].GetComponent<SpriteRenderer>().sprite = _numberTex[1];
                break;
            case 2:
                m_childObj[idx].GetComponent<SpriteRenderer>().sprite = _numberTex[2];
                break;
            case 3:
                m_childObj[idx].GetComponent<SpriteRenderer>().sprite = _numberTex[3];
                break;
            case 4:
                m_childObj[idx].GetComponent<SpriteRenderer>().sprite = _numberTex[4];
                break;
            case 5:
                m_childObj[idx].GetComponent<SpriteRenderer>().sprite = _numberTex[5];
                break;
            case 6:
                m_childObj[idx].GetComponent<SpriteRenderer>().sprite = _numberTex[6];
                break;
            case 7:
                m_childObj[idx].GetComponent<SpriteRenderer>().sprite = _numberTex[7];
                break;
            case 8:
                m_childObj[idx].GetComponent<SpriteRenderer>().sprite = _numberTex[8];
                break;
            case 9:
                m_childObj[idx].GetComponent<SpriteRenderer>().sprite = _numberTex[9];
                break;
        }        
    }
}
