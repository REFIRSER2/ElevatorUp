using System.Collections.Generic;
using System.Transactions;
using RF.Game;
using RF.UI.Base;
using UnityEngine;
using Sirenix.OdinInspector;
using TMPro;
using UniRx;
using UnityEngine.UI;

namespace RF.UI.Ingame.Start_Screen
{
    public class UI_Ingame_StartScreen : UI_Base
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
        [BoxGroup("MVP")] public UI_Ingame_StartScreen_Model model = new UI_Ingame_StartScreen_Model();
        [BoxGroup("MVP")] public UI_Ingame_StartScreen_View view;

        [BoxGroup("MVP")] public List<Button> startSelect_Btns = new List<Button>();
        
        private void Setup()
        {
            int index = 0;
            foreach (var btn in startSelect_Btns)
            {
                int copy = index;
                
                btn.transform.Find("Text").GetComponent<TMP_Text>().text = (index+1) + "번";
                
                btn.OnClickAsObservable().Subscribe(next =>
                {
                    model.startIndex.Value = copy;         
                    view.Set_IngameUI(true);
                });
                index++;
            }

            model.startIndex.ObserveEveryValueChanged(prop => prop.Value).Subscribe(value =>
            {
                if (value == -1)
                {
                    return;
                }
                
                Game.Game.instance.SpawnPlayer(value);
                Game.Game.instance.SetState(GameState.GameStart);
            });
        }
        #endregion
    }
}
