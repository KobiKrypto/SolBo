﻿using Binance.Net.Objects;
using SolBo.Shared.Domain.Enums;
using SolBo.Shared.Extensions;
using System;

namespace SolBo.Shared.Domain.Statics
{
    public static class LogGenerator
    {
        public static string ErrorTicker => "Bad ticker definition";

        public static string ValidationSuccess(string ruleAttribute)
            => $"Validation SUCCESS => {ruleAttribute}";
        public static string ValidationError(string ruleAttribute, string attributeValue)
            => $"Validation ERROR => {ruleAttribute} => Value => {attributeValue} => BAD";

        public static string SaveSuccess => "Save SUCCESS";
        public static string SaveError => "Save ERROR";

        public static string SequenceSuccess(string sequenceName, string attribute)
            => $"{sequenceName} SUCCESS => {attribute}";
        public static string SequenceError(string sequenceName, string attribute)
            => $"{sequenceName} ERROR => {attribute}";
        public static string SequenceException(string sequenceName, Exception e)
            => $"{sequenceName} EXCEPTION => {e.GetFullMessage()}";

        public static string ModeStart(string modeName)
            => $"{modeName} START";
        public static string ModeEnd(string modeName)
            => $"{modeName} END";
        public static string ModeExecuted(string modeName)
            => $"{modeName} EXECUTED";

        public static string Off(MarketOrderType orderType)
            => $"{orderType.GetDescription()} => OFF";

        public static string StepMarketSuccess(MarketOrderType orderType, decimal priceCurrent, decimal priceAverage, decimal change)
            => $"{orderType.GetDescription()} => Price ({priceCurrent}) increased from the average ({priceAverage}) by {Math.Abs(change)}%";
        public static string StepMarketError(MarketOrderType orderType, decimal priceCurrent, decimal priceAverage, decimal change)
            => $"{orderType.GetDescription()} => Price ({priceCurrent}) has fallen from the average ({priceAverage}) by {Math.Abs(change)}%";

        public static string PriceMarketSuccess(MarketOrderType orderType)
            => $"{orderType.GetDescription()} => Order will be placed on exchange";
        public static string PriceMarketError(MarketOrderType orderType)
            => $"{orderType.GetDescription()} => Order will not be placed on exchange";

        public static string OrderMarketSuccess(MarketOrderType orderType)
            => $"{orderType.GetDescription()} => Order succeed on exchange";
        public static string OrderMarketError(MarketOrderType orderType)
            => $"{orderType.GetDescription()} => Order not succeed on exchange";

        public static string StopLossResultStart(long orderId)
            => $"Order ({orderId}) => START";
        public static string StopLossResultEnd(long orderId)
            => $"Order ({orderId}) => END";
        public static string StopLossResult(BinanceOrderTrade order)
            => $"Trade ({order.TradeId}) => Price => {order.Price} => Quantity {order.Quantity} => Commission {order.Commission} ({order.CommissionAsset})";

        public static string ExecuteMarketSuccess(MarketOrderType orderType, bool priceReached, int bought)
            => $"{orderType.GetDescription()} => Price reached ({priceReached}), bought before ({bought})";
        public static string ExecuteMarketError(MarketOrderType orderType, bool priceReached, int bought)
            => $"{orderType.GetDescription()} => Price reached ({priceReached}), bought before ({bought})";

        public static string ModeTypeSuccess(string sequenceName, string attribute)
            => $"{sequenceName} ON => {attribute}";
        public static string ModeTypeError(string sequenceName, string attribute)
            => $"{sequenceName} OFF => {attribute}";

        public static string ExchangeLog(string baseAsset, string quoteAsset)
            => $"Assets on exchange => base ({baseAsset}), quote ({quoteAsset})";
    }
}