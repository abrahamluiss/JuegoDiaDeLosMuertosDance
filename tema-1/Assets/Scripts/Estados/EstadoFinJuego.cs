using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EstadoFinJuego : InstanciEstadoBase<EstadoFinJuego>
{
    float m_reloj = 0;
    float m_duracion = 5.0f;//segundos

    public override void Start(MainGame game)
    {
        m_reloj = 0;
        game.GameOver();

    }
    public override void Update(MainGame game)
    {
        m_reloj += Time.deltaTime;//sumar al tiempor transcurrido entre frame y frame
        if (m_reloj > m_duracion)
        {
            SceneManager.LoadScene("MainMenu");
        }
        
    }
}
