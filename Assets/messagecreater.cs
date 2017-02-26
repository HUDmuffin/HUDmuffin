using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class messagecreater : MonoBehaviour {
	float timeLeft = 5.0f;
	ImgResponse r;

	// Use this for initialization
	IEnumerator Start () {
		string image_url = "http://dev1-api.prolifiq.com/muffin/api/calendar/101?month=january";
		var headers = new Hashtable();
		headers.Add("Content-Type", "application/json");
		WWW response = new WWW(image_url);
		yield return response;
		print ("got response");
		Debug.Log(response.text);
		r = ImgResponse.CreateFromJSON(response.text);
	}

	Mesh CreateMesh(float width, float height)
	{
		Mesh m = new Mesh();
		m.name = "ScriptedMesh";
		m.vertices = new Vector3[] {
			new Vector3(-width, -height, 0.01f),
			new Vector3(width, -height, 0.01f),
			new Vector3(width, height, 0.01f),
			new Vector3(-width, height, 0.01f)
		};
		m.uv = new Vector2[] {
			new Vector2 (0, 0),
			new Vector2 (0, 1),
			new Vector2(1, 1),
			new Vector2 (1, 0)
		};
		m.triangles = new int[] { 0, 1, 2, 0, 2, 3};
		m.RecalculateNormals();

		return m;
	}

	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;

		if(timeLeft < 0)
		{
			timeLeft = 5.0f;
			Debug.Log ("making plane");
			GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
			plane.transform.position = new Vector3(0, 0, 20);
			plane.transform.Rotate (new Vector3 (0, 180, 0));

			MeshFilter meshFilter = plane.GetComponent<MeshFilter> ();
			meshFilter.mesh = CreateMesh(10, 4);
			//MeshRenderer renderer = plane.AddComponent(typeof(MeshRenderer)) as MeshRenderer;
			//renderer.material.shader = Shader.Find ("Mobile/Particles/Alpha Blended");
			plane.transform.parent = this.transform;
			plane.GetComponent<Renderer>().material = new Material(Shader.Find("Mobile/Particles/Alpha Blended"));

			//plane.GetComponent<Renderer>().material.shader = Shader.Find ("Mobile/Particles/Alpha Blended");
			plane.GetComponent<Renderer>().material.mainTexture = r.get_texture(); 
			plane.transform.position = new Vector3(0, 0, 20);
			plane.transform.Rotate (new Vector3 (0, 180, 0));

			Debug.Log ("goint to loop");
			//Renderer[] ChildrenRenderer = GetComponent().GetComponentsInChildren(typeof(Renderer));
			//foreach(Renderer abc in ChildrenRenderer ) {

			for (int i = 0; i < transform.childCount - 1; i++) {
				Debug.Log ("running");
				Debug.Log (i);
				transform.GetChild (i).transform.Translate (0, -4.25f, 0);
				if (i >= 3) {
					Debug.Log ("removing");
						GameObject.Destroy (transform.GetChild (i)); }}}}}