using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveLeftSide : MonoBehaviour
{
    public float velocity = 30.0f;
    public float maximumAngle = 0.0f;
    public float minimumAngle = -45.0f;
    public Vector3 rotationDirection = new(1, 1, 0);
    private float x;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var x2 = x + velocity * Time.deltaTime;

        if (x2 > maximumAngle || x2 < minimumAngle)
        {
            velocity = -velocity;
        }

        x += velocity * Time.deltaTime;
        transform.localRotation = Quaternion.AngleAxis(x, rotationDirection);
    }

    private void OnValidate()
    {
    }
}