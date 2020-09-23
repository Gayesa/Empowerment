using Empowerment.Web.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Empowerment.Web.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext _datacontext;

        public CombosHelper(DataContext datacontext)
        {
            _datacontext = datacontext;
        }

        public IEnumerable<SelectListItem> GetComboPlanes()
        {
            var list = _datacontext.Planes.Select(p => new SelectListItem
            {
                Text = p.Nombre,
                Value = $"{p.Id}"
            })
                .OrderBy(p => p.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "-- Seleccionar Plan --",
                Value = "0"
            });

            return list;
        }
    }
}
