using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HoloButton : MonoBehaviour {

    public Button popup;

    public void Selected()
    {
        popup.gameObject.SetActive(false);

    }

}
