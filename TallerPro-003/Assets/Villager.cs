using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace NPC
{
    namespace Ally
    {
        public class Villager : MonoBehaviour
        {
            // se llama a el structur del aldeano
            public datosVillager datosAldeano = new datosVillager();
            // se crea el enum que va a almacenar los posibles nombres de los aldeanos
            public enum nombres
            {
                Daniel, Julio, Sebastian, Santiago, Alex, Danilo, Luis, Juan, Anderson, Cristian, Alejandro, Kevin, Jorge, Felipe, David, Natalia, Camila, Monica, Andrea, Carolina
            }
            /// <summary>
            /// le asignamos un rigidbody
            /// le damos un nombre y una edad aleatoria al aldeano
            /// </summary>
            void Start()
            {
                Rigidbody Villa;
                this.gameObject.tag = "Villager";
                Villa = this.gameObject.AddComponent<Rigidbody>();
                Villa.constraints = RigidbodyConstraints.FreezeAll;
                Villa.useGravity = false;
                nombres nombre;
                nombre = (nombres)Random.Range(0, 21);
                datosAldeano.nombre = nombre.ToString();
                int edad = Random.Range(15, 101);
                datosAldeano.edad = edad.ToString();
                this.gameObject.name = nombre.ToString();
            }

        }

    }
}

