using System;
using System.ComponentModel;
using System.Windows.Media;

namespace AccountingApp.Model
{
    class CategoryItem : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public int Id { get; set; }

        private string? _colorHex;
        public string? ColorHex
        {
            get { return _colorHex; }
            set { _colorHex = value; OnPropertyChanged(nameof(ColorHex)); }
        }

        private string? _title;
        public string? Title
        {
            get { return _title; }
            set { _title = value; OnPropertyChanged(nameof(Title));}
        }

        private string? _categoryCode;
        private bool disposedValue;

        public string? CategoryCode
        {
            get { return _categoryCode; }
            set { _categoryCode = value; OnPropertyChanged(nameof(CategoryCode));}
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
        // ~CategoryItem()
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
