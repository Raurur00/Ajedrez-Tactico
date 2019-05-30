using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tablero : MonoBehaviour {
    public GameObject[,] tablero;
    public GameObject CasillaPrefab; //Prefab de una casilla
    
    void Start() {
		createTablero();
	}

    public void createTablero(){
        //Abrir el archivo
        StreamReader objReader = new StreamReader("./Assets/tableros/default.txt");
        //Extraer Ancho y Largo de la matriz del archivo
        string sLine = objReader.ReadLine();
        string[] linea = sLine.Split(' ');
        int Ancho = Int32.Parse(linea[0]);
        int Largo = Int32.Parse(linea[1]);
        //Crear arreglo con Ancho y Largo
        tablero = new GameObject[Ancho,Largo];
        for(int i = 0;i<Ancho;i++) {
			sLine = objReader.ReadLine();
            if (sLine!=null){
                string[] numbers = sLine.Split(' ');
                for(int j=0;j<Largo;j++) {
                    if (numbers[j].Equals("0")) {
                        GameObject casillaTemp = Instantiate(CasillaPrefab, new Vector3(i,0,j), Quaternion.identity);
                        tablero[i,j] = casillaTemp;
                    }
                }
            }
            
            
		}
    }
}