using UnityEngine;
using System.Collections;
using System;
using NativeBox2D;

public class Bridge : Testbed {
	
	IntPtr m_body;
	public int e_count = 30;

	// Use this for initialization
	protected override void Init () {
		var ground = API.CreateBody(world, new Vector2(0,0), 0, BodyType.STATIC_BODY );
		API.AddEdgeShape(ground, new Vector2(-40.0f,0.0f), new Vector2(40.0f,0.0f), new ShapeDef(0));
		
		ShapeDef sp = new ShapeDef( 20.0f );
		sp.friction = 0.2f;
		
		RevoluteJointDef def = new RevoluteJointDef();
		IntPtr prevBody = ground;
		for(int i=0; i<e_count; ++i)
		{
			var b = API.CreateBody(world, new Vector2(-14.5f+i,5.0f), 0, BodyType.DYNAMIC_BODY );
			API.AddBoxShape(b, 0.5f, 0.125f, Vector2.zero, 0, sp);
						
			def.Initialize(prevBody, b, new Vector2(-15.0f+i, 5.0f));
			API.CreateRevoluteJoint(world, def );
			prevBody = b;
		}
		
		def.Initialize(prevBody, ground, new Vector2(-15.0f+e_count, 5.0f));
		API.CreateRevoluteJoint(world,def);
	
		for(int i=0; i<2; ++i)
		{
			var b = API.CreateBody(world,new Vector2(-8.0f + 8*i,12), 0, BodyType.DYNAMIC_BODY);
			Vector2[] vertices = new Vector2[3];
			vertices[0].Set(-0.5f, 0.0f);
			vertices[1].Set(0.5f, 0.0f);
			vertices[2].Set(0.0f, 1.5f);
			API.AddPolygonShape(b,vertices,vertices.Length, new ShapeDef(1.0f));			
		}
		
		for(int i=0; i<3; ++i)
		{
			var b = API.CreateBody(world,new Vector2(-6.0f + 6*i,10), 0, BodyType.DYNAMIC_BODY);
			API.AddCircleShape(b,0.5f,new ShapeDef(1.0f));
		}
	}
}
