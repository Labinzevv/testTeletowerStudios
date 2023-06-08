Shader "Custom/CartoonWater"
{
	Properties
	{
		_MainTex("Main Texture", 2D) = "white" {}
		_Speed("Speed", Range(0.1, 5)) = 1.0
		_Amplitude("Amplitude", Range(0.1, 1)) = 0.5
		_Color("Color", Color) = (1, 1, 1, 1)
	}

		SubShader
		{
			Tags { "RenderType" = "Opaque" }

			CGPROGRAM
			#pragma surface surf Lambert

			sampler2D _MainTex;
			float _Speed;
			float _Amplitude;
			fixed4 _Color;

			struct Input
			{
				float2 uv_MainTex;
			};

			void surf(Input IN, inout SurfaceOutput o)
			{
				float2 uv = IN.uv_MainTex + _Time.y * _Speed;
				float2 offset = float2(
					sin(uv.x),
					cos(uv.y)
				) * _Amplitude;
				float4 color = tex2D(_MainTex, IN.uv_MainTex + offset);
				o.Albedo = color.rgb * _Color.rgb;
				o.Alpha = color.a * _Color.a;
			}
			ENDCG
		}

			FallBack "Diffuse"
}