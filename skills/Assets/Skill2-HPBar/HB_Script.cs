using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HB_Script : MonoBehaviour
{
  [SerializeField] GameObject m_goPrefab = null;
  
  List<Transform> m_objcetList = new List<Transform>();
  List<GameObject> m_hpBarList = new List<GameObject>();

  Camera m_cam = null;

  void Start(){
    m_cam = Camera.main;

    GameObject[] t_object = GameObject.FindGameObjectsWithTag("Player");
    for(int i = 0; i < t_object.Length; i++){
      m_objcetList.Add(t_object[i].transform);
      GameObject t_hpbar = Instantiate(m_goPrefab, transform.position, Quaternion.identity, transform);
      m_hpBarList.Add(t_hpbar);
    }
  }

  void Update(){
    for(int i = 0; i < m_objcetList.Count; i++){
      m_hpBarList[i].transform.position = m_cam.WorldToScreenPoint(m_objcetList[i].position + new Vector3(0, 1.15f, 0));
    }
  }
}