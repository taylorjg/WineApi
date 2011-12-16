using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using WineApi;
using WPF.DataVirtualization;

namespace WineDemo.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainWindowViewModel : ViewModelBase
    {
        private const int FAUX_CATEGORY_NO_SELECTION = -1;
        private const int FAUX_CATEGORY_DUMMY_APPELLATION = -2;

        private readonly Refinement _noSelectionWineTypes = new Refinement() { Name = "All Wine Types", Id = FAUX_CATEGORY_NO_SELECTION };
        private readonly Refinement _noSelectionVarietals = new Refinement() { Name = "All Varietals", Id = FAUX_CATEGORY_NO_SELECTION };
        private readonly Refinement _noSelectionRegions = new Refinement() { Name = "All Regions", Id = FAUX_CATEGORY_NO_SELECTION };
        private readonly Refinement _noSelectionAppellations = new Refinement() { Name = "All Appellations", Id = FAUX_CATEGORY_NO_SELECTION };

        // TODO: move these into WineApi
        private const int CATEGORY_SHOP = 490;
        private const int CATEGORY_WINETYPES = 4;
        private const int CATEGORY_VARIETALS = 5;
        private const int CATEGORY_REGIONS = 1;
        private const int CATEGORY_APPELATIONS = 6;

        private const string PROPERTY_NAME_WINETYPES = "WineTypes";
        private const string PROPERTY_NAME_VARIETALS = "Varietals";
        private const string PROPERTY_NAME_REGIONS = "Regions";
        private const string PROPERTY_NAME_APPELLATIONS = "Appellations";

        private const string PROPERTY_NAME_SELECTED_WINETYPE = "SelectedWineType";
        private const string PROPERTY_NAME_SELECTED_VARIETAL = "SelectedVarietal";
        private const string PROPERTY_NAME_SELECTED_REGION = "SelectedRegion";
        private const string PROPERTY_NAME_SELECTED_APPELLATION = "SelectedAppellation";

        private const string PROPERTY_NAME_PRODUCTS = "Products";
        //private const string PROPERTY_NAME_SELECTED_PRODUCT = "SelectedProduct";
        private const string PROPERTY_NAME_TOTAL = "Total";

        private const string PROPERTY_NAME_SELECTED_SEARCHSORTOPTION = "SelectedSearchSortOption";

        private IEnumerable<Refinement> _wineTypes = null;
        private IEnumerable<Refinement> _varietals = null;
        private IEnumerable<Refinement> _regions = null;
        private IEnumerable<Refinement> _appellations = null;

        private Refinement _selectedWineType = null;
        private Refinement _selectedVarietal = null;
        private Refinement _selectedRegion = null;
        private Refinement _selectedAppellation = null;

        private IEnumerable<Refinement> _allWineTypes = null;
        private IEnumerable<Refinement> _allVarietals = null;
        private IEnumerable<Refinement> _allRegions = null;
        private IEnumerable<Refinement> _allAppellations = null;

        private Dictionary<int, Refinement[]> _wineTypesToVarietals = new Dictionary<int, Refinement[]>();
        private Dictionary<int, Refinement[]> _regionsToAppellations = new Dictionary<int, Refinement[]>();

        private VirtualList<Product> _products = null;
        //private object _selectedProduct = null;
        private int _total = 0;

        private readonly ICommand _searchCommand = null;
        private readonly ICommand _clearCommand = null;

        public class SearchSortOption
        {
            public string Name { get; set; }
            public SortOptions SortOption { get; set; }
            public SortDirection SortDirection { get; set; }
        }

        private IEnumerable<SearchSortOption> _searchSortOptions = null;
        private SearchSortOption _selectedSearchSortOption = null;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainWindowViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
            if (IsInDesignMode) {
                //SearchResults = new Product[]
                //{
                //    new Product() {
                //        Id = 92192,
                //        Name = "Chateau Mont Redon Cotes-du-Rhone 2005",
                //        Description = string.Empty,
                //        PriceMin = 12.29M,
                //        PriceMax = 19.29M,
                //        PriceRetail = 12.29M,
                //        Type = "Wine",
                //        Url = "http://www.wine.com/V6/Chateau-Mont-Redon-Cotes-du-Rhone-2005/wine/92192/detail.aspx",
                //        Vintages = new Vintages() {
                //        },
                //        Year = string.Empty,
                //        Labels = new Label[] {
                //            new Label() {
                //                Id = "92192m",
                //                Name = "thumbnail",
                //                Url = "http://cache.wine.com/labels/92192m.jpg"
                //            },
                //            new Label() {
                //                Id = "92192l",
                //                Name = "large",
                //                Url = "http://cache.wine.com/labels/92192l.jpg"
                //            },
                //        }
                //    }
                //};
            }
            else {
                Config.ApiKey = WineDemoConfig.API_KEY;
                Config.Version = WineDemoConfig.VERSION;
                PopulateSearchSortOptions();
                PopulateReferenceData();
            }

            _searchCommand = new RelayCommand(Search, CanSearch);
            _clearCommand = new RelayCommand(Clear, CanClear);
        }

        public IEnumerable<SearchSortOption> SearchSortOptions
        {
            get
            {
                return _searchSortOptions;
            }
        }

        public SearchSortOption SelectedSearchSortOption
        {
            get
            {
                return _selectedSearchSortOption;
            }
            set
            {
                if (value == _selectedSearchSortOption) {
                    return;
                }

                _selectedSearchSortOption = value;
                RaisePropertyChanged(PROPERTY_NAME_SELECTED_SEARCHSORTOPTION);

                if (CanClear()) {
                    Clear();
                    Search();
                }
            }
        }

        public IEnumerable<Refinement> WineTypes
        {
            get
            {
                return _wineTypes;
            }
            set
            {
                if (value == _wineTypes) {
                    return;
                }

                _wineTypes = value;
                RaisePropertyChanged(PROPERTY_NAME_WINETYPES);
            }
        }

        public IEnumerable<Refinement> Varietals
        {
            get
            {
                return _varietals;
            }
            set
            {
                if (value == _varietals) {
                    return;
                }

                _varietals = value;
                RaisePropertyChanged(PROPERTY_NAME_VARIETALS);
            }
        }

        public IEnumerable<Refinement> Regions
        {
            get
            {
                return _regions;
            }
            set
            {
                if (value == _regions) {
                    return;
                }

                _regions = value;
                RaisePropertyChanged(PROPERTY_NAME_REGIONS);
            }
        }

        public IEnumerable<Refinement> Appellations
        {
            get
            {
                return _appellations;
            }
            set
            {
                if (value == _appellations) {
                    return;
                }

                _appellations = value;
                RaisePropertyChanged(PROPERTY_NAME_APPELLATIONS);
            }
        }

        public Refinement SelectedWineType
        {
            get
            {
                return _selectedWineType;
            }
            set
            {
                if (value == _selectedWineType) {
                    return;
                }

            	_selectedWineType = value;
                RaisePropertyChanged(PROPERTY_NAME_SELECTED_WINETYPE);

                if (value == null || value.Id == FAUX_CATEGORY_NO_SELECTION) {
                    _varietals = _allVarietals;
                }
                else {
                    int wineTypeId = value.Id;
                    _varietals = _wineTypesToVarietals[wineTypeId];
                }
                RaisePropertyChanged(PROPERTY_NAME_VARIETALS);

                _selectedVarietal = _noSelectionVarietals;
                RaisePropertyChanged(PROPERTY_NAME_SELECTED_VARIETAL);
            }
        }

        public Refinement SelectedVarietal
        {
            get
            {
                return _selectedVarietal;
            }
            set
            {
                if (value == _selectedVarietal) {
                    return;
                }

            	_selectedVarietal = value;
                RaisePropertyChanged(PROPERTY_NAME_SELECTED_VARIETAL);

                if (value == null || value.Id == FAUX_CATEGORY_NO_SELECTION) {
                    _selectedWineType = _noSelectionWineTypes;
                    RaisePropertyChanged(PROPERTY_NAME_SELECTED_WINETYPE);
                }
                else {
                    int varietalId = value.Id;
                    int wineTypeId = 0;
                    foreach (var kvp in _wineTypesToVarietals) {
                        var varietalRefinement = (from vr in kvp.Value where vr.Id == varietalId select vr).FirstOrDefault();
                        if (varietalRefinement != null) {
                            wineTypeId = kvp.Key;
                            break;
                        }
                    }
                    if (wineTypeId > 0) {
                        var wineTypeRefinement = (from wtr in _allWineTypes where wtr.Id == wineTypeId select wtr).FirstOrDefault();
                        if (wineTypeRefinement != null) {
                            _selectedWineType = wineTypeRefinement;
                            RaisePropertyChanged(PROPERTY_NAME_SELECTED_WINETYPE);
                        }
                    }
                }
            }
        }

        public Refinement SelectedRegion
        {
            get
            {
                return _selectedRegion;
            }
            set
            {
                if (value == _selectedRegion) {
                    return;
                }

            	_selectedRegion = value;
                RaisePropertyChanged(PROPERTY_NAME_SELECTED_REGION);

                if (value == null || value.Id == FAUX_CATEGORY_NO_SELECTION) {
                    _appellations = _allAppellations;
                }
                else {
                    int regionId = value.Id;
                    _appellations = _regionsToAppellations[regionId];
                }
                RaisePropertyChanged(PROPERTY_NAME_APPELLATIONS);

                _selectedAppellation = _noSelectionAppellations;
                RaisePropertyChanged(PROPERTY_NAME_SELECTED_APPELLATION);
            }
        }

        public Refinement SelectedAppellation
        {
            get
            {
                return _selectedAppellation;
            }

            set
            {
                if (value == _selectedAppellation) {
                    return;
                }

            	_selectedAppellation = value;
                RaisePropertyChanged(PROPERTY_NAME_SELECTED_APPELLATION);

                if (value == null || value.Id == FAUX_CATEGORY_NO_SELECTION) {
                }
                else {
                    int appellationId = value.Id;
                    if (appellationId == FAUX_CATEGORY_DUMMY_APPELLATION) {
                        var regionRefinement = (from rr in _allRegions where rr.Name == value.Name select rr).FirstOrDefault();
                        if (regionRefinement != null) {
                            _selectedRegion = regionRefinement;
                            RaisePropertyChanged(PROPERTY_NAME_SELECTED_REGION);
                        }
                    }
                    else {
                        int regionId = 0;
                        foreach (var kvp in _regionsToAppellations) {
                            var appellationRefinement = (from ar in kvp.Value where ar.Id == appellationId select ar).FirstOrDefault();
                            if (appellationRefinement != null) {
                                regionId = kvp.Key;
                                break;
                            }
                        }
                        if (regionId > 0) {
                            var regionRefinement = (from rr in _allRegions where rr.Id == regionId select rr).FirstOrDefault();
                            if (regionRefinement != null) {
                                _selectedRegion = regionRefinement;
                                RaisePropertyChanged(PROPERTY_NAME_SELECTED_REGION);
                            }
                        }
                    }
                }
            }
        }

        public VirtualList<Product> Products
        {
            get
            {
                return _products;
            }
            set
            {
                if (value == _products) {
                    return;
                }

                _products = value;
                RaisePropertyChanged(PROPERTY_NAME_PRODUCTS);
            }
        }

        //public object SelectedProduct
        //{
        //    get
        //    {
        //        return _selectedProduct;
        //    }
        //    set
        //    {
        //        if (value == _selectedProduct) {
        //            return;
        //        }

        //        _selectedProduct = value;
        //        RaisePropertyChanged(PROPERTY_NAME_SELECTED_PRODUCT);
        //    }
        //}

        public int Total
        {
            get
            {
                return _total;
            }
            set
            {
            	_total = value;
                RaisePropertyChanged(PROPERTY_NAME_TOTAL);
            }
        }

        public ICommand SearchCommand
        {
            get
            {
                return _searchCommand;
            }
        }

        public ICommand ClearCommand
        {
            get
            {
                return _clearCommand;
            }
        }

        private void Search()
        {
            Total = LoadNextChunkOfProducts(0, 0).Total;
            Products = new VirtualList<Product>(LoadProducts, 100, 10);
            //if (Total > 0) {
            //    SelectedProduct = Products.First();
            //}
        }

        private bool CanSearch()
        {
            return true;
        }

        private void Clear()
        {
            Products = null;
            //SelectedProduct = null;
            Total = 0;
        }

        private bool CanClear()
        {
            return _products != null && _total > 0;
        }

        private void PopulateSearchSortOptions()
        {
            _searchSortOptions = new SearchSortOption[] {
                new SearchSortOption() { Name = "Most Popular", SortOption = SortOptions.Popularity, SortDirection = SortDirection.Descending },
                new SearchSortOption() { Name = "Top Rated", SortOption = SortOptions.Rating, SortDirection = SortDirection.Descending },
                new SearchSortOption() { Name = "Price: Low to High", SortOption = SortOptions.Price, SortDirection = SortDirection.Ascending },
                new SearchSortOption() { Name = "Price: High to Low", SortOption = SortOptions.Price, SortDirection = SortDirection.Descending },
                new SearchSortOption() { Name = "Savings", SortOption = SortOptions.Saving, SortDirection = SortDirection.Descending },
                new SearchSortOption() { Name = "Just In", SortOption = SortOptions.JustIn, SortDirection = SortDirection.Descending },
                new SearchSortOption() { Name = "Name", SortOption = SortOptions.Name, SortDirection = SortDirection.Ascending },
                new SearchSortOption() { Name = "Winery: A to Z", SortOption = SortOptions.Winery, SortDirection = SortDirection.Ascending },
                new SearchSortOption() { Name = "Winery: Z to A", SortOption = SortOptions.Winery, SortDirection = SortDirection.Descending },
                new SearchSortOption() { Name = "Vintage: Old to New", SortOption = SortOptions.Vintage, SortDirection = SortDirection.Ascending },
                new SearchSortOption() { Name = "Vintage: New to Old", SortOption = SortOptions.Vintage, SortDirection = SortDirection.Descending }
            };

            SelectedSearchSortOption = _searchSortOptions.First();
        }

        private void PopulateReferenceData()
        {
            PopulateFullLists();
            PopulateWineTypesToVarietals();
            PopulateRegionsToAppellations();

            SelectedWineType = _noSelectionWineTypes;
            SelectedRegion = _noSelectionRegions;
        }

        private void PopulateFullLists()
        {
            var categoryMapService = new CategoryMapService();
            categoryMapService.CategoriesFilter(CATEGORY_SHOP);
            var categoryMap = categoryMapService.Execute();

            var wineTypeCategory = (from c in categoryMap.Categories where c.Id == CATEGORY_WINETYPES select c).FirstOrDefault();
            if (wineTypeCategory != null) {
                // Wine types seem to be presented in the order that they are returned in.
                var wineTypes = new List<Refinement>();
                wineTypes.Add(_noSelectionWineTypes);
                wineTypes.AddRange(wineTypeCategory.Refinements);
                _wineTypes = _allWineTypes = wineTypes;
            }

            var varietalCategory = (from c in categoryMap.Categories where c.Id == CATEGORY_VARIETALS select c).FirstOrDefault();
            if (varietalCategory != null) {
                // All Varietals seem to be ordered by Id.
                var orderedVarietals = (from r in varietalCategory.Refinements orderby r.Id select r).ToArray();
                var varietals = new List<Refinement>();
                varietals.Add(_noSelectionVarietals);
                varietals.AddRange(orderedVarietals);
                _varietals = _allVarietals = varietals;
            }

            var regionCategory = (from c in categoryMap.Categories where c.Id == CATEGORY_REGIONS select c).FirstOrDefault();
            if (regionCategory != null) {
                // All Regions seem to be presented in the order that they are returned in.
                var regions = new List<Refinement>();
                regions.Add(_noSelectionRegions);
                regions.AddRange(regionCategory.Refinements);
                _regions = _allRegions = regions;
            }

            var appellationCategory = (from c in categoryMap.Categories where c.Id == CATEGORY_APPELATIONS select c).FirstOrDefault();
            if (appellationCategory != null) {
                // All Appellations seems to be ordered as follows:
                // 
                //  "All Appellations"
                //  Alphabetical list of appellations for the first region
                //  Alphabetical list of appellations for the second region
                //  ...
                //
                // where the regions are themselves ordered alphabetically.
                // An oddity is that "Greece", "Portugal" and "South Africa" are listed as appellations but "Canada" is not.
                // 
                // Hence, we build _allAppellations in PopulateRegionsToAppellations() below.
            }
        }

        private void PopulateWineTypesToVarietals()
        {
            if (_allWineTypes != null) {

                foreach (var wineType in _allWineTypes) {

                    string wineTypeName = wineType.Name;
                    int wineTypeId = wineType.Id;

                    if (wineTypeId == FAUX_CATEGORY_NO_SELECTION) {
                        continue;
                    }

                    var categoryMapService = new CategoryMapService();
                    categoryMapService.CategoriesFilter(CATEGORY_SHOP, wineTypeId);
                    var categoryMap = categoryMapService.Execute();

                    var matchingVarietals = (from c in categoryMap.Categories where c.Id == CATEGORY_VARIETALS select c).FirstOrDefault();
                    if (matchingVarietals != null) {
                        var varietals = new List<Refinement>();
                        varietals.Add(_noSelectionVarietals);
                        varietals.AddRange(matchingVarietals.Refinements);
                        _wineTypesToVarietals.Add(wineTypeId, varietals.ToArray());
                    }
                }
            }
        }

        private void PopulateRegionsToAppellations()
        {
            if (_allRegions != null) {

                foreach (var region in _allRegions) {

                    string regionName = region.Name;
                    int regionId = region.Id;

                    if (regionId == FAUX_CATEGORY_NO_SELECTION) {
                        continue;
                    }

                    var categoryMapService = new CategoryMapService();
                    categoryMapService.CategoriesFilter(CATEGORY_SHOP, regionId);
                    var categoryMap = categoryMapService.Execute();

                    var matchingAppellations = (from c in categoryMap.Categories where c.Id == CATEGORY_APPELATIONS select c).FirstOrDefault();
                    if (matchingAppellations != null) {
                        var orderedMatchingAppellations = (from r in matchingAppellations.Refinements orderby r.Name select r).ToArray();
                        var appellations = new List<Refinement>();
                        appellations.Add(_noSelectionAppellations);
                        appellations.AddRange(orderedMatchingAppellations);
                        _regionsToAppellations.Add(regionId, appellations.ToArray());
                    }
                    else {
                        Refinement dummyAppellation = new Refinement();
                        dummyAppellation.Id = FAUX_CATEGORY_DUMMY_APPELLATION;
                        dummyAppellation.Name = regionName;
                        dummyAppellation.Url = string.Empty;
                        _regionsToAppellations.Add(regionId, new Refinement[] { _noSelectionAppellations, dummyAppellation });
                    }
                }

                // Now we can go ahead and build _allAppellations.

                var alphabeticalRegions = (from rr in _allRegions orderby rr.Name where rr.Id != FAUX_CATEGORY_NO_SELECTION select rr).ToArray();

                var allAppellations = new List<Refinement>();
                allAppellations.Add(_noSelectionAppellations);
                foreach (var region in alphabeticalRegions) {
                    int regionId = region.Id;
                    var appellations1 = _regionsToAppellations[regionId];
                    if (appellations1 != null) {
                        var appellations2 = (from ar in appellations1 where ar.Id != FAUX_CATEGORY_NO_SELECTION select ar).ToArray();
                        allAppellations.AddRange(appellations2);
                    }
                }
                _allAppellations = allAppellations;
            }
        }

        private Products LoadNextChunkOfProducts(int offset, int size)
        {
            var catalogService = new CatalogService();

            var categories = new List<int>();

            if (SelectedWineType != null && SelectedWineType.Id != FAUX_CATEGORY_NO_SELECTION) {
                categories.Add(SelectedWineType.Id);
            }

            if (SelectedVarietal != null && SelectedVarietal.Id != FAUX_CATEGORY_NO_SELECTION) {
                categories.Add(SelectedVarietal.Id);
            }

            if (SelectedRegion != null && SelectedRegion.Id != FAUX_CATEGORY_NO_SELECTION) {
                categories.Add(SelectedRegion.Id);
            }

            if (SelectedAppellation != null && SelectedAppellation.Id != FAUX_CATEGORY_NO_SELECTION) {
                categories.Add(SelectedAppellation.Id);
            }

            var catalog = catalogService
                .CategoriesFilter(categories.ToArray())
                .SortBy(_selectedSearchSortOption.SortOption, _selectedSearchSortOption.SortDirection)
                .State("CA")
                .InStock()
                .Offset(offset)
                .Size(size)
                .Execute();

            return catalog.Products;
        }

        private int LoadProducts(SortDescriptionCollection sortDescriptions, Predicate<object> filter, Product[] products, int startIndex)
        {
            int offset = startIndex;
            int size = products.Length;
            int index = 0;

            for (; size > 0; ) {

                Products nextChunkOfProducts = LoadNextChunkOfProducts(offset, size);

                foreach (var product in nextChunkOfProducts.List) {
                    products[index++] = product;
                }

                int numberFetched = nextChunkOfProducts.List.Length;

                offset += numberFetched;
                size -= numberFetched;

                if (offset >= Total) {
                    break;
                }
            }

            return Total;
        }
    }
}
