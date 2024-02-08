using AccountingApp.Model;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Application = System.Windows.Application;
using LicenseContext = OfficeOpenXml.LicenseContext;
using MessageBox = System.Windows.MessageBox;

namespace AccountingApp.ViewModel
{
    internal class MainViewModel : INotifyPropertyChanged
    {

        //implementing interface for changing properties
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        
        //constructor
        public MainViewModel()
        {
            try
            {
                SetDefaulProperties();

                category_combobox_items = new ObservableCollection<CategoryItem>
                {
                new CategoryItem {Title = "No category", ColorHex = _defaultCategoryColor, CategoryCode = _defaultCategoryCode}
                };

                category_sort_items = new ObservableCollection<CategoryItem>
                {
                new CategoryItem {Title = "All", ColorHex = "#5A5A5A", CategoryCode = "000000"}
                };

                using (DataBaseAccess db = new DataBaseAccess())
                {
                    var category_items = db.GetCategoryItems();
                    var finance_items = db.GetFinanceItems();

                    if (category_items != null)
                    {
                        InitializeCategoryCollectionAsync(category_items);
                    }
                    if (finance_items != null)
                    {
                        InitializeFinanceCollectionsAsync(finance_items);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\n{ex.ToString()}");
            }
            finally
            {
                if (!File.Exists(configPath))
                    CreateConfigFile();
                SetConfigDefaultProperties();
                CalculateAndSetSum();
            }
        }

        #region Properties

        //collections
        #region Collections

        public ObservableCollection<CategoryItem>? categoryItems { get; set; }
        public ObservableCollection<CategoryItem>? category_combobox_items { get; set; }
        public ObservableCollection<CategoryItem>? category_sort_items { get; set; }

        private ObservableCollection<FinanceItem>? _financeItems;
        public ObservableCollection<FinanceItem>? financeItems
        {
            get { return _financeItems; }
            set
            {
                if (_financeItems != value)
                {
                    _financeItems = value;
                    OnPropertyChanged(nameof(financeItems));
                }
            }
        }
        public ObservableCollection<FinanceItem>? sortedFinanceItems { get; set; }

        #endregion

        //other
        #region Other properties

        private Configuration? configuration { get; set; }

        private string configPath { get; set; } = "settings.config";

        private string _incomeSign { get; set; } = "+";

        private string _expensesSign { get; set; } = "-";

        private string _defaultCategoryColor { get; set; } = "#808080";

        private string _defaultCategoryCode { get; set; } = "111111";

        private string _defaultDescription { get; set; } = "Описание отсутствует.";

        private string _greenSumColor { get; set; } = "#228d57";

        private string _redSumColor { get; set; } = "#b31424";

        private FinanceItem oldData { get; set; } = new FinanceItem();

        private CategoryItem oldCategory { get; set;} = new CategoryItem();

        private double _mainCurrentSum;
        public double MainCurrentSum
        {
            get { return _mainCurrentSum; }
            set { _mainCurrentSum = value; OnPropertyChanged(nameof(MainCurrentSum)); }
        }

        private bool _isPinned;
        public bool IsPinned
        {
            get { return _isPinned; }
            set 
            { 
                _isPinned = value; 
                OnPropertyChanged(nameof(IsPinned));

                if(configuration != null)
                {
                    configuration.AppSettings.Settings["is_pinned"].Value = value.ToString();
                    configuration.Save(ConfigurationSaveMode.Modified);
                }
            }
        }


        private WindowState _windowStateProp;
        public WindowState WindowStateProp
        {
            get { return _windowStateProp; }
            set 
            {
                _windowStateProp = value; 
                OnPropertyChanged(nameof(WindowStateProp));

                if(configuration != null)
                {
                    configuration.AppSettings.Settings["is_full_screen"].Value = value == WindowState.Maximized ? "true" : "false";
                    configuration.Save(ConfigurationSaveMode.Modified);
                }
            }
        }

        private string? _searchContent;
        public string? SearchContent
        {
            get { return _searchContent; }
            set
            {
                _searchContent = value;
                OnPropertyChanged(nameof(SearchContent));
            }
        }


        private bool? _isTrayActive;
        public bool? IsTrayActive
        {
            get { return _isTrayActive; }
            set 
            { 
                _isTrayActive = value; 
                OnPropertyChanged(nameof(IsTrayActive));
                
                if(configuration != null)
                {
                    configuration.AppSettings.Settings["tray_is_active"].Value = value.ToString() ?? "false";
                    configuration.Save(ConfigurationSaveMode.Modified);
                }
            }
        }

        private Visibility _convertButtonVisible;
        public Visibility ConvertButtonVisible
        {
            get { return _convertButtonVisible; }
            set { _convertButtonVisible = value; OnPropertyChanged(nameof(ConvertButtonVisible)); }
        }

        private Visibility _convertProgressVisible;
        public Visibility ConvertProgressVisible
        {
            get { return _convertProgressVisible; }
            set { _convertProgressVisible = value; OnPropertyChanged(nameof(ConvertProgressVisible)); }
        }


        private int? _convertProgressBarValue;
        public int? ConvertProgressBarValue
        {
            get { return _convertProgressBarValue; }
            set { _convertProgressBarValue = value; OnPropertyChanged(nameof(ConvertProgressBarValue)); }
        }


        private bool _isListUpdating;
        public bool IsListUpdating
        {
            get { return _isListUpdating; }
            set { _isListUpdating = value; OnPropertyChanged(nameof(IsListUpdating)); }
        }

        #endregion

        //selected
        #region Selected items / indices

        //left side panel
        private int _selectedSidePanelMenu;
        public int SelectedSidePanelMenu
        {
            get { return _selectedSidePanelMenu; }
            set { _selectedSidePanelMenu = value; OnPropertyChanged(nameof(SelectedSidePanelMenu)); }
        }


        private int _selectedFinanceItemIndex;
        public int SelectedFinanceItemIndex
        {
            get { return _selectedFinanceItemIndex;  }
            set { _selectedFinanceItemIndex = value; OnPropertyChanged(nameof(SelectedFinanceItemIndex)); }
        }


        private FinanceItem? _selectedFinanceItem;
        public FinanceItem? SelectedFinanceItem
        {
            get { return _selectedFinanceItem; }
            set { _selectedFinanceItem = value; OnPropertyChanged(nameof(SelectedFinanceItem)); }
        }


        private CategoryItem? _selectedCategoryItem;
        public CategoryItem? SelectedCategoryItem
        {
            get { return _selectedCategoryItem; }
            set { _selectedCategoryItem = value; OnPropertyChanged(nameof(SelectedCategoryItem)); }
        }

        //right side panel
        private int? _selectedRightPanelIndex;
        public int? SelectedRightPanelIndex
        {
            get { return _selectedRightPanelIndex; }
            set { _selectedRightPanelIndex = value; OnPropertyChanged(nameof(SelectedRightPanelIndex)); }
        }

        #endregion

        //category
        #region Panel for adding category

        private string? _categoryTitle;
        public string? CategoryTitle
        {
            get { return _categoryTitle; }
            set { _categoryTitle = value; OnPropertyChanged(nameof(CategoryTitle)); }
        }


        private string? _categoryColorHex;
        public string? CategoryColorHex
        {
            get { return _categoryColorHex; }
            set { _categoryColorHex = value; OnPropertyChanged(nameof(CategoryColorHex)); }
        }

        #endregion

        //add income
        #region Panel fo adding income

        private string? _incomeTitle;
        public string? IncomeTitle
        {
            get { return _incomeTitle; }
            set { _incomeTitle = value; OnPropertyChanged(nameof(IncomeTitle)); }
        }


        private string? _incomeDesc;
        public string? IncomeDesc
        {
            get { return _incomeDesc; }
            set { _incomeDesc = value; OnPropertyChanged(nameof(IncomeDesc)); }
        }


        private int? _selectedCurrencyIndexIncome;
        public int? SelectedCurrencyIndexIncome
        {
            get { return _selectedCurrencyIndexIncome; }
            set { _selectedCurrencyIndexIncome = value; OnPropertyChanged(nameof(SelectedCurrencyIndexIncome)); }
        }


        private double? _incomeSum;
        public double? IncomeSum
        {
            get { return _incomeSum; }
            set
            {
                if (!value.HasValue)
                {
                    throw new ArgumentException("Значение не может быть пустым", nameof(IncomeSum));
                }
                _incomeSum = value;
                OnPropertyChanged(nameof(IncomeSum));
            }
        }


        private bool? _incomeSumHasValidationError;
        public bool? IncomeSumHasValidationError
        {
            get { return _incomeSumHasValidationError; }
            set { _incomeSumHasValidationError = value; OnPropertyChanged(nameof(IncomeSumHasValidationError)); }
        }

        private CategoryItem? _selectedIncomeCategory;
        public CategoryItem? SelectedIncomeCategory
        {
            get { return _selectedIncomeCategory; }
            set { _selectedIncomeCategory = value; OnPropertyChanged(nameof(SelectedIncomeCategory)); }
        }


        private int? _selectedCategoryIncomeAdd; //index
        public int? SelectedCategoryIncomeAdd
        {
            get { return _selectedCategoryIncomeAdd; }
            set { _selectedCategoryIncomeAdd = value; OnPropertyChanged(nameof(SelectedCategoryIncomeAdd)); }
        }

        #endregion

        //add expenses
        #region Panel for adding expenses

        private string? _expensesTitle;
        public string? ExpensesTitle
        {
            get { return _expensesTitle; }
            set { _expensesTitle = value; OnPropertyChanged(nameof(ExpensesTitle)); }
        }


        private string? _expensesDesc;
        public string? ExpensesDesc
        {
            get { return _expensesDesc; }
            set { _expensesDesc = value; OnPropertyChanged(nameof(ExpensesDesc)); }
        }


        private int? _selectedCurrencyIndexExpenses;
        public int? SelectedCurrencyIndexExpenses
        {
            get { return _selectedCurrencyIndexExpenses; }
            set { _selectedCurrencyIndexExpenses = value; OnPropertyChanged(nameof(SelectedCurrencyIndexExpenses)); }
        }


        private double? _expensesSum;
        public double? ExpensesSum
        {
            get { return _expensesSum; }
            set { _expensesSum = value; OnPropertyChanged(nameof(ExpensesSum)); }
        }


        private bool? _expensesSumHasValidationError;
        public bool? ExpensesSumHasValidationError
        {
            get { return _expensesSumHasValidationError; }
            set { _expensesSumHasValidationError = value; OnPropertyChanged(nameof(ExpensesSumHasValidationError)); }
        }

        private CategoryItem? _selectedExpensesCategory;
        public CategoryItem? SelectedExpensesCategory
        {
            get { return _selectedExpensesCategory; }
            set { _selectedExpensesCategory = value; OnPropertyChanged(nameof(SelectedExpensesCategory)); }
        }


        private int? _selectedCategoryExpensesAdd; //index
        public int? SelectedCategoryExpensesAdd
        {
            get { return _selectedCategoryExpensesAdd; }
            set { _selectedCategoryExpensesAdd = value; OnPropertyChanged(nameof(SelectedCategoryExpensesAdd)); }
        }

        #endregion

        //edit finance
        #region Panel for editing finance

        private int? _selectedCurrencyIndexEdit;
        public int? SelectedCurrencyIndexEdit
        {
            get { return _selectedCurrencyIndexEdit; }
            set { _selectedCurrencyIndexEdit = value; OnPropertyChanged(nameof(SelectedCurrencyIndexEdit)); }
        }


        private bool? _editSumHasValidationError;
        public bool? EditSumHasValidationError
        {
            get { return _editSumHasValidationError; }
            set { _editSumHasValidationError = value; OnPropertyChanged(nameof(EditSumHasValidationError)); }
        }


        private CategoryItem? _selectedFinanceCategoryEdit;
        public CategoryItem? SelectedFinanceCategoryEdit
        {
            get { return _selectedFinanceCategoryEdit; }
            set { _selectedFinanceCategoryEdit = value; OnPropertyChanged(nameof(SelectedFinanceCategoryEdit)); }
        }


        private int? _selectedFinanceIndexCategoryEdit;
        public int? SelectedFinanceIndexCategoryEdit
        {
            get { return _selectedFinanceIndexCategoryEdit; }
            set { _selectedFinanceIndexCategoryEdit = value; OnPropertyChanged(nameof(SelectedFinanceIndexCategoryEdit)); }
        }


        private int? _selectedTypeIndexEdit;
        public int? SelectedTypeIndexEdit
        {
            get { return _selectedTypeIndexEdit; }
            set { _selectedTypeIndexEdit = value; OnPropertyChanged(nameof(SelectedTypeIndexEdit)); }
        }

        #endregion

        //sort finance
        #region Panel for sorting finance

        private double? _sortingSum;
        public double? SortingSum
        {
            get { return _sortingSum; }
            set
            {
                _sortingSum = value; OnPropertyChanged(nameof(SortingSum));
            }
        }


        private int? _sortingSumIndex;
        public int? SortingSumIndex
        {
            get { return _sortingSumIndex; }
            set { _sortingSumIndex = value; OnPropertyChanged(nameof(SortingSumIndex)); }
        }


        private DateTime? _sortingDate;
        public DateTime? SortingDate
        {
            get { return _sortingDate; }
            set { _sortingDate = value; OnPropertyChanged(nameof(SortingDate)); }
        }


        private int? _sortingDateIndex;
        public int? SortingDateIndex
        {
            get { return _sortingDateIndex; }
            set { _sortingDateIndex = value; OnPropertyChanged(nameof(SortingDateIndex)); }
        }


        private CategoryItem? _sortingCategory;
        public CategoryItem? SortingCategory
        {
            get { return _sortingCategory; }
            set
            {
                _sortingCategory = value;
                OnPropertyChanged(nameof(SortingCategory));
            }
        }


        private int? _sortingCategoryIndex;
        public int? SortingCategoryIndex
        {
            get { return _sortingCategoryIndex; }
            set { _sortingCategoryIndex = value; OnPropertyChanged(nameof(SortingCategoryIndex)); }
        }


        private int? _sortingTypeIndex;
        public int? SortingTypeIndex
        {
            get { return _sortingTypeIndex; }
            set { _sortingTypeIndex = value; OnPropertyChanged(nameof(SortingTypeIndex)); }
        }


        private int? _sortingCurrencyIndex;
        public int? SortingCurrencyIndex
        {
            get { return _sortingCurrencyIndex; }
            set { _sortingCurrencyIndex = value; OnPropertyChanged(nameof(SortingCurrencyIndex)); }
        }

        #endregion

        //convert to Excel
        #region For converting (formating) to Excel

        private string? _excelFilePath;
        public string? ExcelFilePath
        {
            get { return _excelFilePath; }
            set 
            { 
                _excelFilePath = value; 
                OnPropertyChanged(nameof(ExcelFilePath));

                if(configuration != null)
                {
                    configuration.AppSettings.Settings["save_excel_path"].Value = value ?? String.Empty;
                    configuration.Save(ConfigurationSaveMode.Modified);
                }
            }
        }


        private CategoryItem? _selectedConvertingCategory;
        public CategoryItem? SelectedConvertingCategory
        {
            get { return _selectedConvertingCategory; }
            set { _selectedConvertingCategory = value; OnPropertyChanged(nameof(SelectedConvertingCategory)); }
        }


        private int? _selectedConvertingCategoryIndex;
        public int? SelectedConvertingCategoryIndex
        {
            get { return _selectedConvertingCategoryIndex; }
            set 
            {   _selectedConvertingCategoryIndex = value; 
                OnPropertyChanged(nameof(SelectedConvertingCategoryIndex)); 
                
                if(configuration != null)
                {
                    configuration.AppSettings.Settings["selected_convert_category_index"].Value = value.ToString() ?? "0";
                    configuration.Save(ConfigurationSaveMode.Modified);
                }
            }
        }


        private bool? _isConverting;
        public bool? IsConverting
        {
            get { return _isConverting; }
            set { _isConverting = value; OnPropertyChanged(nameof(IsConverting)); }
        }


        private bool? _isUsingSorted;
        public bool? IsUsingSorted
        {
            get { return _isUsingSorted; }
            set 
            {
                _isUsingSorted = value; 
                OnPropertyChanged(nameof(IsUsingSorted));

                if(configuration != null)
                {
                    configuration.AppSettings.Settings["is_using_sorted"].Value = value.ToString() ?? "false";
                    configuration.Save(ConfigurationSaveMode.Modified);
                }
            }
        }


        private string? _convertedFileName;
        public string? ConvertedFileName
        {
            get { return _convertedFileName; }
            set { _convertedFileName = value; OnPropertyChanged(nameof(ConvertedFileName)); }
        }

        #endregion

        //Currency info
        #region

        private double _usdtouah;
        public double UsdToUah
        {
            get { return _usdtouah; }
            set 
            { 
                _usdtouah = value; 
                OnPropertyChanged(nameof(UsdToUah));

                if(configuration != null)
                {
                    configuration.AppSettings.Settings["usd_uah"].Value = value.ToString();
                    configuration.Save(ConfigurationSaveMode.Modified);
                }
            }
        }

        private double _eurtouah;
        public double EurToUah
        {
            get { return _eurtouah; }
            set 
            { 
                _eurtouah = value; 
                OnPropertyChanged(nameof(EurToUah));

                if(configuration != null)
                {
                    configuration.AppSettings.Settings["eur_uah"].Value = value.ToString();
                    configuration.Save(ConfigurationSaveMode.Modified);
                }
            }
        }

        private bool _usdHasValidError;
        public bool UsdHasValidError
        {
            get { return _usdHasValidError; }
            set { _usdHasValidError = value; OnPropertyChanged(nameof(_usdHasValidError)); }
        }

        private bool _eurHasValidError;
        public bool EurHasValidError
        {
            get { return _eurHasValidError; }
            set { _eurHasValidError = value; OnPropertyChanged(nameof(_eurHasValidError)); }
        }

        private string? _currencyLabelForeColor;
        public string? CurrencyLabelForeColor
        {
            get { return _currencyLabelForeColor; }
            set { _currencyLabelForeColor = value; OnPropertyChanged(nameof(CurrencyLabelForeColor)); }
        }

        private bool? _currencyWarningState;
        public bool? CurrencyWarningState
        {
            get { return _currencyWarningState; }
            set { _currencyWarningState = value; OnPropertyChanged(nameof(CurrencyWarningState)); }
        }

        #endregion

        #endregion

        #region Commands

        //for debugging
        private ICommand? _testCommand;
        public ICommand? TestCommand
        {
            get
            {
                if(_testCommand == null)
                {
                    _testCommand = new RelayCommand((p) =>
                    {
                        //TestMethod();
                    });
                }

                return _testCommand;
            }
        }


        private ICommand? _closeWindowCommand;
        public ICommand? CloseWindowCommand
        {
            get
            {
                if(_closeWindowCommand == null)
                {
                    _closeWindowCommand = new RelayCommand((p) =>
                    {
                        MainWindow? window = p as MainWindow;

                        if (window != null)
                        {
                            window.Close();
                        }
                    });
                }

                return _closeWindowCommand;
            }
        }


        private ICommand? _closeByTrayCommand;
        public ICommand? CloseByTrayCommand
        {
            get
            {
                if(_closeByTrayCommand == null)
                {
                    _closeByTrayCommand = new RelayCommand((p) =>
                    {
                        MainWindow? window = p as MainWindow;

                        if (window != null)
                        {
                            if(IsTrayActive == true)
                            {
                                IsTrayActive = false;
                                window.Close();
                                IsTrayActive = true;
                            }
                            else if (IsTrayActive == false)
                            {
                                IsTrayActive = false;
                                window.Close();
                            }
                        }
                    });
                }

                return _closeByTrayCommand;
            }
        }


        private ICommand? _windowStateChanged;
        public ICommand? WindowStateChanged
        {
            get
            {
                if(_windowStateChanged == null)
                {
                    _windowStateChanged = new RelayCommand((p) =>
                    {
                        MainWindow? window = p as MainWindow;

                        if (window != null)
                        {
                            Grid? mGrid = window.mainGrid as Grid;

                            if (mGrid != null)
                            {
                                if (window.WindowState == WindowState.Maximized)
                                {
                                    mGrid.Margin = new Thickness(10, 6, 10, 0);
                                }
                                else if (window.WindowState == WindowState.Normal)
                                {
                                    mGrid.Margin = new Thickness(0, 1, 0, 0);
                                }
                            }
                        }
                    });
                }

                return _windowStateChanged;
            }
        }


        private ICommand? _stateChangeCommand;
        public ICommand? StateChangeCommand
        {
            get
            {
                if (_stateChangeCommand == null)
                {
                    _stateChangeCommand = new RelayCommand((p) =>
                    {
                        MainWindow? window = p as MainWindow;

                        if(window != null)
                        {
                            window.WindowState = window.WindowState == WindowState.Maximized 
                            ? WindowState.Normal 
                            : WindowState.Maximized;
                        }
                    });
                }

                return _stateChangeCommand;
            }
        }


        private ICommand? _minimizeWindowCommand;
        public ICommand? MinimizeWindowCommand
        {
            get
            {
                if (_minimizeWindowCommand == null)
                {
                    _minimizeWindowCommand = new RelayCommand((p) =>
                    {
                        MainWindow? window = p as MainWindow;

                        if (window != null)
                        {
                            window.WindowState = WindowState.Minimized;
                        }
                    });
                } 

                return _minimizeWindowCommand;
            }
        }


        private ICommand? _showWindowCommand;
        public ICommand? ShowWindowCommand
        {
            get
            {
                if(_showWindowCommand == null)
                {
                    _showWindowCommand = new RelayCommand((p) =>
                    {
                        MainWindow? window = p as MainWindow;

                        if (window != null)
                        {
                            if (!window.IsVisible)
                            {
                                window.Show();
                            }
                        }
                    });
                }

                return _showWindowCommand;
            }
        }

        private ICommand? _pinUnpinCommand;
        public ICommand PinUnpinCommand
        {
            get
            {
                if (_pinUnpinCommand == null)
                {
                    _pinUnpinCommand = new RelayCommand((p) =>
                    {
                        MainWindow? window = p as MainWindow;

                        if (window != null)
                        {
                            if (!IsPinned)
                            {
                                window.Topmost = true;
                                IsPinned = true;
                            }
                            else
                            {
                                window.Topmost = false;
                                IsPinned = false;
                            }
                        }
                    });
                }

                return _pinUnpinCommand;
            }
        }


        private ICommand? _switchToAddIncome;
        public ICommand SwitchToAddIncome
        {
            get
            {
                if (_switchToAddIncome == null)
                {
                    _switchToAddIncome = new RelayCommand((p) =>
                    {
                        IncomeTitle = $"{DateTime.Now.ToString("yyyy.MM.dd")}: ";
                        SelectedSidePanelMenu = 0;
                    });
                }

                return _switchToAddIncome;
            }
        }


        private ICommand? _switchToAddExpenses;
        public ICommand SwitchToAddExpenses
        {
            get
            {
                if (_switchToAddExpenses == null)
                {
                    _switchToAddExpenses = new RelayCommand((p) =>
                    {
                        ExpensesTitle = $"{DateTime.Now.ToString("yyyy.MM.dd")}: ";
                        SelectedSidePanelMenu = 1;
                    });
                }

                return _switchToAddExpenses;
            }
        }


        private ICommand? _switchToAddCategory;
        public ICommand SwitchToAddCategory
        {
            get
            {
                if (_switchToAddCategory == null)
                {
                    _switchToAddCategory = new RelayCommand((p) =>
                    {
                        CategoryTitle = $"{DateTime.Now.ToString("yyyy.MM.dd")}: ";
                        CategoryColorHex = _defaultCategoryColor;
                        SelectedSidePanelMenu = 3;
                    });
                }

                return _switchToAddCategory;
            }
        }


        private ICommand? _switchToEditCategory;
        public ICommand SwitchToEditCategory
        {
            get
            {
                if (_switchToEditCategory == null)
                {
                    _switchToEditCategory = new RelayCommand((p) =>
                    {
                        SelectedSidePanelMenu = 4;
                        SaveOldCategoryData();
                    });
                }

                return _switchToEditCategory;
            }
        }


        private ICommand? _switchToEditFinance;
        public ICommand SwitchToEditFinance
        {
            get
            {
                if (_switchToEditFinance == null)
                {
                    _switchToEditFinance = new RelayCommand((p) =>
                    {
                        SelectedSidePanelMenu = 2;
                        FillEditParametrs();
                    });
                }

                return _switchToEditFinance;
            }
        }


        private ICommand? _addNewIncomeCommand;
        public ICommand AddNewIncomeCommand
        {
            get
            {
                if (_addNewIncomeCommand == null)
                {
                    _addNewIncomeCommand = new RelayCommand((p) =>
                    {
                        if (SelectedIncomeCategory != null && SelectedCurrencyIndexIncome != null && IncomeSum != null && IncomeTitle != null)
                        {

                            try
                            {
                                AddNewFinance
                                    (title: IncomeTitle ?? String.Empty,
                                    description: (string.IsNullOrEmpty(IncomeDesc)) ? _defaultDescription : IncomeDesc,
                                    sum: (double)IncomeSum,
                                    categoryCode: SelectedIncomeCategory.CategoryCode ?? _defaultCategoryCode,
                                    status: true,
                                    sumColor: _greenSumColor,
                                    color: SelectedIncomeCategory.ColorHex ?? _defaultCategoryColor,
                                    currency: Special.GetCurrencyTag((int)SelectedCurrencyIndexIncome) ?? "NULL",
                                    sign: _incomeSign);

                                ClearIncomeFields();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"{ex.Message}");
                            }
                        }
                    },
                    (p) => !string.IsNullOrWhiteSpace(IncomeTitle) && IncomeSum != 0);
                }

                return _addNewIncomeCommand;
            }
        }


        private ICommand? _addNewExpensesCommand;
        public ICommand AddNewExpensesCommand
        {
            get
            {
                if (_addNewExpensesCommand == null)
                {
                    _addNewExpensesCommand = new RelayCommand((p) =>
                    {
                        if (SelectedExpensesCategory != null && SelectedCurrencyIndexExpenses != null && ExpensesSum != null)
                        {

                            try
                            {
                                AddNewFinance
                                    (title: ExpensesTitle ?? String.Empty,
                                    description: (string.IsNullOrEmpty(ExpensesDesc)) ? _defaultDescription : ExpensesDesc,
                                    sum: (double)ExpensesSum,
                                    categoryCode: SelectedExpensesCategory.CategoryCode ?? _defaultCategoryCode,
                                    status: false,
                                    sumColor: _redSumColor,
                                    color: SelectedExpensesCategory.ColorHex ?? _defaultCategoryColor,
                                    currency: Special.GetCurrencyTag((int)SelectedCurrencyIndexExpenses) ?? "NULL",
                                    sign: _expensesSign);

                                ClearExpensesFields();
                            }
                            catch(Exception ex)
                            {
                                MessageBox.Show($"{ex.Message}");
                            }
                        }
                    },
                    (p) => !string.IsNullOrWhiteSpace(ExpensesTitle) && ExpensesSum != 0);
                }

                return _addNewExpensesCommand;
            }
        }


        private ICommand? _addNewCategoryCommand;
        public ICommand AddNewCategoryCommand
        {
            get
            {
                if (_addNewCategoryCommand == null)
                {
                    _addNewCategoryCommand = new RelayCommand((p) =>
                    {
                        try
                        {
                            if (CategoryTitle != null && CategoryColorHex != null)
                            {
                                CategoryItem? item = new CategoryItem
                                {
                                    Title = CategoryTitle,
                                    ColorHex = CategoryColorHex.ToString(),
                                    CategoryCode = Special.GenerateCategoryCode()
                                };

                                if (item != null)
                                {
                                    categoryItems?.Add(item);

                                    category_combobox_items?.Add(item);

                                    category_sort_items?.Add(item);

                                    using(DataBaseAccess db = new DataBaseAccess())
                                    {
                                        db.AddCategoryItemAsync(item);
                                    }

                                    CategoryTitle = String.Empty;
                                    CategoryColorHex = _defaultCategoryColor;
                                }
                            }
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show($"{ex.Message}");
                        }

                    }, (p) => !string.IsNullOrEmpty(CategoryTitle) &&
                    !string.IsNullOrEmpty(CategoryColorHex));
                }

                return _addNewCategoryCommand;
            }
        }


        private ICommand? _removeCategoryCommand;
        public ICommand RemoveCategoryCommand
        {
            get
            {
                if (_removeCategoryCommand == null)
                {
                    _removeCategoryCommand = new RelayCommand((p) =>
                    {
                        if (SelectedCategoryItem != null && SortingCategory != null && IsListUpdating == false)
                        {
                            //update data base
                            using(DataBaseAccess db = new DataBaseAccess())
                            {
                                db.RemoveCategoryItemAsync(SelectedCategoryItem);
                            }

                            var currentSortingCategoryCode = SortingCategory.CategoryCode;

                            UpdateFinanceCategory(categoryCode: SelectedCategoryItem.CategoryCode,
                                    colorHex: _defaultCategoryColor, newCategoryCode: _defaultCategoryCode);

                            //remove category item from all collections
                            category_combobox_items?.Remove(SelectedCategoryItem);

                            category_sort_items?.Remove(SelectedCategoryItem);

                            categoryItems?.Remove(SelectedCategoryItem);


                            //setting all selected categories by default
                            SortingCategoryIndex = currentSortingCategoryCode == "000000" ? 0 : 1;
                            SelectedCategoryIncomeAdd = 0;
                            SelectedCategoryExpensesAdd = 0;
                            SelectedFinanceIndexCategoryEdit = 0;
                            SelectedConvertingCategoryIndex = 0;

                        }
                    });
                }

                return _removeCategoryCommand;
            }
        }


        private ICommand? _editFinanceCommand;
        public ICommand EditFinanceCommand
        {
            get
            {
                if (_editFinanceCommand == null)
                {
                    _editFinanceCommand = new RelayCommand((p) =>
                    {
                        if (SelectedFinanceItem != null)
                        {
                            using (DataBaseAccess db = new DataBaseAccess())
                            {
                                db.UpdateFinanceItemAsync(SelectedFinanceItem);
                                CalculateAndSetSum();
                            }
                        }
                    },
                    (p) => SelectedFinanceItem != null && !string.IsNullOrEmpty(SelectedFinanceItem.Title) &&
                    !string.IsNullOrEmpty(SelectedFinanceItem.Sum.ToString()) && SelectedFinanceItem.Sum != 0);
                }

                return _editFinanceCommand;
            }
        }


        private ICommand? _editCategoryCommand;
        public ICommand EditCategoryCommand
        {
            get
            {
                if (_editCategoryCommand == null)
                {
                    _editCategoryCommand = new RelayCommand((p) =>
                    {
                        if (SelectedCategoryItem != null && categoryItems != null && category_combobox_items != null && IsListUpdating == false)
                        {
                            MainWindow? window = p as MainWindow;
                            if (window != null)
                            {
                                using(DataBaseAccess db = new DataBaseAccess())
                                {
                                    db.UpdateCategoryItemAsync(SelectedCategoryItem);
                                }
                                UpdateFinanceCategoryColor(categoryCode: SelectedCategoryItem.CategoryCode, colorHex: SelectedCategoryItem.ColorHex, window:window);
                            }
                        }
                        else if (IsListUpdating)
                        {
                            SetOldCategoryData();
                        }
                    },
                    (p) => SelectedCategoryItem != null &&
                    !string.IsNullOrEmpty(SelectedCategoryItem.Title) &&
                    !string.IsNullOrEmpty(SelectedCategoryItem.ColorHex));
                }

                return _editCategoryCommand;
            }
        }


        private ICommand? _removeFinanceCommand;
        public ICommand? RemoveFinanceCommand
        {
            get
            {
                if (_removeFinanceCommand == null)
                {
                    _removeFinanceCommand = new RelayCommand((p) =>
                    {
                        if (SelectedFinanceItem != null && financeItems != null && sortedFinanceItems != null)
                        {
                            using(DataBaseAccess db = new DataBaseAccess())
                            {
                                db.RemoveFinanceItemAsync(SelectedFinanceItem);

                                financeItems.Remove(SelectedFinanceItem);
                                sortedFinanceItems.Remove(SelectedFinanceItem);

                                CalculateAndSetSum();
                            }
                        }
                    });
                }

                return _removeFinanceCommand;
            }
        }


        private ICommand? _financeSelectCommand;
        public ICommand? FinanceSelectCommand
        {
            get
            {
                if (_financeSelectCommand == null)
                {
                    _financeSelectCommand = new RelayCommand((p) =>
                    {
                        FillEditParametrs();
                    });
                }

                return _financeSelectCommand;
            }
        }


        private ICommand? _currencyChanged;
        public ICommand? CurrencyChanged
        {
            get
            {
                if (_currencyChanged == null)
                {
                    _currencyChanged = new RelayCommand((p) =>
                    {
                        if (SelectedFinanceItem != null && SelectedCurrencyIndexEdit != null)
                        {
                            switch (SelectedCurrencyIndexEdit)
                            {
                                case 0:
                                    SelectedFinanceItem.Currency = "USD";
                                    break;
                                case 1:
                                    SelectedFinanceItem.Currency = "EUR";
                                    break;
                                case 2:
                                    SelectedFinanceItem.Currency = "UAH";
                                    break;
                            }
                        }
                    });
                }

                return _currencyChanged;
            }
        }


        private ICommand? _categoryChanged;
        public ICommand? CategoryChanged
        {
            get
            {
                if (_categoryChanged == null)
                {
                    _categoryChanged = new RelayCommand((p) =>
                    {
                        if (SelectedFinanceItem != null && SelectedFinanceCategoryEdit != null)
                        {
                            SelectedFinanceItem.Color = SelectedFinanceCategoryEdit.ColorHex;
                            SelectedFinanceItem.CategoryId = SelectedFinanceCategoryEdit.CategoryCode;
                        }
                    });
                }

                return _categoryChanged;
            }
        }


        private ICommand? _typeChanged;
        public ICommand? TypeChanged
        {
            get
            {
                if (_typeChanged == null)
                {
                    _typeChanged = new RelayCommand((p) =>
                    {
                        if (SelectedFinanceItem != null && SelectedTypeIndexEdit != null)
                        {

                            switch (SelectedTypeIndexEdit)
                            {
                                case 0:
                                    SelectedFinanceItem.IsIncome = true;
                                    SelectedFinanceItem.SumColor = _greenSumColor;
                                    SelectedFinanceItem.Sign = _incomeSign;
                                    break;
                                case 1:
                                    SelectedFinanceItem.IsIncome = false;
                                    SelectedFinanceItem.SumColor = _redSumColor;
                                    SelectedFinanceItem.Sign = _expensesSign;
                                    break;
                            }
                        }
                    });
                }

                return _typeChanged;
            }
        }

        //for income and expenses editing panel
        private ICommand? _closeFinanceEditCommand;
        public ICommand? CloseFinanceEditCommand
        {
            get
            {
                if (_closeFinanceEditCommand == null)
                {
                    _closeFinanceEditCommand = new RelayCommand((p) =>
                    {
                        SetOldDataItem();
                    });
                }

                return _closeFinanceEditCommand;
            }
        }

        //for income adding panel
        private ICommand? _closeIncomeAddCommand;
        public ICommand? CloseIncomeAddCommand
        {
            get
            {
                if (_closeIncomeAddCommand == null)
                {
                    _closeIncomeAddCommand = new RelayCommand((p) =>
                    {
                        ClearIncomeFields();
                    });
                }

                return _closeIncomeAddCommand;
            }
        }

        //for expenses adding panel
        private ICommand? _closeExpensesAddCommand;
        public ICommand? CloseExpensesAddCommand
        {
            get
            {
                if (_closeExpensesAddCommand == null)
                {
                    _closeExpensesAddCommand = new RelayCommand((p) =>
                    {
                        ClearExpensesFields();
                    });
                }

                return _closeExpensesAddCommand;
            }
        }

        //for category editing panel
        private ICommand? _closeCategoryEditCommand;
        public ICommand? CloseCategoryEditCommand
        {
            get
            {
                if (_closeCategoryEditCommand == null)
                {
                    _closeCategoryEditCommand = new RelayCommand((p) =>
                    {
                        SetOldCategoryData();
                    });
                }

                return _closeCategoryEditCommand;
            }
        }


        private ICommand? _applyFiltersCommand;
        public ICommand? ApplyFiltersCommand
        {
            get
            {
                if (_applyFiltersCommand == null)
                {
                    _applyFiltersCommand = new RelayCommand((p) =>
                    {
                        try
                        {
                            GetAndApllyFilteredSettings();
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show($"{ex.Message}");
                        }
                    });
                }

                return _applyFiltersCommand;
            }
        }


        private ICommand? _switchToExcelConverterPanel;
        public ICommand? SwitchToExcelConverterPanel
        {
            get
            {
                if (_switchToExcelConverterPanel == null)
                {
                    _switchToExcelConverterPanel = new RelayCommand((p) =>
                    {
                        SelectedRightPanelIndex = 1;
                    });
                }

                return _switchToExcelConverterPanel;
            }
        }

        private ICommand? _switchToFilterPanel;
        public ICommand? SwitchToFilterPanel
        {
            get
            {
                if (_switchToFilterPanel == null)
                {
                    _switchToFilterPanel = new RelayCommand((p) =>
                    {
                        SelectedRightPanelIndex = 0;
                    });
                }

                return _switchToFilterPanel;
            }
        }

        private ICommand? _switchToCurrencyPanel;
        public ICommand? SwitchToCurrencyPanel
        {
            get
            {
                if (_switchToCurrencyPanel == null)
                {
                    _switchToCurrencyPanel = new RelayCommand((p) =>
                    {
                        SelectedRightPanelIndex = 2;
                    });
                }

                return _switchToCurrencyPanel;
            }
        }

        private ICommand? _convertToExcelCommand;
        public ICommand? ConvertToExcelCommand
        {
            get
            {
                if (_convertToExcelCommand == null)
                {
                    _convertToExcelCommand = new RelayCommand((p) =>
                    {
                        if (ExcelFilePath != null && SelectedConvertingCategory != null && category_combobox_items != null && financeItems != null && ConvertedFileName != null)
                        {
                            try
                            {
                                IsConverting = true;

                                if (SelectedConvertingCategory.CategoryCode == "000000")
                                {
                                    FormExcel(ExcelFilePath, ConvertedFileName, category_combobox_items.Count);
                                }
                                else
                                {
                                    var code = SelectedConvertingCategory.CategoryCode;
                                    var number = financeItems.Where(item => item.CategoryId == code).Count();
                                    if (number > 0)
                                    {
                                        FormExcel(ExcelFilePath, ConvertedFileName, 1, code);
                                    }
                                    else
                                    {
                                        MessageBox.Show(
                                            messageBoxText: $"Выбранная категория \"{SelectedConvertingCategory.Title}\", не содержит элементов!",
                                            icon: MessageBoxImage.Warning,
                                            caption: "Ошибка!",
                                            button: MessageBoxButton.OK);

                                        IsConverting = false;
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                ConvertedFileName = String.Empty;
                                ExcelFilePath = String.Empty;
                                MessageBox.Show($"{e.Message}");
                            }
                        }
                    }, (p) => IsConverting == false && 
                    !string.IsNullOrWhiteSpace(ExcelFilePath) && 
                    !string.IsNullOrWhiteSpace(ConvertedFileName));
                }

                return _convertToExcelCommand;
            }
        }


        private ICommand? _selectExcelPathCommand;
        public ICommand? SelectExcelPathCommand
        {
            get
            {
                if (_selectExcelPathCommand == null)
                {
                    _selectExcelPathCommand = new RelayCommand((p) =>
                    {
                        ExcelFilePath = Special.GetFolderPath();
                    });
                }

                return _selectExcelPathCommand;
            }
        }

        private ICommand? _searchCommand;
        public ICommand? SearchCommand
        {
            get
            {
                if(_searchCommand == null)
                {
                    _searchCommand = new RelayCommand((p) =>
                    {
                        if (string.IsNullOrEmpty(SearchContent))
                        {
                            GetAndApllyFilteredSettings();
                        }
                        else
                        {
                            SearchItems(SearchContent);
                        }
                    });
                }

                return _searchCommand;
            }
        }

        private ICommand? _usdTextChanged;
        public ICommand? UsdTextChanged
        {
            get
            {
                if(_usdTextChanged == null)
                {
                    _usdTextChanged = new RelayCommand((p) =>
                    {
                        TextBox? textBox = p as TextBox;

                        if(textBox != null)
                        {
                            CurrencyWarningState = true;
                            UsdHasValidError = Validation.GetHasError(textBox);
                        }
                    });
                }

                return _usdTextChanged;
            }
        }

        private ICommand? _eurTextChanged;
        public ICommand? EurTextChanged
        {
            get
            {
                if (_eurTextChanged == null)
                {
                    _eurTextChanged = new RelayCommand((p) =>
                    {
                        TextBox? textBox = p as TextBox;

                        if (textBox != null)
                        {
                            CurrencyWarningState = true;
                            EurHasValidError = Validation.GetHasError(textBox);
                        }
                    });
                }

                return _eurTextChanged;
            }
        }

        private ICommand? _applyCurrencySettings;
        public ICommand? ApplyCurrencySettings
        {
            get
            {
                if(_applyCurrencySettings == null)
                {
                    _applyCurrencySettings = new RelayCommand((p) =>
                    {
                        CalculateAndSetSum();
                        CurrencyWarningState = false;
                    }, (p) => !UsdHasValidError && !EurHasValidError);
                }

                return _applyCurrencySettings;
            }
        }
        #endregion

        #region Other methods

        //Transfering all received finance elements to the bound collection
        internal async void InitializeFinanceCollectionsAsync(FinanceItem[] finance_items)
        {
            await Task.Run(() =>
            {
                financeItems = new ObservableCollection<FinanceItem>(finance_items);

                if (financeItems != null)
                {
                    var collection = SortByDate(financeItems);

                    if (collection != null)
                    {
                        sortedFinanceItems = new ObservableCollection<FinanceItem>(collection);
                    }
                }
            });
        }

        // Transfering all received category elements to the bound collection
        internal async void InitializeCategoryCollectionAsync(CategoryItem[] category_items)
        {
            await Task.Run(() =>
            {
                categoryItems = new ObservableCollection<CategoryItem>(category_items);

                if (categoryItems != null && category_combobox_items != null && category_sort_items != null)
                {
                    MergeTwoObservableCollections<CategoryItem>(category_combobox_items, categoryItems);
                    MergeTwoObservableCollections<CategoryItem>(category_sort_items, category_combobox_items);
                }
            });
        }

        // Setting data from configuration
        internal void SetConfigDefaultProperties()
        {
            ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
            configFileMap.ExeConfigFilename = configPath;
            configuration = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);

            bool isTrayActive;
            if (bool.TryParse(configuration.AppSettings.Settings["tray_is_active"].Value, out isTrayActive))
                IsTrayActive = isTrayActive;
            else
                IsTrayActive = false;

            ExcelFilePath = configuration.AppSettings.Settings["save_excel_path"].Value;

            bool isPinned;
            if (bool.TryParse(configuration.AppSettings.Settings["is_pinned"].Value, out isPinned))
                IsPinned = isPinned;
            else
                IsPinned = false;

            bool isUsingSorted;
            if (bool.TryParse(configuration.AppSettings.Settings["is_using_sorted"].Value, out isUsingSorted))
                IsUsingSorted = isUsingSorted;
            else
                IsUsingSorted = false;

            int selectedConvertCategoryIndex;
            if (int.TryParse(configuration.AppSettings.Settings["selected_convert_category_index"].Value, out selectedConvertCategoryIndex))
                SelectedConvertingCategoryIndex = selectedConvertCategoryIndex;
            else
                SelectedConvertingCategoryIndex = 0;   

            bool isFullScreen;
            if (bool.TryParse(configuration.AppSettings.Settings["is_full_screen"].Value, out isFullScreen))
                WindowStateProp = isFullScreen ? WindowState.Maximized : WindowState.Normal;    
            else
                WindowStateProp = WindowState.Normal;

            double usdToUah;
            if (double.TryParse(configuration.AppSettings.Settings["usd_uah"].Value, out usdToUah))
                UsdToUah = usdToUah;
            else
                UsdToUah = 0.0;

            double eurToUah;
            if (double.TryParse(configuration.AppSettings.Settings["eur_uah"].Value, out eurToUah))
                EurToUah = eurToUah;
            else
                EurToUah = 0.0;
        }

        // Setting some properties by default
        internal void SetDefaulProperties()
        {
            MainCurrentSum = 0;
            CurrencyLabelForeColor = "#808080";

            //finance adding panel (income)
            SelectedCurrencyIndexIncome = 0;
            SelectedCategoryIncomeAdd = 0;
            IncomeSum = 0;

            //finance adding panel (expenses)
            SelectedCurrencyIndexExpenses = 0;
            SelectedCategoryExpensesAdd = 0;
            ExpensesSum = 0;

            //filter side panel
            SortingDateIndex = 0;
            SortingCurrencyIndex = 0;
            SortingCategoryIndex = 0;
            SortingTypeIndex = 0;
            SortingSum = 0;
            SortingSumIndex = 0;

            //side panel indices
            SelectedRightPanelIndex = 0;
            SelectedSidePanelMenu = 0;

            //excel side panel
            IsConverting = false;
            ConvertProgressVisible = Visibility.Hidden;
            ConvertProgressBarValue = 0;
            SelectedConvertingCategoryIndex = 0;

            //sidebar
            IsListUpdating = false;
        }

        // Merging two collections and overwrite main collection with the result
        internal void MergeTwoObservableCollections<T>(ObservableCollection<T> mainCollection, ObservableCollection<T> extraCollection)
        {
            Application.Current.Dispatcher.BeginInvoke(() =>
            {
                foreach (T item in extraCollection)
                {
                    mainCollection.Add(item);
                }
            });
        }

        // Clearing fields in adding income panel
        internal void ClearIncomeFields()
        {
            IncomeTitle = String.Empty;
            IncomeDesc = String.Empty;
            IncomeSum = 0;
            SelectedCategoryIncomeAdd = 0;
        }

        // Clearing fields in adding expenses panel
        internal void ClearExpensesFields()
        {
            ExpensesTitle = String.Empty;
            ExpensesDesc = String.Empty;
            ExpensesSum = 0;
            SelectedCategoryExpensesAdd = 0;
        }


        // Adding a new finance item to sorted and main collections, adding to the data base
        internal void AddNewFinance(string title, string description, double sum,
            string categoryCode, bool status, string sumColor, string color, string currency, string sign)
        {
            using (FinanceItem item = new FinanceItem())
            {
                using(DataBaseAccess db = new DataBaseAccess())
                {
                    item.Title = title;
                    item.Description = description;
                    item.Sum = sum;
                    item.CategoryId = categoryCode;
                    item.IsIncome = status;
                    item.SumColor = sumColor;
                    item.Color = color;
                    item.Sign = sign;
                    item.Currency = currency;
                    item.Time = Special.GetCurrentTime();

                    DateTime date = DateTime.Now;

                    item.Date = $"{date.Day} {date.ToString("MMMM")} {date.Year}";
                    item.DateForSort = $"{date.ToString("dd")}/{date.ToString("MM")}/{date.ToString("yyyy")}";
                    item.TimeForSort = $"{date.ToString("hh")}:{date.ToString("mm")}:{date.ToString("ss")}";

                    if (financeItems != null && sortedFinanceItems != null)
                    {
                        financeItems.Add(item);

                        sortedFinanceItems.Insert(0, item);

                    }
                    db.AddFinanceItemAsync(item);

                    CalculateAndSetSum();
                }
            }
        }

        // Sorting the passed collection by the passed available parameters
        internal async void SortCollection(ObservableCollection<FinanceItem> financeItems, double? sum = null, string? date = null, bool? type = null, string? categoryCode = null, string? currency = null)
        {
#nullable disable
            await Task.Run(() =>
            {
                var filteredItems = financeItems.Where(item =>
                    (sum == null || item.Sum.ToString().Contains(sum.ToString())) &&
                    (date == null || date == item.DateForSort) &&
                    (type == null || type == item.IsIncome) &&
                    (categoryCode == null || categoryCode == item.CategoryId) &&
                    (currency == null || currency == item.Currency));

                var result = filteredItems
                    .OrderByDescending(x => DateTime.ParseExact(
                        $"{x.DateForSort} {x.TimeForSort}",
                        new[] { "dd/MM/yyyy HH:mm:ss", "d/M/yyyy HH:mm:ss", "d/M/yyyy HH:mm:s", "d/MM/yyyy HH:mm:s", "d/MM/yyyy HH:mm:ss", "dd/M/yyyy HH:mm:s", "dd/M/yyyy HH:mm:ss" },
                        CultureInfo.InvariantCulture)).ToList();

                if (sortedFinanceItems != null)
                {
                    Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        sortedFinanceItems.Clear();

                        foreach (var item in result)
                        {
                            sortedFinanceItems.Add(item);
                        }
                    }), System.Windows.Threading.DispatcherPriority.Background);
                }
            });
#nullable restore
        }

