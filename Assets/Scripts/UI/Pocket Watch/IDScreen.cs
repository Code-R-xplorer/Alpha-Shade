using UnityEngine;
using Player;
using Utilities;

namespace UI.Pocket_Watch
{
    public class IDScreen : BaseScreen
    {
        [SerializeField] private GameObject idUIPrefab;
        [SerializeField] private GameObject idGameObject;
        public override void Init(PocketWatch pw, GameObject p)
        {
            base.Init(pw, p);
        }

        public void AddCardToScreen(string idName, AccessLevel accessLevel)
        {
            GameObject idImage = Instantiate(idUIPrefab, idGameObject.transform, false);
            idImage.GetComponent<ID>().CreateID(idName, accessLevel.ToString());
        }
    }
}