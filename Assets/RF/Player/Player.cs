using System;
using UnityEngine;

namespace RF.Player
{
    public class Player : MonoBehaviour
    {
        #region 기본 내장 함수

        private void Awake()
        {
            controller.Init(this, rigidBody);
        }

        private void Start()
        {
            
        }

        private void Update()
        {
           controller.Think(); 
        }

        #endregion
        
        #region 리기드바디
        [SerializeField] private Rigidbody rigidBody;
        #endregion
        
        #region 애니메이터
        [SerializeField] private Animator animator;

        public Animator GetAnimator()
        {
            return animator;
        }
        #endregion
        
        #region 컨트롤러
        private IPlayerController controller = new PlayerController();

        public IPlayerController GetController()
        {
            return controller;
        }
        #endregion
        
        #region 데이터

        private PlayerData playerData = new PlayerData();

        public PlayerData GetPlayerData()
        {
            return playerData;
        }
        #endregion
    }
}
