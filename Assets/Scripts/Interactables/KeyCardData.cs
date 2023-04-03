using UnityEngine;

namespace Interactables
{
    public class KeyCardData : MonoBehaviour
    {
        public int id;
        public bool selected;
        public bool inUse;
        public string doorName;

        public void Initialize(int keyID)
        {
            id = keyID;
        }

        public void UseKeyCard(string nameOfDoor)
        {
            doorName = nameOfDoor;
            inUse = true;
        }
    }
}