using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace REO
{
    public class S_1_BouncingBeam
    {
        Vector3 pos, dir;
        GameObject laserObj;
        LineRenderer laser;
        List<Vector3> laserIndices = new List<Vector3>();

        public S_1_BouncingBeam(Vector3 pos , Vector3 dir, Material mat, int beamNum , Transform parent)
        {
            //this.laser = new LineRenderer();
            this.laserObj = parent.GetChild(0).gameObject;

            if(beamNum == 0)
            {
                this.laserObj.name = "LaserBeam";                
            }
            else
            {
                this.laserObj.name = "LaserBeam1";                
            }
            this.pos = pos;
            this.dir = dir;

            //this.laser = this.laserObj.AddComponent(typeof(LineRenderer)) as LineRenderer;
            this.laser = this.laserObj.GetComponent<LineRenderer>();
            this.laser.startWidth = 0.05f;
            this.laser.endWidth = 0.05f;
            this.laser.material = mat;            

            CastRay(pos,dir,laser);
        }

        void CastRay(Vector3 pos, Vector3 dir, LineRenderer laser)
        {
            laserIndices.Add(pos);

            Ray ray = new Ray(pos, dir);

            RaycastHit hit;

            int layerMask = ((1 << LayerMask.NameToLayer("DrawBoard")) | 
                                (1 << LayerMask.NameToLayer("HandPlayer")) | 
                                    (1 << LayerMask.NameToLayer("Warning Trigger")));
            layerMask = ~layerMask;
            if (Physics.Raycast(ray,out hit, Mathf.Infinity, layerMask))
            {
                CheckHit(hit,dir,laser);
            }
            else
            {
                laserObj.transform.GetChild(0).gameObject.SetActive(false);

                laserIndices.Add(ray.GetPoint(Mathf.Infinity));
                UpdateLaser();
            }
        }

        void UpdateLaser()
        {
            int count = 0;
            laser.positionCount = laserIndices.Count;
            foreach(Vector3 idx in laserIndices)
            {
                laser.SetPosition(count, idx);
                count++;
            }
        }

        void CheckHit(RaycastHit hitInfo,Vector3 direction, LineRenderer laser)
        {
            if (hitInfo.collider.gameObject.name == "S_1_Mirror")
            {
                Vector3 pos = hitInfo.point;
                Vector3 dir = Vector3.Reflect(direction, hitInfo.normal);

                CastRay(pos, dir, laser);
            }
            else
            {
                if (hitInfo.transform.gameObject.layer == LayerMask.NameToLayer("trigger object") || 
                    hitInfo.transform.gameObject.layer == LayerMask.NameToLayer("Grabbing"))
                {                    
                    laserObj.transform.GetChild(0).gameObject.SetActive(false);
                }
                else
                {
                    laserObj.transform.GetChild(0).gameObject.transform.position = hitInfo.point;
                    laserObj.transform.GetChild(0).gameObject.SetActive(true);
                }                               

                laserIndices.Add(hitInfo.point);
                UpdateLaser();
            }
        }
    }
}
