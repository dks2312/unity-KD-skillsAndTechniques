﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT_chd : MonoBehaviour
{
    public float Speed = 50f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Speed * Time.deltaTime;
    }
}
