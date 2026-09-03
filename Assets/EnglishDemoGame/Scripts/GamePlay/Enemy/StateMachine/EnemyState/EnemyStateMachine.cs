using EnglishDemoGame.Scripts.GamePlay.Enemy.StateMachine.EnemyState.Predicate.Interface;
using EnglishDemoGame.Scripts.GamePlay.Enemy.StateMachine.EnemyState.States.Interface;
using EnglishDemoGame.Scripts.GamePlay.Enemy.StateMachine.EnemyState.Transition;
using EnglishDemoGame.Scripts.GamePlay.Enemy.StateMachine.EnemyState.Transition.Interface;
using System;
using System.Collections.Generic;



namespace EnglishDemoGame.Scripts.GamePlay.Enemy.StateMachine.EnemyState
{
    public class EnemyStateMachine
    {
        private StateNode current;
        private Dictionary<Type, StateNode> _states = new();
        private HashSet<ITransition> anyTransitions = new();

        public  EnemyStateMachine()
        {

        }

        public void SetState(IEnemyState state)
        {
            if (state == null)
                throw new ArgumentNullException(nameof(state));

            if (!_states.ContainsKey(state.GetType()))
                throw new InvalidOperationException(
                    $"State {state.GetType().Name} is not registered.");

            current = _states[state.GetType()];
            current.State?.Enter();
        }

        public void AddState(IEnemyState state)
        {
            if (state == null)
                throw new ArgumentNullException(nameof(state));

            GetOrAddNode(state);
        }
        public void Update()
        {
            var transition = GetTransition();

            if (transition != null)
            {
                ChangeState(transition.To);
            }


            current.State?.Update();
        }

        private ITransition GetTransition()
        {
            foreach (var transition in anyTransitions)
            {
                if (transition.Condition.Evaluate())
                {
                    return transition;
                }
            }

            foreach (var transition in current.Transitions)
            {
                if (transition.Condition.Evaluate())
                {
                    return transition;
                }
            }

            return null;

        }

        private void ChangeState(IEnemyState state)
        {
           
            if (state == current.State)
            {
                return;
            }

            var previousState = current.State;
            var nextState = _states[state.GetType()].State;

            previousState?.Exit();
            nextState?.Enter();

            current = _states[nextState.GetType()];

        }


        

        public void AddAnyTransition(IEnemyState to , IPredicate condition)
        {
            anyTransitions.Add(new EnemyTransition(GetOrAddNode(to).State, condition));
        }
        public void AddTransition(IEnemyState from , IEnemyState to, IPredicate condition)
        {
            GetOrAddNode(from).AddTransitions(GetOrAddNode(to).State, condition);
        }

        private StateNode GetOrAddNode(IEnemyState state)
        {
            var node = _states.GetValueOrDefault(state.GetType());

            if(node == null)
            {
                node = new StateNode(state);
                _states.Add(state.GetType(), node);
            }

            return node;
        } 
        private class StateNode
        {
            public IEnemyState State { get; }

            public HashSet<ITransition> Transitions { get; } = new();

            public StateNode (IEnemyState state)
            {
                State = state;
            }

            public void AddTransitions(IEnemyState to, IPredicate condition)
            {
                Transitions.Add(new EnemyTransition(to, condition));
            }

        }
    }
}