using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using zom = NPC.Enemy;
using villa = NPC.Ally;
/// <summary>
/// toda esta clase se encarga de la creacion de las entidades que van a estar en el juego
/// </summary>
public class Create : MonoBehaviour
{
    public TextMeshProUGUI numeroZombies;
    public TextMeshProUGUI numeroAldeanos;
    public int numZombies;
    public int numAldeanos;
    GameObject[] Zom,Villa;

    void Start()
    {
        // se ejecuta el constructor
        new CrearInstancias();

    }
    public void Update()
    {
        // en los arrays declarados anteriormente asiganamos todos los objetos con la tag "Zombie", "Villager" mediante un foreach
        Zom = GameObject.FindGameObjectsWithTag("Zombie");
        Villa = GameObject.FindGameObjectsWithTag("Villager");
        foreach (GameObject item in Zom)
        {
            numZombies = Zom.Length;
        }
        foreach (GameObject item in Villa)
        {
            numAldeanos = Villa.Length;
        }

        numeroZombies.text = numZombies.ToString();
        numeroAldeanos.text = numAldeanos.ToString();
    }
}
/// <summary>
/// en este constructor nos encargamos de asignar de maneria aleatoria los componentes a las antidades creadas 
/// </summary>
 class CrearInstancias 
{
    public GameObject cube;
    public readonly int minInstancias = Random.Range(5, 16);
    int selector = 0;
    const int MAX = 26;
    public CrearInstancias()
    {
        for (int i = 0; i < Random.Range(minInstancias,MAX); i++)
        {
            
            if (selector == 0)
            {
                cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.AddComponent<Camera>();
                cube.AddComponent<Heroe>();
                cube.transform.position = new Vector3(Random.Range(-20, 21), 0, Random.Range(-20, 21));
                selector += 1;

            }
            int selec = Random.Range(selector, 3);

            if (selec == 1)
            {
                cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.AddComponent<villa.Villager>();
                cube.transform.position = new Vector3(Random.Range(-20, 21), 0, Random.Range(-20, 21));

            }
            if (selec == 2)
            {
                cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.AddComponent<zom.Zombie>();
                cube.transform.position = new Vector3(Random.Range(-20, 21), 0, Random.Range(-20, 21));

            }
        }
    }
}