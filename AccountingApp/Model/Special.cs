using System;
using System.Windows.Forms;

namespace AccountingApp.Model
{
    static class Special
    {
        internal enum currencies
        {
            USD,
            EUR,
            UAH
        }

        /// <summary>
        /// Getting and returning path to folder
        /// </summary>
        /// <returns></returns>
        public static string? GetFolderPath()
        {
            using (var fbd = new FolderBrowserDialog())
            {
                string folderPath = String.Empty;
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    folderPath = fbd.SelectedPath;
                }

                return folderPath;
            }
        }

        /// <summary>
        /// Generating random code for new category item
        /// </summary>
        /// <returns></returns>
        internal static string GenerateCategoryCode()
        {
            Random rnd = new Random();
            int num = rnd.Next(100000, 1000000);
            return num.ToString();
        }


        /// <summary>
        /// Getting currency tag by index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        internal static string? GetCurrencyTag(int index)
        {
            switch (index)
            {
                case 0:
                    return nameof(currencies.USD);
                case 1:
                    return nameof(currencies.EUR);
                case 2:
                    return nameof(currencies.UAH);
            }

            return null;
        }


        /// <summary>
        /// Getting current time for adding to new finance item
        /// </summary>
        /// <returns></returns>
        internal static string? GetCurrentTime()
        {
            DateTime currentTime = DateTime.Now;

            int hours = currentTime.Hour;
            int minutes = currentTime.Minute;

            string amPm = hours < 12 ? "AM" : "PM";
            if (hours == 0)
                hours = 12;
            else if (hours > 12)
                hours -= 12;

            return $"{hours:D2}:{minutes:D2} {amPm}";
        }
    }
}
