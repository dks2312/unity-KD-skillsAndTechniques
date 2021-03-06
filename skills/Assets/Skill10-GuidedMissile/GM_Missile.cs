using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_Missile : MonoBehaviour
{
    Rigidbody m_rigid = null;
    Transform m_tfTarget = null;

    [SerializeField] float m_speed = 0f;
    float m_currentSpeed = 0f;
    [SerializeField] LayerMask m_layerMask = 0;
    [SerializeField] ParticleSystem m_psEttect = null;

    void SerachEnemy(){
        Collider[] t_cols = Physics.OverlapSphere(transform.position, 100f, m_layerMask);

        if(t_cols.Length > 0){
            m_tfTarget = t_cols[Random.Range(0, t_cols.Length)].transform;
        }
    }

    IEnumerator LaunchDelay(){
        yield return new WaitUntil(() => m_rigid.velocity.y < 0f);
        yield return new WaitForSeconds(0.1f);

        SerachEnemy();
        m_psEttect.Play();

        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
    void Start()
    {
        m_rigid = GetComponent<Rigidbody>();
        StartCoroutine(LaunchDelay());
    }

    // Update is called once per frame
    void Update()
    {
        if(m_tfTarget != null){
            if(m_currentSpeed <= m_speed){
                m_currentSpeed += m_speed * Time.deltaTime;
            }

            transform.position += transform.up * m_currentSpeed * Time.deltaTime;

            Vector3 t_dir = (m_tfTarget.position - transform.position).normalized;
            transform.up = Vector3.Lerp(transform.up, t_dir, 0.25f);
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(other.transform.CompareTag("Enemy")){
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
