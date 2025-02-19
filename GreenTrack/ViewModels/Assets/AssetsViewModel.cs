using CommunityToolkit.Mvvm.ComponentModel;
using GreenTrack.Models;
using GreenTrack.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTrack.ViewModels.Assets
{
    public partial class AssetsViewModel: ObservableObject
    {
        #region Properties
        private readonly AssetService _assetService;
        [ObservableProperty]
        private List<Asset> _assetsList;
        [ObservableProperty]
        private bool _isRefreshing;
        #endregion

        #region Constructor
        public AssetsViewModel(AssetService assetService)
        {
            _assetService = assetService;
            _ = GetAssetsAsync();
        }
        #endregion
        async Task GetAssetsAsync()
        {
            IsRefreshing = true;
            ApiResponse<List<Asset>>? assets = await _assetService.GetAssests();
            if (assets != null)
            {
                AssetsList = assets.Data!;
            }
            IsRefreshing = false;
        }

    }
}
