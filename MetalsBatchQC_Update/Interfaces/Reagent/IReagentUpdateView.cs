﻿using Toxikon.BatchQC.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Toxikon.BatchQC.Interfaces
{
    public interface IReagentUpdateView
    {
        void SetController(ReagentUpdateController controller);
        void SetDialogResult(DialogResult dialogResult);

        string ReagentID { get; set; }
        string ReagentName { get; set; }
        string Amount { get; set; }
    }
}
