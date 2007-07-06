using System;

namespace Krs.Ats.IBNet
{
    /// <summary>
    /// Order class passed to Interactive Brokers to place an order.
    /// </summary>
    public class Order
    {
        #region Private Variables
        // main order fields
        private int orderId;
        private int clientId;
        private int permId;
        private ActionSide action;
        private int totalQuantity;
        private OrderType orderType;
        private double lmtPrice;
        private double auxPrice;
		
        // extended order fields
        private TimeInForce tif; // "Time in Force" - DAY, GTC, etc.
        private String ocaGroup; // one cancels all group name
        private OcaType ocaType; // 1 = CANCEL_WITH_BLOCK, 2 = REDUCE_WITH_BLOCK, 3 = REDUCE_NON_BLOCK
        private String orderRef;
        private bool transmit; // if false, order will be created but not transmited
        private int parentId; // Parent order Id, to associate Auto STP or TRAIL orders with the original order.
        private bool blockOrder;
        private bool sweepToFill;
        private int displaySize;
        private TriggerMethod triggerMethod; // 0=Default, 1=Double_Bid_Ask, 2=Last, 3=Double_Last, 4=Bid_Ask, 7=Last_or_Bid_Ask, 8=Mid-point
        private bool ignoreRth;
        private bool hidden;
        private String goodAfterTime; // FORMAT: 20060505 08:00:00 {time zone}
        private String goodTillDate; // FORMAT: 20060505 08:00:00 {time zone}
        private bool rthOnly;
        private bool overridePercentageConstraints;
        private AgentDescription rule80A; // Individual = 'I', Agency = 'A', AgentOtherMember = 'W', IndividualPTIA = 'J', AgencyPTIA = 'U', AgentOtherMemberPTIA = 'M', IndividualPT = 'K', AgencyPT = 'Y', AgentOtherMemberPT = 'N'
        private bool allOrNone;
        private int minQty;
        private double percentOffset; // REL orders only
        private double trailStopPrice; // for TRAILLIMIT orders only
        private String sharesAllocation; // deprecated
		
        // Financial advisors only 
        private String faGroup;
        private String faProfile;
        private String faMethod;
        private String faPercentage;
		
        // Institutional orders only
        private String account;
        private String settlingFirm;
        private String openClose; // O=Open, C=Close
        private OrderOrigin origin; // 0=Customer, 1=Firm
        private int shortSaleSlot; // 1 if you hold the shares, 2 if they will be delivered from elsewhere.  Only for Action="SSHORT
        private String designatedLocation; // set when slot=2 only.
		
        // SMART routing only
        private double discretionaryAmt;
        private bool eTradeOnly;
        private bool firmQuoteOnly;
        private double nbboPriceCap;
		
        // BOX or VOL ORDERS ONLY
        private AuctionStrategy auctionStrategy; // 1=AUCTION_MATCH, 2=AUCTION_IMPROVEMENT, 3=AUCTION_TRANSPARENT
		
        // BOX ORDERS ONLY
        private double startingPrice;
        private double stockRefPrice;
        private double delta;
		
        // pegged to stock or VOL orders
        private double stockRangeLower;
        private double stockRangeUpper;
		
        // VOLATILITY ORDERS ONLY
        private double volatility;
        private VolatilityType volatilityType; // 1=daily, 2=annual
        private int continuousUpdate;
        private int referencePriceType; // 1=Average, 2 = BidOrAsk
        private OrderType deltaNeutralOrderType;
        private double deltaNeutralAuxPrice;
		
