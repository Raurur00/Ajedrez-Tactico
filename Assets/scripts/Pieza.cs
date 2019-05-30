using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Clase utilizada para controlar una pieza
/// </summary>
public abstract class Pieza: MonoBehaviour {
	public int x; //Posición x de la pieza
	public int y; //Posición y de la pieza
	/// <summary>
	/// Selecciona las casillas donde es posible moverse
	/// </summary>
	/// <param name="tablero">Arreglo con las casillas</param>
	public abstract void seleccionarCasillas(GameObject[,] tablero);
	/// <summary>
	/// Mueve la pieza a la casilla seleccionada
	/// </summary>
	/// <param name="xObjetivo">Coordenada y donde se movera la pieza</param>
	/// <param name="yObjetivo">Coordenda x donde se movera la pieza</param>
	public abstract bool mover(int xObjetivo,int yObjetivo);
}
