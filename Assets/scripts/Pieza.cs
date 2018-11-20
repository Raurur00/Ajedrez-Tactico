using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pieza: MonoBehaviour {
	public int x;
	public int y;
	
	public abstract void seleccionarCasillas(GameObject[,] tablero);
	public abstract void mover();
}
