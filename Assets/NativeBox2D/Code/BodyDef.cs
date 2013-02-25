using UnityEngine;
using System.Runtime.InteropServices;

namespace NativeBox2D
{	
	[StructLayout (LayoutKind.Sequential, Pack = 4)]
	[ System.Serializable]
	public struct BodyDef
	{
		[MarshalAs (UnmanagedType.I1)]
		public BodyType type;
		public Vector2  position;
		public float    angle;
		public Vector2 linearVelocity;
		public float angularVelocity;
		public float linearDamping;
		public float angularDamping;
		[MarshalAs (UnmanagedType.I1)]
		public bool allowSleep;
		[MarshalAs (UnmanagedType.I1)]
		public bool awake;
		[MarshalAs (UnmanagedType.I1)]
		public bool fixedRotation;
		[MarshalAs (UnmanagedType.I1)]
		public bool bullet;
		[MarshalAs (UnmanagedType.I1)]
		public bool active;
		public int userData;
		public float gravityScale;
		
		public BodyDef(BodyType t)
		{
			type = t;
			position = Vector2.zero;
			angle = 0.0f;
			linearVelocity = Vector2.zero;
			angularVelocity = 0.0f;
			linearDamping = 0.0f;
			angularDamping = 0.0f;
			allowSleep = true;
			awake = true;
			fixedRotation = false;
			bullet = false;
			active = true;
			userData = 0;
			gravityScale = 1.0f;			
		}
	}
}