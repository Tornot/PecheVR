using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ResetBobberPos : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean resetAction;

    public Transform bobberTransform;
    private Vector3 bobberStartPos;
    private Quaternion bobberStartRotation;

    // Start is called before the first frame update
    void Start()
    {
        bobberStartPos = bobberTransform.position;
        bobberStartRotation = bobberTransform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetReset())
        {
            ResetBobber();
        }
    }

    public bool GetReset() // 2
    {
        return resetAction.GetStateDown(handType);
    }
    public void ResetBobber()
    {
        bobberTransform.position = bobberStartPos;
        bobberTransform.rotation = bobberStartRotation;
    }
}
