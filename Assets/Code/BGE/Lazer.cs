using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;

namespace BGE
{
	class Lazer:MonoBehaviour
	{
		float range;
		public String lazerTargetTag;
		public GameObject lazerTarget;
		private LineRenderer line;
		private Vector3 targetPos;
		private ParticleSystem explosion;
		
		public void Start()
		{
			line = gameObject.GetComponent<LineRenderer>();
			line.enabled = false;
			range = 33.0f;
		}
		
		public void Update()
		{
			if (lazerTarget == null && lazerTargetTag != null && tag == "Ally")
			{
				lazerTarget = GameObject.FindGameObjectWithTag("Enemy");
			}

			if (lazerTarget == null && lazerTargetTag != null && tag == "Enemy")
			{
				lazerTarget = GameObject.FindGameObjectWithTag("Ally");
			}
			
			targetPos = lazerTarget.transform.position - transform.position;
			
			if (Physics.Raycast(transform.position, targetPos, range))
			{
				//lazerTarget.GetComponent<ParticleSystem>().Play();
				
				StopCoroutine("shoot");

				StartCoroutine("shoot");
				
			}
		}
		
		IEnumerator shoot()
		{
			line.SetPosition(0, transform.position);
			line.SetPosition(1, targetPos);
			line.enabled = true;

			AudioSource audio = GetComponent<AudioSource> ();
			audio.Play ();


			Destroy(lazerTarget);
			
			yield return new WaitForSeconds(3);
			line.enabled = false;

		}
	}
}
