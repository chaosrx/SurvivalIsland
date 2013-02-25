using UnityEngine;
using System;
using System.Runtime.InteropServices;

namespace NativeBox2D
{
	[StructLayout (LayoutKind.Sequential, Pack = 4)]
	public struct GearJointDef
	{
		[MarshalAs (UnmanagedType.I4)]
		public IntPtr bodyA;
		[MarshalAs (UnmanagedType.I4)]
		public IntPtr bodyB;
		[MarshalAs (UnmanagedType.I1)]
		public bool collideConnected;
		
		[MarshalAs (UnmanagedType.I4)]
		public IntPtr joint1;
		[MarshalAs (UnmanagedType.I4)]
		public IntPtr joint2;
		public float ratio;
		
		public GearJointDef(IntPtr bA, IntPtr bB)
		{
			bodyA = bA;
			bodyB = bB;
			collideConnected = false;
			joint1 = IntPtr.Zero;
			joint2 = IntPtr.Zero;
			ratio = 1.0f;
		}
	}
}