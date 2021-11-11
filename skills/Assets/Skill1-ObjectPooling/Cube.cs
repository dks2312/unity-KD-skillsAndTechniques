using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    Rigidbody m_rigidbody = null;

    private void OnEnable() {
        if(m_rigidbody == null){
            m_rigidbody = GetComponent<Rigidbody>();
        }

        m_rigidbody.AddExplosionForce(1000, transform.position, 1f);
        StartCoroutine(DestroyCube());
    }

    IEnumerator DestroyCube(){
        yield return new WaitForSeconds(1f);
        ObjectPoolingManager.instance.InsertQueue(gameObject);
    }
}
