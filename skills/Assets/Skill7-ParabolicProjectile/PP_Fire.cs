using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PP_Fire : MonoBehaviour
{
    [SerializeField] GameObject m_goPrefab = null;
    [SerializeField] Transform m_tfArrow = null;
    Camera m_cam = null;

    // Start is called before the first frame update
    void Start()
    {
        m_cam = Camera.main;
    }

    void LookAtMouse(){
        Vector3 t_mousePos = m_cam.ScreenToWorldPoint(Input.mousePosition);
        
        Vector3 t_direction = new Vector3(t_mousePos.x, t_mousePos.y, m_tfArrow.position.z);
        // Vector2 t_direction = new Vector2(t_mousePos.x - m_tfArrow.position.x, t_mousePos.y - m_tfArrow.position.y);

        m_tfArrow.LookAt(t_direction);
        
    }

    void TryFire(){
        if(Input.GetMouseButtonDown(0)){
            GameObject t_arrow = Instantiate(m_goPrefab, m_tfArrow.position, m_tfArrow.rotation);
            t_arrow.GetComponent<Rigidbody>().velocity = t_arrow.transform.right * 10;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //현재 씬에서 할려면 설정할 것들이 생기고 그로 인해 전체적으로 수정이 필요해짐 = 다음 기회에
        // LookAtMouse(); 
        TryFire();
    }
}
