using UnityEngine;

namespace Guards
{
    public class StationaryGuard : GuardController
    {
        protected override void Start()
        {
            base.Start();
            blackboard.homePosition = transform.position;
            blackboard.homeRotation = transform.rotation;
        }
    }
}
