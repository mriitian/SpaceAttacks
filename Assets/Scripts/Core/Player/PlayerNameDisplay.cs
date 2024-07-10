using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using UnityEngine;

public class PlayerNameDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text playerNameDisplay;
    [SerializeField] private TankPlayer player;
    // Start is called before the first frame update
    void Start()
    {
        HandlePlayerNameChanged(string.Empty, player.PlayerName.Value);
        player.PlayerName.OnValueChanged += HandlePlayerNameChanged;
    }

    private void HandlePlayerNameChanged(FixedString32Bytes oldName, FixedString32Bytes newName)
    {
        playerNameDisplay.text = newName.ToString();
    }

    // Update is called once per frame
    void OnDestroy()
    {
        player.PlayerName.OnValueChanged -= HandlePlayerNameChanged;
    }
}
