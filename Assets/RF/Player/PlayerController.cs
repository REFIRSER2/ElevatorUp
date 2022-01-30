using UnityEngine;

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
            ply.GetPlayerData().SetPosIndex();
        }

        public void Backward()
        {
            
        }

        public void Left()
        {
            
        }

        public void Right()
        {
            
        }
    }
}
