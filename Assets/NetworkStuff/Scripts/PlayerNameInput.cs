using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//See from resource: https://www.youtube.com/watch?v=Fx8efi2MNz0
public class PlayerNameInput : MonoBehaviour
{

    [Header("UI")]
    [SerializeField] private TMP_InputField nameInputField = null;
    [SerializeField] private Button continueButton = null;

    //Grabs display name
    public static string DisplayName { get; private set; }

    //constant string for player name
    private const string PlayerPrefsNameKey = "PlayerName";

    private void Start() => SetUpInputField();

    private void SetUpInputField()
    {
        if (!PlayerPrefs.HasKey(PlayerPrefsNameKey)) { return; }

        string defaultName = PlayerPrefs.GetString(PlayerPrefsNameKey);
        //Loads saved player name
        nameInputField.text = defaultName;

        SetPlayerName(defaultName);

    }

    //This allows player to only continue when their name is valid
    public void SetPlayerName(string name)
    {
        continueButton.interactable = !string.IsNullOrEmpty(name);
    }

    //Saves player name for players that have played before
    public void SavePlayerName()
    {
        DisplayName = nameInputField.text;

        PlayerPrefs.SetString(PlayerPrefsNameKey, DisplayName);
    }
}
