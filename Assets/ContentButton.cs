using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ContentButton : MonoBehaviour {

    public Button food;

    public void ToggleFood()
    {
        food.Select();
    }
	
}
