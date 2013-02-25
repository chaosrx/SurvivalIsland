using UnityEngine;
using System.Collections;
using System;
using NativeBox2D;

[AddComponentMenu("NativeBox2D/Shapes/Box Shape")]
public class B2DBoxShape : B2DShape
{
    public float width =  1;
    public float height = 1;
    public Vector3 center;
    public float angle = 0;
    Vector3 scale;
    // Use this for initialization
    protected override IntPtr Create( ShapeDef def )
    {
        scale = transform.localScale;

        return API.AddBoxShape(body.body, width*scale.x, height*scale.y, new Vector2(center.x,center.y), angle, def);
    }

    void OnDrawGizmos11()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position + center, new Vector3(width * scale.x, height * scale.y, 1));
    }
}
