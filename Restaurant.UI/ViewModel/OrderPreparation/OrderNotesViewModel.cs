using Prism.Events;
using Restaurant.UI.Event;
using Restaurant.UI.Helpers;
using Restaurant.UI.Interfaces.ViewModel.OrderPreparation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.UI.ViewModel.OrderPreparation
{
    public class OrderNotesViewModel : BindableBase, IOrderNotesViewModel
    {
        private IEventAggregator _eventAggregator;
        private string _notes;

        public OrderNotesViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        public string Notes
        {
            get { return _notes; }
            set
            {
                _notes = value;
                OnPropertyChanged();
                if (_notes != null)
                {
                    _eventAggregator.GetEvent<NotesChangedEvent>()
                        .Publish(_notes);
                }
            }
        }

    }
}
