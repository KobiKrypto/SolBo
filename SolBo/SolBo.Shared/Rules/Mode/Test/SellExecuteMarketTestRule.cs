﻿using SolBo.Shared.Domain.Configs;
using SolBo.Shared.Domain.Enums;
using SolBo.Shared.Domain.Statics;
using SolBo.Shared.Services;

namespace SolBo.Shared.Rules.Mode.Test
{
    public class SellExecuteMarketTestRule : IMarketRule
    {
        public MarketOrderType MarketOrder => MarketOrderType.SELLING;
        private readonly IPushOverNotificationService _pushOverNotificationService;
        public SellExecuteMarketTestRule(
            IPushOverNotificationService pushOverNotificationService)
        {
            _pushOverNotificationService = pushOverNotificationService;
        }
        public IRuleResult RuleExecuted(Solbot solbot)
        {
            var result = solbot.Communication.Sell.PriceReached && 
                solbot.Actions.BoughtPrice > 0 &&
                solbot.Communication.Price.Current > solbot.Actions.BoughtPrice;

            if (result)
            {
                solbot.Actions.BoughtPrice = 0;
                result = true;

                _pushOverNotificationService.Send(
                    LogGenerator.NotificationTitle(WorkingType.TEST, MarketOrder, solbot.Strategy.AvailableStrategy.Symbol),
                    LogGenerator.NotificationMessage(
                        solbot.Communication.Average.Current,
                        solbot.Communication.Price.Current,
                        solbot.Communication.Sell.Change));
            }

            return new MarketRuleResult()
            {
                Success = result,
                Message = result
                    ? LogGenerator.ExecuteMarketSuccess(MarketOrder, solbot.Actions.BoughtPrice)
                    : LogGenerator.ExecuteMarketError(MarketOrder, solbot.Actions.BoughtPrice)
            };
        }
    }
}