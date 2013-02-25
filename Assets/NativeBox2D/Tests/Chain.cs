using UnityEngine;
using System.Collections;
using System;
using NativeBox2D;

public class Chain : Testbed {
	
	IntPtr m_body;
	public int e_count = 30;

	// Use this for initialization
	protected override void Init () {
		var ground = API.CreateBody(world, new Vector2(0,0), 0, BodyType.STATIC_BODY );
		API.AddEdgeShape(ground, new Vector2(-40.0f,0.0f), new Vector2(40.0f,0.0f), new ShapeDef(0));
		
		ShapeDef sp = new ShapeDef( 20.0f );
		sp.friction = 0.2f;
		
		Vector2 anchor;
		RevoluteJointDef jd = new RevoluteJointDef();
		
		IntPtr prevBody = ground;
		float y = 25;
		for(int i=0; i<e_count; ++i)
		{
			var b = API.CreateBody(world, new Vector2(0.5f+i,y), 0, BodyType.DYNAMIC_BODY );
			API.AddBoxShape(b, 0.6f, 0.125f, Vector2.zero, 0, sp);
			
			anchor = new Vector2(i,y);
			jd.Initialize(prevBody,b,anchor);
			API.CreateRevoluteJoint(world,jd);
			
			prevBody = b;
		}
	}
}
