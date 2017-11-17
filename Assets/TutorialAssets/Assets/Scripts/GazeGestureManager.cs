using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class GazeGestureManager : MonoBehaviour {

    public static GazeGestureManager Instance { get; private set; }

    public Button popUp;
    // Represents the hologram that is currently being gazed at.
    public GameObject FocusedObject { get; private set; }

    UnityEngine.XR.WSA.Input.GestureRecognizer recognizer;

    // Use this for initialization
    void Start()
    {
        Instance = this;
        popUp.gameObject.SetActive(false);
        // Set up a GestureRecognizer to detect Select gestures.
        recognizer = new UnityEngine.XR.WSA.Input.GestureRecognizer();
        recognizer.TappedEvent += (source, tapCount, ray) =>
        {
            // Send an OnSelect message to the focused object and its ancestors.
            if (FocusedObject != null)
            {
                if (FocusedObject.gameObject.tag == "Button")  // comment out if u want it to turn on and off
                {
                    FocusedObject.SendMessageUpwards("HighlightButton");
                }
                FocusedObject.SendMessageUpwards("OnSelect");    
            }
        };
        recognizer.StartCapturingGestures();
    }

    // Update is called once per frame
    void Update()
    {
        // Figure out which hologram is focused this frame.
        GameObject oldFocusObject = FocusedObject;

        // Do a raycast into the world based on the user's
        // head position and orientation.
        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;

        RaycastHit hitInfo;
        if (Physics.Raycast(headPosition, gazeDirection, out hitInfo))
        {
            // If the raycast hit a hologram, use that as the focused object.
            FocusedObject = hitInfo.collider.gameObject;
            if (hitInfo.collider.gameObject.tag == "Fridge")
            {
                OnSelect();
            }
            if (FocusedObject.tag == "Button")
            {
                HighlightButton();
            }
        }
        else
        {
            // If the raycast did not hit a hologram, clear the focused object.
            FocusedObject = null;
        }

        // If the focused object changed this frame,
        // start detecting fresh gestures again.
        if (FocusedObject != oldFocusObject)
        {
            recognizer.CancelGestures();
            recognizer.StartCapturingGestures();
        }
    }

     void OnSelect()
    {
        popUp.gameObject.SetActive(true);
    }
    void HighlightButton()
    {
        popUp.Select();
    }
}
