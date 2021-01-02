using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;


public class CapsuleFollowCamera : MonoBehaviour
{
    private XRRig rig;
    private Vector2 inputAxis;
    private CharacterController character;
    private GameObject head = null;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        rig = GetComponent<XRRig>();
        head = GetComponent<XRRig>().cameraGameObject;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CapsuleFollowHeadset();
    }

    void CapsuleFollowHeadset()

    {

        character.height = rig.cameraInRigSpaceHeight;
        Vector3 capsuleCenter = transform.InverseTransformPoint(rig.cameraGameObject.transform.position);
        character.center = new Vector3(capsuleCenter.x, character.height / 2 + 0.08f, capsuleCenter.z);





    }



}