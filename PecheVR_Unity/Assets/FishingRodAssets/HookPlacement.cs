using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookPlacement : MonoBehaviour
{
    public Transform whatTheHookIsConnectedTo;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(whatTheHookIsConnectedTo.position.x, whatTheHookIsConnectedTo.position.y, whatTheHookIsConnectedTo.position.z);

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(whatTheHookIsConnectedTo.position.x, whatTheHookIsConnectedTo.position.y - 0.08f, whatTheHookIsConnectedTo.position.z);
    }
}
