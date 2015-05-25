using UnityEngine;
using System.Collections;


namespace Snakyy { 

        public interface IEatObjectsController {

		float probabilityMult{get; set;}

		void start();
		void update();
		void pause();
		void resume();
    }

}
