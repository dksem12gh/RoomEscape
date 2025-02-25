using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace REO
{
    public class S_1_ObjectReSpawn : MonoBehaviour
    {
        Vector3 pos;
        Quaternion rot;

        public S_1_NarationPlayerState TrickCheck = null;

        void Start()
        {
            pos = this.transform.position;
            rot = this.transform.rotation;

            StartCoroutine("fallObjectCheck");
        }

        public void CheckTrickEnable()
        {
            for(int i = 0; i<4; i++)
            {                
                if (TrickCheck._trickClear[i] == false)
                {
                    if (this.gameObject.name == "SquarePuzzle01" & i == 0)
                    {
                        this.GetComponent<BoxCollider>().enabled = false;
                    }
                    else if (this.gameObject.name == "SquarePuzzle02" & i == 1)
                    {
                        this.GetComponent<BoxCollider>().enabled = false;
                    }
                    else if (this.gameObject.name == "SquarePuzzle03" & i == 2)
                    {
                        this.GetComponent<BoxCollider>().enabled = false;
                    }
                    else if (this.gameObject.name == "SquarePuzzle04" & i == 3)
                    {
                        this.GetComponent<BoxCollider>().enabled = false;
                    }
                }
                else if (TrickCheck._trickClear[i] == true)
                {
                    if (this.gameObject.name == "SquarePuzzle01" & i == 0)
                    {
                        this.GetComponent<BoxCollider>().enabled = true;
                    }
                    else if (this.gameObject.name == "SquarePuzzle02" & i == 1)
                    {
                        this.GetComponent<BoxCollider>().enabled = true;
                    }
                    else if (this.gameObject.name == "SquarePuzzle03" & i == 2)
                    {
                        this.GetComponent<BoxCollider>().enabled = true;
                    }
                    else if (this.gameObject.name == "SquarePuzzle04" & i == 3)
                    {
                        this.GetComponent<BoxCollider>().enabled = true;
                    }
                }
            }
        }

        private void OnDisable()
        {
            StopCoroutine("fallObjectCheck");
        }

        IEnumerator fallObjectCheck()
        {
            yield return new WaitUntil(() => this.transform.position.y <= -5.0f);
            this.transform.position = pos;
            this.transform.rotation = rot;
            StartCoroutine("fallObjectCheck");
        }
    }
}
