using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearPiezas : MonoBehaviour {

    public GameObject torre, caballo, peon, alfil, reina, rey;
    private GameObject[] listaPiezas;
    private int[] cantidad = { 2, 2, 4, 2, 1, 1 };
     
	public void crear()
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < cantidad[i]; j++)
            {
                Instantiate(listaPiezas[j],new Vector3(i, 0, j),new Quaternion(1f,0f,0f,0f));
            }
        }
    }

    // Use this for initialization
    void Start() {
        listaPiezas = new GameObject[6];
        listaPiezas[0] = torre;
        listaPiezas[1] = caballo;
        listaPiezas[2] = peon;
        listaPiezas[3] = alfil;
        listaPiezas[4] = reina;
        listaPiezas[5] = rey;
        crear();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
