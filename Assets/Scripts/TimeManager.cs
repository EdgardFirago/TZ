using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
	static private bool rew;
	public KeyCode key = KeyCode.Space;

	public static bool GetRew
	{
		get { return rew; }
	}

	void Start()
	{
	}

	void Update()
	{
		if (Input.GetKey(key))
		{
			rew = true;
		}
		else
		{
			rew = false;
		}
	}
}
