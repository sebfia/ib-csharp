using System;
using System.Collections.ObjectModel;
using System.Threading;

namespace Krs.Ats.IBNet
{
    public interface IIBClient
    {
        /// <summary>
        /// This event is called when the market data changes. Prices are updated immediately with no delay.
        /// </summary>
        event EventHandler<TickPriceEventArgs> TickPrice;

        /// <summary>
        /// This event is called when the market data changes. Sizes are updated immediately with no delay.
        /// </summary>
        event EventHandler<TickSizeEventArgs> TickSize;

        /// <summary>
        /// This method is called when the market in an option or its underlier moves.
        /// TWS’s option model volatilities, prices, and deltas, along with the present
        /// value of dividends expected on that option’s underlier are received.
        /// </summary>
        event EventHandler<TickOptionComputationEventArgs> TickOptionComputation;

        /// <summary>
        /// This method is called when the market data changes. Values are updated immediately with no delay.
        /// </summary>
        event EventHandler<TickGenericEventArgs> TickGeneric;

        /// <summary>
        /// This method is called when the market data changes. Values are updated immediately with no delay.
        /// </summary>
        event EventHandler<TickStringEventArgs> TickString;

        /// <summary>
        /// This method is called when the market data changes. Values are updated immediately with no delay.
        /// </summary>
        event EventHandler<TickEfpEventArgs> TickEfp;

        /// <summary>
        /// This methodis called whenever the status of an order changes. It is also fired after reconnecting
        /// to TWS if the client has any open orders.
        /// </summary>
        event EventHandler<OrderStatusEventArgs> OrderStatus;

        /// <summary>
        /// This method is called to feed in open orders.
        /// </summary>
        event EventHandler<OpenOrderEventArgs> OpenOrder;

        /// <summary>
        /// This method is called only when reqAccountUpdates() method on the EClientSocket object has been called.
        /// </summary>
        event EventHandler<UpdateAccountValueEventArgs> UpdateAccountValue;

        /// <summary>
        /// This method is called only when reqAccountUpdates() method on the EClientSocket object has been called.
        /// </summary>
        event EventHandler<UpdatePortfolioEventArgs> UpdatePortfolio;

        /// <summary>
        /// This method is called only when reqAccountUpdates() method on the EClientSocket object has been called.
        /// </summary>
        event EventHandler<UpdateAccountTimeEventArgs> UpdateAccountTime;

        /// <summary>
        /// This method is called after a successful connection to TWS.
        /// </summary>
        event EventHandler<NextValidIdEventArgs> NextValidId;

        /// <summary>
        /// This event fires in response to the <see cref="IBClient.RequestContractDetails"/> method.
        /// </summary>
        event EventHandler<ContractDetailsEventArgs> ContractDetails;

        /// <summary>
        /// This event fires in response to the <see cref="IBClient.RequestContractDetails"/> method called on a bond contract.
        /// </summary>
        event EventHandler<BondContractDetailsEventArgs> BondContractDetails;

        /// <summary>
        /// Called once all contract details for a given request are received.
        /// This, for example, helps to define the end of an option chain.
        /// </summary>
        event EventHandler<ContractDetailsEndEventArgs> ContractDetailsEnd;

        /// <summary>
        /// Called once all the open orders for a given request are received.
        /// </summary>
        event EventHandler<EventArgs> OpenOrderEnd;

        /// <summary>
        /// Called once all Account Details for a given request are received.
        /// </summary>
        event EventHandler<AccountDownloadEndEventArgs> AccountDownloadEnd;

        /// <summary>
        /// Called once all contract details for a given request are received.
        /// This, for example, helps to define the end of an option chain.
        /// </summary>
        event EventHandler<ExecutionDataEndEventArgs> ExecutionDataEnd;

        /// <summary>
        /// Called once all execution data for a given request are received.
        /// </summary>
        event EventHandler<DeltaNuetralValidationEventArgs> DeltaNuetralValidation;

