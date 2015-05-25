using UnityEngine;
using System.Collections;

namespace Snakyy
{
	public class RectField1 : BaseRectField {

		public RectField1(int screenWidth, int screenHeight) : base(screenWidth, screenHeight){

		}


		public override void create()
		{
			Debug.Log("Class created!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
			createBackground();
			createFieldBorder();
		}

		public override void pause(){}
		public override void resume(){}
		public override void clear(){}

    }

}
