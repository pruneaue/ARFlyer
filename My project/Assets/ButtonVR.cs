using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonVR : MonoBehaviour
{

    public GameObject videoPlayer;
    public int timetoStop;
    // public GameObject button;
    // public UnityEven onPress;
    // public UnityEvent onRelease;
    // GameObject presser;
    // bool isPressed;
    

    // Start is called before the first frame update
    void Start()
    {
        // isPressed = false;
        videoPlayer.SetActive(false);
    }

    void OnTriggerEnter(Collider player)
    {
        if (player.GameObject.tag == "MainCamera") {
            // presser = player.GameObject;
            // onPress.Invoke();
            // isPressed = true;
            videoPlayer.SetActive(true);
            Destroy(videoPlayer, timetoStop);
        }
    }

    // private void OnTriggerExit(Collider other) {
    //     if (other == presser) {
    //         onRelease.Invoke();
    //         isPressed = false;
    //         videoPlayer.SetActive(false);
    //     }
    // }




}
