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
        StreamReader objReader = new StreamReader("./Assets/tableros/default.txt");
        string sLine = "";
        ArrayList arrText = new ArrayList();
        sLine = objReader.ReadLine();
        string[] linea = sLine.Split(' ');
        int Ancho = Int32.Parse(linea[0]);
        int Alto = Int32.Parse(linea[1]);
        tablero = new GameObject[Ancho,Alto];
        while (sLine !=null) {
            sLine = objReader.ReadLine();
            if (sLine != null) {
                string[] numbers = sLine.Split(' ');
                arrText.Add(numbers);
            };
        }
        objReader.Close();
        for(int i = 0;i<Ancho;i++){
			for(int j=0;j<Alto;j++){
				GameObject casillaTemp = Instantiate(CasillaPrefab,new Vector3(i,0,j),Quaternion.identity);
				tablero[i,j] = casillaTemp;
			}
		}
        /*foreach (string[] sOutputs in arrText) { 
            foreach (string sOutput in sOutputs) {
                if (sOutput.Equals("0")) {
                    GameObject casillaTemp = Instantiate(CasillaPrefab,new Vector3(i,0,j),Quaternion.identity);
				    tablero[i,j] = casillaTemp;
                }
            }
        }*/
    }
}