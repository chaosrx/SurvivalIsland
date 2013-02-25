using UnityEngine;
using System.Collections;
using System;
using NativeBox2D;

public class TheoJansen: Testbed {
	
	Vector2 m_offset;
	IntPtr m_chassis;
	IntPtr m_wheel;
	IntPtr m_motorJoint;
	bool m_motorOn;
	float m_motorSpeed;
	
	void CreateLeg(float s, Vector2 wheelAnchor)
	{
		Vector2 p1 = new Vector2(5.4f * s, -6.1f);
		Vector2 p2 = new Vector2(7.2f * s, -1.2f);
		Vector2 p3 = new Vector2(4.3f * s, -1.9f);
		Vector2 p4 = new Vector2(3.1f * s, 0.8f);
		Vector2 p5 = new Vector2(6.0f * s, 1.5f);
		Vector2 p6 = new Vector2(2.5f * s, 3.7f);
		
		ShapeDef sp = new ShapeDef(1.0f);
		sp.groupIndex = -1;
		Vector2[] vertices1 = new Vector2[3];
		Vector2[] vertices2 = new Vector2[3];
		if( s > 0.0f )
		{
			vertices1[0] = p1;
			vertices1[1] = p2;
			vertices1[2] = p3;

			vertices2[0] = Vector2.zero;
			vertices2[1] = p5-p4;
			vertices2[2] = p6-p4;
		}
		else
		{
			vertices1[0] = p1;
			vertices1[1] = p3;
			vertices1[2] = p2;

			vertices2[0] = Vector2.zero;
			vertices2[1] = p6-p4;
			vertices2[2] = p5-p4;
		}
		
		BodyDef bd1 = new BodyDef(BodyType.DYNAMIC_BODY);
		BodyDef bd2 = new BodyDef(BodyType.DYNAMIC_BODY);
		bd1.position = m_offset;
		bd2.position = p4 + m_offset;
		
		bd1.angularDamping = 10.0f;
		bd2.angularDamping = 10.0f;
		
		var body1 = API.CreateBody(world,bd1);
		var body2 = API.CreateBody(world,bd2);
		API.AddPolygonShape(body1, vertices1,vertices1.Length,sp);
		API.AddPolygonShape(body2, vertices2,vertices2.Length,sp);
		
		DistanceJointDef djd = new DistanceJointDef();
		djd.dampingRatio = 0.5f;
		djd.frequencyHz = 10.0f;
		
		djd.Initialize(body1,body2,p2+m_offset, p5+m_offset);
		API.CreateDistanceJoint(world, djd );
		
		djd.Initialize(body1, body2, p3 + m_offset, p4 + m_offset);
		API.CreateDistanceJoint(world, djd );

		djd.Initialize(body1, m_wheel, p3 + m_offset, wheelAnchor + m_offset);
		API.CreateDistanceJoint(world, djd );

		djd.Initialize(body2, m_wheel, p6 + m_offset, wheelAnchor + m_offset);
		API.CreateDistanceJoint(world, djd );
		
		RevoluteJointDef rjd = new RevoluteJointDef();
		rjd.Initialize(body2, m_chassis,p4+m_offset);
		API.CreateRevoluteJoint(world,rjd);
	}
	
	// Use this for initialization
	protected override void Init () {
		m_offset = new Vector2(0,8);
		m_motorSpeed = 2.0f;
		m_motorOn = true;
		Vector2 pivot = new Vector2(0,0.8f);
		
		//ground
		var ground = API.CreateBody(world, new Vector2(0,0), 0, BodyType.STATIC_BODY );
		API.AddEdgeShape( ground, new Vector2(-50,0), new Vector2(50,0), new ShapeDef(0) );
		API.AddEdgeShape( ground, new Vector2(-50,0), new Vector2(-50,10), new ShapeDef(0) );
		API.AddEdgeShape( ground, new Vector2(50,0), new Vector2(50,10), new ShapeDef(0) );
		
		//Balls
		for(int i=0; i<40; ++i)
		{
			var b = API.CreateBody(world, new Vector2(-40+2*i,0.5f), 0, BodyType.DYNAMIC_BODY);
			API.AddCircleShape(b, 0.25f, new ShapeDef(1.0f));
		}
		
		//Chassis
		ShapeDef sp = new ShapeDef(1.0f);
		sp.groupIndex = -1;
		m_chassis = API.CreateBody(world, pivot+m_offset,0,BodyType.DYNAMIC_BODY);
		API.AddBoxShape(m_chassis,2.5f,1.0f,Vector2.zero,0,sp);
		
		m_wheel = API.CreateBody(world, pivot+m_offset,0,BodyType.DYNAMIC_BODY);
		API.AddCircleShape(m_wheel,1.6f,sp);
		
//		Vector2 localArchorA,localArchorB;
//		
//		API.GetLocalPoint(m_wheel,pivot + m_offset,out localArchorA);
//		API.GetLocalPoint(m_chassis,pivot + m_offset,out localArchorB);
//		float referenceAngle = API.GetBodyAngle(m_chassis) - API.GetBodyAngle(m_wheel);
//		API.CreateRevoluteJoint(m_wheel, m_chassis, localArchorA, localArchorB, false, 
//			referenceAngle,false, 0, 0, m_motorOn, m_motorSpeed, 400.0f);
		
		RevoluteJointDef rjd = new RevoluteJointDef();
		rjd.Initialize(m_wheel,m_chassis,pivot+m_offset);
		rjd.collideConnected = false;
		rjd.motorSpeed = m_motorSpeed;
		rjd.maxMotorTorque = 400.0f;
		rjd.enableMotor = m_motorOn;
		API.CreateRevoluteJoint(world, rjd );
		
		Vector2 wheelAnchor = pivot + new Vector2(0,-0.8f);
		
		CreateLeg(-1.0f, wheelAnchor);
		CreateLeg(1.0f, wheelAnchor);
		
		Vector2 pos;
		API.GetPosition(m_wheel, out pos);
		API.SetTransform(m_wheel, pos, 120.0f*Mathf.PI/180.0f);
		CreateLeg(-1.0f, wheelAnchor);
		CreateLeg(1.0f, wheelAnchor);

		API.GetPosition(m_wheel, out pos);
		API.SetTransform(m_wheel, pos, -120.0f*Mathf.PI/180.0f);
		CreateLeg(-1.0f, wheelAnchor);
		CreateLeg(1.0f, wheelAnchor);
	}
}
