using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class spawn : MonoBehaviour {

	public Transform[] creapieza;

	public int proxpieza;
	public List<GameObject> muestrapiezas;
	public float puntosdedifilcultad;
	public float dificultad= 1;
	public int puntos;
	public AudioSource audioSourse;
	public AudioClip borrarlinea;


	public void Borrarlinea()
	{
		audioSourse.clip = borrarlinea;
		audioSourse.loop = false;
		audioSourse.Play ();
	}



	// Use this for initialization

	void Start ()
	{
		proxpieza = Random.Range (0, 7);
		proximapieza ();




		}

	public void proximapieza()
	{
		Instantiate (creapieza [proxpieza], transform.position, Quaternion.identity);

		proxpieza = Random.Range (0, 7);




		for (int i = 0; i < muestrapiezas.Count; i++) {
			muestrapiezas [i].SetActive (false);
		}
		muestrapiezas [proxpieza].SetActive (true);
	}
	void Update () {

		puntosdedifilcultad = puntosdedifilcultad + 4.5f * Time.deltaTime;


		if (puntosdedifilcultad > 500f) {
			puntosdedifilcultad -= 500f; 
			dificultad += .5f;

		}
	}
}

     
