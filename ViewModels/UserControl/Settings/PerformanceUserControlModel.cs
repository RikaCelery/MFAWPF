using CommunityToolkit.Mvvm.ComponentModel;
using MaaFramework.Binding;
using MFAWPF.Data;
using MFAWPF.Helper.Converters;
using System.Collections.ObjectModel;

namespace MFAWPF.ViewModels.UserControl.Settings;

public partial class PerformanceUserControlModel : ViewModel
{
    public static ObservableCollection<Tool.LocalizationViewModel> GpuOptions =>
    [
        new("GpuOptionAuto")
        {
            Other = InferenceDevice.Auto
        },
        new("GpuOptionDisable")
        {
            Other = InferenceDevice.CPU
        }
    ];

    [ObservableProperty] private InferenceDevice _gpuOption = MFAConfiguration.GetConfiguration("GPUOption", InferenceDevice.Auto, new UniversalEnumConverter<InferenceDevice>());

    partial void OnGpuOptionChanged(InferenceDevice value)
    {
        MFAConfiguration.SetConfiguration("GPUOption", value.ToString());
    }
}
