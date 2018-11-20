using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createBox : MonoBehaviour {

	public GameObject CasillaPrefab;
	public int Ancho;
	public int Alto;

	public Material Blanco;
	public Material Negro;
	public Material colorSeleccion;

	private Pieza piezaSeleccionada;
	private Box casillaSeleccionada;

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

	void Start(){
		tablero = new GameObject[8,8];
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