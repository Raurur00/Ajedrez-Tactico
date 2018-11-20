using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torre : Pieza {

	public override void seleccionarCasillas(GameObject[,] tablero){
		for (int i = 0;i<8;i++){
			tablero[x,i].GetComponent<Box>().seleccionar();
			tablero[i,y].GetComponent<Box>().seleccionar();
		}
	}
	
	public override void mover(){

	}
}
