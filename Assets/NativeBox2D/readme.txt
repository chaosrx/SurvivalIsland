NativeBox2D.

NativeBox2D is a native plugin to provide Box2D functions in Unity environment without performance loss,  NativeBox2D integrates Box2D seamlessly into Unity and suppose to be the best 2D physics solution for Unity.

 Among the features provided in NativeBox2D are:

NativeBox2D APIs:
       *  b2World methods support.
       *  b2Body methods support. 
       *  b2Fixture methods support.
       *  all joints methods support.
       *  ContactListener, ContactFilter, QuerryAABB, Raycast callbacks support.

A component based wrapper layer around the APIs:

B2DWorld
        *  A b2World in Unity.

B2DBody
        *  A b2Body in Unity.

B2DBoxShape
B2DCircleShape
B2DPolygonShape
B2DEdgeShapes      
        *  Provide a shape for collision as their names suggest.

DistanceJoint
FrictionJoint
GearJoint
MouseJoint
PrismaticJoint
PulleyJoint
RevoluteJoint
RopeJoint
WeldJoint
WheelJoint
        *  Provide a Bo2D joint as their names suggest.

BeginContact
EndContact
OnFixtureDestroy
OnJointDestroy
       *  Messages sent by NativeBox2D, check Tests/CallbackTest.cs for sample usage.


Please check Example.scene for the basic usage of these components, as well as Testbed.scene for the usage of  NativeBox2D API.

Notice:
      Build for Windows standalone, Mac OSX standalone, Android is as easy as just Buld&Run.
      Build for iOS, please check Plugin/IOS/readme for detail instructions.