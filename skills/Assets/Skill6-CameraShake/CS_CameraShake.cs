using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_CameraShake : MonoBehaviour
{
    [SerializeField] float m_force = 0f;
    [SerializeField] Vector3 m_offset = Vector3.zero;

    Quaternion m_originRot;
    Camera m_cam = null;

    // Start is called before the first frame update
    void Start()
    {
        m_cam = Camera.main;
        m_originRot = m_cam.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)){
            StartCoroutine(ShakeCoroutine());
        } else if(Input.GetKeyDown(KeyCode.B)){
            StopAllCoroutines();
            StartCoroutine(Reset());
        }
    }

    IEnumerator ShakeCoroutine(){
        Vector3 t_originEuler = m_cam.transform.eulerAngles;
        while(true){
            float t_rotX = Random.Range(-m_offset.x, m_offset.x);
            float t_rotY = Random.Range(-m_offset.y, m_offset.y);
            float t_rotZ = Random.Range(-m_offset.z, m_offset.z);

            Vector3 t_randomRot = t_originEuler + new Vector3(t_rotX, t_rotY, t_rotZ);
            Quaternion t_rot = Quaternion.Euler(t_randomRot);


            while(Quaternion.Angle(m_cam.
transform.rotation, t_rot) > 0.1f){
                m_cam.
    transform.rotation = Quaternion.RotateTowards(m_cam.
    transform.rotation, t_rot, m_force * Time.deltaTime);
                yield return null;
            }
            yield return null;
        }
    }
    
    IEnumerator Reset(){
        while(Quaternion.Angle(m_cam.transform.rotation, m_originRot) > 0f){
            m_cam.
transform.rotation = Quaternion.RotateTowards(m_cam.
transform.rotation, m_originRot, m_force * Time.deltaTime);
            yield return null;
        }
    }
}