        /// <summary>
        /// This event fires in response to the <see cref="IBClient.RequestExecutions"/> method or after an order is placed.
        /// </summary>
        event EventHandler<ExecDetailsEventArgs> ExecDetails;

        /// <summary>
        /// This method is called when the market depth changes.
        /// </summary>
        event EventHandler<UpdateMarketDepthEventArgs> UpdateMarketDepth;

        /// <summary>
        /// This method is called when the Level II market depth changes.
        /// </summary>
        event EventHandler<UpdateMarketDepthL2EventArgs> UpdateMarketDepthL2;

        /// <summary>
        /// This method is triggered for any exceptions caught.
        /// </summary>
        event EventHandler<ReportExceptionEventArgs> ReportException;

        /// <summary>
        /// This method is triggered for each new bulletin if the client has subscribed (i.e. by calling the reqNewsBulletins() method.
        /// </summary>
        event EventHandler<UpdateNewsBulletinEventArgs> UpdateNewsBulletin;

        /// <summary>
        /// This method is called when a successful connection is made to a Financial Advisor account.
        /// It is also called when the reqManagedAccts() method is invoked.
        /// </summary>
        event EventHandler<ManagedAccountsEventArgs> ManagedAccounts;

        /// <summary>
        /// This method receives previously requested FA configuration information from TWS.
        /// </summary>
        event EventHandler<ReceiveFAEventArgs> ReceiveFA;

        /// <summary>
        /// This method receives the requested historical data results
        /// </summary>
        event EventHandler<HistoricalDataEventArgs> HistoricalData;

        /// <summary>
        /// This method receives an XML document that describes the valid parameters that a scanner subscription can have
        /// </summary>
        event EventHandler<ScannerParametersEventArgs> ScannerParameters;

        /// <summary>
        /// This method receives the requested market scanner data results
        /// </summary>
        event EventHandler<ScannerDataEventArgs> ScannerData;

        /// <summary>
        /// This method receives the requested market scanner data results
        /// </summary>
        event EventHandler<ScannerDataEndEventArgs> ScannerDataEnd;

        /// <summary>
        /// This method receives the realtime bars data results.
        /// </summary>
        event EventHandler<RealTimeBarEventArgs> RealTimeBar;

        /// <summary>
        /// This method receives the current system time on the server side.
        /// </summary>
        event EventHandler<CurrentTimeEventArgs> CurrentTime;

        /// <summary>
        /// Reuters global fundamental market data
        /// </summary>
        event EventHandler<FundamentalDetailsEventArgs> FundamentalData;

        /// <summary>
        /// Called on a market data type call back.
        /// </summary>
        event EventHandler<MarketDataTypeEventArgs> MarketDataType;

        /// <summary>
        /// Called on a commission report call back.
        /// </summary>
        event EventHandler<CommissionReportEventArgs> CommissionReport;

        /// <summary>
        /// This event is fired when there is an error with the communication or when TWS wants to send a message to the client.
        /// </summary>
        event EventHandler<ErrorEventArgs> Error;

        /// <summary>
        /// This method is called when TWS closes the sockets connection, or when TWS is shut down.
        /// </summary>
        event EventHandler<ConnectionClosedEventArgs> ConnectionClosed;

        /// <summary>
        /// Called once the tick snap shot is complete.
        /// </summary>
        event EventHandler<TickSnapshotEndEventArgs> TickSnapshotEnd;

        /// <summary>
        /// Used to control the exception handling.
        /// If true, all exceptions are thrown, else only throw non network exceptions.
        /// </summary>
        bool ThrowExceptions { get; set; }

        /// <summary>
        /// Returns the status of the connection to TWS.
        /// </summary>
        bool Connected { get; }

        /// <summary>
        /// Returns the version of the TWS instance the API application is connected to
        /// </summary>
        int ServerVersion { get; }

