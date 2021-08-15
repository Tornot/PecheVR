using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodStringSpawn : MonoBehaviour
{

    [SerializeField]
    GameObject partPrefab, parentObject;

    [SerializeField]
    [Range(1, 1000)]
    int lenght = 1;

    [SerializeField]
    float partDistance = 0.09f;

    [SerializeField]
    bool reset, spawn, snapFirst, snapLast;

    private void Start()
    {/*
        GameObject tmp1, tmp2;
        tmp1 = GameObject.Find("rod 2");
        tmp2 = GameObject.Find("RodString");
        tmp2.transform.position.Set(tmp1.transform.position.x, tmp1.transform.position.y, tmp1.transform.position.z);
        */
    }

    // Update is called once per frame
    void Update()
    {
        if (reset)
        {
            foreach (GameObject tmp in GameObject.FindGameObjectsWithTag("Player"))
            {
                Destroy(tmp);
            }

            reset = false;
        }

        if (spawn)
        {
            Spawn();

            spawn = false;
        }



    }


    public void Spawn()
    {
        int count = (int)(lenght / partDistance);
        

        for (int x = 0; x < count; x++)
        {

            GameObject tmp;

            tmp = Instantiate(partPrefab, new Vector3(parentObject.transform.position.x, parentObject.transform.position.y + partDistance * (x + 1), parentObject.transform.position.z), Quaternion.identity, parentObject.transform);
            tmp.transform.eulerAngles = new Vector3(180, 0, 0);

            tmp.name = parentObject.transform.childCount.ToString();

            if (x == 0)
            {
                Destroy(tmp.GetComponent<CharacterJoint>());
                if (snapFirst)
                {
                    tmp.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                }
            }
            else
            {
                tmp.GetComponent<CharacterJoint>().connectedBody = parentObject.transform.Find((parentObject.transform.childCount - 1).ToString()).GetComponent<Rigidbody>();
            }

            if (snapLast)
            {
                parentObject.transform.Find((parentObject.transform.childCount).ToString()).GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            }
        }
    }
}
