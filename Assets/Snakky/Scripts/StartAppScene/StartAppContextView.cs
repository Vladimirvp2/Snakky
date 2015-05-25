using UnityEngine;
using System.Collections;
using strange.extensions.context.impl;
using strange.extensions.mediation.impl;

namespace Snakyy{
	
	public class StartAppContextView : ContextView {
		
		void Awake()
		{
			context = new StartAppContext(this);
		}
	}
}