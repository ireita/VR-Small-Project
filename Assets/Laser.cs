using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Laser : MonoBehaviour
{
    public float shootRate;
    public XRController links;
    public XRController rechts;

    private float m_shootRateTimeStamp;
    private float activationThreshold = 0.1f;

    public GameObject m_shotPrefab;
    public InputHelpers.Button ActivationButton;
    RaycastHit hit;
    float range = 1000.0f;


    void Update()
    {
        if (CheckIfActivated(rechts))
        {
            if (Time.time > m_shootRateTimeStamp)
            {
                shootLaser();
                m_shootRateTimeStamp = Time.time + shootRate;
            }
        }

    }

    void shootLaser()
    {
        Ray ray = new Ray(this.transform.position, this.transform.forward);
        if (Physics.Raycast(ray, out hit, range))
        {
            GameObject laser = GameObject.Instantiate(m_shotPrefab, transform.position, transform.rotation) as GameObject;
            laser.GetComponent<ShotBehavior>().setTarget(hit.point);
            GameObject.Destroy(laser, 2.0f);


        }

    }

    public bool CheckIfActivated(XRController rechts)
    {
        InputHelpers.IsPressed(rechts.inputDevice, ActivationButton, out bool isActivated, activationThreshold);
        return isActivated;
    }

}