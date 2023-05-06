using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] private List<Transform> positions;
        [SerializeField] private GameObject cameras;
        
        
        public void SwitchCameraPosition(int index)
        {
            cameras.transform.position = positions[index].position;
        }
    }
}