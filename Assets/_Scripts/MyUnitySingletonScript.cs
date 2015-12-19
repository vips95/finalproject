﻿using UnityEngine;
using System.Collections;

public class MyUnitySingletonScript : MonoBehaviour {

		
	static bool AudioBegin = false;
	GameObject otherSound;
	
	
	void Awake()
	{
		otherSound = GameObject.FindGameObjectWithTag("GameMusic");
		
		if (otherSound == this.gameObject)
		{
			if (!AudioBegin)
			{
				DontDestroyOnLoad(this.gameObject);
				AudioBegin = true;
			}
		}
		else
		{
			Destroy(this.gameObject);
		}
		
		
		
	}
}