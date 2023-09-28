using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class gameManager : MonoBehaviour {

	public static int altura = 24;
	public static int largura = 12;



	public Text textoscore;
	//public float puntosdedifilcultad;
	//public float dificultad= 1;

	public static Transform[,] campo = new Transform[largura, altura];

	void Start () 
	{
		

	}
	void Update()
	{
		
		textoscore.text = "Puntos:" + FindObjectOfType<spawn>().puntos.ToString();

		//textoscore.text = score.ToString();

		/*puntosdedifilcultad = puntosdedifilcultad + 10.5f * Time.deltaTime;


		if (puntosdedifilcultad > 100f) 
		{
			puntosdedifilcultad -= 100f; 
			dificultad += .5f;
			
		}


*/
	


	}
	public bool dentrocampo(Vector2 posicion)
	{
		return ((int)posicion.x >= 0 && (int)posicion.x < largura && (int)posicion.y >= 0);
	}
	public Vector2 arredonda(Vector2 nA)
	{
		return new Vector2 (Mathf.Round(nA.x), Mathf.Round (nA.y));
	}

	public void actualizarcampo(tetrismov piezatetris)
	{
		for (int y = 0; y < altura; y++) 
		{
			for (int x = 0; x < largura; x++ )
			{
				if (campo[x,y] != null)
				{
				if(campo[x,y].parent == piezatetris.transform)
					{
						campo[x, y] = null;
					}
				}
			}
		
		
		}


		foreach(Transform pieza in piezatetris.transform)
		{
			Vector2 posicion = arredonda(pieza.position);

			if (posicion.y < altura)
			{
				campo[(int)posicion.x,(int)posicion.y] = pieza;
			}
		}
	}

	public Transform posicionTransformcampo(Vector2 posicion)
	{
		if (posicion.y > altura - 1) 
		{
			return null;
		} else 
		{
			return campo [(int)posicion.x, (int)posicion.y]; 
		}
	}

	public bool lineallena(int y)
	{
		for (int x = 0; x < largura; x++)
		{
			if (campo[x,y] == null)
			{
				return false;
			}
		}return true;
	}

	public void borrarcuadrado(int y)
	{
		
		for (int x = 0; x < largura; x++) 
		{
			Destroy (campo [x, y].gameObject);
			campo [x, y] = null;


		}
	}
	public void movlineaabajo(int y)

	{
		
		for (int x = 0; x < largura; x++) 
		{
			if (campo[x, y] != null)
			{
				campo[x, y - 1] = campo [x, y];
				campo[x, y] = null;
				campo[x, y - 1].position += new Vector3 (0, -1, 0);

			}
		}
	}
	public void movtodaslaslineasabajo(int y)
	{
		for (int i = y; i < altura; i++)
			movlineaabajo(i);
		
	}
	public void apragarlinea()
	{
		for (int y = 0; y < altura; y++)
		{
			if (lineallena(y))
			{

			borrarcuadrado(y);
			movtodaslaslineasabajo(y + 1);
			y--;
				FindObjectOfType<spawn> ().puntos += 100;
				FindObjectOfType<spawn> ().Borrarlinea();

				//FindObjectOfType<spawn> ().puntosdedifilcultad += 100;	

		    }

	    }


    }
	public bool topecampo(tetrismov piezatetrismino)
	{
		for (int x = 0; x < largura; x++) 
		{
			foreach (Transform cuadrado in piezatetrismino.transform)
			{
				Vector2 posicion = arredonda(cuadrado.position);

				if (posicion.y > altura - 1) 
				{
					return true;
				}
			}
		}
		return false;
	}

	public void gameover()
	{
		SceneManager.LoadScene ("gameover");

	}




}