using System;
using System.Collections.Generic;
using System.Text;
using Krs.Ats.IBNet;
using System.Threading;
using Krs.Ats.IBNet.Contracts;

namespace Krs.Ats.TestApp
{
    class Program
    {
        private static int NextOrderId = 0;
        private static Contract TF;
        private static Contract TickNasdaq;
        private static Contract VolNasdaq;
        private static Contract AdNasdaq;
        private static Contract TickNyse;
        private static Contract VolNyse;
        private static Contract AdNyse;
        private static Contract YmEcbot;
        private static Contract ES;
        private static Contract SPY;
        private static Contract ZN;
        private static Contract ZB;
        private static Contract ZT;
        private static Contract ZF;
        private static IBClient client;
        static void Main(string[] args)
        {
            client = new IBClient();
            client.ThrowExceptions = true;

            client.TickPrice += client_TickPrice;
            client.TickSize += client_TickSize;
            client.Error += client_Error;
            client.NextValidId += client_NextValidId;
            client.UpdateMarketDepth += client_UpdateMktDepth;
            client.RealTimeBar += client_RealTimeBar;
            client.OrderStatus += client_OrderStatus;
            client.ExecDetails += client_ExecDetails;
            client.HistoricalData += client_HistoricalData;

            Console.WriteLine("Connecting to IB.");
            client.Connect("127.0.0.1", 7496, 0);
            //TF = new Contract("TF", "NYBOT", SecurityType.Future, "USD", "200909");
            //YmEcbot = new Contract("YM", "ECBOT", SecurityType.Future, "USD", "200909");
            ES = new Contract("ES", "GLOBEX", SecurityType.Future, "USD", "201609");
            //SPY = new Contract("SPY", "GLOBEX", SecurityType.Future, "USD", "200909");
            //ZN = new Contract("ZN", "ECBOT", SecurityType.Future, "USD", "200909");
            //ZB = new Contract("ZB", "ECBOT", SecurityType.Future, "USD", "201609");
            //ZT = new Contract("ZT", "ECBOT", SecurityType.Future, "USD", "200909");
            //ZF = new Contract("ZF", "ECBOT", SecurityType.Future, "USD", "200909");
            var dbk = new Contract();
            dbk.ContractId = 14121;
            dbk.Exchange = "IBIS";
            //var dbk = new Contract("DBK", "IBIS", SecurityType.Stock, "EUR");
            client.RequestHistoricalData(1, ES, DateTime.Today.AddDays(1), "5 D", BarSize.OneDay, HistoricalDataType.Trades, 0);
            //var eurusd = new Contract();
            //eurusd.ContractId = 12087792;
            //eurusd.Exchange = "IDEALPRO";
            //var eurusd = new Contract("EUR", "IDEALPRO", SecurityType.Cash, "USD");
            //client.RequestRealTimeBars(1, eurusd, 5, RealTimeBarType.Midpoint, true);
            //TickNasdaq = new Contract("TICK-NASD", "NASDAQ", SecurityType.Index, "USD");
            //VolNasdaq = new Contract("VOL-NASD", "NASDAQ", SecurityType.Index, "USD");
            //AdNasdaq = new Contract("AD-NASD", "NASDAQ", SecurityType.Index, "USD");


            //TickNyse = new Contract("TICK-NYSE", "NYSE", SecurityType.Index, "USD");
            //VolNyse = new Contract("VOL-NYSE", "NYSE", SecurityType.Index, "USD");
            //AdNyse = new Contract("AD-NYSE", "NYSE", SecurityType.Index, "USD");

            //New Contract Creation Features
            //Equity Google = new Equity("GOOG");

            //Forex Test
            //Forex EUR = new Forex("EUR", "USD");

            //client.RequestMarketData(14, Google, null, false, false);
            //client.RequestMarketDepth(15, Google, 5);
            //client.RequestRealTimeBars(16, Google, 5, RealTimeBarType.Trades,false);
            //client.RequestMarketData(17, EUR, null, false, false);

            //Order BuyContract = new Order();
            //BuyContract.Action = ActionSide.Buy;
            //BuyContract.OutsideRth = false;
            //BuyContract.LimitPrice = 560;
            //BuyContract.OrderType = OrderType.Limit;
            //BuyContract.TotalQuantity = 1;
            ////client.PlaceOrder(503, TF, BuyContract);

            //client.RequestExecutions(34, new ExecutionFilter());

            //client.RequestAllOpenOrders();

            while(true)
            {
                Thread.Sleep(100);
            }
        }

        private static void client_HistoricalData(object sender, HistoricalDataEventArgs e)
        {
            Console.WriteLine(String.Format($"{e.Date},{e.Open},{e.High},{e.Low},{e.Close},{e.Volume},{e.Wap}"));
        }

        static void client_ExecDetails(object sender, ExecDetailsEventArgs e)
        {
            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}",
                e.Contract.Symbol, e.Execution.AccountNumber, e.Execution.ClientId, e.Execution.Exchange, e.Execution.ExecutionId,
                e.Execution.Liquidation, e.Execution.OrderId, e.Execution.PermId, e.Execution.Price, e.Execution.Shares, e.Execution.Side, e.Execution.Time);
        }

        static void client_RealTimeBar(object sender, RealTimeBarEventArgs e)
        {
            Console.WriteLine("Received Real Time Bar: " + e.Close);
        }

        static void client_OrderStatus(object sender, OrderStatusEventArgs e)
        {
            Console.WriteLine("Order Placed.");
        }

        static void client_UpdateMktDepth(object sender, UpdateMarketDepthEventArgs e)
        {
            Console.WriteLine("Tick ID: " + e.TickerId + " Tick Side: " + EnumDescConverter.GetEnumDescription(e.Side) +
                              " Tick Size: " + e.Size + " Tick Price: " + e.Price + " Tick Position: " + e.Position +
                              " Operation: " + EnumDescConverter.GetEnumDescription(e.Operation));
        }

        static void client_NextValidId(object sender, NextValidIdEventArgs e)
        {
            Console.WriteLine("Next Valid Id: " + e.OrderId);
            NextOrderId = e.OrderId;
        }

        static void client_TickSize(object sender, TickSizeEventArgs e)
        {
            Console.WriteLine("Tick Size: " + e.Size + " Tick Type: " + EnumDescConverter.GetEnumDescription(e.TickType));
        }

        static void client_Error(object sender, ErrorEventArgs e)
        {
            Console.WriteLine("Error: "+ e.ErrorMsg);
        }

        static void client_TickPrice(object sender, TickPriceEventArgs e)
        {
            Console.WriteLine("Price: " + e.Price + " Tick Type: " + EnumDescConverter.GetEnumDescription(e.TickType));
        }
    }
}
