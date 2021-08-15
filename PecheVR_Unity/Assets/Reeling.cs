using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Reeling : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean reelingAction;

    public Transform bobbertransform;
    public Rigidbody bobberRigidbody;
    public Transform fishingRodTipTransform;

    

    public float forceOnReeling = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetReel())
        {
            ReelingAction();
        }
    }
    public bool GetReel() // 2
    {
        return reelingAction.GetState(handType);
    }
    public void ReelingAction()
    {
        Vector3 forceDirection;

        //print("Reeling " + handType);
        //Compute force direction
        forceDirection.x = fishingRodTipTransform.position.x - bobbertransform.position.x;
        forceDirection.y = fishingRodTipTransform.position.y - bobbertransform.position.y;
        forceDirection.z = fishingRodTipTransform.position.z - bobbertransform.position.z;
        bobbertransform.transform.LookAt(fishingRodTipTransform);
        bobberRigidbody.AddForce(forceDirection.normalized * forceOnReeling);
    }
}
