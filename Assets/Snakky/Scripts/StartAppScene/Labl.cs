using UnityEngine;
using System.Collections;
using System.IO;
using SimpleJSON;

public class Labl : MonoBehaviour {

	string m_DataFile = "3.json";
	void OnGUI() {

		if (!File.Exists( m_DataFile )){
			Debug.Log(m_DataFile + " doesn't exists.");
			//return null;
		}

		//string url = Application.dataPath + @"/3.json";
		string url = "http://www.txt.ru/";
		Debug.Log ("Loading " + url.ToString());
		WWW request = new WWW(url);
		
		while(!request.isDone) {
			Debug.Log("Loading...");
		}
		
		Debug.Log("Data: " + request.data);
		
		//string text = File.ReadAllText( m_DataFile );
		string text = request.data ;
		GUI.Label(new Rect(10, 10, 400, 400), text);
	}
}
