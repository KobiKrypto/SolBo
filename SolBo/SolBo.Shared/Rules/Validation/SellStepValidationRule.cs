﻿using SolBo.Shared.Domain.Configs;

namespace SolBo.Shared.Rules.Validation
{
    public class SellStepValidationRule : IValidatedRule
    {
        public string RuleAttribute => "SellUp";
        public IRuleResult RuleExecuted(Solbot solbot)
            => ValidatedRuleResult.New(
                RulePassed(solbot),
                RuleAttribute,
                $"{solbot.Strategy.AvailableStrategy.SellUp}");
        public bool RulePassed(Solbot solbot)
            => solbot.Strategy.AvailableStrategy.SellUp > 0;
    }
}