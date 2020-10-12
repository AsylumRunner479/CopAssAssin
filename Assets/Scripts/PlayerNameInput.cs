using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace MirrorMPlayer
{
    public class PlayerNameInput : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private TMP_Inputfield nameInputField = null;
        [SerializeField] private Button continueButton = null;

        public static string DisplayName { get; private set; }

        private const string PlayerPrefsNameKey = "PlayerName";

        private void Start() => SetUpInputField();
        private void SetUpInputField()
        {
            if (!PlayerPrefsNameKey.HasKey(PlayerPrefsNameKey))
            {
                return;
            }

            string defaultName = PlayerPrefs.GetString(PlayerPrefsNameKey);

            nameInputField.text = defaultName;
            SetPlayerName(default);
        }
        public void SetPlayerName(string Name)
        {
            continueButton.intractable = !string.IsNullOrEmpty(name);
        }
    }
}
