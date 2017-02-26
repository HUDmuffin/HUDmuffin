using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Linq;
using System.Xml.Linq;
using System;
using System.Text;
using System.Threading;
[System.Serializable]

public class quadscript : MonoBehaviour {
	string url = "http://i.imgur.com/6g4wY8F.png";

	IEnumerator Start () {
		string image_url = "http://dev1-api.prolifiq.com/muffin/api/hud?message=welcome";
		var headers = new Hashtable();
		headers.Add("Content-Type", "application/json");
		WWW response = new WWW(image_url);
		yield return response;

		ImgResponse r = ImgResponse.CreateFromJSON(response.text);
		GetComponent<Renderer>().material = new Material(Shader.Find("Mobile/Particles/Alpha Blended"));
		GetComponent<Renderer>().material.mainTexture = r.get_texture(); 
	}

	void Update () {

	}
}
