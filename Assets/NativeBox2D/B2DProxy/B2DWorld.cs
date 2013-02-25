using UnityEngine;
using System.Collections;
using System;
using NativeBox2D;

[AddComponentMenu("NativeBox2D/World")]
public class B2DWorld : MonoBehaviour {
	
	public static B2DWorld instance;
	
	public Vector2 gravity = new Vector2(0,-10);
	public int velocityIterations = 8;
	public int positionIterations = 3;
	
	[HideInInspector]
	public IntPtr world;

	// Use this for initialization
	void Awake () {
		instance = this;
		world = API.CreateWorld( gravity );
	}
	
	// Update is called once per frame
    void FixedUpdate()
    {
        //API.SetSubStepping(world, true);
		API.Step( world, Time.fixedDeltaTime, velocityIterations, positionIterations );
	}
	
	void OnDestroy()
	{
		API.DestroyWorld(world);
		world = IntPtr.Zero;
	}
}
