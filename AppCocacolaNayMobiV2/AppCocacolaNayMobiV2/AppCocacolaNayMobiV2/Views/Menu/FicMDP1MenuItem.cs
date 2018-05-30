using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCocacolaNayMobiV2.Views.Menu
{

    public class FicMDP1MenuItem
    {
        public FicMDP1MenuItem()
        {
            TargetType = typeof(FicMDP1Detail);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }

        public string Icon { get; set; }

        public string ficPageName { get; set; }
    }
}