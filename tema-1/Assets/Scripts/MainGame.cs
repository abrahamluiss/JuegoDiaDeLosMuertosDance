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
    public GameObject m_camaraPrincipal;
    public GameObject m_maestro;
    public GameObject m_jugador;
    public Animator m_animadorMaestro;
    public Animator m_animadorJugador;
    public enum TipoPaso { None, Right, Up, Left, Down};
    //para la flecha
    static Quaternion[] PasoBase = new Quaternion[] { 
        Quaternion.Euler(0,0,0f),
        Quaternion.Euler(0,0,0f),
        Quaternion.Euler(0,0,90f),
        Quaternion.Euler(0,0,180f),
        Quaternion.Euler(0,0,270f),

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
        EstadoBase.SetGame(this);//asigandno al valor
        EstadoBase.Cambiar(EstadoIrProfesor.Intancia);
    }

    void ReiniciarJuego()
    {
        m_Vamos.SetActive(false);
        m_nVidas = 3;
        m_MisPuntos = 0;
        ActualizarVidas();
        SumaPuntuacion(0);
        m_Pasos.Clear();//limpia lista de pasos
        ReiniciarPaso();
    }

    public void ReiniciarPaso()
    {
        m_Fall.SetActive(false);
        m_Flecha.SetActive(false);
    }

    public void SumaPuntuacion(int puntos)
    {
        m_MisPuntos += puntos;
        m_Puntuacion.text = m_MisPuntos.ToString("D6");
    }

    private void ActualizarVidas()//establece un contador activa y desactiva los obj de vidas dependiendo de las vidas que tenemos
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
    public void IniciarPasos()
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
        animator.SetInteger("Direccion", 0);
        return false;
    }
    public bool CompruebaPaso(Animator animator, TipoPaso _paso)
    {
        if (m_PasoActual.MoveNext())
        {
            m_Flecha.SetActive(true);
            int paso = (int)_paso;
            animator.SetInteger("Direccion", paso);
            //TODO:sonido

            m_Flecha.transform.rotation = PasoBase[paso];
            if(m_PasoActual.Current == _paso)//comprobar q el paso actual sea igual al paso q se lepaso
            {
                animator.Update(0);
                animator.SetInteger("Direccion",0);
                return true;
            }
        }
        animator.SetInteger("Direccion", 0);
        return false;
    }
    public bool HaTerminado()
    {
        var copia = m_PasoActual;
        return !copia.MoveNext();
    }
    public void AddNewStep()//agrega paso a la lista, mete un nuevo paso a la lista
    {
        m_Pasos.Add((TipoPaso)UnityEngine.Random.Range(1,5));
    }

    // Update is called once per frame
    void Update()
    {
        EstadoBase.ActualizarEstadoActual();
        //if (Input.GetMouseButtonDown(0))
        //   GameObject.Destroy(m_miChica);
    }
    public void MuestraEmpezar()
    {
        m_Vamos.SetActive(true);
    }
    public void MalPaso()
    {
        m_Fall.SetActive(true);
        m_animadorJugador.SetInteger("Direccion", 5);
        m_animadorJugador.Update(0);
        m_animadorJugador.SetInteger("Direccion", 0);
        m_nVidas--;
        ActualizarVidas();
        if (m_nVidas < 1)
        {
            //finalizar Parti
            EstadoBase.Cambiar(EstadoFinJuego.Intancia);
        }
        else//se entra en un nuevos estado
        {
            EstadoBase.Cambiar(EstadoFinJugador.Intancia);
        }
    }
    public void GameOver()
    {
        m_InGame.SetActive(false);
        m_GameOver.SetActive(true);
    }
}
