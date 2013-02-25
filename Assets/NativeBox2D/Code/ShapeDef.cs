using UnityEngine;
using System.Runtime.InteropServices;

namespace NativeBox2D
{
	[StructLayout (LayoutKind.Sequential, Pack = 4)]
	public struct ShapeDef
	{
	    public float density;
	    public float restitution;
	    public float friction;
		[MarshalAs (UnmanagedType.I1)]
	    public bool  sensor;
	    public int   catogoryBits;
	    public int   maskBits;
	    public int   groupIndex;

		public ShapeDef(float density_ )
		{
			density = density_;
			restitution = 0.0f;
			friction = 0.2f;
			sensor = false;
			catogoryBits = 0x0001;
			maskBits = 0xFFFF;
			groupIndex = 0;
		}
	}
}