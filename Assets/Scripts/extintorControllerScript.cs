using UnityEngine;
using System.Collections;

public class extintorControllerScript : MonoBehaviour
{

	//variable para modificar la animación
	Animator anim;

	void Start ()
	{
		//obtenemos el controlador de animator asociado a este objeto
		anim = GetComponent<Animator>();
	}

	void FixedUpdate ()
	{
		//debe hacer que el personaje NO SE MUEVA

		GameObject ghost = GameObject.Find("Arrows");
		
		//calculo de movimiento
		ghost.rigidbody2D.velocity = new Vector2(0,0);
	}

}
