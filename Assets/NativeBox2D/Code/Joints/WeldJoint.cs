using UnityEngine;
using System;
using System.Runtime.InteropServices;

namespace NativeBox2D
{
	[StructLayout (LayoutKind.Sequential, Pack = 4)]
	public struct WeldJointDef
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
		public float frequencyHz;
		public float dampingRatio;
		
		public WeldJointDef(IntPtr bA, IntPtr bB)
		{
			bodyA = bA;
			bodyB = bB;
			collideConnected = false;
			localAnchorA = Vector2.zero;
			localAnchorB = Vector2.zero;
			referenceAngle = 0;
			frequencyHz = 0.0f;
			dampingRatio = 0.0f;
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