        /// <summary>
        /// Returns the time the API application made a connection to TWS
        /// </summary>
        String TwsConnectionTime { get; }

        /// <summary>
        /// Thread that is reading and parsing the network stream
        /// </summary>
        Thread ReadThread { get; }

        /// <summary>
        /// Returns whether the worker thread has been asked to stop.
        /// This continues to return true even after the thread has stopped.
        /// </summary>
        bool Stopping { get; }

        /// <summary>
        /// Returns whether the worker thread has stopped.
        /// </summary>
        bool Stopped { get; }

        /// <summary>
        /// Dispose() calls Dispose(true)
        /// </summary>
        void Dispose();

        /// <summary>
        /// This function must be called before any other. There is no feedback for a successful connection, but a subsequent attempt to connect will return the message "Already connected."
        /// </summary>
        /// <param name="host">host name or IP address of the machine where TWS is running. Leave blank to connect to the local host.</param>
        /// <param name="port">must match the port specified in TWS on the Configure>API>Socket Port field.</param>
        /// <param name="clientId">A number used to identify this client connection. All orders placed/modified from this client will be associated with this client identifier.
        /// Each client MUST connect with a unique clientId.</param>
        void Connect(String host, int port, int clientId);

        /// <summary>
        /// Call this method to terminate the connections with TWS. Calling this method does not cancel orders that have already been sent.
        /// </summary>
        void Disconnect();

        /// <summary>
        /// Call the cancelScannerSubscription() method to stop receiving market scanner results. 
        /// </summary>
        /// <param name="tickerId">the Id that was specified in the call to reqScannerSubscription().</param>
        void CancelScannerSubscription(int tickerId);

        /// <summary>
        /// Call the reqScannerParameters() method to receive an XML document that describes the valid parameters that a scanner subscription can have.
        /// </summary>
        void RequestScannerParameters();

        /// <summary>
        /// Call the reqScannerSubscription() method to start receiving market scanner results through the scannerData() EWrapper method. 
        /// </summary>
        /// <param name="tickerId">the Id for the subscription. Must be a unique value. When the subscription  data is received, it will be identified by this Id. This is also used when canceling the scanner.</param>
        /// <param name="subscription">summary of the scanner subscription parameters including filters.</param>
        void RequestScannerSubscription(int tickerId, ScannerSubscription subscription);

        /// <summary>
        /// Call this method to request market data. The market data will be returned by the tickPrice, tickSize, tickOptionComputation(), tickGeneric(), tickString() and tickEFP() methods.
        /// </summary>
        /// <param name="tickerId">the ticker id. Must be a unique value. When the market data returns, it will be identified by this tag. This is also used when canceling the market data.</param>
        /// <param name="contract">this structure contains a description of the contract for which market data is being requested.</param>
        /// <param name="genericTickList">comma delimited list of generic tick types.  Tick types can be found here: (new Generic Tick Types page) </param>
        /// <param name="snapshot">Allows client to request snapshot market data.</param>
        /// <param name="marketDataOff">Market Data Off - used in conjunction with RTVolume Generic tick type causes only volume data to be sent.</param>
        void RequestMarketData(int tickerId, Contract contract, Collection<GenericTickType> genericTickList, bool snapshot, bool marketDataOff);

        /// <summary>
        /// Call the CancelHistoricalData method to stop receiving historical data results.
        /// </summary>
        /// <param name="tickerId">the Id that was specified in the call to <see cref="IBClient.RequestHistoricalData(int,Krs.Ats.IBNet.Contract,System.DateTime,System.TimeSpan,Krs.Ats.IBNet.BarSize,Krs.Ats.IBNet.HistoricalDataType,int)"/>.</param>
        void CancelHistoricalData(int tickerId);

