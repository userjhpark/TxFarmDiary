using DevExpress.Data.Mask.Internal;
using HxCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WIA;

namespace TxFarmDiaryAI.Win
{
    public partial class SbUtils : HxCore.Win.HxWin
    {
        #region Static & Instance
        public static SbUtils Instance { get; private set;} = new();
        public static SbUtils CreateInstance() { return new SbUtils(); }
        public static SbUtils GetInstance(bool condition = false) { return ( condition == true ? Instance : CreateInstance()) ?? (Instance = CreateInstance()); }
        #endregion

        public SbUtils() 
            : base()
        {   // Initialize
            ; ;
        }
    }
    /*
    public class Utils : SbUtils
    {
        
    }
    */
}
