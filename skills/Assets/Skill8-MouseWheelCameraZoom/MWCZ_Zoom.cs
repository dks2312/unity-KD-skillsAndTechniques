using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MWCZ_Zoom : MonoBehaviour
{

    [SerializeField] float m_zoomSpeed = 0f;
    [SerializeField] float m_zoomMax = 0f;
    [SerializeField] float m_zoomMin = 0f;
    Camera m_cam = null;

    void CameraZoom(){
        float t_zoomDirection = -Input.GetAxis("Mouse ScrollWheel");
        
        if(transform.position.z >= m_zoomMax && t_zoomDirection > 0)
            return;
        if(transform.position.z <= m_zoomMin && t_zoomDirection < 0)
            return;
        
        transform.position += transform.forward * t_zoomDirection * m_zoomSpeed;
        
    }

    void CameraMove(){
        if(Input.GetMouseButton(2)){
            float t_posX = Input.GetAxis("Mouse X");
            float t_posZ = Input.GetAxis("Mouse Y");

            transform.position += new Vector3(t_posX, 0, t_posZ);
        }
    }
    
    void Start()
    {
        m_cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        CameraZoom();
        CameraMove();
    }
}
