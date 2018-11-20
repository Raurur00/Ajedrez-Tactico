using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {

	private Material colorCasilla;
	public Material colorSeleccion;
	private int x;
	private int y;
	private bool seleccionada;

	public void setX(int x){
		this.x = x;
	}

	public int getX(){
		return x;
	}

	public void setY(int y){
		this.y = y;
	}

	public int getY(){
		return y;
	}

	public bool isSeleccionada(){
		return seleccionada;
	}

	public void setColor(Material color){
		GetComponent<MeshRenderer>().material = color;
		colorCasilla = color;
	}

	public void seleccionar(){
		GetComponent<MeshRenderer>().material = colorSeleccion;
		seleccionada = true;
	}	

	public void deseleccionar(){
		GetComponent<MeshRenderer>().material = colorCasilla;
		seleccionada = false;
	}
}