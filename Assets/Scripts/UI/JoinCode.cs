using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JoinCode : MonoBehaviour
{
    

    public TMP_Text code;

    private void Start()
    {
        string Code = PlayerPrefs.GetString("JoinCode");
        code.text = Code;
    }
}
