using MapSystem;
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class S_1_TimerView : TimeUpdateProcedureAbstract
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

        StartCoroutine(texChange(sceonds, minutes));

        //m_text = time.ToString("hh':'mm':'ss");
    }

    IEnumerator texChange(float sec, float min)
    {
        double f04 = (sec % 10) / 1;
        double f03 = Math.Truncate((sec % 100) / 10);
        double f02 = (min % 10) / 1;
        double f01 = Math.Truncate((min % 100) / 10);

        ChangeNumber(f04, 3);
        ChangeNumber(f03, 2);
        ChangeNumber(f02, 1);
        ChangeNumber(f01, 0);

        yield return new WaitForSeconds(1.0f);
    }

    void ChangeNumber(double num, int idx)
    {
        switch (num)
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
