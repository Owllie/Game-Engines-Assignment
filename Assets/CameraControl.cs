using UnityEngine;
using System.Collections;
using BGE;

public class CameraControl : MonoBehaviour {

	private Camera bat_cam;
	private Camera main_cam;
	private Camera end_cam;

	private bool use_cam;
	private bool use_main;
	private bool use_end;

	// Use this for initialization
	void Start () {
		bat_cam = GameObject.Find("BattleShip").GetComponentInChildren<Camera>();
		end_cam = GameObject.Find("Angle").GetComponentInChildren<Camera>();;
		main_cam = GameObject.Find("MainCamera").GetComponentInChildren<Camera>();;

		main_cam.enabled = false;
		end_cam.enabled = false;
		bat_cam.enabled = true;

		use_cam = false;
		use_main = true;
		use_end = false;
	}
	
	// Update is called once per frame
	void Update () {
		if((use_cam == true)&&(use_main == false))
		{
			StartCoroutine(to_main());
			StopCoroutine(to_main());
		}

		if ((use_main == true) && (use_end == false)) 
		{
			StartCoroutine(to_end());
			StopCoroutine(to_end());
		}
	}

	IEnumerator to_main()
	{
		yield return new WaitForSeconds(1);

		bat_cam.enabled = false;
		main_cam.enabled = true;

		use_cam = true;

	}

	IEnumerator to_end()
	{
		yield return new WaitForSeconds(15);

		bat_cam.enabled = false;
		end_cam.enabled = true;

		use_end = true;
	}
}
