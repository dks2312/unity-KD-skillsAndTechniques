using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScrolling : MonoBehaviour
{
    [SerializeField] Transform[] m_tfBackgrounds = null;
    [SerializeField] float m_speed = 0f;
 
    float m_leftPosX = 0f;
    float m_rightPosX = 0f;
    void Start()
    {
        float t_length = m_tfBackgrounds[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        m_leftPosX = -t_length;
        m_rightPosX = t_length * m_tfBackgrounds.Length;
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < m_tfBackgrounds.Length; i++){
            m_tfBackgrounds[i].position += new Vector3(m_speed,0,0) * Time.deltaTime;

            if(m_tfBackgrounds[i].position.x < m_leftPosX){
                Vector3 t_selfPox = m_tfBackgrounds[i].position;
                t_selfPox.Set(t_selfPox.x + m_rightPosX, t_selfPox.y, t_selfPox.z);
                m_tfBackgrounds[i].position = t_selfPox;
            }
        }
    }
}
