using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quit : MonoBehaviour
{
    public GameObject Menu;

    public void Menu_Open()
    {
        Menu.SetActive(true);
    }

    public void Menu_Cancel()
    {
        Menu.SetActive(false);
    }
}
