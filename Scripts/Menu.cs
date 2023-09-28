using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour {
	public AudioSource fuente;
	public AudioClip clip;
	public AudioSource audioSourse;
	public AudioClip apagarpieza;

	public void Apagarpieza()
	{
		audioSourse.clip = apagarpieza;
		audioSourse.loop = false;
		audioSourse.Play ();
	}





	public void jugarnormal()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void menu()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
		}

	public void volverajugar()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

	}
	void Start (){
		fuente.clip=clip;

	}
		public void Reprodicir()
		{
		fuente.Play ();

		}

	void Update()
	{
		
	}


}
