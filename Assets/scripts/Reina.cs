using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reina : Pieza {

	public override void seleccionarCasillas(GameObject[,] tablero){
		for (int i = 0;i<8;i++){
			tablero[x,i].GetComponent<Box>().seleccionar();
			tablero[i,y].GetComponent<Box>().seleccionar();
			if (x+i < 8 && y+i < 8){
				tablero[x+i,y+i].GetComponent<Box>().seleccionar();
			}
			if (x-i >= 0 && y+i < 8){
				tablero[x-i,y+i].GetComponent<Box>().seleccionar();
			}
			if (x+i < 8 && y-i >= 0){
				tablero[x+i,y-i].GetComponent<Box>().seleccionar();
			}
			if (x-i >= 0 && y-i >= 0){
				tablero[x-i,y-i].GetComponent<Box>().seleccionar();
			}
			

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
