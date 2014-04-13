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
		//por ahora no tendra nada
	}

}
