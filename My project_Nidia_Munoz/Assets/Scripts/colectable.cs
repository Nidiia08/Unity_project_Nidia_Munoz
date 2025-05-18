using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colectable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colisiones con: " + other.name);

        //Accediendo a las variables y m�todos de la clase player (en este caso se llama move)
        move myObject = other.GetComponent<move>();
        myObject.cambioObjeto = true;
        Debug.Log("la variable es: " + myObject.cambioObjeto);
        Destroy(this.gameObject);
    }
}
