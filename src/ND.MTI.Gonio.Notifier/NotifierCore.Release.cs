#if !DEBUG

using System;
using System.Collections.Generic;

namespace ND.MTI.Gonio.Notifier
{
    public abstract class NotifierCore
    {
        private readonly IList<string> _targetAddresses;
        private readonly IList<NotifyContext> _messages;

        public NotifierCore(IList<string> addresses)
        {
            _targetAddresses = addresses;
            _messages = new List<NotifyContext>();
        }

        internal void AddMessage(NotifyContext context) =>
            _messages.Add(context);

        internal void SendMessages()
        {
            try
            {
                BeforeSendMessages();

                foreach (var message in _messages)
                    foreach (var target in _targetAddresses)
                        ExecuteMessage(target, message.Body, message.Title);

                _messages.Clear();

                AfterSendMessages();
            }
            catch (Exception)
            {
            }
        }

        protected virtual void OnException(Exception ex) { }
        protected abstract void BeforeSendMessages();
        protected abstract void AfterSendMessages();
        protected abstract void ExecuteMessage(string target, string body, string title);
    }
}

#endif
