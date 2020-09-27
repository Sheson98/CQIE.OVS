using CQIE.RIS.Domain;
using CQIE.RIS.Manager;
using CQIE.RIS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQIE.RIS.Component
{
    public class OptionsComponent : BaseComponent<Options, OptionsManager>, IOptionsService
    {
    }
}
