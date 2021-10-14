using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataObject : MonoBehaviour
{
	private int arr = 500;
	private Rigidbody rig;
	private Transform tr;
	private Vector3[] pos;
	private Quaternion[] rot;
	private Vector3[] vel;
	private Vector3[] ang_vel;
	private int T_A;
	private int T_B;
	private int timer;

	void Awake()
	{
		pos = new Vector3[arr];
		rot = new Quaternion[arr];
		vel = new Vector3[arr];
		ang_vel = new Vector3[arr];
		rig = GetComponent<Rigidbody>();
		tr = transform;
	}

	void Rec()
	{
		pos[T_A] = tr.position;
		rot[T_A] = tr.rotation;
		vel[T_A] = rig.velocity;
		ang_vel[T_A] = rig.angularVelocity;
		if (T_A < arr - 1) T_A++; else T_A = 0;
	}

	void Rew()
	{
		if (timer > 1)
		{
			if (T_B > 0)
			{
				T_B--;
				timer--;
				T_A = T_B;
				tr.position = pos[T_B];
				tr.rotation = rot[T_B];
				rig.velocity = vel[T_B];
				rig.angularVelocity = ang_vel[T_B];
			}
			else
			{
				T_B = arr - 1;

			}
		}
	}


	void FixedUpdate()
	{
		if (!ObjectController.GetRest)
        {
            Rec();
            T_B = T_A;
            if (timer < arr - 1) timer++;
        }
        else
        {
            Rew();
        }
    }
}
