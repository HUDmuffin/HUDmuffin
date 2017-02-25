using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planescript : MonoBehaviour {
	IEnumerator Start () {
		string url = "https://i.imgflip.com/1kc3j8.jpg";
		WWW www = new WWW(url);
		yield return www;

		GetComponent<Renderer>().material.mainTexture = www.texture;
		load_image ();
	}

	IEnumerator load_image() {
		Debug.Log ("loading an image");
		string url = "https://i.imgflip.com/1kc3j8.jpg";
		WWW www = new WWW(url);
		yield return www;

		GetComponent<Renderer>().material.mainTexture = www.texture;
	}

	void Update () {
		
	}
}
