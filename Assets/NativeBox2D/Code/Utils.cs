using UnityEngine;
using System.Collections;

/// Rotation
public class b2Rot
{
	public b2Rot() {}

	public b2Rot(float angle)
	{
		/// TODO_ERIN optimize
		s = Mathf.Sin(angle);
		c = Mathf.Cos(angle);
	}

	/// Set using an angle in radians.
	public void Set(float angle)
	{
		/// TODO_ERIN optimize
		s = Mathf.Sin(angle);
		c = Mathf.Cos(angle);
	}

	/// Set to the identity rotation
	public void SetIdentity()
	{
		s = 0.0f;
		c = 1.0f;
	}

	/// Get the angle in radians
	public float GetAngle()
	{
		return Mathf.Atan2(s, c);
	}

	/// Get the x-axis
	public Vector2 GetXAxis()
	{
		return new Vector2(c, s);
	}

	/// Get the u-axis
	public Vector2 GetYAxis()
	{
		return new Vector2(-s, c);
	}

	/// Sine and cosine
	public float s, c;
};

/// A transform contains translation and rotation. It is used to represent
/// the position and orientation of rigid frames.
public class b2Transform
{
	/// The default constructor does nothing.
	public b2Transform() {}

	/// Initialize using a position vector and a rotation.
	public b2Transform( Vector2 position, b2Rot rotation )
	{
		p = position;
		q = rotation;
	}

	/// Set this to the identity transform.
	public void SetIdentity()
	{
		p = Vector2.zero;
		q.SetIdentity();
	}

	/// Set this based on the position and angle.
	public void Set(Vector2 position, float angle)
	{
		p = position;
		q.Set(angle);
	}

	public Vector2 p;
	public b2Rot q;
};

public class b2Math
{
	public static Vector2 b2Mul(b2Transform T, Vector2 v)
	{
		float x = (T.q.c * v.x - T.q.s * v.y) + T.p.x;
		float y = (T.q.s * v.x + T.q.c * v.y) + T.p.y;
		return new Vector2(x, y);
	}	
};
