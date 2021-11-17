using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PP_Arrow : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.right = GetComponent<Rigidbody>().velocity;
    }
}