        // COMBO ORDERS ONLY
        private double basisPoints; // EFP orders only
        private int basisPointsType; // EFP orders only
        #endregion

        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Order()
        {
            openClose = "O";
            origin = OrderOrigin.Customer;
            transmit = true;
            designatedLocation = "";
            minQty = System.Int32.MaxValue;
            percentOffset = System.Double.MaxValue;
            nbboPriceCap = System.Double.MaxValue;
            startingPrice = System.Double.MaxValue;
            stockRefPrice = System.Double.MaxValue;
            delta = System.Double.MaxValue;
            stockRangeLower = System.Double.MaxValue;
            stockRangeUpper = System.Double.MaxValue;
            volatility = System.Double.MaxValue;
            volatilityType = IBNet.VolatilityType.Undefined;
            deltaNeutralOrderType = IBNet.OrderType.None;
            deltaNeutralAuxPrice = System.Double.MaxValue;
            referencePriceType = System.Int32.MaxValue;
            trailStopPrice = System.Double.MaxValue;
            basisPoints = System.Double.MaxValue;
            basisPointsType = System.Int32.MaxValue;
        }
        #endregion

        #region Properties
        /// <summary>
        /// The id for this order.
        /// </summary>
        public int OrderId
        {
            get { return orderId; }
            set { orderId = value; }
        }

        /// <summary>
        /// The id of the client that placed this order.
        /// </summary>
        public int ClientId
        {
            get { return clientId; }
            set { clientId = value; }
        }

        /// <summary>
        /// The TWS id used to identify orders, remains the same over TWS sessions.
        /// </summary>
        public int PermId
        {
            get { return permId; }
            set { permId = value; }
        }

        /// <summary>
        /// Identifies the side. Valid values are: BUY, SELL, SSHORT
        /// </summary>
        public ActionSide Action
        {
            get { return action; }
            set { action = value; }
        }

        /// <summary>
        /// The order quantity.
        /// </summary>
        public int TotalQuantity
        {
            get { return totalQuantity; }
            set { totalQuantity = value; }
        }

        /// <summary>
        /// The order type.
        /// </summary>
        /// <seealso cref="OrderType"/>
        public OrderType OrderType
        {
            get { return orderType; }
            set { orderType = value; }
        }

        /// <summary>
        /// This is the LIMIT price, used for limit, stop-limit and relative orders.
        /// In all other cases specify zero. For relative orders with no limit price,
        /// also specify zero.
        /// </summary>
        public double LmtPrice
        {
            get { return lmtPrice; }
            set { lmtPrice = value; }
        }

        /// <summary>
        /// This is the STOP price for stop-limit orders, and the offset amount for
        /// relative orders. In all other cases, specify zero.
        /// </summary>
        public double AuxPrice
        {
            get { return auxPrice; }
            set { auxPrice = value; }
        }

        /// <summary>
        /// The time in force.
        /// </summary>
        /// <remarks>Valid values are: DAY, GTC, IOC, GTD.</remarks>
        /// <seealso cref="TimeInForce"/>
        public TimeInForce Tif
        {
            get { return tif; }
            set { tif = value; }
        }

        /// <summary>
        /// Identifies an OCA (one cancels all) group.
        /// </summary>
        public string OcaGroup
        {
            get { return ocaGroup; }
            set { ocaGroup = value; }
        }

        /// <summary>
        /// Tells how to handle remaining orders in an OCA group when one order or part of an order executes.
        /// </summary>
        /// <remarks>
        /// Valid values include:
        /// <list type="bullet">
        /// <item>1 = Cancel all remaining orders with block.</item>
        /// <item>2 = Remaining orders are proportionately reduced in size with block.</item>
        /// <item>3 = Remaining orders are proportionately reduced in size with no block.</item>
        /// </list>
        /// If you use a value "with block"gives your order has overfill protection. This means  that only one order in the group will be routed at a time to remove the possibility of an overfill.
        /// </remarks>
        /// <seealso cref="OcaType"/>
        public OcaType OcaType
        {
            get { return ocaType; }
            set { ocaType = value; }
        }

        /// <summary>
        /// The order reference. For institutional customers only.
        /// </summary>
        public string OrderRef
        {
            get { return orderRef; }
            set { orderRef = value; }
        }

        /// <summary>
        /// Specifies whether the order will be transmitted by TWS.
        /// If set to false, the order will be created at TWS but will not be sent.
        /// </summary>
        public bool Transmit
        {
            get { return transmit; }
            set { transmit = value; }
        }