        /// <summary>
        /// Call the CancelRealTimeBars() method to stop receiving real time bar results. 
        /// </summary>
        /// <param name="tickerId">The Id that was specified in the call to <see cref="IBClient.RequestRealTimeBars"/>.</param>
        void CancelRealTimeBars(int tickerId);

        /// <summary>
        /// Call the reqHistoricalData() method to start receiving historical data results through the historicalData() EWrapper method. 
        /// </summary>
        /// <param name="tickerId">the Id for the request. Must be a unique value. When the data is received, it will be identified by this Id. This is also used when canceling the historical data request.</param>
        /// <param name="contract">this structure contains a description of the contract for which market data is being requested.</param>
        /// <param name="endDateTime">Date is sent after a .ToUniversalTime, so make sure the kind property is set correctly, and assumes GMT timezone. Use the format yyyymmdd hh:mm:ss tmz, where the time zone is allowed (optionally) after a space at the end.</param>
        /// <param name="duration">This is the time span the request will cover, and is specified using the format:
        /// <integer /> <unit />, i.e., 1 D, where valid units are:
        /// S (seconds)
        /// D (days)
        /// W (weeks)
        /// M (months)
        /// Y (years)
        /// If no unit is specified, seconds are used. "years" is currently limited to one.
        /// </param>
        /// <param name="barSizeSetting">
        /// specifies the size of the bars that will be returned (within IB/TWS limits). Valid values include:
        /// <list type="table">
        /// <listheader>
        ///     <term>Bar Size</term>
        ///     <description>Parametric Value</description>
        /// </listheader>
        /// <item>
        ///     <term>1 sec</term>
        ///     <description>1</description>
        /// </item>
        /// <item>
        ///     <term>5 secs</term>
        ///     <description>2</description>
        /// </item>
        /// <item>
        ///     <term>15 secs</term>
        ///     <description>3</description>
        /// </item>
        /// <item>
        ///     <term>30 secs</term>
        ///     <description>4</description>
        /// </item>
        /// <item>
        ///     <term>1 min</term>
        ///     <description>5</description>
        /// </item>
        /// <item>
        ///     <term>2 mins</term>
        ///     <description>6</description>
        /// </item>
        /// <item>
        ///     <term>5 mins</term>
        ///     <description>7</description>
        /// </item>
        /// <item>
        ///     <term>15 mins</term>
        ///     <description>8</description>
        /// </item>
        /// <item>
        ///     <term>30 mins</term>
        ///     <description>9</description>
        /// </item>
        /// <item>
        ///     <term>1 hour</term>
        ///     <description>10</description>
        /// </item>
        /// <item>
        ///     <term>1 day</term>
        ///     <description>11</description>
        /// </item>
        /// <item>
        ///     <term>1 week</term>
        ///     <description></description>
        /// </item>
        /// <item>
        ///     <term>1 month</term>
        ///     <description></description>
        /// </item>
        /// <item>
        ///     <term>3 months</term>
        ///     <description></description>
        /// </item>
        /// <item>
        ///     <term>1 year</term>
        ///     <description></description>
        /// </item>
        /// </list>
        /// </param>
        /// <param name="whatToShow">determines the nature of data being extracted. Valid values include:
        /// TRADES
        /// MIDPOINT
        /// BID
        /// ASK
        /// BID/ASK
        /// </param>
        /// <param name="useRth">
        /// determines whether to return all data available during the requested time span, or only data that falls within regular trading hours. Valid values include:
        /// 0 - all data is returned even where the market in question was outside of its regular trading hours.
        /// 1 - only data within the regular trading hours is returned, even if the requested time span falls partially or completely outside of the RTH.
        /// </param>
        void RequestHistoricalData(int tickerId, Contract contract, DateTime endDateTime, TimeSpan duration,
            BarSize barSizeSetting, HistoricalDataType whatToShow, int useRth);

