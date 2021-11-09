using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    Rigidbody rigidbody = null;

    private void OnEnable() {
        if(rigidbody == null){
            rigidbody = GetComponent<Rigidbody>();
        }

        rigidbody.AddExplosionForce(1000, transform.position, 1f);
        StartCoroutine(DestroyCube());
    }

    IEnumerator DestroyCube(){
        yield return new WaitForSeconds(1f);
        ObjectPoolingManager.instance.InsertQueue(gameObject);
    }
}
