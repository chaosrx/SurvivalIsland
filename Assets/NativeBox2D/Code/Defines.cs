namespace NativeBox2D
{
    public enum BodyType
    {
        STATIC_BODY = 0,
        KINEMATIC_BODY,
        DYNAMIC_BODY
    };
	
	public enum JointType
	{
		UNKNOWNJOINT=0,
		REVOLUTEJOINT,
		PRISMATICJOINT,
		DISTANCEJOINT,
		PULLEYJOINT,
		MOUSEJOINT,
		GEARJOINT,
		WHEELJOINT,
	    WELDJOINT,
		FRICTIONJOINT,
		ROPEJOINT		
	};
}