        /// <summary>
        /// Call the reqHistoricalData() method to start receiving historical data results through the historicalData() EWrapper method. 
        /// </summary>
        /// <param name="tickerId">the Id for the request. Must be a unique value. When the data is received, it will be identified by this Id. This is also used when canceling the historical data request.</param>
        /// <param name="contract">this structure contains a description of the contract for which market data is being requested.</param>
        /// <param name="endDateTime">Date is sent after a .ToUniversalTime, so make sure the kind property is set correctly, and assumes GMT timezone. Use the format yyyymmdd hh:mm:ss tmz, where the time zone is allowed (optionally) after a space at the end.</param>
        /// <param name="duration">This is the time span the request will cover, and is specified using the format:
        /// <integer /> <unit />, i.e., 1 D, where valid units are:
        /// S (seconds)
        /// D (days)
        /// W (weeks)
        /// M (months)
        /// Y (years)
        /// If no unit is specified, seconds are used. "years" is currently limited to one.
        /// </param>
        /// <param name="barSizeSetting">
        /// specifies the size of the bars that will be returned (within IB/TWS limits). Valid values include:
        /// <list type="table">
        /// <listheader>
        ///     <term>Bar Size</term>
        ///     <description>Parametric Value</description>
        /// </listheader>
        /// <item>
        ///     <term>1 sec</term>
        ///     <description>1</description>
        /// </item>
        /// <item>
        ///     <term>5 secs</term>
        ///     <description>2</description>
        /// </item>
        /// <item>
        ///     <term>15 secs</term>
        ///     <description>3</description>
        /// </item>
        /// <item>
        ///     <term>30 secs</term>
        ///     <description>4</description>
        /// </item>
        /// <item>
        ///     <term>1 min</term>
        ///     <description>5</description>
        /// </item>
        /// <item>
        ///     <term>2 mins</term>
        ///     <description>6</description>
        /// </item>
        /// <item>
        ///     <term>5 mins</term>
        ///     <description>7</description>
        /// </item>
        /// <item>
        ///     <term>15 mins</term>
        ///     <description>8</description>
        /// </item>
        /// <item>
        ///     <term>30 mins</term>
        ///     <description>9</description>
        /// </item>
        /// <item>
        ///     <term>1 hour</term>
        ///     <description>10</description>
        /// </item>
        /// <item>
        ///     <term>1 day</term>
        ///     <description>11</description>
        /// </item>
        /// <item>
        ///     <term>1 week</term>
        ///     <description></description>
        /// </item>
        /// <item>
        ///     <term>1 month</term>
        ///     <description></description>
        /// </item>
        /// <item>
        ///     <term>3 months</term>
        ///     <description></description>
        /// </item>
        /// <item>
        ///     <term>1 year</term>
        ///     <description></description>
        /// </item>
        /// </list>
        /// </param>
        /// <param name="whatToShow">determines the nature of data being extracted. Valid values include:
        /// TRADES
        /// MIDPOINT
        /// BID
        /// ASK
        /// BID/ASK
        /// </param>
        /// <param name="useRth">
        /// determines whether to return all data available during the requested time span, or only data that falls within regular trading hours. Valid values include:
        /// 0 - all data is returned even where the market in question was outside of its regular trading hours.
        /// 1 - only data within the regular trading hours is returned, even if the requested time span falls partially or completely outside of the RTH.
        /// </param>
        void RequestHistoricalData(int tickerId, Contract contract, DateTime endDateTime, string duration,
            BarSize barSizeSetting, HistoricalDataType whatToShow, int useRth);

        /// <summary>
        /// Call this function to download all details for a particular underlying. the contract details will be received via the contractDetails() function on the EWrapper.
        /// </summary>
        /// <param name="requestId">Request Id for Contract Details</param>
        /// <param name="contract">summary description of the contract being looked up.</param>
        void RequestContractDetails(int requestId, Contract contract);

