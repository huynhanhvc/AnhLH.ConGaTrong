using AnhLH.ConGaTrong.Localization;
using Volo.Abp.Application.Services;

namespace AnhLH.ConGaTrong;

public abstract class ConGaTrongAPIAppService : ApplicationService
{
    protected ConGaTrongAPIAppService()
    {
        LocalizationResource = typeof(ConGaTrongResource);
        ObjectMapperContext = typeof(ConGaTrongApplicationModule);
    }
}
