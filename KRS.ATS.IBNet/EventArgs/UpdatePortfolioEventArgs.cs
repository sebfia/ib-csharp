using System;
using System.Collections.Generic;
using System.Text;

namespace Krs.Ats.IBNet
{
    /// <summary>
    /// Update Portfolio Event Arguments
    /// </summary>
    public class UpdatePortfolioEventArgs : EventArgs
    {
        private readonly Contract contract;
        /// <summary>
        /// This structure contains a description of the contract which is being traded.
        /// The exchange field in a contract is not set for portfolio update.
        /// </summary>
        public Contract Contract
        {
            get
            {
                return contract;
            }
        }

        private readonly int position;
        /// <summary>
        /// This integer indicates the position on the contract.
        /// If the position is 0, it means the position has just cleared.
        /// </summary>
        public int Position
        {
            get
            {
                return position;
            }
        }

        private readonly double marketPrice;
        /// <summary>
        /// Unit price of the instrument.
        /// </summary>
        public double MarketPrice
        {
            get
            {
                return marketPrice;
            }
        }

        private readonly double marketValue;
        /// <summary>
        /// The total market value of the instrument.
        /// </summary>
        public double MarketValue
        {
            get
            {
                return marketValue;
            }
        }

        private readonly double averageCost;
        /// <summary>
        /// The average cost per share is calculated by dividing your cost
        /// (execution price + commission) by the quantity of your position.
        /// </summary>
        public double AverageCost
        {
            get
            {
                return averageCost;
            }
        }

        private readonly double unrealizedPnl;
        /// <summary>
        /// The difference between the current market value of your open positions and the average cost, or Value - Average Cost.
        /// </summary>
        public double UnrealizedPnl
        {
            get
            {
                return unrealizedPnl;
            }
        }

        private readonly double realizedPnl;
        /// <summary>
        /// Shows your profit on closed positions, which is the difference between your entry execution cost
        /// (execution price + commissions to open the position) and exit execution cost ((execution price + commissions to close the position)
        /// </summary>
        public double RealizedPnl
        {
            get
            {
                return realizedPnl;
            }
        }

        private readonly string accountName;
        /// <summary>
        /// The name of the account the message applies to.  Useful for Financial Advisor sub-account messages.
        /// </summary>
        public string AccountName
        {
            get
            {
                return accountName;
            }
        }

        /// <summary>
        /// Full Constructor
        /// </summary>
        /// <param name="contract">This structure contains a description of the contract which is being traded.
        /// The exchange field in a contract is not set for portfolio update.</param>
        /// <param name="position">This integer indicates the position on the contract.
        /// If the position is 0, it means the position has just cleared.</param>
        /// <param name="marketPrice">Unit price of the instrument.</param>
        /// <param name="marketValue">The total market value of the instrument.</param>
        /// <param name="averageCost">The average cost per share is calculated by dividing your cost
        /// (execution price + commission) by the quantity of your position.</param>
        /// <param name="unrealizedPnl">The difference between the current market value of your open positions and the average cost, or Value - Average Cost.</param>
        /// <param name="realizedPnl">Shows your profit on closed positions, which is the difference between your entry execution cost
        /// (execution price + commissions to open the position) and exit execution cost ((execution price + commissions to close the position)</param>
        /// <param name="accountName">The name of the account the message applies to.  Useful for Financial Advisor sub-account messages.</param>
        public UpdatePortfolioEventArgs(Contract contract, int position, double marketPrice, double marketValue, double averageCost, double unrealizedPnl, double realizedPnl, string accountName)
        {
            this.contract = contract;
            this.accountName = accountName;
            this.realizedPnl = realizedPnl;
            this.unrealizedPnl = unrealizedPnl;
            this.averageCost = averageCost;
            this.marketValue = marketValue;
            this.marketPrice = marketPrice;
            this.position = position;
        }
    }
}