        // Sorting by date the passed collection
        internal FinanceItem[]? SortByDate(ObservableCollection<FinanceItem> items)
        {
            var result = items.OrderByDescending(x => DateTime.ParseExact($"{x.DateForSort} {x.TimeForSort}", new[] { "dd/MM/yyyy HH:mm:ss", "d/M/yyyy HH:mm:ss", "d/M/yyyy HH:mm:s" }, CultureInfo.InvariantCulture)).ToArray();
            return result;
        }

        // Sorting by date the passed enumeration
        internal FinanceItem[]? SortByDate(IEnumerable<FinanceItem> items)
        {
            var result = items.OrderByDescending(x => DateTime.ParseExact($"{x.DateForSort} {x.TimeForSort}", new[] { "dd/MM/yyyy HH:mm:ss", "d/M/yyyy HH:mm:ss", "d/M/yyyy HH:mm:s" }, CultureInfo.InvariantCulture)).ToArray();
            return result;
        }

        // Updating the category color in all finance items and commit it to the database
        internal async void UpdateFinanceCategoryColor(string? categoryCode, string? colorHex, MainWindow window)
        {
            await Task.Run(() =>
            {
                try
                {
                    IsListUpdating = true;

                    if (sortedFinanceItems != null && financeItems != null && categoryCode != null && colorHex != null)
                    {
                        using(DataBaseAccess db = new DataBaseAccess())
                        {
                            sortedFinanceItems.Where(item => item.CategoryId == categoryCode).ToList()
                            .ForEach(item =>
                            {
                                item.Color = colorHex;
                            });

                            financeItems.Where(item => item.CategoryId == categoryCode).ToList()
                            .ForEach(item =>
                            {
                                item.Color = colorHex;
                            });

                            db.UpdateFinanceRange(financeItems.ToArray());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}");
                }
                finally
                {
                    IsListUpdating = false;
                }

            });
        }

        // Updating the category color to the default color in all finance items and commit it to the database
        internal async void UpdateFinanceCategory(string? categoryCode, string? colorHex, string? newCategoryCode)
        {
            await Task.Run(() =>
            {
                try
                {
                    IsListUpdating = true;

                    if (sortedFinanceItems != null && financeItems != null && categoryCode != null && colorHex != null)
                    {
                        using(DataBaseAccess db = new DataBaseAccess())
                        {
                            sortedFinanceItems.Where(item => item.CategoryId == categoryCode).ToList()
                            .ForEach(item =>
                            {
                                item.Color = colorHex;
                                item.CategoryId = newCategoryCode;
                            });

                            financeItems.Where(item => item.CategoryId == categoryCode).ToList()
                            .ForEach(item =>
                            {
                                item.Color = colorHex;
                                item.CategoryId = newCategoryCode;
                            });

                            db.UpdateFinanceRange(financeItems.ToArray());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}");
                }
                finally
                {
                    IsListUpdating = false;
                }
            });
        }


        // Forming an excel document from data
        internal async void FormExcel(string path, string name, int categoryNumber, string? categoryCode = null)
        {
            await Task.Run(() =>
            {
                try
                {
                    ConvertButtonVisible = Visibility.Hidden;
                    ConvertProgressVisible = Visibility.Visible;

                    FileInfo file = new FileInfo(@$"{path}\{name}.xlsx");

                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                    using (ExcelPackage package = new ExcelPackage(file))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");

                        int startRow = 1;
                        int startColumn = 1;
                        int numberOfCategories = categoryNumber;

                        var step = 100 / numberOfCategories;

                        if (categoryItems != null && sortedFinanceItems != null && financeItems != null && category_combobox_items != null)
                        {

                            for (int i = 0; i < numberOfCategories; i++)
                            {
                                var currentCategory = categoryCode == null
                                    ? category_combobox_items[i] : category_combobox_items.FirstOrDefault(item => item.CategoryCode == categoryCode);

                                if (currentCategory != null)
                                {
                                    var collection = IsUsingSorted == true
                                        ? SortByDate(sortedFinanceItems.Where(item => item.CategoryId == currentCategory.CategoryCode))
                                        : SortByDate(financeItems.Where(item => item.CategoryId == currentCategory.CategoryCode));

                                    if (collection != null)
                                    {
                                        var currentItemsByCategory = new ObservableCollection<FinanceItem>(collection);

                                        int numberOfItemsPerCategory = currentItemsByCategory.Count();

                                        string categoryName = $"{currentCategory.Title} ({numberOfItemsPerCategory})" ?? "None";
                                        worksheet.InsertColumn(startColumn + i * 5, 4);

                                        worksheet.Cells[startRow, startColumn + i * 5, startRow, startColumn + i * 5 + 4].Merge = true;
                                        worksheet.Cells[startRow, startColumn + i * 5].Value = categoryName;

                                        worksheet.Cells[startRow + 1, startColumn + i * 5].Value = "Наименование";
                                        worksheet.Cells[startRow + 1, startColumn + i * 5 + 1].Value = "Дата";
                                        worksheet.Cells[startRow + 1, startColumn + i * 5 + 2].Value = "Сумма";
                                        worksheet.Cells[startRow + 1, startColumn + i * 5 + 3].Value = "Валюта";
                                        worksheet.Cells[startRow + 1, startColumn + i * 5 + 4].Value = "Доходы или расходы";

                                        if (numberOfItemsPerCategory > 0)
                                        {
                                            for (int j = 0; j < numberOfItemsPerCategory; j++)
                                            {
                                                int currentRow = startRow + 2 + j;
                                                worksheet.Cells[currentRow, startColumn + i * 5].Value = currentItemsByCategory[j].Title;
                                                worksheet.Cells[currentRow, startColumn + i * 5 + 1].Value = currentItemsByCategory[j].DateForSort;
                                                worksheet.Cells[currentRow, startColumn + i * 5 + 2].Value = currentItemsByCategory[j].Sum;
                                                worksheet.Cells[currentRow, startColumn + i * 5 + 3].Value = currentItemsByCategory[j].Currency;
                                                worksheet.Cells[currentRow, startColumn + i * 5 + 4].Value
                                                    = currentItemsByCategory[j].IsIncome == true ? "Доход(+)" : "Расход(-)";
                                            }
                                        }
                                    }
                                }

                                ConvertProgressBarValue += step;
                            }
                        }

                        worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
                        package.Save();
                    }
                }
                catch(Exception ex)
                {
                    ExcelFilePath = String.Empty;
                    MessageBox.Show($"{ex.Message}");
                }
                finally
                {
                    IsConverting = false;
                    ConvertedFileName = String.Empty;
                    ConvertProgressVisible = Visibility.Hidden;
                    ConvertButtonVisible = Visibility.Visible;
                }
            });
        }


        // Filling the fields of the editing panel with parameters
        internal void FillEditParametrs()
        {
            if (SelectedFinanceItem != null && category_combobox_items != null)
            {
                //saving old data about selected item
                SaveOldDataItem();

                SetCurrencyTag(SelectedFinanceItem.Currency ?? "UAH");

                string categCode = SelectedFinanceItem.CategoryId ?? String.Empty;
                SelectedFinanceCategoryEdit = category_combobox_items.FirstOrDefault(item => item.CategoryCode == categCode);

                switch (SelectedFinanceItem.IsIncome)
                {
                    case true:
                        SelectedTypeIndexEdit = 0;
                        break;
                    case false:
                        SelectedTypeIndexEdit = 1;
                        break;
                }
            }
        }

        // Setting currency tag
        internal void SetCurrencyTag(string currency)
        {
            switch (currency)
            {
                case "USD":
                    SelectedCurrencyIndexEdit = 0;
                    break;
                case "EUR":
                    SelectedCurrencyIndexEdit = 1;
                    break;
                case "UAH":
                    SelectedCurrencyIndexEdit = 2;
                    break;
            }
        }

        // Saving old data about selected finance item
        internal void SaveOldDataItem()
        {
            if (SelectedFinanceItem != null)
            {
                oldData.Title = SelectedFinanceItem.Title;
                oldData.Description = SelectedFinanceItem.Description;
                oldData.Currency = SelectedFinanceItem.Currency;
                oldData.Sum = SelectedFinanceItem.Sum;
                oldData.SumColor = SelectedFinanceItem.SumColor;
                oldData.CategoryId = SelectedFinanceItem.CategoryId;
                oldData.Color = SelectedFinanceItem.Color;
                oldData.Sign = SelectedFinanceItem.Sign;
                oldData.IsIncome = SelectedFinanceItem.IsIncome;
            }
        }

        // Setting old data to selected finance item
        internal void SetOldDataItem()
        {
            if (SelectedFinanceItem != null)
            {
                SelectedFinanceItem.Title = oldData.Title;
                SelectedFinanceItem.Description = oldData.Description;
                SelectedFinanceItem.Currency = oldData.Currency;
                SelectedFinanceItem.Sum = oldData.Sum;
                SelectedFinanceItem.SumColor = oldData.SumColor;
                SelectedFinanceItem.CategoryId = oldData.CategoryId;
                SelectedFinanceItem.Color = oldData.Color;
                SelectedFinanceItem.Sign = oldData.Sign;
                SelectedFinanceItem.IsIncome = oldData.IsIncome;
            }
        }

        // Saving old data about selected category item
        internal void SaveOldCategoryData()
        {
            if (SelectedCategoryItem != null)
            {
                oldCategory.Title = SelectedCategoryItem.Title;
                oldCategory.ColorHex = SelectedCategoryItem.ColorHex;
            }
        }

        // Setting old data to selected category item
        internal void SetOldCategoryData()
        {
            if (SelectedCategoryItem != null)
            {
                SelectedCategoryItem.Title = oldCategory.Title;
                SelectedCategoryItem.ColorHex = oldCategory.ColorHex;
            }
        }


        // Sorting main collection by the title with containing string
        internal async void SearchItems(string request)
        {
            await Task.Run(() =>
            {
                if (financeItems != null && sortedFinanceItems != null)
                {
                    var filteredCollection = SortByDate(financeItems.Where(item => item.Title?.ToLower().Contains(request.ToLower()) ?? false));

                    if (sortedFinanceItems != null && filteredCollection != null)
                    {
                        Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            sortedFinanceItems.Clear();

                            foreach (var item in filteredCollection)
                            {
                                sortedFinanceItems.Add(item);
                            }
                        }), System.Windows.Threading.DispatcherPriority.Background);
                    }
                }
            });
        }

        // Getting available filter properties, sorting and overwriting bound collection
        internal void GetAndApllyFilteredSettings()
        {
            double? _sum = null;
            string? _date = null;
            bool? _type = null;
            string? _categoryCode = null;
            string? _currency = null;

            if (SortingSumIndex != 0)
            {
                if (!string.IsNullOrEmpty(SortingSum.ToString()))
                    _sum = SortingSum;
            }
            if (SortingCurrencyIndex != null && SortingCurrencyIndex != 0)
            {
                _currency = Special.GetCurrencyTag((int)SortingCurrencyIndex - 1);
            }
            if (SortingDateIndex != 0 && SortingDate != null && SortingDateIndex != null)
            {
                _date = SortingDate.Value.ToString("dd/MM/yyyy");
            }
            if (SortingCategory != null)
            {
                if (SortingCategory.CategoryCode != "000000")
                    _categoryCode = SortingCategory.CategoryCode;
            }
            if (SortingTypeIndex != 0 && SortingDateIndex != null)
            {
                //true is Income
                //false are Expenses
                _type = SortingTypeIndex == 1 ? true : false;
            }

            if (financeItems != null)
            {
                SortCollection(financeItems, sum: _sum, date: _date, type: _type, categoryCode: _categoryCode, currency: _currency);
            }
        }

        internal void CalculateAndSetSum()
        {
            if(financeItems != null)
            {
                //MainCurrentSum = financeItems.Sum(item => item.Currency == "USD" 
                //? item.Sum * UsdToUah 
                //: item.Currency == "EUR" ? item.Sum * EurToUah 
                //: item.Sum);

                MainCurrentSum = financeItems.Sum(item =>
                {
                    int multiplier = item.IsIncome == false ? -1 : 1;

                    return item.Currency == "USD"
                    ? item.Sum * UsdToUah * multiplier

                    : item.Currency == "EUR" 
                    ? item.Sum * EurToUah * multiplier

                    : item.Sum * multiplier;
                });
            }
        }

        internal void CreateConfigFile()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Add("tray_is_active", "false");
            config.AppSettings.Settings.Add("save_excel_path", $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}");
            config.AppSettings.Settings.Add("is_pinned", "false");
            config.AppSettings.Settings.Add("is_using_sorted", "true");
            config.AppSettings.Settings.Add("selected_convert_category_index", "0");
            config.AppSettings.Settings.Add("is_full_screen", "false");
            config.AppSettings.Settings.Add("usd_uah", "0");
            config.AppSettings.Settings.Add("eur_uah", "0");
            config.SaveAs(configPath);
        }
        #endregion

        //random filling of the data base
        //internal async void TestMethod()
        //{
        //    await Task.Run(() =>
        //    {
        //        Application.Current.Dispatcher.Invoke(() =>
        //        {
        //            MessageBox.Show("Operation has started!");
        //        });

        //        Random randomGG = new Random();

        //        for (int i = 0; i < 50000; i++)
        //        {
        //            using (FinanceItem item = new FinanceItem())
        //            {
                        
        //                using(DataBaseAccess db = new DataBaseAccess())
        //                {
        //                    if (categoryItems != null)
        //                    {
        //                        DateTime date = DateTime.Now;
        //                        int randomIndex = randomGG.Next(categoryItems.Count);
        //                        Type type = typeof(Special.currencies);
        //                        Array values = type.GetEnumValues();
        //                        int index = randomGG.Next(values.Length);

        //                        item.Sum = Math.Round(randomGG.NextDouble() * 999 + 1, 2);

        //                        if (randomGG.Next(1, 3) == 1)
        //                        {
        //                            item.SumColor = _greenSumColor;
        //                            item.Sign = _incomeSign;
        //                            item.IsIncome = true;
        //                        }
        //                        else
        //                        {
        //                            item.SumColor = _redSumColor;
        //                            item.Sign = _expensesSign;
        //                            item.IsIncome = false;
        //                        }

        //                        item.Currency = ((Special.currencies)values.GetValue(index)).ToString();
        //                        item.CategoryId = categoryItems[randomIndex].CategoryCode;
        //                        item.Color = categoryItems[randomIndex].ColorHex;
        //                        item.Title = $"{categoryItems[randomIndex].Title}";
        //                        item.Time = Special.GetCurrentTime();
        //                        item.Date = $"{date.Day} {date.ToString("MMMM")} {date.Year}";
        //                        item.DateForSort = $"{date.ToString("dd")}/{date.ToString("MM")}/{date.ToString("yyyy")}";
        //                        item.TimeForSort = $"{date.ToString("hh")}:{date.ToString("mm")}:{date.ToString("ss")}";
        //                        item.Description = "Описание отсутствует.";

        //                        db.AddFinanceItemAsync(item);
        //                    }
        //                }

        //            }
        //        }

        //        Application.Current.Dispatcher.Invoke(() =>
        //        {
        //            MessageBox.Show("Operation has completed!");
        //        });
        //    });
        //}

    }
}
