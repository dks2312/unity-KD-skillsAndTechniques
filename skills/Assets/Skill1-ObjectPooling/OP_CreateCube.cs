using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OP_CreateCube : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(CreateCorouttine());
    }

    IEnumerator CreateCorouttine(){
        while(true){
            yield return null;
            GameObject t_object = OP_Manager.instance.GetQueue();
            t_object.transform.position = transform.position;
        }
    }
}
