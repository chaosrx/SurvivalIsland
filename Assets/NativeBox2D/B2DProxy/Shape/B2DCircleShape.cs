using UnityEngine;
using System.Collections;
using System;
using NativeBox2D;

[AddComponentMenu("NativeBox2D/Shapes/Circle Shape")]
public class B2DCircleShape : B2DShape
{

    public float radius = 1;
    public float scale = 1;
    // Use this for initialization
    protected override IntPtr Create( ShapeDef def )
    {
        scale = transform.localScale.x;
        return API.AddCircleShape(body.body, radius*scale, def);
    }

    void OnDrawGizmos11()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius*scale);
    }

}
