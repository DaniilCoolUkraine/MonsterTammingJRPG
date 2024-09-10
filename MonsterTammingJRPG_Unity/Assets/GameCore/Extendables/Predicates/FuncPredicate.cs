using System;
using JetBrains.Annotations;
using Jrpg.GameCore.Core.Interfaces;

namespace Jrpg.GameCore.Extendables.Predicates
{
    public class FuncPredicate : IPredicate
    {
        private readonly Func<bool> _evaluator;

        public FuncPredicate([NotNull] Func<bool> evaluator)
        {
            _evaluator = evaluator;
        }

        public bool Evaluate()
        {
            return _evaluator.Invoke();
        }
    }
}