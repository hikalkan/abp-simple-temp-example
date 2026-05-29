using Microsoft.Extensions.Localization;
using AbpTempSimpleApp.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace AbpTempSimpleApp;

[Dependency(ReplaceServices = true)]
public class AbpTempSimpleAppBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<AbpTempSimpleAppResource> _localizer;

    public AbpTempSimpleAppBrandingProvider(IStringLocalizer<AbpTempSimpleAppResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}