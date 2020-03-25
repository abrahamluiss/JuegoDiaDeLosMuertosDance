using UnityEngine;

public class EstadoIrJugador : InstanciEstadoBase<EstadoIrJugador>
{
    float m_reloj = 0;
    float m_duracion = 0.5f;//segundos
    Vector3 m_currentTarget;
    public override void Start(MainGame game)
    {
        m_reloj = 0;
        float distance = (game.m_camaraPrincipal.transform.position -
            game.m_jugador.transform.position).magnitude;//una transicion de la camara desde un punto a otro
        m_currentTarget = game.m_camaraPrincipal.transform.position + game.m_camaraPrincipal.transform.forward * distance;//tender el punto en el espacio hgacia el maestro
    }
    public override void Update(MainGame game)
    {
        m_reloj += Time.deltaTime;//sumar al tiempor transcurrido entre frame y frame
        if(m_reloj > m_duracion)
        {
            EstadoBase.Cambiar(EstadoJugador.Intancia);
        }
        else
        {
            m_currentTarget = Vector3.Lerp(m_currentTarget,
                game.m_jugador.transform.position, m_reloj / m_duracion);
            game.m_camaraPrincipal.transform.LookAt(m_currentTarget + Vector3.up);//que mire a la posicion actual
        }
    }
}
