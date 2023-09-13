using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

namespace VG
{
    public class Tweener : MonoBehaviour
    {
        public enum ActionType { Open, Close };


        [System.Serializable]
        public class Tween
        {
            public Tweenable tweenable;
            public ActionType actionType;
        }


        [System.Serializable]
        public class TweenGroup
        {
            public string key;
            public List<Tween> tweens;
        }

        [SerializeField] private List<TweenGroup> _tweenGroups;

        private static Dictionary<string, TweenGroup> tweenGroups = new Dictionary<string, TweenGroup>();


        private void Awake()
        {
            DOTween.Init().SetCapacity(40, 20);
            tweenGroups.Clear();

            foreach (var tweenGroup in _tweenGroups)
                tweenGroups.Add(tweenGroup.key, tweenGroup);
        }


        public static void Run(string tweenGroupKey)
        {
            TweenGroup tweenGroup = tweenGroups[tweenGroupKey];

            foreach (var tween in tweenGroup.tweens)
            {
                if (tween.actionType == ActionType.Open) tween.tweenable.Open();
                else if (tween.actionType == ActionType.Close) tween.tweenable.Close();
            }
        }



    }
}



