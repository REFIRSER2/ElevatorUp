using System;
using RF.UI.Ingame;
using UnityEngine;

namespace RF.Game
{
    public enum GameState
    {
        Idle,
        WaitGame,
        GameStart,
        GameOver,
    }
    
    public class Game : MonoBehaviour
    {
        #region 싱글톤
        public static Game instance;
        #endregion
        
        #region 기본 내장 함수
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }

        private void Update()
        {
            GameThink();
        }
        #endregion
        
        #region 게임 진행
        [SerializeField] private Elevator.Elevator elevator;
        
        private void GameThink()
        {
            switch (gameState)
            {
                case GameState.Idle:
                {
                    gameState = GameState.WaitGame;
                    break;
                }
                case GameState.WaitGame:
                {
                    
                    break;
                }
                case GameState.GameStart:
                {
                    ActiveGame();
                    break;
                }
                case GameState.GameOver:
                {
                    
                    break;
                }
            }
        }

        private void ActiveGame()
        {
            var position = elevator.transform.position;
            var floor = 1 + Mathf.FloorToInt(position.y / 5F);
            ingameUI.SetHeight(position.y);
            ingameUI.SetFloor(floor);
            elevator.GetController().Up();
        }
        #endregion
        
        #region 층
        [SerializeField] private UI_Ingame ingameUI;
        #endregion
        
        #region 플레이어
        [SerializeField] private GameObject playerPrefab;

        private Player.Player player;
        
        // ReSharper disable Unity.PerformanceAnalysis
        public void SpawnPlayer(int index)
        {
            player = Instantiate(playerPrefab).GetComponent<Player.Player>();
            player.transform.SetParent(elevator.transform, false);
            
            Vector3 spawnPos = elevator.movePosList[index % 4, index / 4].transform.localPosition + new Vector3(0,0.2F, 0);
            player.transform.localPosition = new Vector3(spawnPos.x, player.transform.localPosition.y, spawnPos.z);
            
            player.GetPlayerData().SetPosIndex(index);
        }

        public Player.Player GetPlayer()
        {
            return player;
        }
        #endregion
        
        #region 게임 상태
        private GameState gameState = GameState.Idle;

        public GameState GetState()
        {
            return gameState;
        }

        public void SetState(GameState state)
        {
            gameState = state;
        }
        #endregion
    }
}
