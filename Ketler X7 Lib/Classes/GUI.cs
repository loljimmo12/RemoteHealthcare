﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ketler_X7_Lib.Classes
{
    public class GUI
    {
        /// <summary>
        /// The delegate used for safely updating the control
        /// </summary>
        public delegate void updateControlAction();

        /// <summary>
        /// Thread safely updates given control
        /// </summary>
        /// <param name="pControl"></param>
        /// <param name="pAction"></param>
        public static void safelyUpdateControl(System.Windows.Forms.Control pControl, updateControlAction pAction)
        {
            if (pControl.InvokeRequired)
            {
                pControl.Invoke(pAction);
                return;
            }

            pAction();
        }
    }
}