        /// <summary>
        /// Call the reqRealTimeBars() method to start receiving real time bar results through the realtimeBar() EWrapper method.
        /// </summary>
        /// <param name="tickerId">The Id for the request. Must be a unique value. When the data is received, it will be identified
        /// by this Id. This is also used when canceling the historical data request.</param>
        /// <param name="contract">This structure contains a description of the contract for which historical data is being requested.</param>
        /// <param name="barSize">Currently only 5 second bars are supported, if any other value is used, an exception will be thrown.</param>
        /// <param name="whatToShow">Determines the nature of the data extracted. Valid values include:
        /// TRADES
        /// BID
        /// ASK
        /// MIDPOINT
        /// </param>
        /// <param name="useRth">useRth – Regular Trading Hours only. Valid values include:
        /// 0 = all data available during the time span requested is returned, including time intervals when the market in question was outside of regular trading hours.
        /// 1 = only data within the regular trading hours for the product requested is returned, even if the time time span falls partially or completely outside.
        /// </param>
        void RequestRealTimeBars(int tickerId, Contract contract, int barSize, RealTimeBarType whatToShow, bool useRth);

        /// <summary>
        /// Call this method to request market depth for a specific contract. The market depth will be returned by the updateMktDepth() and updateMktDepthL2() methods.
        /// </summary>
        /// <param name="tickerId">the ticker Id. Must be a unique value. When the market depth data returns, it will be identified by this tag. This is also used when canceling the market depth.</param>
        /// <param name="contract">this structure contains a description of the contract for which market depth data is being requested.</param>
        /// <param name="numberOfRows">specifies the number of market depth rows to return.</param>
        void RequestMarketDepth(int tickerId, Contract contract, int numberOfRows);

        /// <summary>
        /// After calling this method, market data for the specified Id will stop flowing.
        /// </summary>
        /// <param name="tickerId">the Id that was specified in the call to reqMktData().</param>
        void CancelMarketData(int tickerId);

        /// <summary>
        /// After calling this method, market depth data for the specified Id will stop flowing.
        /// </summary>
        /// <param name="tickerId">the Id that was specified in the call to reqMktDepth().</param>
        void CancelMarketDepth(int tickerId);

        /// <summary>
        /// Call the exerciseOptions() method to exercise options. 
        /// “SMART” is not an allowed exchange in exerciseOptions() calls, and that TWS does a moneyness request for the position in question whenever any API initiated exercise or lapse is attempted.
        /// </summary>
        /// <param name="tickerId">the Id for the exercise request.</param>
        /// <param name="contract">this structure contains a description of the contract to be exercised.  If no multiplier is specified, a default of 100 is assumed.</param>
        /// <param name="exerciseAction">this can have two values:
        /// 1 = specifies exercise
        /// 2 = specifies lapse
        /// </param>
        /// <param name="exerciseQuantity">the number of contracts to be exercised</param>
        /// <param name="account">specifies whether your setting will override the system's natural action. For example, if your action is "exercise" and the option is not in-the-money, by natural action the option would not exercise. If you have override set to "yes" the natural action would be overridden and the out-of-the money option would be exercised. Values are: 
        /// 0 = no
        /// 1 = yes
        /// </param>
        /// <param name="overrideRenamed">
        /// specifies whether your setting will override the system's natural action. For example, if your action is "exercise" and the option is not in-the-money, by natural action the option would not exercise. If you have override set to "yes" the natural action would be overridden and the out-of-the money option would be exercised. Values are: 
        /// 0 = no
        /// 1 = yes
        /// </param>
        void ExerciseOptions(int tickerId, Contract contract, int exerciseAction, int exerciseQuantity,
            String account, int overrideRenamed);

        /// <summary>
        /// Call this method to place an order. The order status will be returned by the orderStatus event.
        /// </summary>
        /// <param name="orderId">the order Id. You must specify a unique value. When the order status returns, it will be identified by this tag. This tag is also used when canceling the order.</param>
        /// <param name="contract">this structure contains a description of the contract which is being traded.</param>
        /// <param name="order">this structure contains the details of the order.
        /// Each client MUST connect with a unique clientId.</param>
        void PlaceOrder(int orderId, Contract contract, Order order);

