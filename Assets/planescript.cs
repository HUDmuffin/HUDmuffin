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


public class ImgResponse
{
	public string image;
	public string status;
	public string ReceivedOn;
	public string RecievedBy;

	public static ImgResponse CreateFromJSON(string jsonString)
	{
		ImgResponse x = JsonUtility.FromJson<ImgResponse>(jsonString);
		return x;
	}

	public Texture2D get_texture() {
		Texture2D texture = new Texture2D (1, 1);
		texture.LoadImage (Convert.FromBase64String (image)); 
		return texture;
	}

}

public class planescript : MonoBehaviour {
	string url = "http://i.imgur.com/6g4wY8F.png";

	IEnumerator Start () {
		/*WWW www = new WWW(url);

		yield return www;
		GetComponent<Renderer>().material = new Material(Shader.Find("Unlit/Transparent"));*/

		string image_url = "http://dev1-api.prolifiq.com/muffin/api/calendar/101?month=march";
		var headers = new Hashtable();
		headers.Add("Content-Type", "application/json");
		WWW response = new WWW(image_url);
		yield return response;

		//string dummy = "{image: \"asdf\", status:\"asdf\",ReceivedOn: \"skldfjsdlkf\", RecievedBy: \"sdkfj\"}";

		ImgResponse r = ImgResponse.CreateFromJSON(response.text);
		GetComponent<Renderer>().material = new Material(Shader.Find("Unlit/Transparent"));
		GetComponent<Renderer>().material.mainTexture = r.get_texture(); 

		//GetComponent<Renderer>().material.mainTexture = www.texture;
	}

	IEnumerator get_image() {
		string image_url = "http://dev1-api.prolifiq.com/muffin/api/calendar/101?month=march";
		var headers = new Hashtable();
		headers.Add("Content-Type", "application/json");
		WWW response = new WWW(image_url);
		yield return response;

		ImgResponse r = JsonUtility.FromJson<ImgResponse>(response.text);
		GetComponent<Renderer>().material = new Material(Shader.Find("Unlit/Transparent"));
		GetComponent<Renderer>().material.mainTexture = r.get_texture(); }
	
	void Update () {
		
	}
}
