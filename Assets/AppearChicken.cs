using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearChicken : MonoBehaviour {

	public void appear(GameObject chicken)
    {
        chicken.SetActive(true);
    }
}