        /// <summary>
        /// The order ID of the parent order, used for bracket and auto trailing stop orders.
        /// </summary>
        public int ParentId
        {
            get { return parentId; }
            set { parentId = value; }
        }

        /// <summary>
        /// If set to true, specifies that the order is an ISE Block order.
        /// </summary>
        public bool BlockOrder
        {
            get { return blockOrder; }
            set { blockOrder = value; }
        }

        /// <summary>
        /// If set to true, specifies that the order is a Sweep-to-Fill order.
        /// </summary>
        public bool SweepToFill
        {
            get { return sweepToFill; }
            set { sweepToFill = value; }
        }

        /// <summary>
        /// The publicly disclosed order size, used when placing Iceberg orders.
        /// </summary>
        public int DisplaySize
        {
            get { return displaySize; }
            set { displaySize = value; }
        }

        /// <summary>
        /// Specifies how Simulated Stop, Stop-Limit and Trailing Stop orders are triggered.
        /// </summary>
        /// <remarks>
        /// Valid values are:
        /// <list type="bullet">
        /// <item>0 - the default value. The "double bid/ask" method will be used for orders for OTC stocks and US options. All other orders will used the "last" method.</item>
        /// <item>1 - use "double bid/ask" method, where stop orders are triggered based on two consecutive bid or ask prices.</item>
        /// <item>2 - "last" method, where stop orders are triggered based on the last price.</item>
        /// <item>3 - double last method.</item>
        /// <item>4 - bid/ask method.</item>
        /// <item>7 - last or bid/ask method.</item>
        /// <item>8 - mid-point method.</item>
        /// </list>
        /// </remarks>
        /// <seealso cref="TriggerMethod"/>
        public TriggerMethod TriggerMethod
        {
            get { return triggerMethod; }
            set { triggerMethod = value; }
        }

        /// <summary>
        /// If set to true, allows triggering of orders outside of regular trading hours.
        /// </summary>
        public bool IgnoreRth
        {
            get { return ignoreRth; }
            set { ignoreRth = value; }
        }

        /// <summary>
        /// If set to true, the order will not be visible when viewing the market depth.
        /// This option only applies to orders routed to the ISLAND exchange.
        /// </summary>
        public bool Hidden
        {
            get { return hidden; }
            set { hidden = value; }
        }

        /// <summary>
        /// The trade's "Good After Time"
        /// </summary>
        /// <remarks>format "YYYYMMDD hh:mm:ss (optional time zone)" 
        /// Use an empty String if not applicable.</remarks>
        public string GoodAfterTime
        {
            get { return goodAfterTime; }
            set { goodAfterTime = value; }
        }

        /// <summary>
        /// You must enter a Time in Force value of Good Till Date.
        /// </summary>
        /// <remarks>The trade's "Good Till Date," format is:
        /// YYYYMMDD hh:mm:ss (optional time zone)
        /// Use an empty String if not applicable.</remarks>
        public string GoodTillDate
        {
            get { return goodTillDate; }
            set { goodTillDate = value; }
        }

        /// <summary>
        /// Regular trading hours only.
        /// </summary>
        /// <remarks>yes=1, no=0</remarks>
        public bool RthOnly
        {
            get { return rthOnly; }
            set { rthOnly = value; }
        }

        /// <summary>
        /// If set, allows you to override TWS order price percentage constraints set to
        /// reject orders that deviate too far from the NBBO. This precaution was created
        /// to avoid transmitting orders with an incorrect price. 
        /// </summary>
        public bool OverridePercentageConstraints
        {
            get { return overridePercentageConstraints; }
            set { overridePercentageConstraints = value; }
        }

        /// <summary>
        /// This identifies what type of trader you are.
        /// </summary>
        /// <remarks>Rule80A required you to identify which type of trader you are.</remarks>
        /// <seealso cref="AgentDescription"/>
        public AgentDescription Rule80A
        {
            get { return rule80A; }
            set { rule80A = value; }
        }

        /// <summary>
        /// yes=1, no=0
        /// </summary>
        public bool AllOrNone
        {
            get { return allOrNone; }
            set { allOrNone = value; }
        }

