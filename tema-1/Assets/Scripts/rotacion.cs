using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotacion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation *= Quaternion.Euler(0, 90f * Time.deltaTime, 0); //en cada frame rote 10 grados, al integrar en el tiempo esque en un segundo gire 10 ggraos
    }
}
