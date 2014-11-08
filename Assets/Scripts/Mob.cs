using UnityEngine;
using System.Collections;

public class Mob : MonoBehaviour 
{

	public float speed;
	public float range; // add attack range?

	public CharacterController controller;
	public Transform player;

	public AnimationClip idle,run;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Debug.Log (inRange ());

		if(!inRange())
		{
			chase ();
		}
		else
		{
			animation.CrossFade(idle.name);
		}
		
	}

	bool inRange()
	{
		if (Vector3.Distance (transform.position, player.position) < range) 
		{
			return true;
		} 
		else
		{
			return false;
		}

		// change to the line below for optimization later!~
		//return Vector3.Distance (transform.position, player.position) < range;
	}

	void chase()
	{
		// hmm.. more smooth transition???
		transform.LookAt(player.position);
		controller.SimpleMove(transform.forward*speed);
		animation.CrossFade(run.name);

	}

	void OnMouseOver()
	{
		player.GetComponent<Combat>().opponent = gameObject ;
	}
}