        /// <summary>
        /// Identifies a minimum quantity order type.
        /// </summary>
        public int MinQty
        {
            get { return minQty; }
            set { minQty = value; }
        }

        /// <summary>
        /// The percent offset amount for relative orders.
        /// </summary>
        public double PercentOffset
        {
            get { return percentOffset; }
            set { percentOffset = value; }
        }

        /// <summary>
        /// For TRAILLIMIT orders only
        /// </summary>
        public double TrailStopPrice
        {
            get { return trailStopPrice; }
            set { trailStopPrice = value; }
        }

        /// <summary>
        /// Deprecated. Upgrade to new FA functionality must be done. 
        /// </summary>
        public string SharesAllocation
        {
            get { return sharesAllocation; }
            set { sharesAllocation = value; }
        }

        /// <summary>
        /// The Financial Advisor group the trade will be allocated to -- use an empty String if not applicable.
        /// </summary>
        public string FAGroup
        {
            get { return faGroup; }
            set { faGroup = value; }
        }

        /// <summary>
        /// The Financial Advisor allocation profile the trade will be allocated to -- use an empty String if not applicable.
        /// </summary>
        public string FAProfile
        {
            get { return faProfile; }
            set { faProfile = value; }
        }

        /// <summary>
        /// The Financial Advisor allocation method the trade will be allocated with -- use an empty String if not applicable.
        /// </summary>
        public string FAMethod
        {
            get { return faMethod; }
            set { faMethod = value; }
        }

        /// <summary>
        /// The Financial Advisor percentage concerning the trade's allocation -- use an empty String if not applicable.
        /// </summary>
        public string FAPercentage
        {
            get { return faPercentage; }
            set { faPercentage = value; }
        }

        /// <summary>
        /// The account. For institutional customers only.
        /// </summary>
        public string Account
        {
            get { return account; }
            set { account = value; }
        }

        /// <summary>
        /// Institutional only.
        /// </summary>
        public string SettlingFirm
        {
            get { return settlingFirm; }
            set { settlingFirm = value; }
        }

        /// <summary>
        /// Specifies whether the order is an open or close order.
        /// For institutional customers only. Valid values are O, C.
        /// </summary>
        public string OpenClose
        {
            get { return openClose; }
            set { openClose = value; }
        }

        /// <summary>
        /// The order origin.
        /// </summary>
        /// <remarks>For institutional customers only.</remarks>
        public OrderOrigin Origin
        {
            get { return origin; }
            set { origin = value; }
        }

        /// <summary>
        /// Values are 1 or 2.
        /// </summary>
        public int ShortSaleSlot
        {
            get { return shortSaleSlot; }
            set { shortSaleSlot = value; }
        }

        /// <summary>
        /// Use only when shortSaleSlot value = 2.
        /// </summary>
        public string DesignatedLocation
        {
            get { return designatedLocation; }
            set { designatedLocation = value; }
        }

        /// <summary>
        /// The amount off the limit price allowed for discretionary orders.
        /// </summary>
        public double DiscretionaryAmt
        {
            get { return discretionaryAmt; }
            set { discretionaryAmt = value; }
        }

        /// <summary>
        /// Trade with electronic quotes.
        /// </summary>
        public bool ETradeOnly
        {
            get { return eTradeOnly; }
            set { eTradeOnly = value; }
        }

        /// <summary>
        /// Trade with firm quotes.
        /// </summary>
        public bool FirmQuoteOnly
        {
            get { return firmQuoteOnly; }
            set { firmQuoteOnly = value; }
        }

        /// <summary>
        /// The maximum Smart order distance from the NBBO.
        /// </summary>
        public double NbboPriceCap
        {
            get { return nbboPriceCap; }
            set { nbboPriceCap = value; }
        }
        
        /// <summary>
        /// The auction strategy.
        /// </summary>
        /// <remarks>For BOX exchange only.</remarks>
        /// <seealso cref="AuctionStrategy"/>
        public AuctionStrategy AuctionStrategy
        {
            get { return auctionStrategy; }
            set { auctionStrategy = value; }
        }

