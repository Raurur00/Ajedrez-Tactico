using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Clase para controlar una torre
/// </summary>
public class Torre : Pieza {

	public override void seleccionarCasillas(GameObject[,] tablero){
		for (int i = 0;i<8;i++){
			tablero[x,i].GetComponent<Box>().seleccionar();
			tablero[i,y].GetComponent<Box>().seleccionar();
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
