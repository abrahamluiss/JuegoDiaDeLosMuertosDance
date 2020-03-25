using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAnimaciones : MonoBehaviour
{
    public AudioClip m_sonido1;
    public AudioSource m_miOrigen;
   // public AudioListener m_camera;//tiene la referencia de la camara
    Animator m_Animator;
    Vector2 m_inicioToque;
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      
        if (Input.touchCount > 0)
        {
            if(Input.touches[0].phase == TouchPhase.Began)
            {
                m_inicioToque = Input.touches[0].position;
            }
            else
            {
                if (Input.touches[0].phase == TouchPhase.Ended)
                {
                    Vector2 dif = Input.touches[0].position - m_inicioToque;
                    if(Mathf.Abs(dif.x) > dif.y)
                    {
                        if (dif.x < 0) { }//Mov izquierda
                        else//movimiento derecha
                        { }

                    }
                    else    
                    {
                        if (dif.y < 0) { }//mov arriba
                        else { }//mov abajo
                    }
                }
            }
        }
        

    }
}
