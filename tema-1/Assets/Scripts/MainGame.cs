using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class MainGame : MonoBehaviour
{
    //public GameObject m_chica;
    //private GameObject m_miChica;
    public GameObject[] m_Vida;//array de vidas
    int m_nVidas;
    public Text m_Puntuacion;
    int m_MisPuntos;
    public GameObject m_Vamos;
    public GameObject m_InGame;
    public GameObject m_GameOver;
    public GameObject m_Flecha;
    public GameObject m_Fall;
    public enum TipoPaso { None, Right, Up, Left, Down};
    //para la flecha
    static Quaternion[] PasoBase = new Quaternion[] { 
        Quaternion.Euler(0,0,0f),
        Quaternion.Euler(0,0,90f),
        Quaternion.Euler(0,0,180f),
        Quaternion.Euler(0,0,270f),
        Quaternion.Euler(0,0,0f)
    };
    List<TipoPaso> m_Pasos = new List<TipoPaso>();
    List<TipoPaso>.Enumerator m_PasoActual;
    // Start is called before the first frame update
    // Que es lo que primero va a ocurrir cuando inicie el juego
    void Start()
    {
        // m_miChica = GameObject.Instantiate(m_chica);
        ReiniciarJuego();

        AddNewStep();
        AddNewStep();
        AddNewStep();
    }

    void ReiniciarJuego()
    {
        m_nVidas = 3;
        m_MisPuntos = 0;
        Actualizar();
        SumaPuntuacion(0);
        m_Pasos.Clear();//limpia lista de pasos
        ReiniciarPaso();
    }

    private void ReiniciarPaso()
    {
        m_Fall.SetActive(false);
        m_Flecha.SetActive(false);
    }

    public void SumaPuntuacion(int puntos)
    {
        m_MisPuntos += puntos;
        m_Puntuacion.text = m_MisPuntos.ToString("D6");
    }

    private void Actualizar()//establece un contador activa y desactiva los obj de vidas dependiendo de las vidas que tenemos
    {
        int i = 0;
        for(i=0; i < m_nVidas; ++i)
        {
            m_Vida[i].SetActive(true);
        }
        for (; i < 3; ++i)
        {
            m_Vida[i].SetActive(false);
        }

    }
    void IniciarPasos()
    {
        m_PasoActual = m_Pasos.GetEnumerator();//da el primer paso
    }
    public bool MuestreSiguientePaso(Animator animator)
    {
        if (m_PasoActual.MoveNext())
        {
            m_Flecha.SetActive(true);
            int paso = (int)m_PasoActual.Current;
            animator.SetInteger("Direccion", paso);
            //TODO:sonido

            m_Flecha.transform.rotation = PasoBase[paso];
            return true;
        }
        return false;
    }
    public void AddNewStep()//agrega paso a la lista, mete un nuevo paso a la lista
    {
        m_Pasos.Add((TipoPaso)UnityEngine.Random.Range(1,4));
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //   GameObject.Destroy(m_miChica);
    }
}
