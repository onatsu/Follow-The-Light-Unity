using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]

public class GhostControllerScript : MonoBehaviour
{
	public float maxSpeed = 10f;
	bool facingRight = true;
	public string ghost = null;
	public string objetoPoseido = null;


	bool estaDentro = false;
	Collider2D collider;

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


		if (this.gameObject.renderer.enabled) {
			//si el pj esta visible....
			if (Input.GetButtonDown ("Action" + ghost) && estaDentro){
				//si se pulsa action y estamos dentro de un objeto 
				print("Has poseido salvajemente el " +this.collider.gameObject.name);

				objetoPoseido = this.collider.gameObject.name;
			 
				this.gameObject.renderer.enabled = false;
				collider.gameObject.GetComponent<archivadorControllerScript>().enabled = true;
			}
		} else {
			//si ya estamos poseyendo un objeto, el pj no se muestra y....

			if (Input.GetButtonDown ("Action" + ghost) && estaDentro){
				//si se pulsa action y estamos dentro de un objeto 
				print("Has desposeido salvajemente el " +this.collider.gameObject.name);

				objetoPoseido = this.collider.gameObject.name;
				this.gameObject.renderer.enabled = true;
				collider.gameObject.GetComponent<archivadorControllerScript>().enabled = false;
			}
		}

	 
/*
		if (Input.GetButtonDown ("Action" + ghost) && estaDentro && !this.gameObject.active) {

			this.gameObject.active = true;
			collider.gameObject.GetComponent<archivadorControllerScript>().enabled = false;
		} 
*/
	}

	//detecta que entra en el objeto poseible. Se hace dos veces porque el prota tiene dos COLLIDERS
	void OnTriggerEnter2D(Collider2D collider){
				if (collider.gameObject.tag == "possesion") {
						estaDentro = true;
						this.collider = collider;
						
				}
		}

	//detecta que sale en el objeto poseible. Se hace dos veces porque el prota tiene dos COLLIDERS
	void OnTriggerExit2D(Collider2D collider){
			if (collider.gameObject.tag == "possesion") {
				estaDentro = false;
				this.collider = null;
				
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
	

	void posesion(){
		print("Has poseido salvajemente el " +this.collider.gameObject.name);

		//desactivamos la posesion temporalmente
		//this.transform.collider.isTrigger = true;

	}
}
