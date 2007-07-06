using System;
using System.Collections.Generic;
using System.Text;

namespace Krs.Ats.IBNet
{
    /// <summary>
    /// Order Status Event Arguments
    /// </summary>
    public class OrderStatusEventArgs : EventArgs
    {
        private readonly int orderId;
        /// <summary>
        /// The order Id that was specified previously in the call to placeOrder().
        /// </summary>
        public int OrderId
        {
            get
            {
                return orderId;
            }
        }

        private readonly OrderStatus status;
        /// <summary>
        /// The order status.
        /// </summary>
        /// <remarks>Possible values include:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>PendingSubmit</term>
        /// <description>indicates that you have transmitted the order, but have not yet received confirmation that it has been accepted by the order destination. This order status is not sent by TWS and should be explicitly set by the API developer when an order is submitted.</description>
        /// </item>
        /// <item>
        /// <term>PendingCancel</term>
        /// <description>Indicates that you have sent a request to cancel the order but have not yet received cancel confirmation from the order destination. At this point, your order is not confirmed canceled. You may still receive an execution while your cancellation request is pending. This order status is not sent by TWS and should be explicitly set by the API developer when an order is canceled.</description>
        /// </item>
        /// <item>
        /// <term>PreSubmitted</term>
        /// <description>Indicates that a simulated order type has been accepted by the IB system and that this order has yet to be elected. The order is held in the IB system (and the status remains DARK BLUE) until the election criteria are met. At that time the order is transmitted to the order destination as specified (and the order status color will change).</description>
        /// </item>
        /// <item>
        /// <term>Submitted</term>
        /// <description>Indicates that your order has been accepted at the order destination and is working.</description>
        /// </item>
        /// <item>
        /// <term>Cancelled</term>
        /// <description>Indicates that the balance of your order has been confirmed canceled by the IB system. This could occur unexpectedly when IB or the destination has rejected your order.</description>
        /// </item>
        /// <item>
        /// <term>Filled</term>
        /// <description>The order has been completely filled.</description>
        /// </item>
        /// </list>
        /// </remarks>
        /// <seealso cref="OrderStatus"/>
        public OrderStatus Status
        {
            get
            {
                return status;
            }
        }

        private readonly int filled;
        /// <summary>
        /// Specifies the number of shares that have been executed.
        /// </summary>
        public int Filled
        {
            get
            {
                return filled;
            }
        }

        private readonly int remaining;
        /// <summary>
        /// Specifies the number of shares still outstanding.
        /// </summary>
        public int Remaining
        {
            get
            {
                return remaining;
            }
        }

        private readonly double avgFillPrice;
        /// <summary>
        /// The average price of the shares that have been executed.
        /// This parameter is valid only if the filled parameter value
        /// is greater than zero. Otherwise, the price parameter will be zero.
        /// </summary>
        public double AvgFillPrice
        {
            get
            {
                return avgFillPrice;
            }
        }

        private readonly int permId;
        /// <summary>
        /// The TWS id used to identify orders. Remains the same over TWS sessions.
        /// </summary>
        public int PermId
        {
            get
            {
                return permId;
            }
        }

        private readonly int parentId;
        /// <summary>
        /// The order ID of the parent order, used for bracket and auto trailing stop orders.
        /// </summary>
        public int ParentId
        {
            get
            {
                return parentId;
            }
        }

        private readonly double lastFillPrice;
        /// <summary>
        /// The last price of the shares that have been executed. This parameter is valid
        /// only if the filled parameter value is greater than zero. Otherwise, the price parameter will be zero.
        /// </summary>
        public double LastFillPrice
        {
            get
            {
                return lastFillPrice;
            }
        }

        private readonly int clientId;
        /// <summary>
        /// The ID of the client (or TWS) that placed the order.
        /// The TWS orders have a fixed clientId and orderId of 0 that distinguishes them from API orders.
        /// </summary>
        public int ClientId
        {
            get
            {
                return clientId;
            }
        }

        /// <summary>
        /// Full Constructor
        /// </summary>
        /// <param name="orderId">The order Id that was specified previously in the call to placeOrder().</param>
        /// <param name="status">The order status.</param>
        /// <param name="filled">Specifies the number of shares that have been executed.</param>
        /// <param name="remaining">Specifies the number of shares still outstanding.</param>
        /// <param name="avgFillPrice">The average price of the shares that have been executed.
        /// This parameter is valid only if the filled parameter value
        /// is greater than zero. Otherwise, the price parameter will be zero.</param>
        /// <param name="permId">The TWS id used to identify orders. Remains the same over TWS sessions.</param>
        /// <param name="parentId">The order ID of the parent order, used for bracket and auto trailing stop orders.</param>
        /// <param name="lastFillPrice">The last price of the shares that have been executed. This parameter is valid
        /// only if the filled parameter value is greater than zero. Otherwise, the price parameter will be zero.</param>
        /// <param name="clientId">The ID of the client (or TWS) that placed the order.
        /// The TWS orders have a fixed clientId and orderId of 0 that distinguishes them from API orders.</param>
        public OrderStatusEventArgs(int orderId, OrderStatus status, int filled, int remaining, double avgFillPrice, int permId, int parentId, double lastFillPrice, int clientId)
        {
            this.orderId = orderId;
            this.clientId = clientId;
            this.lastFillPrice = lastFillPrice;
            this.parentId = parentId;
            this.permId = permId;
            this.avgFillPrice = avgFillPrice;
            this.remaining = remaining;
            this.filled = filled;
            this.status = status;
        }
    }
}