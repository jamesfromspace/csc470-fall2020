﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position += Vector3.right * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
