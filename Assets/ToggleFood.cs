using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleFood : MonoBehaviour {

	// Use this for initialization
	public void TogglePannel(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);
    }
}
