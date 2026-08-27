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

    
    public void Enter()
    {
        
    }

    public void Exit()
    {
        
    }

    public void Update()
    {
        
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