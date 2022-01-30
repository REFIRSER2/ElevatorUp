using System;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace RF.UI.Base
{
    public class UI_Base : SerializedMonoBehaviour
    {
        #region 기본 내장 함수
        private void Awake()
        {
            Initialize();
        }

        private void Update()
        {
            Think();
        }
        #endregion
        
        #region 가상 함수
        public virtual void Initialize()
        {
            
        }

        public virtual void Think()
        {
            
        }
        #endregion
    }
}
