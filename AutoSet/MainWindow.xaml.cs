using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TSD = Tekla.Structures.Drawing;
using TSM = Tekla.Structures.Model;
using Tekla.Structures.Model.Operations;
using System.IO;
using Path = System.IO.Path;
using System.Collections.Specialized;

namespace AutoSet
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AutoSetWindow.Topmost = true;
        }

        void ExportDWG()
        {
            RunRequiredMacro(@"..\drawings\ESD DWG Export.cs");

            //string SetFolder = myTextBox.Text.ToString();
            //SetFolder = SetFolder.Replace(@"\", @"\\");
            //string SetFolderDWG = SetFolder + @"\\DWG";


            //if (Directory.Exists(@"C:\ProgramData\Trimble\Tekla Structures\2025.0\"))
            //{
            //    string path = @"C:\Dropbox\technology\Standarts\Tekla2025 Standards\Environments\common\macros\drawings\ExportDWG_Macro.cs";
            //    string pathdll = @"C:\Dropbox\technology\Standarts\Tekla2025 Standards\Environments\common\macros\drawings\ExportDWG.cs.dll";
            //    string pathpdb = @"C:\Dropbox\technology\Standarts\Tekla2025 Standards\Environments\common\macros\drawings\ExportDWG.cs.pdb";
            //    // This text is added only once to the file.
            //    if (!File.Exists(path))
            //    {
            //        // Create a file to write to.
            //        string st1 = "#pragma warning disable 1633 // Unrecognized #pragma directive" + Environment.NewLine;
            //        File.WriteAllText(path, st1);
            //    }

            //    string st2 = @"#pragma reference ""Tekla.Macros.Wpf.Runtime""" + Environment.NewLine;
            //    File.AppendAllText(path, st2);

            //    string st3 = @"#pragma reference ""Tekla.Macros.Akit""" + Environment.NewLine;
            //    File.AppendAllText(path, st3);

            //    string st4 = @"#pragma reference ""Tekla.Macros.Runtime""" + Environment.NewLine;
            //    File.AppendAllText(path, st4);

            //    string st5 = @"#pragma warning restore 1633 // Unrecognized #pragma directive" + Environment.NewLine;
            //    File.AppendAllText(path, st5);

            //    string st6 = @"namespace UserMacros {" + Environment.NewLine;
            //    File.AppendAllText(path, st6);

            //    string st7 = @"public sealed class Macro {" + Environment.NewLine;
            //    File.AppendAllText(path, st7);

            //    string st8 = @"[Tekla.Macros.Runtime.MacroEntryPointAttribute()]" + Environment.NewLine;
            //    File.AppendAllText(path, st8);

            //    string st9 = @" public static void Run(Tekla.Macros.Runtime.IMacroRuntime runtime) {" + Environment.NewLine;
            //    File.AppendAllText(path, st9);

            //    string st10 = @"Tekla.Macros.Akit.IAkitScriptHost akit = runtime.Get<Tekla.Macros.Akit.IAkitScriptHost>();" + Environment.NewLine;
            //    File.AppendAllText(path, st10);

            //    string st11 = @"Tekla.Macros.Wpf.Runtime.IWpfMacroHost wpf = runtime.Get<Tekla.Macros.Wpf.Runtime.IWpfMacroHost>();" + Environment.NewLine;
            //    File.AppendAllText(path, st11);

            //    string st12 = @"wpf.InvokeCommand(""CommandRepository"", ""Export.Drawings"");" + Environment.NewLine;
            //    File.AppendAllText(path, st12);

            //    string st13 = @"akit.ValueChange(""diaExportDrawings"", ""textFileName""," + '"' + SetFolderDWG + '"' + ");" + Environment.NewLine;
            //    File.AppendAllText(path, st13);

            //    string st14 = $@"akit.PushButton(""butExport"", ""diaExportDrawings"");" + Environment.NewLine;
            //    File.AppendAllText(path, st14);

            //    string st17 = @"}" + Environment.NewLine;
            //    File.AppendAllText(path, st17);

            //    string st18 = @"}" + Environment.NewLine;
            //    File.AppendAllText(path, st18);

            //    string st19 = @"}" + Environment.NewLine;
            //    File.AppendAllText(path, st19);

            //    TSM.Operations.Operation.RunMacro(@"..\drawings\ExportDWG_Macro.cs");

            //    File.Delete(path);
            //    File.Delete(pathdll);
            //    File.Delete(pathpdb);
            //}
        }
              
        void PrintPDF()
        {
            RunRequiredMacro(@"..\drawings\ESD PDF Print.cs");
            //string SetFolder0 = myTextBox.Text.ToString();
            //string SetFolder = SetFolder0 + @"\\";
            //string SetFolderPDF = SetFolder + @"PDF\\";
            //if (Directory.Exists(@"C:\ProgramData\Trimble\Tekla Structures\2025.0\"))
            //{
            //    //string path = @"C:\Dropbox\technology\Standarts\Tekla2025 Standards\Environments\common\macros\drawings\PrintPDF_Macro.cs";
            //    //string pathdll = @"C:\Dropbox\technology\Standarts\Tekla2025 Standards\Environments\common\macros\drawings\PrintPDF.cs.dll";
            //    //string pathpdb = @"C:\Dropbox\technology\Standarts\Tekla2025 Standards\Environments\common\macros\drawings\PrintPDF.cs.pdb";
            //    //// This text is added only once to the file.
            //    //if (!File.Exists(path))
            //    //{
            //    //    // Create a file to write to.
            //    //    string st1 = "#pragma warning disable 1633 // Unrecognized #pragma directive" + Environment.NewLine;
            //    //    File.WriteAllText(path, st1);
            //    //}

            //    //string st2 = @"#pragma reference ""Tekla.Macros.Wpf.Runtime""" + Environment.NewLine;
            //    //File.AppendAllText(path, st2);

            //    //string st3 = @"#pragma reference ""Tekla.Macros.Runtime""" + Environment.NewLine;
            //    //File.AppendAllText(path, st3);

            //    //string st4 = @"#pragma warning restore 1633 // Unrecognized #pragma directive" + Environment.NewLine;
            //    //File.AppendAllText(path, st4);

            //    //string st6 = @"namespace UserMacros {" + Environment.NewLine;
            //    //File.AppendAllText(path, st6);

            //    //string st7 = @"public sealed class Macro {" + Environment.NewLine;
            //    //File.AppendAllText(path, st7);

            //    //string st8 = @"[Tekla.Macros.Runtime.MacroEntryPointAttribute()]" + Environment.NewLine;
            //    //File.AppendAllText(path, st8);

            //    //string st9 = @" public static void Run(Tekla.Macros.Runtime.IMacroRuntime runtime) {" + Environment.NewLine;
            //    //File.AppendAllText(path, st9);

            //    //string st10 = @"Tekla.Macros.Akit.IAkitScriptHost akit = runtime.Get<Tekla.Macros.Akit.IAkitScriptHost>();" + Environment.NewLine;
            //    //File.AppendAllText(path, st10);

            //    //string st11 = @"Tekla.Macros.Wpf.Runtime.IWpfMacroHost wpf = runtime.Get<Tekla.Macros.Wpf.Runtime.IWpfMacroHost>();" + Environment.NewLine;
            //    //File.AppendAllText(path, st11);

            //    //string st12 = @"wpf.View(""DocumentManager.MainWindow"").Find(""AID_DOCMAN_DataGridControl"").As.ContextMenu.Find(""AID_DocMgr_Print"").As.Button.Invoke();" + Environment.NewLine;
            //    //File.AppendAllText(path, st12);

            //    //string st13 = $@"wpf.InvokeCommand(""CommandRepository"", ""Common.PrintDrawings"");" + Environment.NewLine;
            //    //File.AppendAllText(path, st13);
            //    ////FOLDER
            //    //string st17 = $@"wpf.View(""DPMPrinterFeature.DPMPrinterViewWindow"").Find(""AID_PDFPD_SettingsTabControl"", ""AID_PDFPD_ParentStackPanel"", ""AID_PDFPD_FileLocationPanel"", ""AID_PDFPD_FileLocation"").As.TextBox.SetText(@" + '"' + SetFolderPDF + '"' + ");" + Environment.NewLine;
            //    //File.AppendAllText(path, st17);

            //    //string st18 = @"wpf.View(""DPMPrinterFeature.DPMPrinterViewWindow"").Find(""AID_PDFPD_SettingsTabControl"", ""AID_PDFPD_ParentStackPanel"", ""AID_PDFPD_FitToPaper"").As.ToggleButton.State.SetChecked();" + Environment.NewLine;
            //    //File.AppendAllText(path, st18);

            //    //string st19 = @"wpf.View(""DPMPrinterFeature.DPMPrinterViewWindow"").Find(""AID_PDFPD_SettingsTabControl"", ""AID_PDFPD_ParentStackPanel"", ""AID_PDFPD_MultipleSheets"").As.ToggleButton.State.SetUnchecked();" + Environment.NewLine;
            //    //File.AppendAllText(path, st19);

            //    //string st20 = @"wpf.View(""DPMPrinterFeature.DPMPrinterViewWindow"").Find(""AID_PDFPD_SettingsTabControl"", ""AID_PDFPD_ParentStackPanel"", ""AID_PDFPD_CenterDrawingOnPaper"").As.ToggleButton.State.SetUnchecked();" + Environment.NewLine;
            //    //File.AppendAllText(path, st20);

            //    //string st21 = @"wpf.View(""DPMPrinterFeature.DPMPrinterViewWindow"").Find(""AID_PDFPD_SettingsTabControl"", ""AID_PDFPD_ParentStackPanel"", ""AID_PDFPD_PaperSizePanel"", ""AID_PDFPD_PaperSize"").As.Selector.Select(0);" + Environment.NewLine;
            //    //File.AppendAllText(path, st21);

            //    //string st22 = @"wpf.View(""DPMPrinterFeature.DPMPrinterViewWindow"").Find(""AID_PDFPD_SettingsTabControl"", ""AID_PDFPD_ParentStackPanel"", ""AID_PDFPD_OrientationPanel"", ""AID_PDFPD_Orientation"").As.Selector.Select(0);" + Environment.NewLine;
            //    //File.AppendAllText(path, st22);

            //    //string st23 = @"wpf.View(""DPMPrinterFeature.DPMPrinterViewWindow"").Find(""AID_PDFPD_SettingsTabControl"", ""AID_PDFPD_ParentStackPanel"", ""AID_PDFPD_EmbedFontPanel"", ""AID_PDFPD_EmbedFonts"").As.ToggleButton.State.SetChecked();" + Environment.NewLine;
            //    //File.AppendAllText(path, st23);

            //    //string st24 = @"wpf.View(""DPMPrinterFeature.DPMPrinterViewWindow"").Find(""AID_PDFPD_SettingsTabControl"", ""AID_PDFPD_ParentStackPanel"", ""AID_PDFPD_ColorPanel"", ""AID_PDFPD_Color"").As.Selector.Select(1);" + Environment.NewLine;
            //    //File.AppendAllText(path, st24);

            //    //string st25 = @"wpf.View(""DPMPrinterFeature.DPMPrinterViewWindow"").Find(""AID_PDFPD_SettingsTabControl"", ""AID_PDFPD_LinePropertiesTab"").As.SelectorItem.Select();" + Environment.NewLine;
            //    //File.AppendAllText(path, st25);

            //    //string st26 = @"wpf.View(""DPMPrinterFeature.LinePropertiesView"").Find(""AID_PDFPD_ColorTable"", ""AID_PDFPD_ColorTableItem"", ""AID_PDFPD_ColorTablePenThickness153"").As.TextBox.SetText(""0"");" + Environment.NewLine;
            //    //File.AppendAllText(path, st26);

            //    //string st27 = @" wpf.View(""DPMPrinterFeature.LinePropertiesView"").Find(""AID_PDFPD_ColorTable"", ""AID_PDFPD_ColorTableItem"", ""AID_PDFPD_ColorTablePenThickness160"").As.TextBox.SetText(""0"");" + Environment.NewLine;
            //    //File.AppendAllText(path, st27);

            //    //string st28 = @"wpf.View(""DPMPrinterFeature.LinePropertiesView"").Find(""AID_PDFPD_ColorTable"", ""AID_PDFPD_ColorTableItem"", ""AID_PDFPD_ColorTablePenThickness161"").As.TextBox.SetText(""0"");" + Environment.NewLine;
            //    //File.AppendAllText(path, st28);

            //    //string st29 = @"wpf.View(""DPMPrinterFeature.LinePropertiesView"").Find(""AID_PDFPD_ColorTable"", ""AID_PDFPD_ColorTableItem"", ""AID_PDFPD_ColorTablePenThickness162"").As.TextBox.SetText(""7"");" + Environment.NewLine;
            //    //File.AppendAllText(path, st29);

            //    //string st30 = @" wpf.View(""DPMPrinterFeature.LinePropertiesView"").Find(""AID_PDFPD_ColorTable"", ""AID_PDFPD_ColorTableItem"", ""AID_PDFPD_ColorTablePenThickness163"").As.TextBox.SetText(""0"");" + Environment.NewLine;
            //    //File.AppendAllText(path, st30);

            //    //string st31 = @"wpf.View(""DPMPrinterFeature.LinePropertiesView"").Find(""AID_PDFPD_ColorTable"", ""AID_PDFPD_ColorTableItem"", ""AID_PDFPD_ColorTablePenThickness164"").As.TextBox.SetText(""4"";" + Environment.NewLine;
            //    //File.AppendAllText(path, st31);

            //    //string st32 = @"wpf.View(""DPMPrinterFeature.LinePropertiesView"").Find(""AID_PDFPD_ColorTable"", ""AID_PDFPD_ColorTableItem"", ""AID_PDFPD_ColorTablePenThickness165"").As.TextBox.SetText(""0"");" + Environment.NewLine;
            //    //File.AppendAllText(path, st32);

            //    //string st33 = @"wpf.View(""DPMPrinterFeature.LinePropertiesView"").Find(""AID_PDFPD_ColorTable"", ""AID_PDFPD_ColorTableItem"", ""AID_PDFPD_ColorTablePenThickness154"").As.TextBox.SetText(""0"");" + Environment.NewLine;
            //    //File.AppendAllText(path, st33);

            //    //string st34 = @"  wpf.View(""DPMPrinterFeature.LinePropertiesView"").Find(""AID_PDFPD_ColorTable"", ""AID_PDFPD_ColorTableItem"", ""AID_PDFPD_ColorTablePenThickness155"").As.TextBox.SetText(""0"");" + Environment.NewLine;
            //    //File.AppendAllText(path, st34);

            //    //string st35 = @"wpf.View(""DPMPrinterFeature.LinePropertiesView"").Find(""AID_PDFPD_ColorTable"", ""AID_PDFPD_ColorTableItem"", ""AID_PDFPD_ColorTablePenThickness156"").As.TextBox.SetText(""0"");" + Environment.NewLine;
            //    //File.AppendAllText(path, st35);

            //    //string st36 = @"wpf.View(""DPMPrinterFeature.LinePropertiesView"").Find(""AID_PDFPD_ColorTable"", ""AID_PDFPD_ColorTableItem"", ""AID_PDFPD_ColorTablePenThickness157"").As.TextBox.SetText(""0"");" + Environment.NewLine;
            //    //File.AppendAllText(path, st36);

            //    //string st37 = @"wpf.View(""DPMPrinterFeature.LinePropertiesView"").Find(""AID_PDFPD_ColorTable"", ""AID_PDFPD_ColorTableItem"", ""AID_PDFPD_ColorTablePenThickness158"").As.TextBox.SetText(""0"");" + Environment.NewLine;
            //    //File.AppendAllText(path, st37);

            //    //string st38 = @"wpf.View(""DPMPrinterFeature.LinePropertiesView"").Find(""AID_PDFPD_ColorTable"", ""AID_PDFPD_ColorTableItem"", ""AID_PDFPD_ColorTablePenThickness159"").As.TextBox.SetText(""0"");" + Environment.NewLine;
            //    //File.AppendAllText(path, st38);

            //    //string st39 = @"wpf.View(""DPMPrinterFeature.LinePropertiesView"").Find(""AID_PDFPD_ColorTable"", ""AID_PDFPD_ColorTableItem"", ""AID_PDFPD_ColorTablePenThickness130"").As.TextBox.SetText(""0"");" + Environment.NewLine;
            //    //File.AppendAllText(path, st39);

            //    //string st40 = @"wpf.View(""DPMPrinterFeature.LinePropertiesView"").Find(""AID_PDFPD_ColorTable"", ""AID_PDFPD_ColorTableItem"", ""AID_PDFPD_ColorTablePenThickness131"").As.TextBox.SetText(""0"");" + Environment.NewLine;
            //    //File.AppendAllText(path, st40);

            //    //string st41 = @"wpf.View(""DPMPrinterFeature.LinePropertiesView"").Find(""AID_PDFPD_ColorTable"", ""AID_PDFPD_ColorTableItem"", ""AID_PDFPD_ColorTablePenThickness132"").As.TextBox.SetText(""0"");" + Environment.NewLine;
            //    //File.AppendAllText(path, st41);

            //    //string st42 = @"wpf.View(""DPMPrinterFeature.LinePropertiesView"").Find(""AID_PDFPD_ColorTable"", ""AID_PDFPD_ColorTableItem"", ""AID_PDFPD_ColorTablePenThickness133"").As.TextBox.SetText(""0"");" + Environment.NewLine;
            //    //File.AppendAllText(path, st42);

            //    //string st43 = @"wpf.View(""DPMPrinterFeature.LinePropertiesView"").Find(""AID_PDFPD_ColorTable"", ""AID_PDFPD_ColorTableItem"", ""AID_PDFPD_ColorTablePenThickness133"").As.TextBox.SetText(""0"");" + Environment.NewLine;
            //    //File.AppendAllText(path, st43);

            //    //string st44 = @"wpf.View(""DPMPrinterFeature.DPMPrinterViewWindow"").Find(""AID_PDFPD_SettingsTabControl"", ""AID_PDFPD_OptionsTab"").As.SelectorItem.Select();" + Environment.NewLine;
            //    //File.AppendAllText(path, st44);

            //    //string st45 = @"wpf.View(""DPMPrinterFeature.DPMPrinterViewWindow"").Find(""AID_PDFPD_SettingsTabControl"", ""AID_PDFPD_ParentStackPanel"", ""AID_PDFPD_IncludeRevision"").As.ToggleButton.State.SetUnchecked();" + Environment.NewLine;
            //    //File.AppendAllText(path, st45);

            //    //string st46 = @"wpf.View(""DPMPrinterFeature.DPMPrinterViewWindow"").Find(""AID_PDFPD_SettingsTabControl"", ""AID_PDFPD_ParentStackPanel"", ""AID_PDFPD_OpenFolderWhenFinished"").As.ToggleButton.State.SetUnchecked();" + Environment.NewLine;
            //    //File.AppendAllText(path, st46);

            //    //string st47 = @"wpf.View(""DPMPrinterFeature.DPMPrinterViewWindow"").Find(""AID_PDFPD_SettingsTabControl"", ""AID_PDFPD_ParentStackPanel"", ""AID_PDFPD_OutputToSingleFile"").As.ToggleButton.State.SetUnchecked();" + Environment.NewLine;
            //    //File.AppendAllText(path, st47);

            //    //string st48 = @"wpf.View(""DPMPrinterFeature.DPMPrinterViewWindow"").Find(""AID_PDFPD_SettingsTabControl"", ""AID_PDFPD_ParentStackPanel"", ""AID_PDFPD_OpenFileWhenFinished"").As.ToggleButton.State.SetUnchecked();" + Environment.NewLine;
            //    //File.AppendAllText(path, st48);

            //    //string st49 = @"wpf.View(""DPMPrinterFeature.DPMPrinterViewWindow"").Find(""AID_PDFPD_PrintButton"").As.Button.Invoke();" + Environment.NewLine;
            //    //File.AppendAllText(path, st49);

            //    //string st50 = @"}" + Environment.NewLine;
            //    //File.AppendAllText(path, st50);

            //    //string st51 = @"}" + Environment.NewLine;
            //    //File.AppendAllText(path, st51);

            //    //string st52 = @"}" + Environment.NewLine;
            //    //File.AppendAllText(path, st52);

            //    //TSM.Operations.Operation.RunMacro(@"..\drawings\ESD PDF Print.cs");

            //    //File.Delete(path);
            //    //File.Delete(pathdll);
            //    //File.Delete(pathpdb);
            //}
        }

        void ConvertDSTV()
        {
            RunRequiredMacro(@"..\modeling\ESD DSTV to DXF EIW.cs");
        }

        private void RunRequiredMacro(string fileName)
        {
            if (!Operation.RunMacro(fileName))
                throw new InvalidOperationException("Tekla не запустила макрос: " + fileName);
        }

        public bool IsDirectoryEmpty(string path)
        {
            return !Directory.EnumerateFileSystemEntries(path).Any();
        }
        void FolderCheckAndCreate(string path)
        {
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
                Directory.CreateDirectory(path);
            }
            else Directory.CreateDirectory(path);
        }
        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                CreateSet();
            }
            catch (Exception error)
            {
                var cause = error.GetBaseException();
                var missingDependency = cause is FileNotFoundException || cause is FileLoadException ||
                    cause is TypeLoadException || cause is BadImageFormatException;
                MessageBox.Show(this,
                    "Не удалось создать комплект: " + cause.Message +
                    (missingDependency ? "\n\nЗапускайте AutoSet из папки, где находятся DLL Tekla Structures 2025." : ""),
                    "Ошибка AutoSet", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CreateSet()
        {
            // PrintAttributes
            //TSD.DPMPrinterAttributes printAttributes = new TSD.DPMPrinterAttributes();
            //printAttributes.ColorMode = TSD.DotPrintColor.BlackAndWhite;
            //printAttributes.NumberOfCopies = 1;
            //printAttributes.OpenFileWhenFinished = false;
            //printAttributes.Orientation = TSD.DotPrintOrientationType.Auto;
            //printAttributes.OutputType = TSD.DotPrintOutputType.PDF;
            //printAttributes.PaperSize = TSD.DotPrintPaperSize.Auto;
            //printAttributes.PrinterName = "Bluebeam PDF"; // Must use local PDF printer name
            //printAttributes.PrintToMultipleSheet = TSD.DotPrintToMultipleSheet.Off;
            //printAttributes.ScaleFactor = 1.0;
            //printAttributes.ScalingMethod = TSD.DotPrintScalingType.Auto;

            //string pdfName = "";
            var myModel = new TSM.Model();
            if (!myModel.GetConnectionStatus())
                throw new InvalidOperationException("Нет соединения с открытой моделью Tekla Structures.");
            var myModelInfo = myModel.GetInfo();
            if (myModelInfo == null || String.IsNullOrWhiteSpace(myModelInfo.ModelPath))
                throw new InvalidOperationException("Не удалось определить папку модели Tekla Structures.");
            var myModelPath = myModelInfo.ModelPath;

            string PdffilePath = myModelPath + @"\PDF\";
            string PlotfilePath = myModelPath + @"\Plotfiles\";
            string SetFolder0 = myModelPath+@"\_Set\";

            string SetFolder = SetFolder0 + @"\\";
            string SetFolder1 = SetFolder0;

            string SetFolderPDF = SetFolder + @"PDF\\";
            string SetFolderDWG = SetFolder + @"DWG\\";
            string SetFolderNC = SetFolder + @"NC\\";
            string SetFolderReports = SetFolder + @"Reports\\";
            string SetFolderNCAngles = SetFolderNC + @"Angles\\";
            string SetFolderNCPlates = SetFolderNC + @"Plates\\";
            string SetFolderNCProfiles = SetFolderNC + @"Profiles\\";


            //Delete old folders and create new
            if (!Directory.Exists(SetFolder))
                Directory.CreateDirectory(SetFolder);
            if (CheckPDF.IsChecked == true)
                FolderCheckAndCreate(SetFolderPDF);
            if (CheckDWG.IsChecked == true)
            {
                FolderCheckAndCreate(SetFolderDWG);
                FolderCheckAndCreate(PlotfilePath + @"\\");
            }


            if (CheckNC.IsChecked == true) FolderCheckAndCreate(SetFolderNC);


            //Report Creation
            if (CheckReport.IsChecked == true)
            {
                FolderCheckAndCreate(SetFolderReports);
                Operation.CreateReportFromSelected("ASSEMBLY LIST.pdf", SetFolderReports + "Assembly list.pdf", "", "", "");
                Operation.CreateReportFromSelected("ASSEMBLY LIST W BOM.pdf", SetFolderReports + "Assembly list w BOM.pdf", "", "", "");
                Operation.CreateReportFromSelected("MATERIAL LIST.pdf", SetFolderReports + "Material list.pdf", "", "", "");
                Operation.CreateReportFromSelected("BOLT LIST.pdf", SetFolderReports + "Bolt list.pdf", "", "", "");
                Operation.CreateReportFromSelected("MATLIST EXCEL.xls", SetFolderReports + "Material list.xls", "", "", "");
            }

            //Create NC Files
            if (CheckNC.IsChecked == true)
            {
                Operation.CreateNCFilesFromSelected("DSTV for plates", SetFolderNCPlates);
                Operation.CreateNCFilesFromSelected("DSTV for angles", SetFolderNCAngles);
                Operation.CreateNCFilesFromSelected("DSTV for profiles", SetFolderNCProfiles);
            }

            //Export DWG
            if (CheckDWG.IsChecked == true)
                ExportDWG();

            //Printing
            if (CheckPDF.IsChecked == true)
                PrintPDF();

            //DSTV to DXF Convert
            if (CheckDXF.IsChecked == true)
                ConvertDSTV();


            List<string> Uselessshit = System.IO.Directory.GetFiles(SetFolder + @"\\").ToList();
            foreach (string File2 in Uselessshit)
            {
                if (System.IO.Path.GetExtension(File2).ToString().StartsWith(".dpm"))
                    System.IO.File.Delete(File2);
                else if (System.IO.Path.GetExtension(File2).ToString().StartsWith(".json"))
                    System.IO.File.Delete(File2);
            }

            MessageBox.Show(this, "Команды создания комплекта отправлены в Tekla. Проверьте файлы в папке _Set.");
            System.Diagnostics.Process.Start(SetFolder);
            this.Close();
        }

    }
}
