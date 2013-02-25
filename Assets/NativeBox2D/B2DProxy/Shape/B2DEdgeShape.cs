using UnityEngine;
using System.Collections;
using System;
using NativeBox2D;

[AddComponentMenu("NativeBox2D/Shapes/Edge Shape")]
public class B2DEdgeShape : B2DShape
{

    public Vector3 p0;
    public Vector3 p1;

	// Use this for initialization
	protected override IntPtr Create ( ShapeDef def ) 
    {
		Vector3 p00 = p0 + transform.position;
		Vector3 p11 = p1 + transform.position;
        return API.AddEdgeShape(body.body, new Vector2(p00.x, p00.y), new Vector2(p11.x,p11.y), def);
	}
	
    void OnDrawGizmos11()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position + p0, transform.position + p1);
    }	
}
