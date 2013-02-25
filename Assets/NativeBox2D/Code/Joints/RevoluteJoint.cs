using UnityEngine;
using System;
using System.Runtime.InteropServices;

namespace NativeBox2D
{
	[StructLayout (LayoutKind.Sequential, Pack = 4)]
	public struct RevoluteJointDef
	{
		[MarshalAs (UnmanagedType.I4)]
		public IntPtr bodyA;
		[MarshalAs (UnmanagedType.I4)]
		public IntPtr bodyB;
		[MarshalAs (UnmanagedType.I1)]
		public bool collideConnected;
		
		public Vector2 localAnchorA;
		public Vector2 localAnchorB;
		public float referenceAngle;			
		[MarshalAs (UnmanagedType.I1)]
		public bool enableLimit;
		public float lowerAngle;
		public float upperAngle;			
		[MarshalAs (UnmanagedType.I1)]
		public bool enableMotor;
		public float motorSpeed;
		public float maxMotorTorque;
		
		public RevoluteJointDef(IntPtr bA, IntPtr bB)
		{
			bodyA = bA;
			bodyB = bB;
			collideConnected = false;
			localAnchorA = Vector2.zero;
			localAnchorB = Vector2.zero;
			referenceAngle = 0.0f;
			lowerAngle = 0.0f;
			upperAngle = 0.0f;
			maxMotorTorque = 0.0f;
			motorSpeed = 0.0f;
			enableLimit = false;
			enableMotor = false;
		}
		
		public void Initialize(IntPtr bA, IntPtr bB, Vector2 anchor)
		{
			bodyA = bA;
			bodyB = bB;
			API.GetLocalPoint(bodyA, anchor, out localAnchorA);
			API.GetLocalPoint(bodyB, anchor, out localAnchorB);
			referenceAngle = API.GetAngle(bodyB) - API.GetAngle(bodyA);
		}
	}
}