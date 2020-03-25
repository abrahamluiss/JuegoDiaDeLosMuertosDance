using UnityEngine;

public class EstadoFinJugador : InstanciEstadoBase<EstadoFinJugador>
{
    float m_reloj = 0;
    float m_duracion = 1.0f;//segundos

    public override void Start(MainGame game)
    {
        m_reloj = 0;
    }
    public override void Update(MainGame game)
    {
        m_reloj += Time.deltaTime;//sumar al tiempor transcurrido entre frame y frame
        if(m_reloj > m_duracion)//si es mayor
        {
            EstadoBase.Cambiar(EstadoIrProfesor.Intancia);
            
        }
        //else
        //{
        //    //que el tiempo de hacer el mov termino entonces marco mal paso
        //    game.MalPaso();
        //}
    }
    public override void End(MainGame game)
    {
        game.ReiniciarPaso();
    }
}
