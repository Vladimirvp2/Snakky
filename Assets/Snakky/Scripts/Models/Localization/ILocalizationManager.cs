using UnityEngine;
using System.Collections;

namespace Snakyy
{
	public interface ILocalizationManager
	{
		void setCurrLanguage(LanguagesEnum l);
		string getString(string tag);
		void setNextLanguage();
		LanguagesEnum currLanguage{get;}
	}
}
