using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Empowerment.Web.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetComboPlanes();
    }
}