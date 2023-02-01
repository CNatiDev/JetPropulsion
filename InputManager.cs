using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public GameObject[] UiButton;
    void Start()
    {
        if (Application.platform == RuntimePlatform.WindowsPlayer)
        {
            for (int i = 0; i < UiButton.Length; i++)
                UiButton[i].SetActive(false);
        }    
    }
}
