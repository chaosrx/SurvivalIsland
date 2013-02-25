using UnityEngine;
using System.Runtime.InteropServices;
using System;

namespace NativeBox2D
{
	
public class API{
	
#if UNITY_EDITOR || !UNITY_IPHONE
 	public const string pluginName = "NativeBox2D";
#else
	public const string pluginName = "__Internal";
#endif
	public delegate void GL_BEGIN(int mode);
	public delegate void GL_END();
	public delegate void GL_VERTEX3(float x, float y, float z) ;
	public delegate void GL_COLOR4(float r, float g, float b, float a);
	public delegate void GL_DRAWSTRING(float x, float y, string s);
	public delegate bool QUERYCALLBACK( IntPtr b );
	public delegate float RAYCASTCALLBACK(  IntPtr b, Vector2 point, Vector2 normal, float fraction );
	public delegate void CONTACTCALLBACK( IntPtr contact );	
	public delegate bool SHOULDCOLLIDECALLBACK ( IntPtr f1, IntPtr f2 );
	public delegate void DESTRUCTIONCALLBACK( IntPtr j );
		
	#region API Interfaces
	[DllImport(pluginName)]
    public static extern void SetBebugDrawCallbacks(GL_BEGIN begin, GL_END end, GL_VERTEX3 vertex,GL_COLOR4 color,  GL_DRAWSTRING ds);
	[DllImport(pluginName)]
    public static extern void   SetDebugDrawFlags( int flag );
    [DllImport(pluginName)]
    public static extern IntPtr CreateWorld( Vector2 gravity );
    [DllImport(pluginName)]
    public static extern void   DestroyWorld( IntPtr w );
	[DllImport(pluginName)]
    public static extern void   SetDestructionListener( IntPtr w, DESTRUCTIONCALLBACK jdc, DESTRUCTIONCALLBACK fdc  );
	[DllImport(pluginName)]
    public static extern void   SetContactFilter( IntPtr w, SHOULDCOLLIDECALLBACK shouldCollide );	
	[DllImport(pluginName)]
    public static extern void   SetContactListener( IntPtr w, CONTACTCALLBACK begincb, CONTACTCALLBACK endcb  );
	[DllImport(pluginName)]
    public static extern IntPtr CreateBody( IntPtr w, BodyDef def);
    [DllImport(pluginName)]
    public static extern void   DestroyBody( IntPtr w, IntPtr body);
	[DllImport(pluginName)]
    public static extern IntPtr CreateDistanceJoint( IntPtr w, DistanceJointDef def );
    [DllImport(pluginName)]
	public static extern IntPtr CreateFrictionJoint( IntPtr w, FrictionJointDef def);
    [DllImport(pluginName)]
    public static extern IntPtr CreateGearJoint( IntPtr w, GearJointDef def );
    [DllImport(pluginName)]
    public static extern IntPtr CreateMouseJoint( IntPtr w, MouseJointDef def );
    [DllImport(pluginName)]
    public static extern IntPtr CreatePrismaticJoint( IntPtr w, PrismaticJointDef def );
    [DllImport(pluginName)]
    public static extern IntPtr CreatePulleyJoint( IntPtr w, PulleyJointDef def );
    [DllImport(pluginName)]
    public static extern IntPtr CreateRevoluteJoint( IntPtr w, RevoluteJointDef def );
    [DllImport(pluginName)]
    public static extern IntPtr CreateRopeJoint( IntPtr w, RopeJointDef def );
    [DllImport(pluginName)]
    public static extern IntPtr CreateWeldJoint( IntPtr w, WeldJointDef def );    
    [DllImport(pluginName)]
    public static extern IntPtr CreateWheelJoint( IntPtr w, WheelJointDef def ); 
	[DllImport(pluginName)]
    public static extern void DestroyJoint( IntPtr w, IntPtr joint);
    [DllImport(pluginName)]
    public static extern void Step( IntPtr w, float timeStep, int velocityIterations, int positionIterations);
	[DllImport(pluginName)]
    public static extern void ClearForces( IntPtr w );
	[DllImport(pluginName)]
    public static extern void DrawDebugData( IntPtr w );
    [DllImport(pluginName)]
    public static extern void QueryAABB( IntPtr w, Vector2 lowerBound, Vector2 upperBound, QUERYCALLBACK cb );
    [DllImport(pluginName)]
    public static extern void RayCast( IntPtr w, Vector2 point1, Vector2 point2, RAYCASTCALLBACK cb);
	[DllImport(pluginName)]
    public static extern void SetAllowSleeping( IntPtr w, bool flag);
	[DllImport(pluginName)]
    public static extern bool GetAllowSleeping( IntPtr w );
	[DllImport(pluginName)]
    public static extern void SetWarmStarting( IntPtr w ,bool flag);
	[DllImport(pluginName)]
    public static extern bool GetWarmStarting( IntPtr w );
	[DllImport(pluginName)]
    public static extern void SetContinuousPhysics( IntPtr w ,bool flag);
	[DllImport(pluginName)]
    public static extern bool GetContinuousPhysics( IntPtr w );
	[DllImport(pluginName)]
    public static extern void SetSubStepping( IntPtr w ,bool flag);
	[DllImport(pluginName)]
    public static extern bool GetSubStepping( IntPtr w );
	[DllImport(pluginName)]
    public static extern int GetProxyCount( IntPtr w );
	[DllImport(pluginName)]
    public static extern int GetBodyCount( IntPtr w );
 	[DllImport(pluginName)]
    public static extern int GetJointCount( IntPtr w );
	[DllImport(pluginName)]
    public static extern int GetContactCount( IntPtr w );
	[DllImport(pluginName)]
    public static extern int GetTreeHeight( IntPtr w );
 	[DllImport(pluginName)]
    public static extern int GetTreeBalance( IntPtr w );
	[DllImport(pluginName)]
    public static extern float GetTreeQuality( IntPtr w );
	[DllImport(pluginName)]
    public static extern void SetGravity( IntPtr w , Vector2 gravity);
	[DllImport(pluginName)]
    public static extern void GetGravity( IntPtr w, out Vector2 gravity );
	[DllImport(pluginName)]
    public static extern bool IsLocked( IntPtr w );
	[DllImport(pluginName)]
    public static extern void SetAutoClearForces( IntPtr w , bool flag);
	[DllImport(pluginName)]
    public static extern bool GetAutoClearForces( IntPtr w );
		
