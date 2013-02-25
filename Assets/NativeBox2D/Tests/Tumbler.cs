using UnityEngine;
using System.Collections;
using System;
using NativeBox2D;

public class Tumbler : Testbed {
	
	IntPtr m_body;
	public int e_count = 800;
	int count = 0;
	// Use this for initialization
	protected override void Init () {
		var ground = API.CreateBody(world, new Vector2(0,0), 0, BodyType.STATIC_BODY );
		
		BodyDef bd = new BodyDef(BodyType.DYNAMIC_BODY);
		bd.allowSleep = false;
		bd.position = new Vector2(0,10);
		m_body = API.CreateBody(world, bd);
		API.AddBoxShape(m_body,0.5f,10.0f,new Vector2(10.0f,0),0,new ShapeDef(5.0f));
		API.AddBoxShape(m_body,0.5f,10.0f,new Vector2(-10.0f,0),0,new ShapeDef(5.0f));
		API.AddBoxShape(m_body,10.0f,0.5f,new Vector2(0,10),0,new ShapeDef(5.0f));
		API.AddBoxShape(m_body,10.0f,0.5f,new Vector2(0,-10),0,new ShapeDef(5.0f));
		
		RevoluteJointDef rjd = new RevoluteJointDef(IntPtr.Zero, IntPtr.Zero);
		rjd.bodyA = ground;
		rjd.bodyB = m_body;
		rjd.localAnchorA = new Vector2(0,10);
		rjd.localAnchorB = Vector2.zero;
		rjd.referenceAngle = 0;
		rjd.motorSpeed = 0.05f * Mathf.PI;
		rjd.maxMotorTorque = 1e8f;
		rjd.enableMotor = true;
		
		API.CreateRevoluteJoint(world, rjd);
	}
	
	new void Update()
	{
		base.Update();

		if( count < e_count )
		{
			var b = API.CreateBody(world, new Vector2(0,10),0,BodyType.DYNAMIC_BODY);
			API.AddBoxShape(b, 0.125f,0.125f,Vector2.zero,0,new ShapeDef(1.0f));
			++count;
		}
	}
	
	void OnGUI11()
	{
		GUI.Button( new Rect(500,100,300,100), "Count="+count);
	}
}
