using System;
using UnityEngine;

public class EstadoJugador : InstanciEstadoBase<EstadoJugador>
{
    float m_reloj = 0;
    float m_duracion = 2.0f;//segundos

    public override void Start(MainGame game)
    {
        m_reloj = 0;
        game.IniciarPasos();
        game.MuestraEmpezar();
        game.m_camaraPrincipal.transform.LookAt(game.m_jugador.transform.position + Vector3.up);//camara mirando al jugador

    }
    public override void Update(MainGame game)
    {
        m_reloj += Time.deltaTime;//sumar al tiempor transcurrido entre frame y frame
        if(m_reloj < m_duracion)//si es menor
        {
            //puedo marcar mi mov
            MainGame.TipoPaso paso = ControlTeclado();
            if(paso!=MainGame.TipoPaso.None)//que realmente se pulso algo
            {
                m_reloj = 0;
                if(game.CompruebaPaso(game.m_animadorJugador, paso))
                {
                    game.SumaPuntuacion(100);
                    if (game.HaTerminado())
                    {
                        game.TocarSonido(MainGame.Efectos.Bien1, MainGame.Efectos.Bien2);
                        game.AddNewStep();
                        EstadoBase.Cambiar(EstadoFinJugador.Intancia);
                    }
                    return;
                }
                else
                {

                    game.MalPaso();
                }
            }
            else
                return;

        }
        else
        {
            //que el tiempo de hacer el mov termino entonces marco mal paso
            game.MalPaso();
        }
    }

    MainGame.TipoPaso ControlTeclado()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow)) return MainGame.TipoPaso.Down;
        if (Input.GetKeyDown(KeyCode.UpArrow)) return MainGame.TipoPaso.Up;
        if (Input.GetKeyDown(KeyCode.LeftArrow)) return MainGame.TipoPaso.Left;
        if (Input.GetKeyDown(KeyCode.RightArrow)) return MainGame.TipoPaso.Right;
        return ControlGesto();
    }
    Vector2 m_Inicio;
    private MainGame.TipoPaso ControlGesto()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];
            if(touch.phase == TouchPhase.Began)
            {
                m_Inicio = touch.position;
            }
            else
            {
                if (touch.phase == TouchPhase.Ended)
                {
                    Vector2 delta = touch.position - m_Inicio;
                    if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
                    {
                        if (delta.x < 0) return MainGame.TipoPaso.Left;
                        else return MainGame.TipoPaso.Right;

                    }
                    else
                    {
                        if (delta.y < 0) return MainGame.TipoPaso.Up;
                        else return MainGame.TipoPaso.Down;
                    }
                }
            }

        }
        return MainGame.TipoPaso.None;
    }
}
