using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caballo : Pieza {

	public override void seleccionarCasillas(GameObject[,] tablero){
		if (x+2 < 8 && y+1< 8){
			tablero[x+2,y+1].GetComponent<Box>().seleccionar();
		}
		if (x+2 < 8 && y-1 >= 0){
			tablero[x+2,y-1].GetComponent<Box>().seleccionar();
		}
		if (x-2 >= 0 && y+1< 8){
			tablero[x-2,y+1].GetComponent<Box>().seleccionar();
		}
		if (x-2 >= 0 && y-1 >= 0){
			tablero[x-2,y-1].GetComponent<Box>().seleccionar();
		}
		if (x+1 < 8 && y+2< 8){
			tablero[x+1,y+2].GetComponent<Box>().seleccionar();
		}
		if (x+1 < 8 && y-2 >= 0){
			tablero[x+1,y-2].GetComponent<Box>().seleccionar();
		}
		if (x-1 >= 0 && y+2< 8){
			tablero[x-1,y+2].GetComponent<Box>().seleccionar();
		}
		if (x-1 >= 0 && y-2 >= 0){
			tablero[x-1,y-2].GetComponent<Box>().seleccionar();
		}
	}
	
	public override bool mover(int xObjetivo, int yObjetivo){
		this.transform.position = new Vector3(xObjetivo, 0 ,yObjetivo);
		this.x = xObjetivo;
		this.y = yObjetivo;
		return true;
		
	}

	//IEnumerator MovePieza()
	//{
	//	sdlfksjdlf
	//	yield return null;
	//	dgfdfgjdfg
	//	yield return null;
	//}
}
