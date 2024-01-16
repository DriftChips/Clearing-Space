using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenuOpenClose : MonoBehaviour
{
    [SerializeField]
    private GameObject Panel;

    public void OpenSettingsPanel()
    {
        if(Panel != null)
        {
            Panel.SetActive(true);
        }
    }

    public void CloseSettingsPanel()
    {
        if(Panel != null)
        {
            Panel.SetActive(false);
        }
    }
}
