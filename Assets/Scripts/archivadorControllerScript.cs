using UnityEngine;
using System.Collections;

public class archivadorControllerScript : MonoBehaviour
{
	public float maxSpeed = 10f;

	//variable para modificar la animación idle <-> correr
	Animator anim;

	void Start ()
	{
		//obtenemos el controlador de animator asociado a este objeto
		anim = GetComponent<Animator>();
	}

	void FixedUpdate ()
	{

		float move = 0.0F;

		//Obtenemos el eje de movimiento y sus controles: A-D  o  <- ->
		move = Input.GetAxis ("HorizontalArrows");

		//calculo de movimiento
		rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);

	}

}
