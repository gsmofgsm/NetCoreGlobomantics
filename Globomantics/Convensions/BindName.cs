using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globomantics.Convensions
{
    public class BindName : Attribute, IParameterModelConvention
    {
        public string Name { get; set; }

        public void Apply(ParameterModel parameter)
        {
            if (parameter.BindingInfo == null)
            {
                parameter.BindingInfo = new BindingInfo(); // do not try to change Binding info on a null object
            }

            parameter.BindingInfo.BinderModelName = Name;
        }
    }
}
