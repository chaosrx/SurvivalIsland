using UnityEngine;
using System.Collections;
using System;
using NativeBox2D;

[AddComponentMenu("NativeBox2D/Joints/RevoluteJoint")]
public class B2DRevoluteJoint : B2DJoint {
	
	public Vector3 anchor;			
	public bool enableLimit;
	public float lowerAngle;
	public float upperAngle;			
	public bool enableMotor;
	public float motorSpeed;
	public float maxMotorTorque;

    // Use this for initialization
    protected override IntPtr Init()
    {
		Vector3 a = anchor;
		RevoluteJointDef def = new RevoluteJointDef(other.body, body.body);
		def.collideConnected = collideConnected;
		def.Initialize(other.body, body.body, new Vector2(a.x,a.y));
		def.enableLimit = enableLimit;
		def.lowerAngle = lowerAngle;
		def.upperAngle = upperAngle;
		def.enableMotor = enableMotor;
		def.motorSpeed = motorSpeed;
		def.maxMotorTorque = maxMotorTorque;
        return API.CreateRevoluteJoint(B2DWorld.instance.world, def);
    }
}
