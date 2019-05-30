using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Esta clase es utilizada para controlar una casilla
public class Box : MonoBehaviour {
	private Material colorCasilla; //Color default de la casilla
	public Material colorSeleccion; //Color al seleccionar una casilla
	private int x; //Posición en x de la casilla
	private int y; //Posición en y de la casilla
	private bool seleccionada; //True si la casilla esta seleccionada
	/// <summary>
	/// Setea el valor de x
	/// </summary>
	/// <param name="x">Valor de la posición x de la casilla</param>
	public void setX(int x){
		this.x = x;
	}
	/// <summary>
	/// Obtener el valor de x
	/// </summary>
	/// <returns>retorna el valor de la posición x de la casilla</returns>
	public int getX(){
		return x;
	}
	/// <summary>
	/// Setea el valor de y
	/// </summary>
	/// <param name="y">Valor de la posición y de la casilla</param>
	public void setY(int y){
		this.y = y;
	}
	/// <summary>
	/// Obtener el valor de y
	/// </summary>
	/// <returns>Retorna el valor de la posición y de la casilla</returns>
	public int getY(){
		return y;
	}
	/// <summary>
	/// Obtener si esta seleccionada la casilla
	/// </summary>
	/// <returns>Retorna true si la casilla esta seleccionada</returns>
	public bool isSeleccionada(){
		return seleccionada;
	}
	/// <summary>
	/// Setea el color de la casilla
	/// </summary>
	/// <param name="color">Color de la casilla</param>
	public void setColor(Material color){
		GetComponent<MeshRenderer>().material = color;
		colorCasilla = color;
	}
	/// <summary>
	/// Selecciona una casilla. Cambia el atributo seleccionar a true y cambia el color de la casilla.
	/// </summary>
	public void seleccionar(){
		GetComponent<MeshRenderer>().material = colorSeleccion;
		seleccionada = true;
	}	
	/// <summary>
	/// Deselecciona una casilla. Cambia el atributo seleccionar a false y cambia el color de la casilla.
	/// </summary>
	public void deseleccionar(){
		GetComponent<MeshRenderer>().material = colorCasilla;
		seleccionada = false;
	}
}