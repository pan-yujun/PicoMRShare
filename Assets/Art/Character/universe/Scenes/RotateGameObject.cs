using UnityEngine;
using System.Collections;

public class RotateGameObject : MonoBehaviour {
	public float rot_speed_x=0;
	public float rot_speed_y=0;
	public float rot_speed_z=0;
	public bool local=false;
	
	
	
	
	public float move_speed_x=0;
	public float move_speed_y=0;
	public float move_speed_z=0;
	public float move_time=0;
	private Vector3 start_pos;
	private float my_time=0;
	// Use this for initialization
	void Start () { 
		start_pos = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (local) {
			transform.RotateAroundLocal(transform.up, Time.fixedDeltaTime*rot_speed_x);
		} else {
			transform.Rotate(Time.fixedDeltaTime*new Vector3(rot_speed_x,rot_speed_y,rot_speed_z), Space.World);
			my_time+=Time.fixedDeltaTime;
			if(my_time>=move_time)
			{
				transform.position=start_pos;
				my_time=0;
			}
			transform.Translate(Time.fixedDeltaTime*new Vector3(move_speed_x,move_speed_y,move_speed_z), Space.World);
			
			
		}
	}
}
