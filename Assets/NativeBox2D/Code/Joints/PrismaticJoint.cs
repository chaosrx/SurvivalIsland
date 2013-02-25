using UnityEngine;
using System;
using System.Runtime.InteropServices;

namespace NativeBox2D
{
	[StructLayout (LayoutKind.Sequential, Pack = 4)]
	public struct PrismaticJointDef
	{
		[MarshalAs (UnmanagedType.I4)]
		public IntPtr bodyA;
		[MarshalAs (UnmanagedType.I4)]
		public IntPtr bodyB;
		[MarshalAs (UnmanagedType.I1)]
		public bool collideConnected;
		
		public Vector2 localAnchorA;
		public Vector2 localAnchorB;
		public Vector2 localAxisA;
		public float referenceAngle;			
		[MarshalAs (UnmanagedType.I1)]
		public bool enableLimit;
		public float lowerTranslation;
		public float upperTranslation;			
		[MarshalAs (UnmanagedType.I1)]
		public bool enableMotor;
		public float maxMotorForce;
		public float motorSpeed;
		
		public PrismaticJointDef(IntPtr bA, IntPtr bB)
		{
			bodyA = bA;
			bodyB = bB;
			collideConnected = false;
			localAnchorA = Vector2.zero;
			localAnchorB = Vector2.zero;
			localAxisA = new Vector2(1,0);		
			referenceAngle = 0.0f;
			enableLimit = false;
			lowerTranslation = 0.0f;
			upperTranslation = 0.0f;
			enableMotor = false;
			maxMotorForce = 0.0f;
			motorSpeed = 0.0f;
		}
		
		public void Initialize(IntPtr bA, IntPtr bB, Vector2 anchor, Vector2 axis)
		{
			bodyA = bA;
			bodyB = bB;
			API.GetLocalPoint(bodyA, anchor, out localAnchorA);
			API.GetLocalPoint(bodyB, anchor, out localAnchorB);
			API.GetLocalVector(bodyA, axis, out localAxisA);
			referenceAngle = API.GetAngle(bodyB) - API.GetAngle(bodyA);
		}
	}
}