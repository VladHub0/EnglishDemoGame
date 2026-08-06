using EnglishDemoGame.Scripts.GamePlay.Enemy.Model.Enum;
using EnglishDemoGame.Scripts.GamePlay.Enemy.Model.Interface;
using EnglishDemoGame.Scripts.GamePlay.Enemy.Service.EnemyState.State.Interface;
using EnglishDemoGame.Scripts.GamePlay.Enemy.Service.MoveService.Interface;
using Zenject;

public class EnemyStateStart : IEnemyState
{
    public EnemyStateType StateType => EnemyStateType.Start;

    private IEnemyMovementService _movementService;
    private IEnemyModel _model;

    [Inject]
    public void Construct(IEnemyMovementService movementService, IEnemyModel model)
    {
        _movementService = movementService;
        _model = model;
    }


    private float Speed { 
        get { return _model.Speed; }   
    }

    
    public void Enter()
    {
        _movementService?.MoveToHero(Speed);
    }

    public void Exit()
    {
        
    }

    public void Update()
    {
        _movementService?.MoveToHero(Speed);
    }

    public bool CanTransitionTo(EnemyStateType nextState)
    {
        return nextState switch
        {
            EnemyStateType.Attack => true,
            EnemyStateType.Enraged => true,
            _ => false
        };
    }


}