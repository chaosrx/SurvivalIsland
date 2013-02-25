using UnityEngine;
using System;
using System.Runtime.InteropServices;

namespace NativeBox2D
{
	[StructLayout (LayoutKind.Sequential, Pack = 4)]
	public struct FrictionJointDef
	{
		[MarshalAs (UnmanagedType.I4)]
		public IntPtr bodyA;
		[MarshalAs (UnmanagedType.I4)]
		public IntPtr bodyB;
		[MarshalAs (UnmanagedType.I1)]
		public bool collideConnected;
		
		public Vector2 localAnchorA;
		public Vector2 localAnchorB;
		public float maxForce;
		public float maxTorque;
		
		public FrictionJointDef(IntPtr bA, IntPtr bB)
		{
			bodyA = bA;
			bodyB = bB;
			collideConnected = false;
			localAnchorA = Vector2.zero;
			localAnchorB = Vector2.zero;
			maxForce = 0.0f;
			maxTorque = 0.0f;
		}
		
		public void Initialize(IntPtr bA, IntPtr bB, Vector2 anchor)
		{
			bodyA = bA;
			bodyB = bB;
			API.GetLocalPoint(bodyA, anchor, out localAnchorA);
			API.GetLocalPoint(bodyB, anchor, out localAnchorB);
		}
	}
}