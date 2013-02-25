using UnityEngine;
using System.Collections;
using System;
using NativeBox2D;

public class DebugDraw : MonoBehaviour {

	static Material lineMaterial;
	
	public static IntPtr world;
	
	static void CreateLineMaterial() {
	    if( !lineMaterial ) 
		{
	        lineMaterial = new Material( "Shader \"Lines/Colored Blended\" {" +
	            "SubShader { Pass { " +
	            "    Blend SrcAlpha OneMinusSrcAlpha " +
	            "    ZWrite Off Cull Off Fog { Mode Off } " +
	            "    BindChannels {" +
	            "      Bind \"vertex\", vertex Bind \"color\", color }" +
	            "} } }" );
	        lineMaterial.hideFlags = HideFlags.HideAndDontSave;
	        lineMaterial.shader.hideFlags = HideFlags.HideAndDontSave;
	    }
	}
	
	void Start()
	{
		API.InitDebugDraw(3);
		if( B2DWorld.instance )
			world = B2DWorld.instance.world;
	}
	
	void OnPostRender()
	{
		CreateLineMaterial();
		lineMaterial.SetPass(0);
		API.DrawDebugData(world);
	}
}
