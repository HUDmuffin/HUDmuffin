using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planescript : MonoBehaviour {
	string url = "http://i.imgur.com/6g4wY8F.png";

	IEnumerator Start () {
		WWW www = new WWW(url);
		yield return www;
		www.texture.alphaIsTransparency = true;
		GetComponent<Renderer>().material = new Material(Shader.Find("Unlit/Transparent"));

		GetComponent<Renderer>().material.mainTexture = www.texture;
	}

	void Update () {
		
	}
}
