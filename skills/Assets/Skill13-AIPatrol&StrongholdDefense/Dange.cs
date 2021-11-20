using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dange : MonoBehaviour
{
    [SerializeField] EuemyAI m_enemy = null;

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            m_enemy.SetTarget(other.transform);
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("Player")){
            m_enemy.RemoveTarget();
        }
    }
}
