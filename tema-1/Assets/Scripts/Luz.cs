using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luz : MonoBehaviour
{
    Light m_miLuz;
    float m_reloj;
    public float m_tiempo = 1.0f; //esta variable se puede editar desde el inspector
    // Start is called before the first frame update
    void Start()
    {
        m_miLuz = gameObject.GetComponent<Light>();
        m_reloj = 0;
    }

    // Update is called once per frame
    void Update()
    {
        m_reloj += Time.deltaTime;
        if(m_reloj >= m_tiempo)
        {
            m_miLuz.enabled = !m_miLuz.enabled;
            m_reloj = 0;
        }
        
    }
}
