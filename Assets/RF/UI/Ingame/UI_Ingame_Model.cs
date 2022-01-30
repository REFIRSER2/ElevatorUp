using UniRx;

namespace RF.UI.Ingame
{
    public class UI_Ingame_Model
    {
        #region 모델
        public IntReactiveProperty floor;
        public IntReactiveProperty height;

        public UI_Ingame_Model()
        {
            floor = new IntReactiveProperty(1);
            height = new IntReactiveProperty(0);
        }
        #endregion
    }
}
