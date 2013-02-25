using UnityEngine;
using System.Collections;
using System;
using NativeBox2D;

[AddComponentMenu("NativeBox2D/Joints/MouseJoint")]
public class B2DMouseJoint : B2DJoint {

	public float maxForce;
	public float frequencyHz = 5.0f;
	public float dampingRatio = 0.7f;
	MouseJointDef mjd = new MouseJointDef(IntPtr.Zero, IntPtr.Zero);
//    // Use this for initialization
//    protected override IntPtr Init()
//    {
//		MouseJointDef jd = new MouseJointDef(other.body, body.body);
//		jd.target = target;
//		jd.maxForce = maxForce;
//		jd.frequencyHz = frequencyHz;
//		jd.dampingRatio = dampingRatio;
//        return API.CreateMouseJoint( B2DWorld.instance.world, jd );
//    }
	
	void Update()
	{
		if( Input.GetMouseButtonDown(0) )
		{
			if( joint != IntPtr.Zero )
				return;
			
			Vector3 pp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 p = new Vector2(pp.x, pp.y);
			IntPtr bodyUnderMouse = IntPtr.Zero;
			if( other == null )
			{
				Vector2 d = new Vector2(0.001f,0.001f);
				
				API.bodyUnderMouse = IntPtr.Zero;
				
				API.QueryAABB( B2DWorld.instance.world, p-d, p+d, new API.QUERYCALLBACK( API.QueryCallbackFunc ) );
				
				bodyUnderMouse = API.bodyUnderMouse;					
			}
			else
			{
				bodyUnderMouse = other.body;
			}
			
			if( bodyUnderMouse != IntPtr.Zero )
			{
				mjd.bodyA = body.body;
				mjd.bodyB = bodyUnderMouse;
				mjd.target = p;
				mjd.maxForce = maxForce * API.GetMass(bodyUnderMouse);
				mjd.frequencyHz = frequencyHz;
				mjd.dampingRatio = dampingRatio;
				joint = API.CreateMouseJoint(B2DWorld.instance.world, mjd);
				API.SetAwake(bodyUnderMouse,true);
			}

		}
		else if ( Input.GetMouseButtonUp(0) )
		{
			if( joint != IntPtr.Zero )
			{
				API.DestroyJoint(B2DWorld.instance.world, joint );
				joint = IntPtr.Zero;
			}
		}
		else if( Mathf.Abs( Input.GetAxis("Mouse X") ) > 0 )
		{
			if( joint != IntPtr.Zero )
			{
				Vector3 pp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				Vector2 p = new Vector2(pp.x, pp.y);
				API.MouseJointSetTarget(joint, p);
			}
		}		
	}
}
