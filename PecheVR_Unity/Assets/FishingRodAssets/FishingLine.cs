using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingLine : MonoBehaviour
{
    public GameObject FishingTip;
    public GameObject Bobber;
    private float ropeWidth = 0.02f;

    // Start is called before the first frame update
    void Start()
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.startWidth = this.ropeWidth;
        lineRenderer.endWidth = this.ropeWidth;
        lineRenderer.startColor = Color.cyan;
        lineRenderer.endColor = Color.cyan;
        lineRenderer.material = new Material(Shader.Find("Legacy Shaders/Particles/Alpha Blended Premultiply"));

        lineRenderer.SetPosition(0, Bobber.transform.position);
        lineRenderer.SetPosition(1, FishingTip.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = this.ropeWidth;
        lineRenderer.endWidth = this.ropeWidth;

        lineRenderer.startColor = Color.cyan;
        lineRenderer.endColor = Color.cyan;
        lineRenderer.SetPosition(0, Bobber.transform.position);
        lineRenderer.SetPosition(1, FishingTip.transform.position);
    }
}
