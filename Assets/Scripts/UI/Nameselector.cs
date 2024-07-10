using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Nameselector : MonoBehaviour
{
    [SerializeField] private TMP_InputField NameInputField;
    [SerializeField] private Button ConnectButton;
    private int minNameLength = 2;
    private int maxNameLength = 12;
    
    // Start is called before the first frame update
    void Start()
    {
        if(SystemInfo.graphicsDeviceType == UnityEngine.Rendering.GraphicsDeviceType.Null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            return;
        }

        PlayerPrefs.GetString("PlayerNameKey", "Missing Name");
        HandleNameChanged();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleNameChanged()
    {
        ConnectButton.interactable = NameInputField.text.Length >= minNameLength && NameInputField.text.Length <= maxNameLength;
    }

    public void Connect()
    {
        PlayerPrefs.SetString("PlayerNameKey", NameInputField.text);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
