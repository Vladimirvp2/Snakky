using UnityEngine;
using System.Collections;
using strange.extensions.context.impl;
using strange.extensions.mediation.impl;

namespace Snakyy{

    public class GameContextView : ContextView {

	    void Awake()
	    {
	        context = new GameContext(this);
	    }
    }
}
