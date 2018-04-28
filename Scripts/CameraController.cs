using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Vector3 center;
    public Vector3 v = Vector3.zero;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        v = v + 0.001f * (center - transform.position).normalized;
        transform.position = transform.position + v;
        transform.LookAt(transform.position + v);
        MoveCenter();

    }

    void MoveCenter()
    {
        Vector2 rand = 5 * Random.insideUnitCircle;
        Vector3 v3 = new Vector3(rand.x, 0, rand.y);
        center = center + v3;


    }
}
