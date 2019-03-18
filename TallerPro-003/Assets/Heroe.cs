using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using zom = NPC.Enemy;
using villa = NPC.Ally;

public class Heroe : MonoBehaviour
{
    /// <summary>
    /// se crea un rigidbody para el heroe, se le asigna una tag y un nombre
    /// </summary>
    void Start()
    {
        Rigidbody hero = this.gameObject.AddComponent<Rigidbody>();
        this.gameObject.tag = "Hero";
        this.gameObject.name = "Hero";
        hero.constraints = RigidbodyConstraints.FreezeAll;
        hero.useGravity = false;
    }

    void Update()
    {
        // Ejecucion del metodo
        Mover();
    }
    /// <summary>
    /// este metodo se encarga del movimiento del heroe segun las teclas asignadas y de detectar las coliciones 
    /// se llama a la clase velocidad y se le asigna un numero aleatorio
    /// </summary>
    public void Mover()
    {
        Velocidad velocidad = new Velocidad(Random.Range(0.25f, 0.5f));

        if (Input.GetKey(KeyCode.W))
        {
            this.gameObject.transform.Translate(0, 0, velocidad.velo);
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.gameObject.transform.Translate(0, 0, -velocidad.velo);
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.gameObject.transform.Rotate(0, -3, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.gameObject.transform.Rotate(0, 3, 0);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
            datosZombie datosZ = collision.gameObject.GetComponent<zom.Zombie>().datosZombie;
            Debug.Log("Waaaarrrr quiero comer " + datosZ.gusto );
        }
        if (collision.gameObject.tag == "Villager"  )
        {
            datosVillager datosV = collision.gameObject.GetComponent<villa.Villager>().datosAldeano;
            Debug.Log("Hola mi nombre es " + datosV.nombre +" Y tengo " + datosV.edad + " Años");
        }
    }
}
/// <summary>
/// en esta clase declaramos del flotante de tipo read only
/// </summary>
public class Velocidad
{
    public readonly float velo;
    public Velocidad(float vel)
    {
        velo = vel;
    }
}
