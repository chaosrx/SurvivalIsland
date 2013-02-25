using UnityEngine;
using System.Collections;
using System;
using NativeBox2D;

[RequireComponent(typeof(B2DBody))]
public class B2DShape : MonoBehaviour {
	
	[HideInInspector]
    public B2DBody body;
    IntPtr fixture;
		   
	public float density = 1.0f;
    public float restitution = 0.0f;
    public float friction = 0.2f;
    public bool  sensor = false;
    public int   catogoryBits = 1;
    public int   maskBits = 0xFFFF;
    public int   groupIndex = 0;

    public bool Started { get { return started; } }
    bool started = false;

    void Awake()
    {
        body = GetComponent<B2DBody>();
    }

	// Use this for initialization
	public void Start () {
        if (started) return;
        started = true;

        if (!body.Started) body.Start();
    
		ShapeDef def = new ShapeDef(density);
		def.restitution = restitution;
		def.friction = friction;
		def.sensor = sensor;
		def.catogoryBits = catogoryBits;
		def.maskBits = def.maskBits;
		def.groupIndex = def.groupIndex;

        fixture = Create( def );        
	}

    protected virtual IntPtr Create( ShapeDef def )
    {
        return IntPtr.Zero;
    }
}
