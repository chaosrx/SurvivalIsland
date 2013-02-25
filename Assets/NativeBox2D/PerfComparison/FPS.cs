using UnityEngine;
using System.Collections;

public class FPS : MonoBehaviour {

	private int fps = 0;
	private int mFPS = 0;
	private float t = 0.0f;

	// Use this for initialization
	void Start () {
       
	}	    

	// Update is called once per frame
	void Update () {
		++fps;
		t += Time.deltaTime;
		if( t > 1.0f )
		{
			mFPS = fps;
			fps = 0;
			t -= 1.0f;
		}        
	}

	void OnGUI()
	{
		GUI.Label (new Rect (0,0,150,100), "fps = " + mFPS.ToString() );
	}
}
