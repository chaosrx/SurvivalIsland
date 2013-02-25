using UnityEngine;
using System;
using System.Runtime.InteropServices;

namespace NativeBox2D
{
	[StructLayout (LayoutKind.Sequential, Pack = 4)]
	public struct WheelJointDef
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
		[MarshalAs (UnmanagedType.I1)]
		public bool enableMotor;
		public float maxMotorTorque;
		public float motorSpeed;
		public float frequencyHz;
		public float dampingRatio;
		
		public WheelJointDef(IntPtr bA, IntPtr bB)
		{
			bodyA = bA;
			bodyB = bB;
			collideConnected = false;
			localAnchorA = Vector2.zero;
			localAnchorB = Vector2.zero;
			localAxisA = new Vector2(1.0f,0);
			enableMotor = false;
			maxMotorTorque = 0.0f;
			motorSpeed = 0.0f;
			frequencyHz = 2.0f;
			dampingRatio = 0.7f;
		}
		
		public void Initialize(IntPtr bA, IntPtr bB, Vector2 anchor, Vector2 axis)
		{
			bodyA = bA;
			bodyB = bB;
			API.GetLocalPoint(bodyA, anchor, out localAnchorA);
			API.GetLocalPoint(bodyB, anchor, out localAnchorB);
			API.GetLocalVector(bodyA, axis, out localAxisA);
		}
	}
}