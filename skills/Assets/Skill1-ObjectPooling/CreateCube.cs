using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCube : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(CreateCorouttine());
    }

    IEnumerator CreateCorouttine(){
        while(true){
            yield return null;
            GameObject t_object = ObjectPoolingManager.instance.GetQueue();
            t_object.transform.position = transform.position;
        }
    }
}
