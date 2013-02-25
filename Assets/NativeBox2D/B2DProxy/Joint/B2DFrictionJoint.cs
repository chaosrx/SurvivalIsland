using UnityEngine;
using System.Collections;
using System;
using NativeBox2D;

[AddComponentMenu("NativeBox2D/Joints/FrictionJoint")]
public class B2DFrictionJoint : B2DJoint {

    public Vector3 anchor;			
	public float maxForce;
	public float maxTorque;

    // Use this for initialization
    protected override IntPtr Init()
    {
		FrictionJointDef jd = new FrictionJointDef(other.body, body.body);
		jd.Initialize(other.body,body.body,anchor);
		jd.maxForce = maxForce;
		jd.maxTorque = maxTorque;
        return API.CreateFrictionJoint( B2DWorld.instance.world, jd );
    }
}
