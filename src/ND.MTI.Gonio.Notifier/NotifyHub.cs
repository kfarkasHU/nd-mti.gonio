using System.Collections.Generic;

namespace ND.MTI.Gonio.Notifier
{
    public static class NotifyHub
    {
        private static IList<NotifierCore> _notifiers;

        public static void Init()
        {
            _notifiers = new List<NotifierCore>();
        }

        public static void RegisterNotifier(NotifierCore notifier) =>
            _notifiers.Add(notifier);

        public static void AddMessage(string title, string body)
        {
            var context = NotifyContext.Create(body, title);

            foreach (var notifier in _notifiers)
                notifier.AddMessage(context);
        }

        public static void SendMessages()
        {
            foreach (var notifier in _notifiers)
                notifier.SendMessages();
        }
    }
}
