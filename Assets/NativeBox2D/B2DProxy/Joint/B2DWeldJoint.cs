using UnityEngine;
using System.Collections;
using System;
using NativeBox2D;

[AddComponentMenu("NativeBox2D/Joints/WeldJoint")]
public class B2DWeldJoint : B2DJoint {

    public Vector3 anchor;
	public float frequencyHz;
	public float dampingRatio;

    // Use this for initialization
    protected override IntPtr Init()
    {
		WeldJointDef jd = new WeldJointDef(other.body, body.body);
		jd.Initialize(other.body,body.body,anchor);
		jd.frequencyHz = frequencyHz;
		jd.dampingRatio = dampingRatio;
        return API.CreateWeldJoint( B2DWorld.instance.world, jd );
    }
}
