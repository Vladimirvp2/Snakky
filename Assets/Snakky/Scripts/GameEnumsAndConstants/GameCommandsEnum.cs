using UnityEngine;
using System.Collections;


namespace Snakyy {

    public enum GameCommands{
	    START_LEVEL1 = 0,
		SNAKE_HIT_FIELD_BORDER,
		SNAKE_HIT_EATABLE_FIELD_OBJECT,
		LIVE_TIME_OUT_FOR_EATABLE_OBJECT,
		SNAKE_HIT_ITSELF,


		// UI
		SCORE_ADD,
        COIN_ADD,
		LIVE_ADD
    }
}
