namespace ND.MTI.Gonio.Notifier
{
    internal sealed class NotifyContext
    {
        private NotifyContext(string body, string title)
        {
            Body = body;
            Title = title;
        }

        internal static NotifyContext Create(string body, string title) =>
            new NotifyContext(body, title);

        internal string Body { get; private set; }
        internal string Title { get; private set; }
    }
}
