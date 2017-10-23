using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class DisplayingText : MonoBehaviour {

	List<string> pages = new List<string> {};
	int curpage = 0;
	private SteamVR_Controller.Device Controller;


	// Use this for initialization
	void Start () {
		// Read each line of the file into a string array. Each element
		// of the array is one line of the file.


		string text = System.IO.File.ReadAllText(@"/Users/davidgu/Google Drive/Academic/Computer Science/5650-ARVR/test.txt");
		//string[] sentences = Regex.Split(lines, @"(?<=[\.,!\?])\s+");
		string[] sentences = Regex.Split(text, @" ");
		string displayable_text = "";

		//int wordlimit = 0;
		// Display the file contents by using a foreach loop.
		print (text.Length);
		for (int j = 0; j < sentences.Length; j++){
			displayable_text = displayable_text + " "+ sentences [j];
			if ((j+1) % 10 == 0)
				displayable_text = displayable_text + "\n";
			if ((j+1) % 100 == 0) {
				pages.Add (displayable_text);
				displayable_text = "";
			}
				
			
		}
//		foreach (string line in sentences)
//		{	
//			wordlimit = wordlimit + line.Split ().Length;
//			// Use a tab to indent each line of the file.
//			if (wordlimit<50)
//				displayable_text = displayable_text + "\n" + line;
//			else{
//				pages.Add (displayable_text);
//				displayable_text = "";
//				wordlimit = 0;
//				print ("new page");
//			}
//
//		}

		// Keep the console window open in debug mode.
		TextMesh textObject = GameObject.Find("Book").GetComponent<TextMesh>();

		textObject.text = pages[curpage];
		print(pages[curpage]);
//		if (Input.GetMouseButtonDown (0)) {
//			textObject.text = pages [curpage ++];
//		}
	
	}



	void FixedUpdate (){
		TextMesh textObject = GameObject.Find("Book").GetComponent<TextMesh>();

		if (Input.GetMouseButtonDown (0)) {
			Debug.Log ("clicked");
			textObject.text = pages [curpage ++];
		}

//		if (Controller.GetHairTriggerDown ()) {
//			Debug.Log(gameObject.name + " Trigger Press");
//		}
//		if (Controller.GetHairTriggerUp())
//		{
//			Debug.Log(gameObject.name + " Trigger Release");
//		}

	}


}


