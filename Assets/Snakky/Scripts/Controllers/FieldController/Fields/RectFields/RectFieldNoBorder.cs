using UnityEngine;
using System.Collections;

namespace Snakyy
{
	public class RectFieldNoBorder : BaseRectField {
		
		public RectFieldNoBorder(int screenWidth, int screenHeight) : base(screenWidth, screenHeight){
			
		}
		
		public override void create()
		{
			Debug.Log("srart to create RectFieldNoBorder");
			createBackground();
			Debug.Log("RectFieldNoBorder created");
		}
		
		public override void pause(){}
		public override void resume(){}
		public override void clear(){}
		
	}
	
}
