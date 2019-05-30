using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rey : Pieza {

	public override void seleccionarCasillas(GameObject[,] tablero){
		tablero[x,y].GetComponent<Box>().seleccionar();
		if (y+1 < 8){
			tablero[x,y+1].GetComponent<Box>().seleccionar();
			if(x+1 < 8){
				tablero[x+1,y].GetComponent<Box>().seleccionar();
				tablero[x+1,y+1].GetComponent<Box>().seleccionar();	
			}
			if(x-1 >= 0){
				tablero[x-1,y].GetComponent<Box>().seleccionar();
				tablero[x-1,y+1].GetComponent<Box>().seleccionar();	
			}
		}
		if (y-1 >= 0){
			tablero[x,y-1].GetComponent<Box>().seleccionar();
			if(x+1 < 8){
				tablero[x+1,y-1].GetComponent<Box>().seleccionar();	
			}
			if(x-1 >= 0){
				tablero[x-1,y-1].GetComponent<Box>().seleccionar();	
			}
		}
	}
	
	public override bool mover(int xObjetivo, int yObjetivo){
		this.transform.position = new Vector3(xObjetivo, this.transform.position.y ,yObjetivo);
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
