using UnityEngine;
using System.Collections;

public class Combat : MonoBehaviour 
{
	public GameObject opponent;

	public AnimationClip attack;

	public int damage;

	public double impactTime;

	public bool impacted;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKey(KeyCode.Space))
		{
			animation.Play(attack.name); 
			// need to prioritize animations! 
			//unless idle animation will begin to play when not holding down the space bar!
			ClickToMove.attack = true;

			// if you don't have this statement and just transform.LookAt method,
			// you will get a null pointer exception
			if(opponent != null)
			{
				transform.LookAt(opponent.transform.position);
				//opponent.GetComponent<Mob>().getHit(damage);
			}
		
		}else
		{
			if(!animation.IsPlaying(attack.name))
			{
				ClickToMove.attack = false;
				impacted = false;
			}
		}

		impact ();

	}

	void impact()
	{
		if(opponent!=null && animation.IsPlaying(attack.name) && !impacted)
		{
			if((animation[attack.name].time)>(animation[attack.name].length*impactTime))
			{
				opponent.GetComponent<Mob>().getHit(damage);
				impacted = true;
			}
		}
	}
}