        /// <summary>
        /// Call this function to start getting account values, portfolio, and last update time information.
        /// </summary>
        /// <param name="subscribe">If set to TRUE, the client will start receiving account and portfolio updates. If set to FALSE, the client will stop receiving this information.</param>
        /// <param name="acctCode">the account code for which to receive account and portfolio updates.</param>
        void RequestAccountUpdates(bool subscribe, String acctCode);

        /// <summary>
        /// When this method is called, the execution reports that meet the filter criteria are downloaded to the client via the execDetails() method.
        /// </summary>
        /// <param name="requestId">Id of the request</param>
        /// <param name="filter">the filter criteria used to determine which execution reports are returned.</param>
        void RequestExecutions(int requestId, ExecutionFilter filter);

        /// <summary>
        /// Call this method to cancel an order.
        /// </summary>
        /// <param name="orderId">Call this method to cancel an order.</param>
        void CancelOrder(int orderId);

        /// <summary>
        /// Call this method to request the open orders that were placed from this client. Each open order will be fed back through the openOrder() and orderStatus() functions on the EWrapper.
        /// 
        /// The client with a clientId of "0" will also receive the TWS-owned open orders. These orders will be associated with the client and a new orderId will be generated. This association will persist over multiple API and TWS sessions.
        /// </summary>
        void RequestOpenOrders();

        /// <summary>
        /// Returns one next valid Id...
        /// </summary>
        /// <param name="numberOfIds">Has No Effect</param>
        void RequestIds(int numberOfIds);

        /// <summary>
        /// Call this method to start receiving news bulletins. Each bulletin will be returned by the updateNewsBulletin() method.
        /// </summary>
        /// <param name="allMessages">if set to TRUE, returns all the existing bulletins for the current day and any new ones. IF set to FALSE, will only return new bulletins.</param>
        void RequestNewsBulletins(bool allMessages);

        /// <summary>
        /// Call this method to stop receiving news bulletins.
        /// </summary>
        void CancelNewsBulletins();

        /// <summary>
        /// Call this method to request that newly created TWS orders be implicitly associated with the client. When a new TWS order is created, the order will be associated with the client and fed back through the openOrder() and orderStatus() methods on the EWrapper.
        /// 
        /// TWS orders can only be bound to clients with a clientId of “0”.
        /// </summary>
        /// <param name="autoBind">If set to TRUE, newly created TWS orders will be implicitly associated with the client. If set to FALSE, no association will be made.</param>
        void RequestAutoOpenOrders(bool autoBind);

        /// <summary>
        /// Call this method to request the open orders that were placed from all clients and also from TWS. Each open order will be fed back through the openOrder() and orderStatus() functions on the EWrapper.
        /// 
        /// No association is made between the returned orders and the requesting client.
        /// </summary>
        void RequestAllOpenOrders();

        /// <summary>
        /// Call this method to request the list of managed accounts. The list will be returned by the managedAccounts() function on the EWrapper.
        /// 
        /// This request can only be made when connected to a Financial Advisor (FA) account.
        /// </summary>
        void RequestManagedAccts();

        /// <summary>
        /// Call this method to request FA configuration information from TWS. The data returns in an XML string via the receiveFA() method.
        /// </summary>
        /// <param name="faDataType">
        /// faDataType - specifies the type of Financial Advisor configuration data being requested. Valid values include:
        /// 1 = GROUPS
        /// 2 = PROFILE
        /// 3 =ACCOUNT ALIASES
        /// </param>
        void RequestFA(FADataType faDataType);

