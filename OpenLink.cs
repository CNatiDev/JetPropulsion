using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLink : MonoBehaviour
{
    public void OpenLinkURL(string link)
    {
        Application.OpenURL(link);
    }
}