	//Body
    [DllImport(pluginName)]
    public static extern void  GetPosition( IntPtr b, out Vector2 pos);
	[DllImport(pluginName)]
    public static extern float GetAngle(IntPtr b);
    [DllImport(pluginName)]
    public static extern void  SetTransform(IntPtr b, Vector2 pos, float angle);
	[DllImport(pluginName)]
    public static extern void GetWorldCenter( IntPtr b, out Vector2 worldCenter);
	[DllImport(pluginName)]
    public static extern void GetLocalCenter( IntPtr b, out Vector2 localCenter);
    [DllImport(pluginName)]
    public static extern void SetLinearVelocity( IntPtr b, Vector2 v);
	[DllImport(pluginName)]
    public static extern void GetLinearVelocity( IntPtr b, out Vector2 v );
	[DllImport(pluginName)]
    public static extern void SetAngularVelocity( IntPtr b, float omega);
	[DllImport(pluginName)]
    public static extern float GetAngularVelocity( IntPtr b );
    [DllImport(pluginName)]
    public static extern void ApplyForce( IntPtr b, Vector2 force, Vector2 point );
    [DllImport(pluginName)]
    public static extern void ApplyForceToCenter( IntPtr b, Vector2 force );
    [DllImport(pluginName)]
    public static extern void ApplyTorque( IntPtr b, float torque);
    [DllImport(pluginName)]
    public static extern void ApplyLinearImpulse( IntPtr b, Vector2 impulse, Vector2 point);
    [DllImport(pluginName)]
    public static extern void ApplyAngularImpulse( IntPtr b, float impulse);
	[DllImport(pluginName)]
    public static extern float GetMass( IntPtr b );
	[DllImport(pluginName)]
    public static extern float GetInertia( IntPtr b );
    [DllImport(pluginName)]
    public static extern void ResetMassData( IntPtr b );
	[DllImport(pluginName)]
    public static extern void GetWorldPoint( IntPtr b, Vector2 localPoint, out Vector2 worldPoint);
	[DllImport(pluginName)]
    public static extern void GetWorldVector( IntPtr b, Vector2 localVector, out Vector2 worldVector);
  	[DllImport(pluginName)]
    public static extern void GetLocalPoint( IntPtr b, Vector2 worldPoint, out Vector2 localPoint);
	[DllImport(pluginName)]
    public static extern void GetLocalVector( IntPtr b, Vector2 worldVector, out Vector2 localVector);
    [DllImport(pluginName)]
    public static extern void GetLinearVelocityFromWorldPoint( IntPtr b, Vector2 worldPoint, out Vector2 linearVelocity );
	[DllImport(pluginName)]
    public static extern void GetLinearVelocityFromLocalPoint( IntPtr b , Vector2 localPoint, out Vector2 linearVelocity );
	[DllImport(pluginName)]
    public static extern float GetLinearDamping( IntPtr b );
	[DllImport(pluginName)]
    public static extern void SetLinearDamping( IntPtr b , float linearDamping);
	[DllImport(pluginName)]
    public static extern float GetAngularDamping( IntPtr b );
	[DllImport(pluginName)]
    public static extern void SetAngularDamping( IntPtr b , float angularDamping);
	[DllImport(pluginName)]
    public static extern float GetGravityScale( IntPtr b );
	[DllImport(pluginName)]
    public static extern void SetGravityScale( IntPtr b , float scale);
	[DllImport(pluginName)]
    public static extern void SetType( IntPtr b , int type);
	[DllImport(pluginName)]
    public static extern int GetType( IntPtr b );
	[DllImport(pluginName)]
    public static extern bool IsBullet( IntPtr b );
	[DllImport(pluginName)]
    public static extern void SetSleepingAllowed( IntPtr b , bool flag);
	[DllImport(pluginName)]
    public static extern bool IsSleepingAllowed( IntPtr b );
	[DllImport(pluginName)]
    public static extern void SetAwake( IntPtr b , bool flag);
	[DllImport(pluginName)]
    public static extern bool IsAwake( IntPtr b );
	[DllImport(pluginName)]
    public static extern void SetActive( IntPtr b , bool flag);
	[DllImport(pluginName)]
    public static extern bool IsActive( IntPtr b );
	[DllImport(pluginName)]
    public static extern void SetFixedRotation( IntPtr b , bool flag);
	[DllImport(pluginName)]
    public static extern bool IsFixedRotation( IntPtr b );
    [DllImport(pluginName)]
    public static extern IntPtr GetWorld( IntPtr b );
	//

