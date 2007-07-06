using System;
using System.Collections.Generic;
using System.Text;

namespace Krs.Ats.IBNet
{
    /// <summary>
    /// Update News Bulletin Event Arguments
    /// </summary>
    public class UpdateNewsBulletinEventArgs : EventArgs
    {
        private readonly int msgId;
        /// <summary>
        /// The bulletin ID, incrementing for each new bulletin.
        /// </summary>
        public int MsgId
        {
            get
            {
                return msgId;
            }
        }
        private readonly NewsType msgType;
        /// <summary>
        /// Specifies the type of bulletin.
        /// </summary>
        /// <seealso cref="NewsType"/>
        public NewsType MsgType
        {
            get
            {
                return msgType;
            }
        }
        private readonly string message;
        /// <summary>
        /// The bulletin's message text.
        /// </summary>
        public string Message
        {
            get
            {
                return message;
            }
        }
        private readonly string origExchange;
        /// <summary>
        /// The exchange from which this message originated.
        /// </summary>
        public string OrigExchange
        {
            get
            {
                return origExchange;
            }
        }

        /// <summary>
        /// Full Constructor
        /// </summary>
        /// <param name="msgId">The bulletin ID, incrementing for each new bulletin.</param>
        /// <param name="msgType">Specifies the type of bulletin.</param>
        /// <param name="message">The bulletin's message text.</param>
        /// <param name="origExchange">The exchange from which this message originated.</param>
        public UpdateNewsBulletinEventArgs(int msgId, NewsType msgType, string message, string origExchange)
        {
            this.msgId = msgId;
            this.origExchange = origExchange;
            this.message = message;
            this.msgType = msgType;
        }
    }
}