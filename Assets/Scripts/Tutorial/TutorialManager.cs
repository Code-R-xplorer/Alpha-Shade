using System;
using System.Collections.Generic;
using Interactables;
using Managers;
using TheKiwiCoder;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Tutorial
{
    [DefaultExecutionOrder(-1)]
    public class TutorialManager : MonoBehaviour
    {
        public static TutorialManager Instance;
        
        [FormerlySerializedAs("_modelWindow")] [SerializeField] private ModalWindowPanel modelWindow;
        public ModalWindowPanel ModalWindowPanel => modelWindow;

        [FormerlySerializedAs("_dialogWindow")] [SerializeField] private DialogWindow dialogWindow;

        public DialogWindow DialogWindow => dialogWindow;

        [SerializeField] private TextMeshProUGUI objectiveText;

        [SerializeField] private GameObject dialogOne;
        [SerializeField] private GameObject dialogTwo;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            EnableDialog(1);
        }

        public void UpdateObjectiveText(string text)
        {
            objectiveText.text = text;
        }

        public void EnableDialog(int index)
        {
            if(index == 1) dialogOne.SetActive(true);
            if(index == 2) dialogTwo.SetActive(true);
        }

        public void TutorialComplete()
        {
            AppManager.Instance.tutorialComplete = true;
            SceneManager.LoadScene("Level_Select");
        }
    }
}