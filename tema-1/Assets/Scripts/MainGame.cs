using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour
{
    public GameObject m_chica;
    private GameObject m_miChica;
    // Start is called before the first frame update
    void Start()
    {
        m_miChica = GameObject.Instantiate(m_chica);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            GameObject.Destroy(m_miChica);
    }
}
