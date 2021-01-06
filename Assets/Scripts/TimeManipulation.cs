﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class TimeManipulation : MonoBehaviour
{
    public XRController rechts;
    private float fixedDeltaTime;
    public AudioSource slowmoinSource;
    public AudioSource slowmooutSource;
    public AudioClip slowmoin;
    public AudioClip slowmoout;
    public InputHelpers.Button ActivationButton;


    // Update is called once per frame
    void Update()
    {
        if (CheckIfActivated(rechts))
        {
            if (Time.timeScale == 1.0f)

            {
                Time.timeScale = 0.2f;
                slowmoinSource.PlayOneShot(slowmoin, 0.9f);
            }

            else
            {
                Time.timeScale = 1.0f;
                slowmooutSource.PlayOneShot(slowmoout, 0.9f);
            }
                // Adjust fixed delta time according to timescale
                // The fixed delta time will now be 0.02 frames per real-time second
                Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }
    }
    public bool CheckIfActivated(XRController rechts)
    {
        InputHelpers.IsPressed(rechts.inputDevice, ActivationButton, out bool isPressed);
        return isPressed;
    }
}

