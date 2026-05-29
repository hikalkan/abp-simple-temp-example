using Volo.Abp.Application.Services;
using AbpTempSimpleApp.Localization;

namespace AbpTempSimpleApp.Services;

/* Inherit your application services from this class. */
public abstract class AbpTempSimpleAppAppService : ApplicationService
{
    protected AbpTempSimpleAppAppService()
    {
        LocalizationResource = typeof(AbpTempSimpleAppResource);
    }
}