 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DJ_Jump : MonoBehaviour
{
    [SerializeField] float m_jumpForce = 0f;
    [SerializeField] int m_maxJumpCount = 0;
    int m_jumpCount = 0;

    Rigidbody m_rigid = null;

    float m_distance = 0f;
    [SerializeField] LayerMask m_layerMask = 0;
    void Start()
    {
        m_rigid = GetComponent<Rigidbody>();
        m_distance = GetComponent<BoxCollider>().bounds.extents.y + 0.05f;
    }

    // Update is called once per frame
    void TryJump(){
        if(Input.GetKeyDown(KeyCode.Space)){
            if(m_jumpCount < m_maxJumpCount){
                m_rigid.velocity = Vector3.up * m_jumpForce;
                m_jumpCount++;
            }
        }
    }

    void CheckGround(){
        if(m_rigid.velocity.y < 0){
            RaycastHit t_hit;

            if(Physics.Raycast(transform.position, Vector3.down, out t_hit, m_distance, m_layerMask)){
                if(t_hit.transform.CompareTag("Ground")){
                    m_jumpCount = 0;
                }
            }
        }
    }
    void Update()
    {
        TryJump();
        CheckGround();
    }
}