        /// <summary>
        /// Call this method to request FA configuration information from TWS. The data returns in an XML string via a "receiveFA" ActiveX event.  
        /// </summary>
        /// <param name="faDataType">
        /// specifies the type of Financial Advisor configuration data being requested. Valid values include:
        /// 1 = GROUPS
        /// 2 = PROFILE
        /// 3 = ACCOUNT ALIASES</param>
        /// <param name="xml">the XML string containing the new FA configuration information.</param>
        void ReplaceFA(FADataType faDataType, String xml);

        /// <summary>
        /// Returns the current system time on the server side.
        /// </summary>
        void RequestCurrentTime();

        /// <summary>
        /// Request Fundamental Data
        /// </summary>
        /// <param name="requestId">Request Id</param>
        /// <param name="contract">Contract to request fundamental data for</param>
        /// <param name="reportType">Report Type</param>
        void RequestFundamentalData(int requestId, Contract contract, String reportType);

        /// <summary>
        /// Call this method to stop receiving Reuters global fundamental data.
        /// </summary>
        /// <param name="requestId">The ID of the data request.</param>
        void CancelFundamentalData(int requestId);

        /// <summary>
        /// Call this function to cancel a request to calculate volatility for a supplied option price and underlying price.
        /// </summary>
        /// <param name="reqId">The Ticker Id.</param>
        void CancelCalculateImpliedVolatility(int reqId);

        /// <summary>
        /// Calculates the Implied Volatility based on the user-supplied option and underlying prices.
        /// The calculated implied volatility is returned by tickOptionComputation( ) in a new tick type, CUST_OPTION_COMPUTATION, which is described below.
        /// </summary>
        /// <param name="requestId">Request Id</param>
        /// <param name="contract">Contract</param>
        /// <param name="optionPrice">Price of the option</param>
        /// <param name="underPrice">Price of teh underlying of the option</param>
        void RequestCalculateImpliedVolatility(int requestId, Contract contract, double optionPrice, double underPrice);

        /// <summary>
        /// Call this function to calculate option price and greek values for a supplied volatility and underlying price.
        /// </summary>
        /// <param name="reqId">The ticker ID.</param>
        /// <param name="contract">Describes the contract.</param>
        /// <param name="volatility">The volatility.</param>
        /// <param name="underPrice">Price of the underlying.</param>
        void RequestCalculateOptionPrice(int reqId, Contract contract, double volatility,
            double underPrice);

        /// <summary>
        /// Call this function to cancel a request to calculate option price and greek values for a supplied volatility and underlying price.
        /// </summary>
        /// <param name="reqId">The ticker id.</param>
        void CancelCalculateOptionPrice(int reqId);

        /// <summary>
        /// Request Global Cancel.
        /// </summary>
        void RequestGlobalCancel();

        /// <summary>
        /// The API can receive frozen market data from Trader Workstation. 
        /// Frozen market data is the last data recorded in our system. 
        /// During normal trading hours, the API receives real-time market data. 
        /// If you use this function, you are telling TWS to automatically switch to frozen market data after the close. 
        /// Then, before the opening of the next trading day, market data will automatically switch back to real-time market data.
        /// </summary>
        /// <param name="marketDataType">1 for real-time streaming market data or 2 for frozen market data.</param>
        void RequestMarketDataType(int marketDataType);

        /// <summary>
        /// The default level is ERROR. Refer to the API logging page for more details.
        /// </summary>
        /// <param name="serverLogLevel">
        /// logLevel - specifies the level of log entry detail used by the server (TWS) when processing API requests. Valid values include: 
        /// 1 = SYSTEM
        /// 2 = ERROR
        /// 3 = WARNING
        /// 4 = INFORMATION
        /// 5 = DETAIL
        /// </param>
        void SetServerLogLevel(LogLevel serverLogLevel);

        /// <summary>
        /// Tells the worker thread to stop, typically after completing its 
        /// current work item. (The thread is *not* guaranteed to have stopped
        /// by the time this method returns.)
        /// </summary>
        void Stop();
    }
}