        /// <summary>
        /// The starting price.
        /// </summary>
        /// <remarks>Valid on BOX orders only.</remarks>
        public double StartingPrice
        {
            get { return startingPrice; }
            set { startingPrice = value; }
        }

        /// <summary>
        /// The stock reference price.
        /// </summary>
        /// <remarks>The reference price is used for VOL orders
        /// to compute the limit price sent to an exchange (whether or not Continuous
        /// Update is selected), and for price range monitoring.</remarks>
        public double StockRefPrice
        {
            get { return stockRefPrice; }
            set { stockRefPrice = value; }
        }

        /// <summary>
        /// The stock delta.
        /// </summary>
        /// <remarks>Valid on BOX orders only.</remarks>
        public double Delta
        {
            get { return delta; }
            set { delta = value; }
        }

        /// <summary>
        /// The lower value for the acceptable underlying stock price range.
        /// </summary>
        /// <remarks>For price improvement option orders on BOX and VOL orders with dynamic management.</remarks>
        public double StockRangeLower
        {
            get { return stockRangeLower; }
            set { stockRangeLower = value; }
        }

        /// <summary>
        /// The upper value for the acceptable underlying stock price range.
        /// </summary>
        /// <remarks>For price improvement option orders on BOX and VOL orders with dynamic management.</remarks>
        public double StockRangeUpper
        {
            get { return stockRangeUpper; }
            set { stockRangeUpper = value; }
        }

        /// <summary>
        /// What the price is, computed via TWS's Options Analytics.
        /// </summary>
        /// <remarks>For VOL orders, the limit price sent to an exchange is not editable,
        /// as it is the output of a function.  Volatility is expressed as a percentage.</remarks>
        public double Volatility
        {
            get { return volatility; }
            set { volatility = value; }
        }

        /// <summary>
        /// How the volatility is calculated. 
        /// </summary>
        /// <seealso cref="VolatilityType"/>
        public VolatilityType VolatilityType
        {
            get { return volatilityType; }
            set { volatilityType = value; }
        }

        /// <summary>
        /// Used for dynamic management of volatility orders. 
        /// </summary>
        /// <remarks>Determines whether TWS is
        /// supposed to update the order price as the underlying moves.  If selected,
        /// the limit price sent to an exchange is modified by TWS if the computed price
        /// of the option changes enough to warrant doing so.  This is very helpful in
        /// keeping the limit price sent to the exchange up to date as the underlying price changes.</remarks>
        public int ContinuousUpdate
        {
            get { return continuousUpdate; }
            set { continuousUpdate = value; }
        }

        /// <summary>
        /// Used for dynamic management of volatility orders. Set to
        /// 1 = Average of National Best Bid or Ask, or set to
        /// 2 =  National Best Bid when buying a call or selling a put; and National Best Ask when selling a call or buying a put.
        /// </summary>
        public int ReferencePriceType
        {
            get { return referencePriceType; }
            set { referencePriceType = value; }
        }

        /// <summary>
        /// VOL orders only. Enter an order type to instruct TWS to submit a
        /// delta neutral trade on full or partial execution of the VOL order.
        /// For no hedge delta order to be sent, specify NONE.
        /// </summary>
        public OrderType DeltaNeutralOrderType
        {
            get { return deltaNeutralOrderType; }
            set { deltaNeutralOrderType = value; }
        }

        /// <summary>
        /// VOL orders only. Use this field to enter a value if  the value in the
        /// deltaNeutralOrderType field is an order type that requires an Aux price, such as a REL order. 
        /// </summary>
        public double DeltaNeutralAuxPrice
        {
            get { return deltaNeutralAuxPrice; }
            set { deltaNeutralAuxPrice = value; }
        }

        /// <summary>
        /// For EFP orders only
        /// </summary>
        public double BasisPoints
        {
            get { return basisPoints; }
            set { basisPoints = value; }
        }

        /// <summary>
        /// For EFP orders only
        /// </summary>
        public int BasisPointsType
        {
            get { return basisPointsType; }
            set { basisPointsType = value; }
        }
        #endregion

    }
}