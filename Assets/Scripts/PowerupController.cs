﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupController : MonoBehaviour
{
    float rotatespeed;

    // Start is called before the first frame update
    void Start()
    {
        rotatespeed = Random.Range(60.0f, 90.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * rotatespeed);
    }
}
