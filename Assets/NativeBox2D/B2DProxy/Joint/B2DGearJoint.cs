using UnityEngine;
using System.Collections;
using System;
using NativeBox2D;

[AddComponentMenu("NativeBox2D/Joints/GearJoint")]
public class B2DGearJoint : B2DJoint {

	public B2DJoint joint1;
	public B2DJoint joint2;
	public float ratio = 1.0f;

    // Use this for initialization
    protected override IntPtr Init()
    {
        if (!joint1.Started) joint1.Start();
        if (!joint2.Started) joint2.Start();
		
		GearJointDef jd = new GearJointDef(other.body, body.body);
		jd.joint1 = joint1.joint;
		jd.joint2 = joint2.joint;
		jd.ratio = ratio;
        return API.CreateGearJoint( B2DWorld.instance.world, jd );
    }
}
