using UnityEngine;
using System;
using System.Runtime.InteropServices;

namespace NativeBox2D
{
	[StructLayout (LayoutKind.Sequential, Pack = 4)]
	public struct DistanceJointDef
	{
		[MarshalAs (UnmanagedType.I4)]
		public IntPtr bodyA;
		[MarshalAs (UnmanagedType.I4)]
		public IntPtr bodyB;
		[MarshalAs (UnmanagedType.I1)]
		public bool collideConnected;
		
		public Vector2 localAnchorA;
		public Vector2 localAnchorB;
		public float length;
		public float frequencyHz;
		public float dampingRatio;
		
		public DistanceJointDef(IntPtr bA, IntPtr bB)
		{
			bodyA = bA;
			bodyB = bB;
			collideConnected = false;
			localAnchorA = Vector2.zero;
			localAnchorB = Vector2.zero;
			length = 1.0f;
			frequencyHz = 0.0f;
			dampingRatio = 0.0f;
		}
		
		public void Initialize(IntPtr bA, IntPtr bB, Vector2 anchor1, Vector2 anchor2)
		{
			bodyA = bA;
			bodyB = bB;
			API.GetLocalPoint(bodyA, anchor1, out localAnchorA);
			API.GetLocalPoint(bodyB, anchor2, out localAnchorB);
			length = (anchor2-anchor1).magnitude;
		}
	}
}