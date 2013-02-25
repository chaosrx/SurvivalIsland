using UnityEngine;
using System.Collections;
using System;
using NativeBox2D;

[AddComponentMenu("NativeBox2D/Shapes/Polygon Shape")]
public class B2DPolygonShape : B2DShape
{
    public Transform[] vertexTransform;
	public bool destroyTransform = true;
    // Use this for initialization
    protected override IntPtr Create( ShapeDef def )
    {
        Vector2[] vs = new Vector2[vertexTransform.Length];
		for(int i=0; i<vs.Length; ++i)
			vs[i] = new Vector2( vertexTransform[i].localPosition.x, vertexTransform[i].localPosition.y );
		
		if( destroyTransform )
		{
			for(int i=0; i<vertexTransform.Length; ++i)
			{
				Destroy( vertexTransform[i].gameObject );
			}
		}
		
		return API.AddPolygonShape(body.body, vs, vs.Length, def);
    }
}
