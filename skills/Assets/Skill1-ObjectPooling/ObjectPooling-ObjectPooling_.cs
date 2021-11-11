using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling_CreateCube : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(CreateCorouttine());
    }

    IEnumerator CreateCorouttine(){
        while(true){
            yield return null;
            GameObject t_object = ObjectPooling_Manager.instance.GetQueue();
            t_object.transform.position = transform.position;
        }
    }
}
