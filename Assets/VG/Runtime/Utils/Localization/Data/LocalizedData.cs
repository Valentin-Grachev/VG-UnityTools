using System.Collections.Generic;
using UnityEngine;


namespace VG
{



    
    public abstract class LocalizedData<Type> : LoadableFromTable where Type : ITranslation
    {
        [SerializeField] protected List<Type> _translations;

        public Dictionary<string, Type> translations { get; private set; }


        public void Initialize()
        {
            translations = new Dictionary<string, Type>();
            foreach (var phrase in _translations)
                translations.Add(phrase.Key, phrase);
        }

    }



}



