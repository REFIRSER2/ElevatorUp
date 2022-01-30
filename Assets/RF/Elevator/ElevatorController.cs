using UnityEngine;

namespace RF.Elevator
{
    public interface IElevatorController
    {
        public void Init(Elevator elevator);
        public void Think();
        public void Up();
        public void Down();
        public void Stop();

        public void Slow();
    }

    public class ElevatorController:IElevatorController
    {
        private Elevator ent;
        
        public void Init(Elevator elevator)
        {
            ent = elevator;
        }

        public void Think()
        {
            
        }

        public void Up()
        {
            ent.transform.position += new Vector3(0, 0.5F*Time.deltaTime, 0);
        }

        public void Down()
        {
            
        }

        public void Stop()
        {
            
        }

        public void Slow()
        {
            
        }
    }
}
