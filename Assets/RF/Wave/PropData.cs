using UnityEngine;

namespace RF.Wave
{
    public interface IPropData
    {
        public Vector3 targetPos
        {
            get;
            set;
        }

        public void SetTargetPos(Vector3 pos);
    }
    
    public class PropData:IPropData
    {
        public Vector3 targetPos { get; set; }
        public void SetTargetPos(Vector3 pos)
        {
            targetPos = pos;
        }
    }
}
