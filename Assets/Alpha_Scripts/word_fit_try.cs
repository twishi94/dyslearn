﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

[RequireComponent(typeof(AudioSource))]
public class word_fit_try : MonoBehaviour
{
	public AudioClip aud_c1fl;
	public AudioClip aud_c2fl;
	public AudioClip aud_c1fr;

	public AudioClip aud_r1fl;
	public AudioClip aud_r2fl;
	public AudioClip aud_r1fr;

	public AudioClip reorder;

	public AudioClip congo;

	public GameObject obj;
	int x, y, t;

	void Start()
	{
		//		CHANGE WORD HERE
		obj = GameObject.Find("fit");
		if (obj != null)
		{
			Debug.Log("Object is not NULL, turning off visibility");
			obj.SetActive(false);
		}
		x = 0;
		y = 1;
		t = 1;
	}

	void Update()
	{
		if (t == 1) {
			y++;
			if (y % 100 == 0) {
				//          VARIABLES NEED TO BE CHANGED 
				float x_of_f = script_f.x;
				float x_of_i = script_i.x;
				float x_of_t = script_t.x;

				Debug.Log ("I GET " + x_of_f + ", " + x_of_i + ", " + x_of_t);

				bool flip_f = script_f.flip;
				bool flip_i = script_i.flip;
				bool flip_t = script_t.flip;

				if (x_of_f == 0 && x_of_i == 0 && x_of_t == 0)
					return;

				if (x_of_f == 0 || x_of_i == 0 || x_of_t == 0) {
					if (x_of_f == 0) {	
						Debug.Log ("R is not there on the screen");
						AudioSource.PlayClipAtPoint (aud_c1fl, transform.position, 1.0f);
					} else if (x_of_i == 0) {	
						Debug.Log ("A is not there on the screen");
						AudioSource.PlayClipAtPoint (aud_c2fl, transform.position, 1.0f);
					} else if (x_of_t == 0) {	
						Debug.Log ("T is not there on the screen");
						AudioSource.PlayClipAtPoint (aud_c1fr, transform.position, 1.0f);
					}
					obj.SetActive (false);
				} else {
					if (flip_f || flip_i || flip_t) {
						if (flip_f == true) {
							Debug.Log ("Try to flip F");
							AudioSource.PlayClipAtPoint (aud_r1fl, transform.position, 1.0f);
						} else if (flip_i == true) {
							Debug.Log ("Try to flip I");
							AudioSource.PlayClipAtPoint (aud_r2fl, transform.position, 1.0f);
						} else if (flip_t == true) {
							Debug.Log ("Try to flip T");
							AudioSource.PlayClipAtPoint (aud_r1fr, transform.position, 1.0f);
						}
						obj.SetActive (false);
					} else if (x_of_t > x_of_i && x_of_i > x_of_f) {
						Debug.Log ("Congratulations! It is the correct word!");
						AudioSource.PlayClipAtPoint (congo, transform.position, 1.0f);
						obj.SetActive (true);
					} else {
						AudioSource.PlayClipAtPoint (reorder, transform.position, 1.0f);
						obj.SetActive (false);
					}
				}
			}
		}
	}
}