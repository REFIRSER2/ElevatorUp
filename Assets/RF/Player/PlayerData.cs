namespace RF.Player
{
    public class PlayerData 
    {
        #region 플레이어 그리드 포지션

        private int curPosIndex = 0;

        public int GetPosIndex()
        {
            return curPosIndex;
        }

        public void SetPosIndex(int num)
        {
            curPosIndex = num;
        }

        #endregion
    }
}
