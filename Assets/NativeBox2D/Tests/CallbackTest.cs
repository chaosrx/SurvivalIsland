using UnityEngine;
using System.Collections;
using System;
using NativeBox2D;

public class CallbackTest : MonoBehaviour {
	
	public B2DBody destroyOnRightClick;
	
    //[API.MonoPInvokeCallback (typeof (API.SHOULDCOLLIDECALLBACK))]
	public static bool ShouldCollide(  IntPtr f1, IntPtr f2 )
	{
		print ("should collide");
		return true;
	}
		
	// Use this for initialization
	void Start () {
		API.CreateContactListener( B2DWorld.instance.world, gameObject );
        API.CreateContactFilter( B2DWorld.instance.world, new API.SHOULDCOLLIDECALLBACK( ShouldCollide ) );	
        API.CreateDestructionListener(  B2DWorld.instance.world, gameObject );
	}
	
	// Update is called once per frame
	void Update () {
		if( Input.GetMouseButtonDown(1) )
		{
			Destroy( destroyOnRightClick.gameObject );
			//API.DestroyBody( B2DWorld.instance.world, destroyOnRightClick.body );
		}
	}
	
	void BeginContact( IntPtr contact )
	{
		print ("begin contact");
	}
	
	void EndContact( IntPtr contact )
	{
		print ("end contact");
	}
	
	void OnJointDestroy( IntPtr j )
	{
		print ("on joint destroy");		
	}
	
	void OnFixtureDestroy( IntPtr f )
	{
		print ("on fixture destroy");		
	}
	
	void OnGUI()
	{
		GUILayout.Label("Left click to drag some GameObject");
		GUILayout.Label("Right click to check the callback outputs");
	}
}
