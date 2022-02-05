using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace RF.Player
{
    public interface IPlayerController
    {
        public void Init(Player player, Rigidbody rb);
        public void Think();


        public void Forward();
        public void Backward();
        public void Left();
        public void Right();
    }
    
    public class PlayerController:IPlayerController
    {
        private Player ply;
        private Rigidbody rigidbody;

        private Queue<Action> moveActQueue = new Queue<Action>();
        private bool isFirstMove = true;
        
        public void Init(Player player, Rigidbody rb)
        {
            ply = player;
            rigidbody = rb;
        }

        public void Think()
        {

        }

        public void Forward()
        {
            int index = ply.GetPlayerData().GetYPos();
            int value = index - 1 < 0 ? index : index - 1; 
            
            if (index - 1 < 0)
            {
                return;
            }

            ply.GetPlayerData().SetYPos(value);

            Action act = () =>
            {
                ply.transform.DOLookAt(
                    Game.Game.instance.elevator.movePosList[ply.GetPlayerData().GetXPos(), value].transform.position,
                    0.1F);
                
                ply.GetAnimator().Play("Roll");
                
                ply.transform.DOMoveZ(
                    Game.Game.instance.elevator.movePosList[ply.GetPlayerData().GetXPos(), value].transform.position.z, 0.5F,
                    false).OnComplete(() =>
                {
                    if (moveActQueue.Count > 0)
                    {
                        moveActQueue.Dequeue()();
                    }

                    if (moveActQueue.Count == 0)
                    {
                        isFirstMove = true;
                    }
                });
            };
            
            moveActQueue.Enqueue(act);

            if (isFirstMove)
            {
                moveActQueue.Dequeue()();
                isFirstMove = false;
            }
        }

        public void Backward()
        {
            int index = ply.GetPlayerData().GetYPos();
            int value = index + 1 >= 4 ? index : index + 1; 
            
            if (index + 1 >= 4)
            {
                return;
            }
            
            ply.GetPlayerData().SetYPos(value);   
 
            Action act = () =>
            {
                ply.transform.DOLookAt(
                    Game.Game.instance.elevator.movePosList[ply.GetPlayerData().GetXPos(), value].transform.position,
                    0.1F);
                
                ply.GetAnimator().Play("Roll");
                
                ply.transform.DOMoveZ(
                    Game.Game.instance.elevator.movePosList[ply.GetPlayerData().GetXPos(), value].transform.position.z, 0.5F,
                    false).OnComplete(() =>
                {
                    Debug.Log("dequeue");
                    if (moveActQueue.Count > 0)
                    {
                        moveActQueue.Dequeue()();
                    }
                    
                    if (moveActQueue.Count == 0)
                    {
                        isFirstMove = true;
                    }
                });
            };
            
            moveActQueue.Enqueue(act);
            
            if (isFirstMove)
            {
                moveActQueue.Dequeue()();
                isFirstMove = false;
            }
        }

        public void Left()
        {
            int index = ply.GetPlayerData().GetXPos();
            int value = (index-1) < 0 ? index : index - 1; 
            
            if ((index-1) < 0)
            {
                return;
            }
            
            ply.GetPlayerData().SetXPos(value);

            Action act = () =>
            {
                ply.transform.DOLookAt(
                    Game.Game.instance.elevator.movePosList[value, ply.GetPlayerData().GetYPos()].transform.position,
                    0.1F);
                
                ply.GetAnimator().Play("Roll");
                
                ply.transform.DOMoveX(
                    Game.Game.instance.elevator.movePosList[value, ply.GetPlayerData().GetYPos()].transform.position.x, 0.5F,
                    false).OnComplete(() =>
                {
                    Debug.Log("dequeue");
                    if (moveActQueue.Count > 0)
                    {
                        moveActQueue.Dequeue()();
                    }
                    
                    if (moveActQueue.Count == 0)
                    {
                        isFirstMove = true;
                    }
                });
            };
            
            moveActQueue.Enqueue(act);
            
            if (isFirstMove)
            {
                moveActQueue.Dequeue()();
                isFirstMove = false;
            }
        }

        public void Right()
        {
            int index = ply.GetPlayerData().GetXPos();
            int value = (index+1) >= 4 ? index : index + 1; 
            
            if ((index+1) >= 4)
            {
                return;
            }
            
            ply.GetPlayerData().SetXPos(value);  
 
            Action act = () =>
            {
                ply.transform.DOLookAt(
                    Game.Game.instance.elevator.movePosList[value, ply.GetPlayerData().GetYPos()].transform.position,
                    0.1F);
                    
                ply.GetAnimator().Play("Roll");
                
                ply.transform.DOMoveX(
                    Game.Game.instance.elevator.movePosList[value, ply.GetPlayerData().GetYPos()].transform.position.x, 0.5F,
                    false).OnComplete(() =>
                {
                    Debug.Log("dequeue");
                    
                    if (moveActQueue.Count > 0)
                    {
                        moveActQueue.Dequeue()();
                    }
                    
                    if (moveActQueue.Count == 0)
                    {
                        isFirstMove = true;
                    }
                });
            };
            
            moveActQueue.Enqueue(act);
            
            if (isFirstMove)
            {
                moveActQueue.Dequeue()();
                isFirstMove = false;
            }
        }
    }
}
