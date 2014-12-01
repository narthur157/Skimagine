////C# Example
//using UnityEditor;
//using UnityEngine;
//
//public class HillMaker : EditorWindow
//{
////	string myString = "Hello World";
////	bool groupEnabled;
////	bool myBool = true;
////	float myFloat = 1.23f;
//	
//	// Add menu item named "My Window" to the Window menu
//	[MenuItem("Window/Hill Generator")]
//	public static void ShowWindow()
//	{
//		//Show existing window instance. If one doesn't exist, make one.
//		EditorWindow.GetWindow(typeof(HillMaker));
//	}
//	// shamelessly stolen from benk0913 on unity answers
//	public void CreateHill(int x, int y, float height,float pointyness)
//	{
//		float point = 0;
//		float distanceFromTop;
//		
//		terrainGRID[x,y]=height;
//		
//		for(int a=0;a<513;a++)
//		{    
//			for(int b=0;b<513;b++)
//			{
//				distanceFromTop=Mathf.Sqrt(   Mathf.Pow((y-b),2)  +  Mathf.Pow((x-a),2)   );
//				point=((height-terrainGRID[a,b])*1000 - distanceFromTop*pointyness)/1000 ;
//				
//				if(point<0)
//					point=0;
//				
//				terrainGRID[a,b]+=point;
//			}
//		}
//	}
//	// shamelessly stolen from tnetennba on unity answers
//	private void Smooth()
//	{
//		
//		float[,] height = terrain.terrainData.GetHeights(0, 0, terrain.terrainData.heightmapWidth,
//		                                                 terrain.terrainData.heightmapHeight);
//		float k = 0.5f;
//		/* Rows, left to right */
//		for (int x = 1; x < terrain.terrainData.heightmapWidth; x++)
//			for (int z = 0; z < terrain.terrainData.heightmapHeight; z++)
//				height[x, z] = height[x - 1, z] * (1 - k) +
//					height[x, z] * k;
//		
//		/* Rows, right to left*/
//		for (int x = terrain.terrainData.heightmapWidth - 2; x < -1; x--)
//			for (int z = 0; z < terrain.terrainData.heightmapHeight; z++)
//				height[x, z] = height[x + 1, z] * (1 - k) +
//					height[x, z] * k;
//		
//		/* Columns, bottom to top */
//		for (int x = 0; x < terrain.terrainData.heightmapWidth; x++)
//			for (int z = 1; z < terrain.terrainData.heightmapHeight; z++)
//				height[x, z] = height[x, z - 1] * (1 - k) +
//					height[x, z] * k;
//		
//		/* Columns, top to bottom */
//		for (int x = 0; x < terrain.terrainData.heightmapWidth; x++)
//			for (int z = terrain.terrainData.heightmapHeight; z < -1; z--)
//				height[x, z] = height[x, z + 1] * (1 - k) +
//					height[x, z] * k;
//		
//		terrain.terrainData.SetHeights(0, 0, height);
//	}
//	void OnGUI()
//	{
//		GUILayout.Label ("Let's make some hills", EditorStyles.boldLabel);
////		myString = EditorGUILayout.TextField ("Text Field", myString);
//		CreateHill(Random.Range(0,513),Random.Range(0,513),Random.Range(0.005f,0.1f),Random.Range(1f,10f));
////		groupEnabled = EditorGUILayout.BeginToggleGroup ("Optional Settings", groupEnabled);
////		myBool = EditorGUILayout.Toggle ("Toggle", myBool);
////		myFloat = EditorGUILayout.Slider ("Slider", myFloat, -3, 3);
////		EditorGUILayout.EndToggleGroup ();
//	}
//}