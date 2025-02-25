using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UInteractive.Pun2;

    public class S_1_ScarRandomhint : EventSolutionData
    {
        public Material[] _scarMats;
        public Material _invisibleMat;

        public int[] _scarNumber;

        public override int[] Data
        {
            get => m_solution;
            set => m_solution = value;
        }

        //·£´ýÄ®ÀÚ±¹
        public void RandomSettingScarHint()
        {
            Material[] lieMat = new Material[2];
            Transform[] lieTr = new Transform[2];

            lieMat[0] = this.transform.GetChild(4).GetChild(0).GetComponent<MeshRenderer>().materials[0];
            lieMat[1] = this.transform.GetChild(4).GetChild(1).GetComponent<MeshRenderer>().materials[0];

            lieMat[0] = _scarMats[Random.Range(0, 4)];
            lieMat[1] = _scarMats[Random.Range(0, 4)];

            this.transform.GetChild(4).GetChild(0).GetComponent<MeshRenderer>().materials[0] = lieMat[0];
            this.transform.GetChild(4).GetChild(1).GetComponent<MeshRenderer>().materials[0] = lieMat[1];

            lieTr[0] = this.transform.GetChild(4).GetChild(0);
            lieTr[1] = this.transform.GetChild(4).GetChild(1);

            _scarNumber = m_solution;

            //Æ÷Áö¼Ç ·£´ý ÇÑ´Ù¸é Ãß°¡

            /*(¿ìÃø ³¬½ÃÈùÆ®)
            Vector3(0.535000026,0.400000006,0)
            Vector3(0.746999979,0,0)

            (ÁÂÃø ³¬½Ã ÈùÆ®)
            Vector3(-0.808000028,0.226999998,0)
            Vector3(-0.579999983,-0.338,0)*/

            for (int i = 0; i < this.transform.childCount-1; i++)
            {
                Material[] matL = new Material[1]; 
                matL = this.transform.GetChild(i).GetChild(0).GetComponent<MeshRenderer>().materials;
                Material[] matR = new Material[1]; 
                matR = this.transform.GetChild(i).GetChild(1).GetComponent<MeshRenderer>().materials;

                Transform scarTr = this.transform.GetChild(i).GetChild(0);
                

                switch (m_solution[i])
                {
                    case 0:
                        scarTr.localPosition = new Vector3(0,0,0);
                        matL[0] = _invisibleMat;                            
                        matR[0] = _invisibleMat;                        
                        break;
                    case 1:
                        scarTr.localPosition = new Vector3(0, 0, 0);
                        matL[0] = _scarMats[0];                        
                        matR[0] = _invisibleMat;                        
                        break;
                    case 2:
                        scarTr.localPosition = new Vector3(0, 0, 0);
                        matL[0] = _scarMats[1];                        
                        matR[0] = _invisibleMat;                        
                        break;
                    case 3:
                        scarTr.localPosition = new Vector3(0, 0, 0);
                        matL[0] = _scarMats[2];                        
                        matR[0] = _invisibleMat;                        
                        break;
                    case 4:
                        scarTr.localPosition = new Vector3(0, 0, 0);
                        matL[0] = _scarMats[3];                        
                        matR[0] = _invisibleMat;                        
                        break;
                    case 5:
                        scarTr.localPosition = new Vector3(0, 0, 0);
                        matL[0] = _scarMats[4];                        
                        matR[0] = _invisibleMat;                        
                        break;
                    case 6:
                        scarTr.localPosition = new Vector3(0.5f, 0, 0);
                        matL[0] = _scarMats[4];                        
                        matR[0] = _scarMats[0];                        
                        break;
                    case 7:
                        scarTr.localPosition = new Vector3(0.5f, 0, 0);
                        matL[0] = _scarMats[4];                        
                        matR[0] = _scarMats[1];                        
                        break;
                    case 8:
                        scarTr.localPosition = new Vector3(0.5f, 0, 0);
                        matL[0] = _scarMats[4];                        
                        matR[0] = _scarMats[2];                        
                        break;
                    case 9:
                        scarTr.localPosition = new Vector3(0.5f, 0, 0);
                        matL[0] = _scarMats[4];                        
                        matR[0] = _scarMats[3];                        
                        break;                        
                }

                 this.transform.GetChild(i).GetChild(0).GetComponent<MeshRenderer>().materials = matL;
                 this.transform.GetChild(i).GetChild(1).GetComponent<MeshRenderer>().materials = matR;
               
            }

        }


    }
