using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(B2DBody))]
public class B2DJoint : MonoBehaviour {

    public B2DBody other;
    public bool collideConnected = true;
    [HideInInspector]
    public B2DBody body;
	[HideInInspector]
    public IntPtr joint;
    public bool Started { get { return started; } }
    bool started = false;

    public void Awake()
    {
        body = GetComponent<B2DBody>();
    }

    // Use this for initialization
	public void Start () {
        if (started) return;
        started = true;

        if ( other )
		{
			if(!other.Started) other.Start();

	        B2DJoint[] joints = other.GetComponents<B2DJoint>();
	        foreach (B2DJoint j in joints)
	        {
	            j.Start();
	        }
		}
		
		if (!body.Started) body.Start();

        joint = Init();
	}

    protected virtual IntPtr Init()
    {
        return IntPtr.Zero;
    }
}
