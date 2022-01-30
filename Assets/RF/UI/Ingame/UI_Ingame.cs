using System.Collections.Generic;
using RF.UI.Base;
using Sirenix.OdinInspector;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

namespace RF.UI.Ingame
{
    public class UI_Ingame : UI_Base
    {
        #region 오버라이드
        public override void Initialize()
        {
            base.Initialize();

            Setup();
        }

        public override void Think()
        {
            base.Think();
        }
        #endregion
        
        #region MVP
        [BoxGroup("MVP")] public UI_Ingame_Model model = new UI_Ingame_Model();
        [BoxGroup("MVP")] public UI_Ingame_View view;
        [BoxGroup("MVP")] public List<Button> forwardBtns = new List<Button>();
        [BoxGroup("MVP")] public List<Button> sideBtns = new List<Button>();

        public void SetFloor(int num)
        {
            model.floor.Value = num;
        }

        public void SetHeight(float height)
        {
            view.SetHeight(height);
        }
        
        private void Setup()
        {
            model.floor.Subscribe(value =>
            {
                view.SetFloor(value);
            });

            int index = 0;
            foreach (var btn in forwardBtns)
            {
                if (index == 0)
                {
                    btn.OnClickAsObservable().Subscribe(unit =>
                    {
                        Player.Player player = Game.Game.instance.GetPlayer();
                        
                        player.GetController().Forward();
                    });                    
                }
                else
                {
                    btn.OnClickAsObservable().Subscribe(unit =>
                    {
                        Player.Player player = Game.Game.instance.GetPlayer();
                        
                        player.GetController().Backward();                   
                    });                   
                }

                index++;
            }
            
            index = 0;
            foreach (var btn in sideBtns)
            {
                if (index == 0)
                {
                    btn.OnClickAsObservable().Subscribe(unit =>
                    {
                        Player.Player player = Game.Game.instance.GetPlayer();
                        
                        player.GetController().Left();
                    });                    
                }
                else
                {
                    btn.OnClickAsObservable().Subscribe(unit =>
                    {
                        Player.Player player = Game.Game.instance.GetPlayer();
                        
                        player.GetController().Right();                   
                    });                   
                }

                index++;
            }
        }
        #endregion
    }
}
