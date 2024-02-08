using System;
using System.ComponentModel;

namespace AccountingApp.Model
{
    class FinanceItem : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public int Id { get; set; }

        private string? _title;
        public string? Title
        {
            get { return _title; }
            set { _title = value; OnPropertyChanged(nameof(Title)); }
        }

        private string? _description;
        public string? Description
        {
            get { return _description; }
            set { _description = value; OnPropertyChanged(nameof(Description)); }
        }

        private double _sum;
        public double Sum
        {
            get { return _sum; }
            set { _sum = value; OnPropertyChanged(nameof(Sum)); }
        }

        private string? _sign;
        public string? Sign
        {
            get { return _sign; }
            set { _sign = value; OnPropertyChanged(nameof(Sign)); }
        }

        private string? _sumColor;
        public string? SumColor
        {
            get { return _sumColor; }
            set { _sumColor = value; OnPropertyChanged(nameof(SumColor)); }
        }

        private string? _currency;
        public string? Currency
        {
            get { return _currency; }
            set { _currency = value; OnPropertyChanged(nameof(Currency)); }
        }

        private int? _year;
        public int? Year
        {
            get { return _year; }
            set { _year = value; OnPropertyChanged(nameof(Year)); }
        }

        private string? _month;
        public string? Month
        {
            get { return _month; }
            set { _month = value; OnPropertyChanged(nameof(Month)); }
        }

        private int? _day;
        public int? Day
        {
            get { return _day; }
            set { _day = value; OnPropertyChanged(nameof(Day)); }
        }

        private string? _dateForSort;
        public string? DateForSort
        {
            get { return _dateForSort; }
            set { _dateForSort = value; OnPropertyChanged(nameof(DateForSort)); }
        }

        private string? _date;
        public string? Date
        {
            get { return _date; }
            set { _date = value; OnPropertyChanged(nameof(Date)); }
        }

        private string? _timeForSort;
        public string? TimeForSort
        {
            get { return _timeForSort; }
            set { _timeForSort = value; OnPropertyChanged(nameof(TimeForSort)); }
        }

        private string? _time;
        public string? Time
        {
            get { return _time; }
            set { _time = value; OnPropertyChanged(nameof(Time)); }
        }

        private string? _color;
        public string? Color
        {
            get { return _color; }
            set { _color = value; OnPropertyChanged(nameof(Color)); }
        }

        private bool _isIncome;
        public bool IsIncome
        {
            get { return _isIncome; }
            set { _isIncome = value; OnPropertyChanged(nameof(IsIncome)); }
        }

        private string? _categoryId;
        private bool disposedValue;

        public string? CategoryId
        {
            get { return _categoryId; }
            set { _categoryId = value; OnPropertyChanged(nameof(CategoryId)); }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~FinanceItem()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
