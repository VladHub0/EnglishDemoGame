
using UnityEngine;
using Zenject;

namespace EnglishDemoGame.Scripts.GamePlay.Hero.SpawnHero
{
    
        public class HeroSpawnManager : IInitializable
        {
           
            private readonly HeroController _heroController;
            private readonly Vector2 _spawnPosition;

            [Inject]
            public HeroSpawnManager(HeroController heroController, [Inject(Id = "HeroSpawnPoint")] Vector2 spawnPosition)
            { 
               
                _heroController = heroController;
                _spawnPosition = spawnPosition;

            }

            public void Initialize()
            {
                SpawnHero();
            }

            private void SpawnHero()
            {

               _heroController.transform.position = new Vector3(_spawnPosition.x,_spawnPosition.y, -1);
            }
        }
    
}