using UnityEngine;

namespace RF.Player
{
    public class PlayerData 
    {
        #region 플레이어 그리드 포지션

        private int curPosX = 0;
        private int curPosY = 0;

        public int GetXPos()
        {
            return curPosX;
        }
        
        public int GetYPos()
        {
            return curPosY;
        }

        public void SetXPos(int num)
        {
            curPosX = num;
        }

        public void SetYPos(int num)
        {
            curPosY = num;
        }

        #endregion
    }
}
