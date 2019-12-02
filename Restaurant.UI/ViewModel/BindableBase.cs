﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Restaurant.UI.Helpers
{
    public class BindableBase : INotifyPropertyChanged
    {
        protected virtual void SetProperty<T>(ref T member, T val,
            [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(member, val)) return;

            member = val;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
