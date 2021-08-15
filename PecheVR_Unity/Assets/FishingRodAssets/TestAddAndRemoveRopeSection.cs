using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAddAndRemoveRopeSection : MonoBehaviour
{
    private int iterationCount = 0;
    RopeControllerRealistic ropeControllerRealistic0;

    // Start is called before the first frame update
    void Start()
    {
        
        ropeControllerRealistic0 = GameObject.Find("RodLine").GetComponent<RopeControllerRealistic>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (iterationCount > 500)
        {
            //Vector3 tempVect;
            //int tempCount;
            /*
            //Add a new element on the list of sections of the rope, at the position of rodtip
            ropeControllerRealistic0.allRopeSections.Add(new RopeSection(ropeControllerRealistic0.whatTheRopeIsConnectedTo.position)) ;
            ropeControllerRealistic0.allRopeSections[ropeControllerRealistic0.allRopeSections.Count].pos.y -= ropeControllerRealistic0.getRopeSectionLength()/2;
            tempVect = ropeControllerRealistic0.allRopeSections[ropeControllerRealistic0.allRopeSections.Count].pos;
            tempVect.y -= ropeControllerRealistic0.getRopeSectionLength() / 2;
            tempCount = ropeControllerRealistic0.allRopeSections.Count - 2;
            ropeControllerRealistic0.allRopeSections[tempCount].pos = tempVect;

            ropeControllerRealistic0.numberOfRopeSection++;
            Debug.Log(ropeControllerRealistic0.allRopeSections.Count);
            //iterationCount = 0;*/
        }
        iterationCount++;
    }
}
