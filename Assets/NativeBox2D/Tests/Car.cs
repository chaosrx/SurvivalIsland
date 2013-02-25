using UnityEngine;
using System.Collections;
using System;
using NativeBox2D;

public class Car : Testbed {
	
	IntPtr m_car;
	IntPtr m_wheel1;
	IntPtr m_wheel2;

	float m_hz;
	float m_zeta;
	float m_speed;
	IntPtr m_spring1;
	IntPtr m_spring2;
	
	// Use this for initialization
	protected override void Init () {
				
		m_hz = 4.0f;
		m_zeta = 0.7f;
		m_speed = 50.0f;

		IntPtr ground = IntPtr.Zero;
		{
			ground = API.CreateBody(world,new Vector2(0,0), 0, BodyType.STATIC_BODY);
			ShapeDef sp = new ShapeDef(0);
			sp.friction = 0.6f;
			API.AddEdgeShape(ground, new Vector2(-20,0),new Vector2(20,0), sp);

			float[] hs = new float[]{0.25f, 1.0f, 4.0f, 0.0f, 0.0f, -1.0f, -2.0f, -2.0f, -1.25f, 0.0f};

			float x = 20.0f, y1 = 0.0f, dx = 5.0f;

			for (int i = 0; i < 10; ++i)
			{
				float y2 = hs[i];
				API.AddEdgeShape(ground, new Vector2(x,y1), new Vector2(x+dx,y2),sp);
				y1 = y2;
				x += dx;
			}

			for (int i = 0; i < 10; ++i)
			{
				float y2 = hs[i];
				API.AddEdgeShape(ground, new Vector2(x,y1), new Vector2(x+dx,y2),sp);
				y1 = y2;
				x += dx;
			}

			API.AddEdgeShape(ground, new Vector2(x,0), new Vector2(x+40,0),sp);

			x += 80.0f;
			API.AddEdgeShape(ground, new Vector2(x,0), new Vector2(x+40,0),sp);

			x += 40.0f;
			API.AddEdgeShape(ground, new Vector2(x,0), new Vector2(x+10,5),sp);

			x += 20.0f;
			API.AddEdgeShape(ground, new Vector2(x,0), new Vector2(x+40,0),sp);

			x += 40.0f;
			API.AddEdgeShape(ground, new Vector2(x,0), new Vector2(x,20),sp);
		}

		// Teeter
		{
			IntPtr body = API.CreateBody(world,new Vector2(140,1.0f), 0, BodyType.DYNAMIC_BODY);
			API.AddBoxShape(body,10,0.25f,Vector2.zero,0,new ShapeDef(1.0f));
			
			Vector2 archor;
			API.GetPosition(body, out archor);
			RevoluteJointDef jd = new RevoluteJointDef();
			jd.Initialize(ground,body,archor);
			jd.lowerAngle = -8.0f * Mathf.Deg2Rad;
			jd.upperAngle = 8.0f * Mathf.Deg2Rad;
			jd.enableLimit = true;

			API.CreateRevoluteJoint(world,jd);
			
			API.ApplyAngularImpulse(body, 100.0f);
		}

		// Bridge
		{
			int N = 20;
			ShapeDef sp = new ShapeDef(1.0f);
			sp.friction = 0.6f;
			
			Vector2 anchor;
			
			RevoluteJointDef jd = new RevoluteJointDef();
			IntPtr prevBody = ground;
			for (int i = 0; i < N; ++i)
			{
				var body = API.CreateBody(world,new Vector2(161.0f+2.0f*i, -0.125f), 0, BodyType.DYNAMIC_BODY);
				API.AddBoxShape(body,1.0f, 0.125f, Vector2.zero, 0, sp);

				anchor = new Vector2(160.0f + 2.0f * i, -0.125f);
				jd.Initialize(prevBody,body,anchor);
				API.CreateRevoluteJoint(world,jd);
				
				prevBody = body;
			}

			anchor = new Vector2(160.0f + 2.0f * N, -0.125f);
			jd.Initialize(prevBody,ground,anchor);
			API.CreateRevoluteJoint(world,jd);
		}

		// Boxes
		{			
			var body = API.CreateBody(world,new Vector2(230.0f,0.5f), 0, BodyType.DYNAMIC_BODY);
			API.AddBoxShape(body,0.5f,0.5f, Vector2.zero,0,new ShapeDef(0.5f));
			
			body = API.CreateBody(world,new Vector2(230.0f,1.5f), 0, BodyType.DYNAMIC_BODY);
			API.AddBoxShape(body,0.5f,0.5f, Vector2.zero,0,new ShapeDef(0.5f));
			
			body = API.CreateBody(world,new Vector2(230.0f,2.5f), 0, BodyType.DYNAMIC_BODY);
			API.AddBoxShape(body,0.5f,0.5f, Vector2.zero,0,new ShapeDef(0.5f));
			
			body = API.CreateBody(world,new Vector2(230.0f,3.5f), 0, BodyType.DYNAMIC_BODY);
			API.AddBoxShape(body,0.5f,0.5f, Vector2.zero,0,new ShapeDef(0.5f));
			
			body = API.CreateBody(world,new Vector2(230.0f,4.5f), 0, BodyType.DYNAMIC_BODY);
			API.AddBoxShape(body,0.5f,0.5f, Vector2.zero,0,new ShapeDef(0.5f));
		}

		// Car
		{
			ShapeDef sp = new ShapeDef(1.0f);
			
			Vector2[] vertices = new Vector2[6];
			vertices[0] = new Vector2(-1.5f, -0.5f);
			vertices[1] = new Vector2(1.5f, -0.5f);
			vertices[2] = new Vector2(1.5f, 0.0f);
			vertices[3] = new Vector2(0.0f, 0.9f);
			vertices[4] = new Vector2(-1.15f, 0.9f);
			vertices[5] = new Vector2(-1.5f, 0.2f);

			m_car = API.CreateBody(world,new Vector2(0,1.0f),0,BodyType.DYNAMIC_BODY);
			API.AddPolygonShape(m_car,vertices,vertices.Length,sp);
			
			sp.friction = 0.9f;
			m_wheel1 = API.CreateBody(world,new Vector2(-1.0f,0.35f),0,BodyType.DYNAMIC_BODY);
			API.AddCircleShape(m_wheel1, 0.4f, sp);
			m_wheel2 = API.CreateBody(world,new Vector2(1.0f,0.4f),0,BodyType.DYNAMIC_BODY);
			API.AddCircleShape(m_wheel2, 0.4f, sp);
			
			WheelJointDef jd = new WheelJointDef();
			Vector2 axis = new Vector2(0.0f, 1.0f);
			Vector2 pos1,pos2;
			API.GetPosition(m_wheel1,out pos1);
			API.GetPosition(m_wheel2,out pos2);
			jd.Initialize(m_car, m_wheel1, pos1, axis);
			jd.motorSpeed = 0.0f;
			jd.maxMotorTorque = 20.0f;
			jd.enableMotor = true;
			jd.frequencyHz = m_hz;
			jd.dampingRatio = m_zeta;
			m_spring1 = API.CreateWheelJoint(world,jd);
			
			jd.Initialize(m_car, m_wheel2, pos2, axis);
			jd.motorSpeed = 0.0f;
			jd.maxMotorTorque = 10.0f;
			jd.enableMotor = false;
			jd.frequencyHz = m_hz;
			jd.dampingRatio = m_zeta;
			m_spring2 = API.CreateWheelJoint(world,jd);
		}
	}
	
	// Update is called once per frame
	new void Update () {
		base.Update ();
		
		if( Input.GetKey(KeyCode.A) )
		{
			API.WheelJointSetMotorSpeed(m_spring1, m_speed);
		}
		else if( Input.GetKey(KeyCode.S) )
		{
			API.WheelJointSetMotorSpeed(m_spring1, 0.0f);
		}
		else if( Input.GetKey(KeyCode.D) )
		{
			API.WheelJointSetMotorSpeed(m_spring1, -m_speed);
		}		
		else if( Input.GetKey(KeyCode.Q) )
		{
			m_hz = Mathf.Max( 0.0f, m_hz - 1.0f );
			API.WheelJointSetSpringFrequencyHz(m_spring1, m_hz);
			API.WheelJointSetSpringFrequencyHz(m_spring2, m_hz);
		}	
		else if( Input.GetKey(KeyCode.E) )
		{
			m_hz += 1.0f;
			API.WheelJointSetSpringFrequencyHz(m_spring1, m_hz);
			API.WheelJointSetSpringFrequencyHz(m_spring2, m_hz);
		}	
	}
	
}
