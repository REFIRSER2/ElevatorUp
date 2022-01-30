using System;
using Sirenix.OdinInspector;
using UnityEditor.Rendering;
using UnityEngine;

namespace RF.Elevator
{
    public class Elevator : SerializedMonoBehaviour
    {
        #region 기본 내장 함수
        private void Awake()
        {
            controller.Init(this);
        }

        private void Update()
        {
            if (controller != null)
            {
                controller.Think();
            }
        }
        #endregion
        
        #region 컨트롤러
        private IElevatorController controller = new ElevatorController();

        public IElevatorController GetController()
        {
            return controller;
        }
        #endregion
        
        #region Map
        [BoxGroup("Map")] public GameObject[,] movePosList = new GameObject[4, 4];

        public Vector3 GetMovePos(int x, int y)
        {
            return movePosList[x, y].transform.localPosition;
        }
        #endregion


    }
}
