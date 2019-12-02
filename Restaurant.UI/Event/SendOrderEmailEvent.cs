using Prism.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.UI.Event
{
    public class SendOrderEmailEvent : PubSubEvent<string>
    {
    }
}
