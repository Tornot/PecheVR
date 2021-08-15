using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingOnWater : MonoBehaviour
{
    public Transform floatingObjectTransform;
    public Rigidbody floatingObjectRigidbody;
    public float floatingForce = 10.0f;
    public float floatingAltitude = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (floatingObjectTransform.position.y < floatingAltitude)
        {
            floatingObjectRigidbody.AddForce(0, floatingForce, 0, ForceMode.Force);
        }
        if (floatingObjectTransform.position.y < floatingAltitude / 2)
            floatingObjectTransform.position = new Vector3 (floatingObjectTransform.position.x, floatingAltitude / 2, floatingObjectTransform.position.z);
    }
}
