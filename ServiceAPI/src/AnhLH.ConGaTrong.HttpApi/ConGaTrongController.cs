using AnhLH.ConGaTrong.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AnhLH.ConGaTrong;

public abstract class ConGaTrongController : AbpControllerBase
{
    protected ConGaTrongController()
    {
        LocalizationResource = typeof(ConGaTrongResource);
    }
}
