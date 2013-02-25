using UnityEngine;
using System.Collections;
using System;
using NativeBox2D;

[AddComponentMenu("NativeBox2D/Joints/PulleyJoint")]
public class B2DPulleyJoint : B2DJoint {

	public Vector3 groundAnchorA = new Vector2(-1,1);
	public Vector3 groundAnchorB = new Vector2(1,1);
	public Vector3 anchorA;
	public Vector3 anchorB;
	public float ratio = 1.0f;

    // Use this for initialization
    protected override IntPtr Init()
    {
		PulleyJointDef jd = new PulleyJointDef(other.body, body.body);
		jd.Initialize(other.body,body.body, groundAnchorA, groundAnchorB, anchorA, anchorB, ratio);
        return API.CreatePulleyJoint( B2DWorld.instance.world, jd );
    }
}
