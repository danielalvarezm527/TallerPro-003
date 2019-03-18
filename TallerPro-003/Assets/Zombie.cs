using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace NPC
{
    namespace Enemy
    {
        public class Zombie : MonoBehaviour
        {
            public datosZombie datosZombie = new datosZombie();
            int nColor;
            public string Gus;
            public int D = 0;
            public float tiempo = 0;
            public bool mirar = false;
            public Estado zombieEstado;
            // se crea el enum que almacenara el gusto posible del zombie
            public enum Gusto
            {
                Cabezas, Dedos, Lenguas, Higados, Muslos
            }
            // se crea el enum que almacenara el estado posible del zombie
            public enum Estado
            {
                Moving, Idle, Rotating
            }
            /// <summary>
            /// se agrega un rigidbody, se le asigna una tag y un nombre
            /// se le da un color aleatorio entre cyan, verde y magenta
            /// se le asigna su gusto
            /// </summary>
            void Start()
            {
                Rigidbody Zom;
                nColor = Random.Range(0, 3);
                this.gameObject.name = "Zombie";
                this.gameObject.tag = "Zombie";
                Gusto gusto;
                gusto = (Gusto)Random.Range(0, 5);
                Gus = gusto.ToString();
                datosZombie.gusto = Gus;
                Zom = this.gameObject.AddComponent<Rigidbody>();
                Zom.constraints = RigidbodyConstraints.FreezeAll;
                Zom.useGravity = false;

                if (nColor == 0)
                {
                    this.gameObject.GetComponent<Renderer>().material.color = Color.cyan;
                }
                if (nColor == 1)
                {
                    this.gameObject.GetComponent<Renderer>().material.color = Color.magenta;
                }
                if (nColor == 2)
                {
                    this.gameObject.GetComponent<Renderer>().material.color = Color.green;
                }
            }
            /// <summary>
            /// cada 3 segundos le asignamos un numero aleatorio entre 0 y 2 
            /// que nos dara como resultado un estado para el zombie
            /// </summary>
            void Update()
            {
                tiempo += Time.deltaTime;

                if (tiempo >= 3)
                {
                    D = Random.Range(0, 3);
                    mirar = true;
                    tiempo = 0;
                }
                if (D == 0)
                {
                    zombieEstado = Estado.Idle;
                }
                else if (D == 1)
                {
                    zombieEstado = Estado.Moving;
                }
                else if (D == 2)
                {
                    zombieEstado = Estado.Rotating;

                }

                switch (zombieEstado)
                {
                    case Estado.Idle:
                        break;

                    case Estado.Moving:
                        if (mirar)
                        {
                            this.gameObject.transform.Rotate(0, Random.Range(0, 361), 0);
                        }
                        this.gameObject.transform.Translate(0, 0, 0.05f);
                        mirar = false;
                        break;

                    case Estado.Rotating:
                        this.gameObject.transform.Rotate(0, Random.Range(1, 50), 0);
                        break;
                }
            }
        }
    }
}


