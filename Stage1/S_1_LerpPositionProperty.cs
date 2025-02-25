using UnityEngine;
using UInteractive.Implement;


namespace REO
{
    public class S_1_LerpPositionProperty : LerpPropertyInterface
    {
        [SerializeField] Transform m_myTrs = null;
        [SerializeField] bool m_isLocal = true;

        [SerializeField] Vector3 m_defaultPosition = Vector3.zero;
        [SerializeField] Vector3 m_movePosition = Vector3.zero;

        [SerializeField] Transform m_followObject = null; //현재 오브젝트를 따라 다니는 오브젝트  

        Vector3 m_disFollowObj;

        Vector3 MyPosition
        {
            set
            {
                if (true == m_isLocal)
                {
                    m_myTrs.localPosition = value;
                }
                else
                {
                    m_myTrs.position = value;
                }
                SetFollowObject();
            }
            get
            {
                if (true == m_isLocal)
                {
                    return m_myTrs.localPosition;
                }
                else
                {
                    return m_myTrs.position;
                }
            }
        }

        void SetFollowObject()
        {
            if (null != m_followObject)
            {
                m_followObject.position = m_myTrs.position + m_disFollowObj;
            }
        }

        public void DefaultPosChange()
        {
            m_defaultPosition = m_myTrs.localPosition;
        }

        public override void LerpProgress(float t)
        {
            MyPosition = Vector3.Lerp(m_defaultPosition, m_movePosition, t);            
        }

        protected override void InitAbstract()
        {
            if (null != m_followObject)
            {
                m_disFollowObj = m_followObject.position - m_myTrs.position;
            }
        }
    }
}
