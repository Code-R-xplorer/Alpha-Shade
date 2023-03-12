using System;
using System.Collections.Generic;
using Interactables;
using Player;
using UI.Pocket_Watch;
using UnityEngine;

namespace Utilities
{
    public class IDManager : MonoBehaviour
    {
        public static IDManager Instance;

        private List<ID> idCards;

        private ID currentID;

        private PocketWatch pocketWatch;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            // pocketWatch = GameObject.FindWithTag("PocketWatch").GetComponent<PocketWatch>();
            idCards = new List<ID>();
            currentID = new ID
            {
                name = default,
                accessLevel = AccessLevel.Default
            };
        }

        public void IDCardCollected(IDCard card)
        {
            var id = new ID
            {
                name = card.GetIDName(),
                accessLevel = card.GetAccessLevel()
            };
            idCards.Add(id);
            pocketWatch.screens[3].GetComponent<IDScreen>().AddCardToScreen(id.name, id.accessLevel);
            if (currentID.accessLevel < id.accessLevel)
            {
                currentID = id;
            }
        }

        public void SelectID(int id)
        {
            currentID = idCards[id];
        }

        private struct ID
        {
            public string name;
            public AccessLevel accessLevel;
        }

        public List<Tuple<string, AccessLevel>> GetIDCards()
        {
            List<Tuple<string, AccessLevel>> cards = new List<Tuple<string, AccessLevel>>();

            foreach (var card in idCards)
            {
                cards.Add(new Tuple<string,AccessLevel>(card.name, card.accessLevel));
            }

            return cards;
        }

        public bool CheckCorrectIDLevel(AccessLevel accessLevel)
        {
            if (accessLevel == AccessLevel.Default) return false;
            return currentID.accessLevel >= accessLevel;
        }
    }

   

    public enum AccessLevel
    {
        Default,
        Low,
        Medium,
        High,
        Max
    }
}
