using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModels.ValueChangedMessage
{
    public class CheckStateMessage
    {
        public TerstType type { get; set; }
        public bool state { get; set; }
    }
    public class CheckStateChangedMessage : ValueChangedMessage<CheckStateMessage>
    {
        public CheckStateChangedMessage(CheckStateMessage value) : base(value)
        {
        }
    }
}
