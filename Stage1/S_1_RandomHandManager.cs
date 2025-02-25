using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapSystem;

public class S_1_RandomHandManager : MonoBehaviour
{
    public Material leftHandMat;
    public Material rightHandMat;

    public GameObject leftTouchObj;
    public GameObject rightTouchObj;

    public NetRandomData randomManager;

    [SerializeField] private AudioSource _audio;

    public void selectHand()
    {
        int randomNum = randomManager.Data[0];

        Material mat = this.transform.GetChild(0).GetChild(randomNum).GetComponent<MeshRenderer>().materials[0];
        this.transform.GetChild(0).GetChild(randomNum).GetComponent<MeshRenderer>().materials = new Material[2] { mat,leftHandMat};
        leftTouchObj.transform.position = this.transform.GetChild(0).GetChild(randomNum).GetComponent<Transform>().position;

        mat = this.transform.GetChild(1).GetChild(randomNum).GetComponent<MeshRenderer>().materials[0];
        this.transform.GetChild(1).GetChild(randomNum).GetComponent<MeshRenderer>().materials = new Material[2] { mat, rightHandMat };
        rightTouchObj.transform.position = this.transform.GetChild(1).GetChild(randomNum).GetComponent<Transform>().position;

        //this.transform.GetChild(1).GetChild(randomNum).GetComponent<MeshRenderer>().materials.SetValue(rightHandMat, 2);
    }        

    public void LeftTouchOn()
    {
        Debug.Log("�޼���ġ");
    }
    public void LeftTouchOff()
    {
        Debug.Log("�޼ն�");
    }

    public void RightTouchOn()
    {
        Debug.Log("��������ġ");
    }
    public void RightTouchOff()
    {
        Debug.Log("�����ն�");
    }

    public void SoundStop()
    {
        if (!_audio.isPlaying) return;
        _audio.Stop();
    }

    //��Ƽ �̺�Ʈ �׼� -  photonview �� �߰� active in - ����� �ε����� ���� on�� �Ǹ� ����
}
