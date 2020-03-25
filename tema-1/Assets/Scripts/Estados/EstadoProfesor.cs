using UnityEngine;

public class EstadoProfesor : InstanciEstadoBase<EstadoProfesor>
{
    float m_reloj = 0;
    float m_duracion = 0.75f;//segundos
    Vector3 m_currentTarget;
    public override void Start(MainGame game)
    {
        m_reloj = 0;
        game.m_camaraPrincipal.transform.LookAt(game.m_maestro.transform.position+Vector3.up);
        game.IniciarPasos();
    }
    public override void Update(MainGame game)
    {
        m_reloj += Time.deltaTime;//sumar al tiempor transcurrido entre frame y frame
        if (m_reloj > m_duracion)
        {
            m_reloj = 0;
            if (!game.MuestreSiguientePaso(game.m_animadorMaestro))
            {
            EstadoBase.Cambiar(EstadoIrJugador.Intancia);
            }

        }
 
    }
    public override void End(MainGame game)
    {
        game.ReiniciarPaso();
    }
}
