using UnityEngine;
using System.Collections;
using System;
using NativeBox2D;

public class ApplyForce : Testbed {
	
	IntPtr m_body;
	
	// Use this for initialization
	protected override void Init () {
		API.SetGravity(world,Vector2.zero);
		var ground = API.CreateBody(world, new Vector2(0,20), 0, BodyType.STATIC_BODY );
		ShapeDef sp = new ShapeDef(0);
		sp.restitution = 0.4f;
		
		API.AddEdgeShape(ground, new Vector2(-20,-20), new Vector2(-20,20), sp);
		API.AddEdgeShape(ground, new Vector2(20,-20), new Vector2(20,20), sp);
		API.AddEdgeShape(ground, new Vector2(-20,20), new Vector2(20,20), sp);
		API.AddEdgeShape(ground, new Vector2(-20,-20), new Vector2(20,-20), sp);	
		
		BodyDef bd = new BodyDef(BodyType.DYNAMIC_BODY);
		bd.allowSleep = false;
		bd.angle = 3.14159265359f;
		bd.angularDamping = 5.0f;
		bd.linearDamping = 0.1f;
		bd.position = new Vector2(0,2);
		m_body = API.CreateBody(world,bd);
		
		sp.restitution = 0.0f;
		sp.density = 4.0f;
		
		b2Transform xf1 = new b2Transform();
		xf1.q = new b2Rot(0.3524f * Mathf.PI);
		xf1.p = xf1.q.GetXAxis();

		Vector2[] vertices = new Vector2[3];
		vertices[0] = b2Math.b2Mul(xf1, new Vector2(-1.0f, 0.0f));
		vertices[1] = b2Math.b2Mul(xf1, new Vector2(1.0f, 0.0f));
		vertices[2] = b2Math.b2Mul(xf1, new Vector2(0.0f, 0.5f));
		
		API.AddPolygonShape(m_body, vertices, vertices.Length, sp);
		
		sp.density = 2.0f;
		xf1.q = new b2Rot(-0.3524f * Mathf.PI);
		xf1.p = -xf1.q.GetXAxis();

		vertices[0] = b2Math.b2Mul(xf1, new Vector2(-1.0f, 0.0f));
		vertices[1] = b2Math.b2Mul(xf1, new Vector2(1.0f, 0.0f));
		vertices[2] = b2Math.b2Mul(xf1, new Vector2(0.0f, 0.5f));
		
		API.AddPolygonShape(m_body, vertices, vertices.Length, sp);		
		
		sp.density = 1.0f;
		sp.friction = 0.3f;
		float gravity = 10;
		
		FrictionJointDef jd = new FrictionJointDef();
		for(int i=0; i<10; ++i)
		{
			var b = API.CreateBody(world, new Vector2(0,5.0f+1.54f*i), 0, BodyType.DYNAMIC_BODY );
			API.AddBoxShape(b, 0.5f, 0.5f, Vector2.zero, 0, sp);
			float I = API.GetInertia(b);
			float mass = API.GetMass(b);
			float radius = Mathf.Sqrt(2.0f*I/mass);
			
			jd.bodyA = ground;
			jd.bodyB = b;
			jd.collideConnected = true;
			jd.maxForce = mass*gravity;
			jd.maxTorque = mass*radius*gravity;
			
			API.CreateFrictionJoint(world,jd);
		}
	}
	
	void Update()
	{		
		base.Update();
		
		if( Input.GetKey(KeyCode.W) )
		{
			Vector2 f,p;
			API.GetWorldVector(m_body, new Vector2(0,-200), out f);
			API.GetWorldPoint(m_body, new Vector2(0,2), out p);
			API.ApplyForce(m_body, f, p);
		}
		else if( Input.GetKey(KeyCode.A) )
		{
			API.ApplyTorque(m_body, 50);
		}
		else if( Input.GetKey(KeyCode.D) )
		{
			API.ApplyTorque(m_body, -50);
		}		
	}
}
