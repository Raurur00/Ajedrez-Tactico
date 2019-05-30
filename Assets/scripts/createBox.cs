using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Esta clase crea el tablero.
/// </summary>
public class createBox : MonoBehaviour {

	public GameObject CasillaPrefab; //Prefab de una casilla
	public int Ancho; //Ancho del tablero
	public int Alto; //Alto del tablero

	public Material Blanco; //Color blanco para las casillas
	public Material Negro; //Color negro para las casillas
	public Material colorSeleccion; //Color cuando se selecciona una casilla

	private Pieza piezaSeleccionada; //Puntero a la pieza seleccionada
	private Box casillaSeleccionada; //Puntero a la casilla seleccionda

	GameObject[,] tablero;

	//public GameObject Torre;
	/// <summary>
	/// Crear el tablero
	/// </summary>
	public void crear() {
		for(int i = 0;i<Ancho;i++){
			for(int j=0;j<Alto;j++){
				GameObject casillaTemp = Instantiate(CasillaPrefab,new Vector3(i,0,j),Quaternion.identity);
				tablero[i,j] = casillaTemp;
			}
		}
		coloreoPorDefecto(tablero);
	}
	/// <summary>
	/// Colorea las casillas del tablero con los colores por defecto
	/// </summary>
	/// <param name="tablero">Arreglo con las casillas</param>
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
	/// <summary>
	/// Deselecciona todas las casillas
	/// </summary>
	/// <param name="tablero">Arreglo con las casillas</param>
	public void deseleccionarTodo(GameObject[,] tablero){
		for (int i=0;i<Ancho;i++){
			for(int j=0;j<Alto;j++){
				tablero[i,j].GetComponent<Box>().deseleccionar();
			}
		}
	}
	/// <summary>
	/// Se crea el tablero al iniciar el juego
	/// </summary>
	void Start(){
		tablero = new GameObject[Ancho,Alto];
		crear();
	}
	void Update()
	{
		if (Input.GetMouseButtonDown(0)){
			//Si se hace click izquierdo se utiliza raycast para detectar si hay alguna pieza
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			RaycastHit hit;
			if (Physics.Raycast(ray, out hit))
			{
				Debug.Log(hit.collider.tag);
				if  (hit.collider.tag == "pieza") {	
					//Si se golpea alguna pieza se seleccionan las casillas donde tiene permitido moverse
					piezaSeleccionada = hit.collider.gameObject.GetComponentInParent<Pieza>();
					if (piezaSeleccionada != null) {
						deseleccionarTodo(tablero);
						piezaSeleccionada.seleccionarCasillas(tablero);
					}
				} else if (hit.collider.tag == "casilla") {
					//si se golpea una casillas se comprueba que no hay ninguna pieza seleccionada
					if (piezaSeleccionada == null){
						//Si no hay ninguna pieza seleccionada se selecciona la casilla
						deseleccionarTodo(tablero);
						hit.collider.gameObject.GetComponent<MeshRenderer>().material = colorSeleccion;
					} else {
						//Si hay una pieza seleccionada se comprueba si la casilla es una de las casillas a la que la pieza puede moverse
						casillaSeleccionada = hit.collider.gameObject.GetComponent<Box>();
						if (casillaSeleccionada.isSeleccionada()){
							// Si lo es, se mueve la pieza
							hit.collider.gameObject.GetComponent<MeshRenderer>().material = colorSeleccion;
							piezaSeleccionada.mover(casillaSeleccionada.getX(), casillaSeleccionada.getY());
							deseleccionarTodo(tablero);
						} else {
							// Si no lo es, se deselecciona todo
							deseleccionarTodo(tablero);
						}
					}
					
				} else {
					// Si no se golpea nada se deselecciona todo
					deseleccionarTodo(tablero);
				}
			}	
		}
	}
}