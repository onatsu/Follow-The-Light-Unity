using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]

public class GhostControllerScript : MonoBehaviour
{
	public float maxSpeed = 10f;
	bool facingRight = true;
	public string ghost = null;
	int i =0;

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

		//Obtenemos el nombre del pj: ARROWS o WASD
		ghost = this.gameObject.name;


		//Obtenemos el eje de movimiento y sus controles: A-D  o  <- ->
		move = Input.GetAxis ("Horizontal"+ghost);

		/*
		 * si Speed es mayor a 1 empieza la animación RUN
		 * si es menor a 0.01 empieza la animacion de IDLE
		 * esto se controla desde la maquina de estados de animaciones 
		 * del propio UNITY
		*/
		anim.SetFloat("Speed",Mathf.Abs(move));
			
		//calculo de movimiento
		rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);

		//control para encarar al pj
		if (move > 0 && !facingRight)
			Flip ();
		else if(move < 0 && facingRight)
			Flip ();

	}

	void OnTriggerStay2D(Collider2D collider)
	{
		//si el pj accede a un collider
		if (collider.gameObject.tag == "possesion"){

			//si se apreta la acción definida en el UNITY -> PROJECT SETTINGS -> INPUT
			//Cada pj tiene una accion ARROWS o WASD
			if(Input.GetButtonDown("Action"+ghost)){

				//ERROR: ESTO SE HACE DOS VECES!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
				posesion(collider);
				i++;
			}
		}
	}

	void Flip()
	{
		//función que orienta al pj
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void posesion(Collider2D collider){
		print("Has poseido salvajemente el " +collider.gameObject.name +" "+i);


		//rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);
	
	}
}
