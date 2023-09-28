using UnityEngine;
using System.Collections;

public class tetrismov : MonoBehaviour {
	public bool puedegirar;
	public bool girar360;
	public float caer;
	public float velocidad;
	public float timer;




	// Use this for initialization
	void Start () 
	{
		timer = velocidad;

	
	}
	//<>
	// Update is called once per frame
	void Update () {



		if (Input.GetKeyUp (KeyCode.RightArrow) || Input.GetKeyUp (KeyCode.LeftArrow) || Input.GetKeyUp (KeyCode.DownArrow))
		timer = velocidad;
		
		if (Input.GetKey(KeyCode.RightArrow)) {
			
			timer += Time.deltaTime;

			if (timer > velocidad)
			{

				transform.position += new Vector3 (1, 0, 0);
				timer = 0;

			}

			if (posicionValida())
			{
				FindObjectOfType<gameManager> ().actualizarcampo (this);
			}
			else 
			{
				transform.position += new Vector3(-1, 0, 0);
			}
		}

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			timer += Time.deltaTime;

			if (timer > velocidad) 
			{
				
			transform.position += new Vector3 (-1, 0, 0);
			
				timer = 0;
			}
			if (posicionValida())
			{
				FindObjectOfType<gameManager> ().actualizarcampo (this);  
			}
			else 
			{
				transform.position += new Vector3(1, 0, 0);
			}

		}

		if (Input.GetKey(KeyCode.DownArrow)) // || Time.time - caer >=1) 
		{
			timer += Time.deltaTime;

			if (timer > velocidad)
			{
				
			transform.position += new Vector3 (0, -1, 0);
				timer = 0;
			}

			if (posicionValida())
			{
				FindObjectOfType<gameManager> ().actualizarcampo (this);
			}
			else 
			{
				
				transform.position += new Vector3(0, 1, 0);
				FindObjectOfType<gameManager> ().apragarlinea ();
				FindObjectOfType<Menu>().Apagarpieza();

				if (FindObjectOfType<gameManager> ().topecampo (this)) 
				{
					FindObjectOfType<gameManager> ().gameover ();

				}

				FindObjectOfType<spawn> ().puntos += 10;


				//FindObjectOfType<gameManager> ().puntosdedifilcultad += 50;
				enabled = false;
				FindObjectOfType<spawn> ().proximapieza ();
			}
			caer = Time.time; 

		}
		if (Time.time - caer >= (1 / FindObjectOfType<spawn>().dificultad) && !Input.GetKey(KeyCode.DownArrow))//FindObjectOfType<gameManager> ().dificultad)&& !Input.GetKey(KeyCode.DownArrow))
		{
			transform.position += new Vector3 (0, -1, 0);

			if (posicionValida ())
			{
				FindObjectOfType<gameManager> ().actualizarcampo (this);
			
			} else 
			{
				transform.position += new Vector3 (0, 1, 0);
				FindObjectOfType<gameManager> ().apragarlinea();
				FindObjectOfType<spawn> ().puntos += 10;
				FindObjectOfType<Menu>().Apagarpieza();




				if (FindObjectOfType<gameManager> ().topecampo (this)) 
				{
					FindObjectOfType<gameManager> ().gameover ();
				}

				//FindObjectOfType<gameManager> ().puntosdedifilcultad += 50;
				enabled = false;
				FindObjectOfType<spawn> ().proximapieza ();
			}
			caer = Time.time;
		} 

		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			checkgirar ();



		}
          
	
	}

	void checkgirar()
	{
		if (puedegirar) {
			if (!girar360) {
				if (transform.rotation.z < 0) {
					transform.Rotate (0, 0, 90);

					if (posicionValida ()) 
					{
						FindObjectOfType<gameManager> ().actualizarcampo (this);
					} else {
						transform.Rotate (0, 0, -90);
					}
				} else {
					transform.Rotate (0, 0, -90);
					if (posicionValida ()) 
					{FindObjectOfType<gameManager> ().actualizarcampo (this);
					} else {
						transform.Rotate (0, 0, 90);
					}
				}
			} else {
				transform.Rotate (0, 0, 90);
				if (posicionValida ()) 
				{FindObjectOfType<gameManager> ().actualizarcampo (this);
				} else {
					transform.Rotate (0, 0, -90);
				}

			}
		} else {
			transform.Rotate (0, 0, 90);
			if (posicionValida ()) {
			} else {
				transform.Rotate (0, 0, -90);
			}
			
		




		
	}
}
				
			

	
	bool posicionValida()

{
		foreach (Transform child in transform) {
			Vector2 posBlokes = FindObjectOfType<gameManager> ().arredonda (child.position);

			if (FindObjectOfType<gameManager>().dentrocampo(posBlokes) == false)
			{
				return false;
			}
			if (FindObjectOfType<gameManager>().posicionTransformcampo(posBlokes) != null && FindObjectOfType<gameManager>().posicionTransformcampo(posBlokes).parent != transform)
			{
				return false;
			}
		}
		return true;
	

	}
}
