using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AccountingApp.Model
{
    internal class DataBaseAccess : IDisposable
    {
        private bool disposedValue;

        #region Finance actions

        internal async void AddFinanceItemAsync(FinanceItem item)
        {
            await Task.Run(() =>
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    db.FinanceItems.Add(item);
                    db.SaveChanges();
                }
            });
        }

        internal async void RemoveFinanceItemAsync(FinanceItem item)
        {
            await Task.Run(() =>
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    db.FinanceItems.Remove(item);
                    db.SaveChanges();
                }
            });
        }

        internal async void UpdateFinanceItemAsync(FinanceItem item)
        {
            await Task.Run(() =>
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    db.FinanceItems.Update(item);
                    db.SaveChanges();
                }
            });
        }

        internal FinanceItem[]? GetFinanceItems()
        {
            FinanceItem[]? items = null;

            using (ApplicationContext db = new ApplicationContext())
            {
                items = db.FinanceItems.ToList().ToArray();
            }

            return items;
        }

        internal async void UpdateFinanceRangeAsync(FinanceItem[] items)
        {
            await Task.Run(() =>
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                    db.FinanceItems.UpdateRange(items);
                    db.SaveChanges();
                }
            });
        }

        internal void UpdateFinanceRange(FinanceItem[] items)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                db.FinanceItems.UpdateRange(items);
                db.SaveChanges();
            }
        }

        #endregion

        #region Category actions

        internal async void AddCategoryItemAsync(CategoryItem item)
        {
            await Task.Run(() =>
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    db.CategoryItems.Add(item);
                    db.SaveChanges();
                }
            });
        }

        internal async void RemoveCategoryItemAsync(CategoryItem item)
        {
            await Task.Run(() =>
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    db.CategoryItems.Remove(item);
                    db.SaveChanges();
                }
            });
        }

        internal async void UpdateCategoryItemAsync(CategoryItem item)
        {
            await Task.Run(() =>
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    db.CategoryItems.Update(item);
                    db.SaveChanges();
                }
            });
        }

        internal CategoryItem[]? GetCategoryItems()
        {
            CategoryItem[]? items = null;

            using (ApplicationContext db = new ApplicationContext())
            {
                items = db.CategoryItems.ToList().ToArray();
            }

            return items;
        }

        #endregion

        #region Other

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
        // ~DataBaseAccess()
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

        #endregion
    }
}
