using UnityEngine;
using System;
using System.Runtime.InteropServices;

namespace NativeBox2D
{
	[StructLayout (LayoutKind.Sequential, Pack = 4)]
	public struct PulleyJointDef
	{
		[MarshalAs (UnmanagedType.I4)]
		public IntPtr bodyA;
		[MarshalAs (UnmanagedType.I4)]
		public IntPtr bodyB;
		[MarshalAs (UnmanagedType.I1)]
		public bool collideConnected;
		
		public Vector2 groundAnchorA;
		public Vector2 groundAnchorB;
		public Vector2 localAnchorA;
		public Vector2 localAnchorB;
		public float lengthA;
		public float lengthB;
		public float ratio;
		
		public PulleyJointDef(IntPtr bA, IntPtr bB)
		{
			bodyA = bA;
			bodyB = bB;
			collideConnected = true;
			groundAnchorA = new Vector2(-1.0f,1.0f);
			groundAnchorB = new Vector2(1.0f,1.0f);
			localAnchorA = new Vector2(-1.0f,0.0f);
			localAnchorB = new Vector2(1.0f,0.0f);
			lengthA = 0;
			lengthB = 0;
			ratio = 1.0f;
		}
		
		public void Initialize(IntPtr bA, IntPtr bB, Vector2 groundA, Vector2 groundB, Vector2 anchorA, Vector2 anchorB,float r)
		{
			bodyA = bA;
			bodyB = bB;
			groundAnchorA = groundA;
			groundAnchorB = groundB;
			API.GetLocalPoint(bodyA, anchorA, out localAnchorA);
			API.GetLocalPoint(bodyB, anchorB, out localAnchorB);
			lengthA = (anchorA - groundA).magnitude;
			lengthB = (anchorB - groundB).magnitude;
			ratio = r;
		}
	}
}