	[DllImport(pluginName)]
    public static extern IntPtr AddPolygonShape( IntPtr b, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex=1)] Vector2[] v, int len, ShapeDef p );
    [DllImport(pluginName)]
    public static extern IntPtr AddBoxShape(IntPtr b, float w, float h, Vector2 center, float angle, ShapeDef p );
    [DllImport(pluginName)]
    public static extern IntPtr AddCircleShape(IntPtr b, float r, ShapeDef p );
    [DllImport(pluginName)]
    public static extern IntPtr AddEdgeShape(IntPtr b, Vector2 p0, Vector2 p1, ShapeDef p );
    [DllImport(pluginName)]
    public static extern void DestroyShape(IntPtr b, IntPtr f);
		    
	//Fixture
	[DllImport(pluginName)]
    public static extern void SetSensor( IntPtr s, bool sensor);
	[DllImport(pluginName)]
    public static extern bool IsSensor( IntPtr s );
	[DllImport(pluginName)]
    public static extern void SetFilterData( IntPtr s, int categoryBits, int maskBits, int groupIndex);
	[DllImport(pluginName)]
    public static extern void GetFilterData( IntPtr s, out int categoryBits, out int maskBits, out int groupIndex );
	[DllImport(pluginName)]
    public static extern void Refilter( IntPtr s );
	[DllImport(pluginName)]
    public static extern IntPtr GetBody( IntPtr s );
	[DllImport(pluginName)]
    public static extern bool TestPoint( IntPtr s, Vector2 p);
	[DllImport(pluginName)]
    public static extern bool RayCastShape( IntPtr s, int childIndex, Vector2 p1, Vector2 p2, float maxFraction,
                 out Vector2 normal, out float fraction);
	[DllImport(pluginName)]
    public static extern void SetDensity( IntPtr s, float density);
	[DllImport(pluginName)]
    public static extern float GetDensity( IntPtr s );
	[DllImport(pluginName)]
    public static extern float GetFriction( IntPtr s );
	[DllImport(pluginName)]
    public static extern void SetFriction( IntPtr s, float friction);
	[DllImport(pluginName)]
    public static extern float GetRestitution( IntPtr s );
	[DllImport(pluginName)]
    public static extern void SetRestitution( IntPtr s, float restitution);
	[DllImport(pluginName)]
    public static extern void GetAABB( IntPtr s, int childIndex, out Vector2 lowerBound, out Vector2 upperBound);
	//Joint
    [DllImport(pluginName)]
    public static extern int JointGetType( IntPtr j );
    [DllImport(pluginName)]
    public static extern IntPtr JointGetBodyA( IntPtr j );
    [DllImport(pluginName)]
    public static extern IntPtr JointGetBodyB( IntPtr j );
    [DllImport(pluginName)]
    public static extern void JointGetAnchorA( IntPtr j, out Vector2 anchorA );
    [DllImport(pluginName)]
    public static extern void JointGetAnchorB( IntPtr j, out Vector2 anchorB );
    [DllImport(pluginName)]
    public static extern void JointGetReactionForce( IntPtr j, float inv_dt, out Vector2 force );
    [DllImport(pluginName)]
    public static extern float JointGetReactionTorque( IntPtr j, float inv_dt  );
    [DllImport(pluginName)]
    public static extern bool JointIsActive( IntPtr j );
    [DllImport(pluginName)]
    public static extern bool JointGetCollideConnected( IntPtr j );
		
	//DistanceJoint
    [DllImport(pluginName)]
    public static extern void DistanceJointGetLocalAnchorA( IntPtr j, out Vector2 anchorA );
    [DllImport(pluginName)]
    public static extern void DistanceJointGetLocalAnchorB( IntPtr j, out Vector2 anchorB );
    [DllImport(pluginName)]
    public static extern void DistanceJointSetLength( IntPtr j, float length);
	[DllImport(pluginName)]
    public static extern float DistanceJointGetLength( IntPtr j );
	[DllImport(pluginName)]
    public static extern void DistanceJointSetFrequency( IntPtr j , float hz);
	[DllImport(pluginName)]
    public static extern float DistanceJointGetFrequency( IntPtr j );
	[DllImport(pluginName)]
    public static extern void DistanceJointSetDampingRatio( IntPtr j, float ratio);
	[DllImport(pluginName)]
    public static extern float DistanceJointGetDampingRatio( IntPtr j );
	
	//FrictionJoint
    [DllImport(pluginName)]
    public static extern void FrictionJointGetLocalAnchorA( IntPtr j, out Vector2 anchorA );
    [DllImport(pluginName)]
    public static extern void FrictionJointGetLocalAnchorB( IntPtr j, out Vector2 anchorB );
	[DllImport(pluginName)]
    public static extern void FrictionJointSetMaxForce( IntPtr j , float force);
	[DllImport(pluginName)]
    public static extern float FrictionJointGetMaxForce( IntPtr j );
	[DllImport(pluginName)]
    public static extern void FrictionJointSetMaxTorque( IntPtr j , float torque);
	[DllImport(pluginName)]
    public static extern float FrictionJointGetMaxTorque( IntPtr j );
		
	//GearJoint
	[DllImport(pluginName)]
    public static extern IntPtr GearJointGetJoint1( IntPtr j );
	[DllImport(pluginName)]
    public static extern IntPtr GearJointGetJoint2( IntPtr j );
	[DllImport(pluginName)]
    public static extern void GearJointSetRatio( IntPtr j , float ratio);
	[DllImport(pluginName)]
    public static extern float GearJointGetRatio( IntPtr j );
	
	//MouseJoint
	[DllImport(pluginName)]
    public static extern void MouseJointSetTarget( IntPtr j, Vector2 target);
	[DllImport(pluginName)]
    public static extern void MouseJointGetTarget( IntPtr j, out Vector2 target );
	[DllImport(pluginName)]
    public static extern void MouseJointSetMaxForce( IntPtr j , float force);
	[DllImport(pluginName)]
    public static extern float MouseJointGetMaxForce( IntPtr j );
	[DllImport(pluginName)]
    public static extern void MouseJointSetFrequency( IntPtr j , float hz);
	[DllImport(pluginName)]
    public static extern float MouseJointGetFrequency( IntPtr j );
	[DllImport(pluginName)]
    public static extern void MouseJointSetDampingRatio( IntPtr j, float ratio);
	[DllImport(pluginName)]
    public static extern float MouseJointGetDampingRatio( IntPtr j );
		
	//PrismaticJoint    
    [DllImport(pluginName)]
    public static extern void PrismaticJointGetLocalAnchorA( IntPtr j, out Vector2 anchorA );
    [DllImport(pluginName)]
    public static extern void PrismaticJointGetLocalAnchorB( IntPtr j, out Vector2 anchorB );
    [DllImport(pluginName)]
    public static extern void PrismaticJointGetLocalAxisA( IntPtr j, out Vector2 localAxisA );
    [DllImport(pluginName)]
    public static extern float PrismaticJointGetReferenceAngle( IntPtr j );
    [DllImport(pluginName)]
    public static extern float PrismaticJointGetJointTranslation( IntPtr j );
    [DllImport(pluginName)]
    public static extern float PrismaticJointGetJointSpeed( IntPtr j );
    [DllImport(pluginName)]
    public static extern bool PrismaticJointIsLimitEnabled( IntPtr j );
    [DllImport(pluginName)]
    public static extern void PrismaticJointEnableLimit( IntPtr j , bool flag );
    [DllImport(pluginName)]
    public static extern float PrismaticJointGetLowerLimit( IntPtr j );
    [DllImport(pluginName)]
    public static extern float PrismaticJointGetUpperLimit( IntPtr j );
    [DllImport(pluginName)]
    public static extern void PrismaticJointSetLimits( IntPtr j , float lower, float upper );
    [DllImport(pluginName)]
    public static extern bool PrismaticJointIsMotorEnabled( IntPtr j );
    [DllImport(pluginName)]
    public static extern void PrismaticJointEnableMotor( IntPtr j , bool flag );
    [DllImport(pluginName)]
    public static extern void PrismaticJointSetMotorSpeed( IntPtr j, float speed );
    [DllImport(pluginName)]
    public static extern float PrismaticJointGetMotorSpeed( IntPtr j );
    [DllImport(pluginName)]
    public static extern void PrismaticJointSetMaxMotorForce( IntPtr j, float force );
    [DllImport(pluginName)]
    public static extern float PrismaticJointGetMaxMotorForce( IntPtr j );
    [DllImport(pluginName)]
    public static extern float PrismaticJointGetMotorForce( IntPtr j , float inv_dt );
			
	//PulleyJoint
    [DllImport(pluginName)]
    public static extern void PulleyJointGetGroundAnchorA( IntPtr j, out Vector2 groundAnchorA );
    [DllImport(pluginName)]
    public static extern void PulleyJointGetGroundAnchorB( IntPtr j, out Vector2 groundAnchorB );
    [DllImport(pluginName)]
    public static extern float PulleyJointGetLengthA( IntPtr j );
    [DllImport(pluginName)]
    public static extern float PulleyJointGetLengthB( IntPtr j );
    [DllImport(pluginName)]
    public static extern float PulleyJointGetRatio( IntPtr j );

	//RevoluteJoint
	[DllImport(pluginName)]
    public static extern void RevoluteJointGetLocalAnchorA( IntPtr j, out Vector2 localAnchorA );
    [DllImport(pluginName)]
    public static extern void RevoluteJointGetLocalAnchorB( IntPtr j, out Vector2 localAnchorB );
    [DllImport(pluginName)]
    public static extern float RevoluteJointGetReferenceAngle( IntPtr j );
    [DllImport(pluginName)]
    public static extern float RevoluteJointGetJointAngle( IntPtr j );
    [DllImport(pluginName)]
    public static extern float RevoluteJointGetJointSpeed( IntPtr j );
    [DllImport(pluginName)]
    public static extern bool RevoluteJointIsLimitEnabled( IntPtr j );
    [DllImport(pluginName)]
    public static extern void RevoluteJointEnableLimit( IntPtr j , bool flag );
    [DllImport(pluginName)]
    public static extern float RevoluteJointGetLowerLimit( IntPtr j );
    [DllImport(pluginName)]
    public static extern float RevoluteJointGetUpperLimit( IntPtr j );
    [DllImport(pluginName)]
    public static extern void RevoluteJointSetLimits( IntPtr j , float lower, float upper );
    [DllImport(pluginName)]
    public static extern bool RevoluteJointIsMotorEnabled( IntPtr j );
    [DllImport(pluginName)]
    public static extern void RevoluteJointEnableMotor( IntPtr j , bool flag );
    [DllImport(pluginName)]
    public static extern void RevoluteJointSetMotorSpeed( IntPtr j, float speed );
    [DllImport(pluginName)]
    public static extern float RevoluteJointGetMotorSpeed( IntPtr j );
    [DllImport(pluginName)]
    public static extern void RevoluteJointSetMaxMotorTorque( IntPtr j, float torque );
    [DllImport(pluginName)]
    public static extern float RevoluteJointGetMaxMotorTorque( IntPtr j );
    [DllImport(pluginName)]
    public static extern float RevoluteJointGetMotorTorque( IntPtr j , float inv_dt );
		
	//RopeJoint
	[DllImport(pluginName)]
    public static extern void RopeJointGetLocalAnchorA( IntPtr j, out Vector2 localAnchorA );
    [DllImport(pluginName)]
    public static extern void RopeJointGetLocalAnchorB( IntPtr j, out Vector2 localAnchorB );
    [DllImport(pluginName)]
    public static extern void RopeJointSetMaxLength( IntPtr j, float maxLength );
    [DllImport(pluginName)]
    public static extern float RopeJointGetMaxLength( IntPtr j );
    [DllImport(pluginName)]
    public static extern int RopeJointGetLimitState( IntPtr j );

	//WeldJoint
	[DllImport(pluginName)]
    public static extern void WeldJointGetLocalAnchorA( IntPtr j, out Vector2 localAnchorA );
    [DllImport(pluginName)]
    public static extern void WeldJointGetLocalAnchorB( IntPtr j, out Vector2 localAnchorB );
    [DllImport(pluginName)]
    public static extern float WeldJointGetReferenceAngle( IntPtr j );
    [DllImport(pluginName)]
    public static extern void WeldJointSetFrequency( IntPtr j, float hz );
    [DllImport(pluginName)]
    public static extern float WeldJointGetFrequency( IntPtr j );
    [DllImport(pluginName)]
    public static extern void WeldJointSetDampingRatio( IntPtr j, float ratio );
    [DllImport(pluginName)]
    public static extern float WeldJointGetDampingRatio( IntPtr j );
	//WheelJoint
	[DllImport(pluginName)]
    public static extern void WheelJointGetLocalAnchorA( IntPtr j, out Vector2 localAnchorA );
    [DllImport(pluginName)]
    public static extern void WheelJointGetLocalAnchorB( IntPtr j, Vector2 localAnchorB );
    [DllImport(pluginName)]
    public static extern void WheelJointGetLocalAxisA( IntPtr j, Vector2 localAxisA );
	[DllImport(pluginName)]
    public static extern float WheelJointGetJointTranslation( IntPtr j );
    [DllImport(pluginName)]
    public static extern float WheelJointGetJointSpeed( IntPtr j );
    [DllImport(pluginName)]
    public static extern bool WheelJointIsMotorEnabled( IntPtr j );
    [DllImport(pluginName)]
    public static extern void WheelJointEnableMotor( IntPtr j , bool flag );
    [DllImport(pluginName)]
    public static extern void WheelJointSetMotorSpeed( IntPtr j, float speed );
    [DllImport(pluginName)]
    public static extern float WheelJointGetMotorSpeed( IntPtr j );
    [DllImport(pluginName)]
    public static extern void WheelJointSetMaxMotorTorque( IntPtr j, float torque );
    [DllImport(pluginName)]
    public static extern float WheelJointGetMaxMotorTorque( IntPtr j );
    [DllImport(pluginName)]
    public static extern void WheelJointSetSpringFrequencyHz( IntPtr j, float hz );
    [DllImport(pluginName)]
    public static extern float WheelJointGetSpringFrequencyHz( IntPtr j );
    [DllImport(pluginName)]
    public static extern void WheelJointSetSpringDampingRatio( IntPtr j, float ratio );
    [DllImport(pluginName)]
    public static extern float WheelJointGetSpringDampingRatio( IntPtr j );
	//
	
	#endregion

    public static IntPtr CreateBody( IntPtr w, Vector2 pos, float angle, BodyType type)
	{
		BodyDef bd = new BodyDef(type);
		bd.position = pos;
		bd.angle = angle;
		return CreateBody(w,bd);
	}
	
	public static void InitDebugDraw( int flag )
	{
		API.SetBebugDrawCallbacks(
			new API.GL_BEGIN(GL_Begin),
			new API.GL_END(GL_End),
            new API.GL_VERTEX3(GL_Vertex3),
            new API.GL_COLOR4(GL_Color4),
			new API.GL_DRAWSTRING(GL_DrawString));

		API.SetDebugDrawFlags(flag);
	}
		
	public static void CreateContactListener( IntPtr world,  GameObject listener )
	{
		contactListener = listener;
        
		API.SetContactListener(world, 
				new API.CONTACTCALLBACK( BeginContact ),
				new API.CONTACTCALLBACK( EndContact ));
	}
		
	public static void CreateDestructionListener( IntPtr world,  GameObject listener )
	{
		destructionListener = listener;
		API.SetDestructionListener(world, 
				new API.DESTRUCTIONCALLBACK( JointDestruction ),
				new API.DESTRUCTIONCALLBACK( FixtureDestruction ));
	}
		
	/*
	 * example usage:
	 * 
	    	[API.MonoPInvokeCallback (typeof (API.SHOULDCOLLIDECALLBACK))]
			public static bool ShouldCollide(  IntPtr f1, IntPtr f2 )
			{
				return true;
			}
			
			API.CreateContactFilter( world, new API.SHOULDCOLLIDECALLBACK( ShouldCollide ) );
	*/
	public static void CreateContactFilter( IntPtr world,  API.SHOULDCOLLIDECALLBACK cb )
	{
		API.SetContactFilter(world, cb );
	}

    public class MonoPInvokeCallbackAttribute : System.Attribute
    {
        private Type type;
        public MonoPInvokeCallbackAttribute(Type t) { type = t; }
    }

	public static IntPtr bodyUnderMouse;
	public static GameObject contactListener;
	public static GameObject contactFilter;
	public static GameObject destructionListener;
		
	[MonoPInvokeCallback (typeof (API.QUERYCALLBACK))]
	public static bool QueryCallbackFunc( IntPtr b )
	{
		bodyUnderMouse = b;
		return true;
	}
	
	[MonoPInvokeCallback (typeof (API.GL_BEGIN))]
	public static void GL_Begin( int mode )
	{
		GL.Begin(mode);
	}
		
	[MonoPInvokeCallback (typeof (API.GL_END))]
	public static void GL_End( )
	{
		GL.End();
	}
		
	[MonoPInvokeCallback (typeof (API.GL_VERTEX3))]
	public static void GL_Vertex3( float x, float y, float z )
	{
        GL.Vertex3(x,y,z);
	}
		
	[MonoPInvokeCallback (typeof (API.GL_COLOR4))]
	public static void GL_Color4( float r, float g, float b, float a)
	{       
		GL.Color(new Color(r,g,b,a));
	}

	[MonoPInvokeCallback (typeof (API.GL_DRAWSTRING))]
	public static void GL_DrawString( float x, float y,  string s )
	{
	}
		
	[MonoPInvokeCallback (typeof (API.CONTACTCALLBACK))]
	public static void BeginContact(  IntPtr contact )
	{
		if( contactListener )
			contactListener.SendMessage( "BeginContact", contact );
	}
		
	[MonoPInvokeCallback (typeof (API.CONTACTCALLBACK))]
	public static void EndContact(  IntPtr contact )
	{
		if( contactListener )
			contactListener.SendMessage( "EndContact", contact );
	}	
		
	[MonoPInvokeCallback (typeof (API.DESTRUCTIONCALLBACK))]
	public static void JointDestruction(  IntPtr joint )
	{
		if( destructionListener )
			destructionListener.SendMessage( "OnJointDestroy", joint );
	}
		
	[MonoPInvokeCallback (typeof (API.DESTRUCTIONCALLBACK))]
	public static void FixtureDestruction(  IntPtr fixture )
	{
		if( destructionListener )
			destructionListener.SendMessage( "OnFixtureDestroy", fixture );
	}		
		
#if UNITY_EDITOR && UNITY_STANDALONE_WIN
    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    static extern IntPtr GetModuleHandle(string moduleName);
    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool FreeLibrary(IntPtr hModule); 
#endif

#if UNITY_EDITOR && UNITY_STANDALONE_WIN
    public static void UnloadPlugin()
    {
        IntPtr h = GetModuleHandle(pluginName);
        while ( FreeLibrary(h) )
        {
        }
    }
#endif
}

}