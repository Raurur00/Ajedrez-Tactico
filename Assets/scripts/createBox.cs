using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class createBox : MonoBehaviour {

    //Traer variables de tablero

	public GameObject CasillaPrefab;
	public int Ancho;
	public int Alto;

	public Material Blanco;
	public Material Negro;
	public Material colorSeleccion;

	private Pieza piezaSeleccionada;
	private Box casillaSeleccionada;

    //Traer variables de piezas

    public GameObject torre, caballo, peon, alfil, reina, rey;
    private GameObject[] listaPiezas;

    GameObject[,] tablero;

	//public GameObject Torre;

	public void crear(){
		for(int i = 0;i<Ancho;i++){
			for(int j=0;j<Alto;j++){
				GameObject casillaTemp = Instantiate(CasillaPrefab,new Vector3(i,0,j),Quaternion.identity);
				tablero[i,j] = casillaTemp;
			}
		}
		coloreoPorDefecto(tablero);
        
    }

	public void coloreoPorDefecto(GameObject[,] tablero){
		for(int i = 0;i<Ancho;i++){
			for(int j=0;j<Alto;j++){
				if ((i+j)%2 == 0){
					tablero[i,j].GetComponent<Box>().setColor(Negro);
				} else {
					tablero[i,j].GetComponent<Box>().setColor(Blanco);
				}
				tablero[i,j].GetComponent<Box>().setX(i);
				tablero[i,j].GetComponent<Box>().setY(j);
			}
		}
	}

	public void deseleccionarTodo(GameObject[,] tablero){
		for (int i=0;i<Ancho;i++){
			for(int j=0;j<Alto;j++){
				tablero[i,j].GetComponent<Box>().deseleccionar();
			}
		}
	}
    public void leerArchivo()
    {
        StreamReader objReader = new StreamReader("C:/Users/Nicolas/Documents/GitHub/Ajedrez-Tactico/Assets/levels/tablero_1.txt");
        string sLine = "";
        //ArrayList arrText = new ArrayList();
        sLine = objReader.ReadLine();
        string[] space = sLine.Split(' ');
        Debug.Log(space[0]);
        Debug.Log(space[1]);
        Ancho = Int32.Parse(space[0]);
        Alto = Int32.Parse(space[1]);
        tablero = new GameObject[Ancho, Alto];

        for (int i = 0; i < Ancho; i++)
        {
            sLine = objReader.ReadLine();
            if (sLine != null)
            {
                space = sLine.Split(' ');
                for (int j = 0; j < Alto; j++)
                {
                    Debug.Log(space);
                    //Instantiate(listaPiezas[Int32.Parse(space[j]) - 1], new Vector3(i, 0, j), new Quaternion(1f, 0f, 0f, 0f));
                }

                // Debug.Log(sLine);
                //Debug.Log(space);
            }
           
        }
        objReader.Close();
    }

	void Start(){
        leerArchivo();
		// tablero = new GameObject[8,8];
        listaPiezas = new GameObject[6];
        listaPiezas[0] = torre;
        listaPiezas[1] = caballo;
        listaPiezas[2] = peon;
        listaPiezas[3] = alfil;
        listaPiezas[4] = reina;
        listaPiezas[5] = rey;
        crear();

	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0)){
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			RaycastHit hit;
			if (Physics.Raycast(ray, out hit))
			{
				if  (hit.collider.tag == "pieza") {	
					piezaSeleccionada = hit.collider.gameObject.GetComponentInParent<Pieza>();
					if (piezaSeleccionada != null) {
						deseleccionarTodo(tablero);
						piezaSeleccionada.seleccionarCasillas(tablero);
					}
				} else if (hit.collider.tag == "casilla") {
					if (piezaSeleccionada == null){
						deseleccionarTodo(tablero);
						hit.collider.gameObject.GetComponent<MeshRenderer>().material = colorSeleccion;
					} else {
						casillaSeleccionada = hit.collider.gameObject.GetComponent<Box>();
						if (casillaSeleccionada.isSeleccionada()){
							hit.collider.gameObject.GetComponent<MeshRenderer>().material = colorSeleccion;
						} else {
							deseleccionarTodo(tablero);
						}
						
						piezaSeleccionada = null;
					}
					
				} else {
					deseleccionarTodo(tablero);
				}
			}	
		}
	}
}