using UnityEngine;
using System.Collections;

public class TestController : MonoBehaviour {
	
	GameObject[] tests;
	
	public int idx = 4;
	// Use this for initialization
	void Awake () {
		Application.targetFrameRate = 300;
		tests = new GameObject[transform.childCount];
		for(int i=0; i<transform.childCount; ++i)
		{
			tests[i] = transform.GetChild(i).gameObject;
		}
		tests[idx].SetActiveRecursively(true);
	}
	
	void PrevTest()
	{
		tests[idx].gameObject.SetActiveRecursively(false);
		idx = (idx+tests.Length-1)%tests.Length;
		tests[idx].gameObject.SetActiveRecursively(true);
	}
	
	void NextTest()
	{
		tests[idx].gameObject.SetActiveRecursively(false);
		idx = (idx+1)%tests.Length;
		tests[idx].gameObject.SetActiveRecursively(true);
	}
	
	// Update is called once per frame
	void Update () {
		if( Input.GetKeyDown(KeyCode.LeftArrow) )
		{
			PrevTest();
		}
		else if( Input.GetKeyDown(KeyCode.RightArrow) )
		{
			NextTest();
		}	
	}
	
	void OnGUI() 
	{
		GUILayout.BeginArea( new Rect( 0,25,100,200) );
		if( GUILayout.Button("Prev Test", GUILayout.MinWidth(100), GUILayout.MinHeight(60) ) )
		{
			PrevTest();
		}
		else if( GUILayout.Button("Next Test", GUILayout.MinWidth(100), GUILayout.MinHeight(60) ) )
		{
			NextTest();
		}
		GUILayout.EndArea();
	}
}
