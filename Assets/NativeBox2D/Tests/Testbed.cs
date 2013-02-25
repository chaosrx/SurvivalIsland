using UnityEngine;
using System.Collections;
using System;
using NativeBox2D;

public class Testbed : MonoBehaviour {
    public Vector2 gravity = new Vector2(0, -10);
	
	protected IntPtr world;
	IntPtr mouseJoint;
	IntPtr ground;
	MouseJointDef mjd = new MouseJointDef(IntPtr.Zero,IntPtr.Zero);
	// Use this for initialization
	
	void OnEnable()
	{
        world = API.CreateWorld( gravity );
		DebugDraw.world = world;
        ground = API.CreateBody(world, Vector2.zero, 0, BodyType.STATIC_BODY);
		
		Init();
	}
	
	void OnDisable()
	{
		API.DestroyWorld(world);
	}

	public int velocityIterations = 8;
	public int positionIterations = 3;
		
	protected void Update()
	{
		API.SetWarmStarting(world,true);
		API.SetContinuousPhysics(world,true);
		API.Step(world, 1.0f/60, velocityIterations,positionIterations);
		
		if( Input.GetMouseButtonDown(0) )
		{
			if( mouseJoint != IntPtr.Zero )
				return;

			Vector3 pp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 p = new Vector2(pp.x, pp.y);
			Vector2 d = new Vector2(0.001f,0.001f);

			API.bodyUnderMouse = IntPtr.Zero;
			
			API.QueryAABB( world, p-d, p+d, new API.QUERYCALLBACK( API.QueryCallbackFunc ) );
			
			if( API.bodyUnderMouse != IntPtr.Zero )
			{
				mjd.bodyA = ground;
				mjd.bodyB = API.bodyUnderMouse;
				mjd.target = p;
				mjd.maxForce = 1000.0f * API.GetMass(API.bodyUnderMouse);
				mouseJoint = API.CreateMouseJoint(world, mjd);
				API.SetAwake(API.bodyUnderMouse,true);
			}
		}
		else if ( Input.GetMouseButtonUp(0) )
		{
			if( mouseJoint != IntPtr.Zero )
			{
				API.DestroyJoint(world, mouseJoint );
				mouseJoint = IntPtr.Zero;
			}
		}
		else if( Mathf.Abs( Input.GetAxis("Mouse X") ) > 0 )
		{
			if( mouseJoint != IntPtr.Zero )
			{
				Vector3 pp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				Vector2 p = new Vector2(pp.x, pp.y);
				API.MouseJointSetTarget(mouseJoint, p);
			}
		}
	}
		
	void OnGUI()
	{
		GUILayout.Label(gameObject.name);
	}
	
	protected virtual void Init()
	{
	}
}
