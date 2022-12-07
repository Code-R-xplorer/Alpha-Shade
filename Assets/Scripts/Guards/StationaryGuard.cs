using UnityEngine;

namespace Guards
{
    public class StationaryGuard : GuardController
    {
        private Vector3 _homePosition;
        private Quaternion _homeRotation;
        protected override void Start()
        {
            base.Start();
            // _homePosition = transform.position;
            // _homeRotation = transform.rotation;
            blackboard.homePosition = transform.position;
            blackboard.homeRotation = transform.rotation;
        }
    }
}
