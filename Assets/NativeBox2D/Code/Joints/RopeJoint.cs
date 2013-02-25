using UnityEngine;
using System;
using System.Runtime.InteropServices;

namespace NativeBox2D
{
	[StructLayout (LayoutKind.Sequential, Pack = 4)]
	public struct RopeJointDef
	{
		[MarshalAs (UnmanagedType.I4)]
		public IntPtr bodyA;
		[MarshalAs (UnmanagedType.I4)]
		public IntPtr bodyB;
		[MarshalAs (UnmanagedType.I1)]
		public bool collideConnected;
		
		public Vector2 localAnchorA;
		public Vector2 localAnchorB;
		public float maxLength;
		
		public RopeJointDef(IntPtr bA, IntPtr bB)
		{
			bodyA = bA;
			bodyB = bB;
			collideConnected = false;
			localAnchorA = new Vector2(-1.0f,0);
			localAnchorB = new Vector2(1.0f,0);
			maxLength = 0;
		}
	}
}