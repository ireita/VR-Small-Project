using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.XR;

public class DeviceController : MonoBehaviour
{
    [SerializeField]
    private XRNode xrNode = XRNode.LeftHand;

    private List<InputDevice> devices = new List<InputDevice>();


    private InputDevice device;
   
    void GetDevice()
    {
        InputDevices.GetDevicesAtXRNode(xrNode, devices);
        device = devices.FirstOrDefault();
    }

    void OnEnable()
    {
        if (!device.isValid)
        {
            GetDevice();
        }
        
    }
    void Update()
    {
        if (!device.isValid)
        {
            GetDevice();
        }

        List<InputFeatureUsage> features = new List<InputFeatureUsage>();
        device.TryGetFeatureUsages(features);

        foreach (var feature in features)
        {
            Debug.Log(device.name);
        }
        //foreach (var device in devices)
        //{
        //    Debug.Log(device.characteristics);
        //}
        
        
    }
}
