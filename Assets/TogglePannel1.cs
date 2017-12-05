using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglePannel1 : MonoBehaviour {

    // Use this for initialization
    public void TogglePanel(GameObject panel)
    {
        panel.SetActive(true); //called from the fridge button
    }
}
