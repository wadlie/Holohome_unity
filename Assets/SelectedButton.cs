using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;



public class SelectedButton : MonoBehaviour
{

public Button popUp;

    void Select()
    {
        popUp.Select();
    }
    public void ButtonAction()
    {
        Debug.Log("<b>Your button works!</b>");
    }

}
