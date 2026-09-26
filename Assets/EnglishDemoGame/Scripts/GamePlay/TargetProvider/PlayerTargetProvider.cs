
using EnglishDemoGame.Scripts.GamePlay.Hero;
using EnglishDemoGame.Scripts.GamePlay.TargetProvider.Interface;
using UnityEngine;
using Zenject;

namespace EnglishDemoGame.Scripts.GamePlay.TargetProvider
{
    public class PlayerTargetProvider : ITargetProvider
    {
        private readonly HeroController _hero;

        [Inject]
        public PlayerTargetProvider(HeroController hero)
        {
            _hero = hero;
        }

        public Vector3 GetTargetPosition()
        {
            return _hero != null ? _hero.transform.position : Vector3.zero;
        }
    }
}