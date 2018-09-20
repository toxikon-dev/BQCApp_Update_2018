using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using System.IO;

namespace Toxikon.BatchQC.Models.Reports
{
    public class MEMSDataSheet
    {
        private DataSheet dataSheet;
        private string liveFile = @"\\toxx\toxxShared\templates\MEMSDatasheet.docx";
        //private string testFile = @"C:\Users\BMcCulley\Documents\TestResources\BQC_Prep_Data_Sheet\MEMSDatasheet.docx";
        private object TemplateObject;
        private string DestinationFolder;
        private object DestinationObject;

        public MEMSDataSheet()
        {
            dataSheet = DataSheet.GetInstance();
            TemplateObject = liveFile;
            DestinationFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\BQCApp\\";
            DestinationObject = DestinationFolder + dataSheet.BatchCode.FullCode + "_" + 
                                DateTime.Now.ToString("yyyyMMddHHmmss") + ".docx";
        }

        public void Create()
        {
            if(!Directory.Exists(DestinationFolder))
            {
                Directory.CreateDirectory(DestinationFolder);
            }
            Microsoft.Office.Interop.Word._Application wordApp = new Microsoft.Office.Interop.Word.Application();
            object MissingObject = System.Reflection.Missing.Value;
            object ReadOnly = true;
            try
            {               
                File.Copy(TemplateObject.ToString(), DestinationObject.ToString());

                Microsoft.Office.Interop.Word._Document document = 
                        wordApp.Documents.Add(ref DestinationObject, ref MissingObject, 
                        ref MissingObject, ref MissingObject);

                SearchAndReplaceBookmarks(document);
                InsertProjects(document);
                InsertSpikeSolutions(document);
                InsertAllReagent(document);
                InsertSamplesTable(document);

                document.SaveAs(DestinationObject, 
                    MissingObject, MissingObject, MissingObject, MissingObject, MissingObject, ReadOnly);
                document.PrintPreview();
                wordApp.PrintPreview = true;
                wordApp.Visible = true;
            }
            catch(Exception e)
            {
                wordApp.Quit(ref MissingObject, ref MissingObject, ref MissingObject);
                MessageBox.Show(e.Message);
            }
        }

        private void SearchAndReplaceBookmarks(_Document document)
        {
            Dictionary<string, string> bookmarkDictionary = CreateBookmarkDictionary();

            foreach (string bookmarkName in bookmarkDictionary.Keys.ToList())
            {
                object bookmarkObject = bookmarkName;
                Bookmark bookmark = document.Bookmarks[ref bookmarkObject];
                bookmark.Range.Text = bookmarkDictionary[bookmarkName];
            }
        }

        private Dictionary<string, string> CreateBookmarkDictionary()
        {
            string dataSheetSampleUnit = dataSheet.BatchDetail.SampleType == SampleTypes.LIQUID ?
                                         Units.ML : Units.G;
            Dictionary<string, string> keyValues = new Dictionary<string, string>();
            keyValues.Add("BatchQC", dataSheet.BatchCode.FullCode);
            keyValues.Add("PrepDate", dataSheet.BatchDetail.PrepDate);
            keyValues.Add("PreparedBy", dataSheet.BatchDetail.PreparedBy);
            keyValues.Add("SampleType", dataSheet.BatchDetail.SampleType);
            keyValues.Add("PrepType", dataSheet.BatchDetail.PrepType);
            keyValues.Add("MethodName", dataSheet.BatchDetail.Method);
            keyValues.Add("MethodID", dataSheet.BatchDetail.MethodID);
            keyValues.Add("MethodTemp", dataSheet.BatchDetail.MethodTemp.ToString());
            keyValues.Add("BalanceID", dataSheet.BatchDetail.BalanceID);
            keyValues.Add("InstrumentID", dataSheet.BatchDetail.InstrumentID);
            keyValues.Add("PurifiedWater", dataSheet.BatchDetail.PurifiedWater);
            keyValues.Add("Analyte", dataSheet.BatchDetail.Analyte);
            keyValues.Add("SampleUnit", dataSheetSampleUnit);
            keyValues.Add("InitialDigestionUnit", dataSheetSampleUnit);
            return keyValues;
        }

        private void InsertProjects(_Document document)
        {
            object bookmarkObject = "ProjectNumbers";
            string projectStringBuilder = "";
            foreach(Project project in dataSheet.Projects)
            {
                projectStringBuilder += project.ProjectNumber;
                projectStringBuilder += "\v";
            }
            Bookmark bookmark = document.Bookmarks[ref bookmarkObject];
            bookmark.Range.Text = projectStringBuilder;
        }

        private void InsertSpikeSolutions(_Document document)
        {
            object bookmarkObject = "SpikeSolutions";
            string stringBuilder = "";
            foreach (SpikeSolution item in dataSheet.SpikeSolutions)
            {
                stringBuilder += item.ItemCode;
                stringBuilder += "\v";
            }
            Bookmark bookmark = document.Bookmarks[ref bookmarkObject];
            bookmark.Range.Text = stringBuilder;
        }

        private void InsertAllReagent(_Document document)
        {
            for(int i = 0; i < 4; i++)
            {
                Reagent reagent = new Reagent();
                if (i < dataSheet.Reagents.Count)
                {
                    reagent = dataSheet.Reagents[i];
                }
                InsertOneReagent(document, i + 1, reagent);
            }
        }

        private void InsertOneReagent(_Document document, int reagentIndex, Reagent reagent)
        {
            object objReagent = "R" + reagentIndex;
            object objRID = "RID" + reagentIndex;
            object objAmount = "A" + reagentIndex;
            object objUnit = "U" + reagentIndex;

            Bookmark bookmarkR = document.Bookmarks[ref objReagent];
            bookmarkR.Range.Text = reagent.ProductName;
            Bookmark bookmarkRID = document.Bookmarks[ref objRID];
            bookmarkRID.Range.Text = reagent.ItemCode;
            Bookmark bookmarkA = document.Bookmarks[ref objAmount];
            bookmarkA.Range.Text = reagent.Amount == 0 ? "N/A" : reagent.Amount.ToString();
            Bookmark bookmarkU = document.Bookmarks[ref objUnit];
            bookmarkU.Range.Text = reagent.Unit;
        }

        private void InsertSamplesTable(_Document document)
        {
            object MissingObject = System.Reflection.Missing.Value;
            List<Sample> samples = dataSheet.GetAllSamples();
            if (samples.Count != 0)
            {
                Table table = document.Tables[2];
                int rowCount = 2;
                foreach (Sample sample in samples)
                {
                    Row row = table.Rows.Add(ref MissingObject);
                    row.Range.Shading.BackgroundPatternColorIndex = WdColorIndex.wdWhite;
                    row.Range.Font.Bold = 0;
                    foreach (Cell cell in row.Cells)
                    {
                       CreateSampleTableItemRow(cell, sample);
                    }
                    rowCount += 1;
                }
                table.AutoFitBehavior(WdAutoFitBehavior.wdAutoFitContent);
                table.PreferredWidth = 504f;
                table.PreferredWidthType = WdPreferredWidthType.wdPreferredWidthPoints;
            }
        }

        private void CreateSampleTableItemRow(Cell cell, Sample item)
        {
            if (cell.ColumnIndex == 1)
            {
                cell.Range.Text = item.SampleCode;
            }
            else if (cell.ColumnIndex == 2)
            {
                cell.Range.Text = item.SampleAmount.ToString();
            }
            else if(cell.ColumnIndex == 3)
            {
                cell.Range.Text = item.InitialDigestionAmount.ToString();
            }
            else if (cell.ColumnIndex == 4)
            {
                cell.Range.Text = item.FinalAmount.ToString();
            }
            else if (cell.ColumnIndex == 5)
            {
                if(item.Comment != "")
                {
                    cell.Range.Text = item.Description + "\v" + "COMMENT: " + item.Comment;
                    Range commentRange = cell.Range.Duplicate;
                    int startPos = commentRange.Text.IndexOf("\v") + 1;
                    commentRange.MoveStart(WdUnits.wdCharacter, startPos);
                    commentRange.Font.ColorIndex = WdColorIndex.wdGray50;
                }
                else
                {
                    cell.Range.Text = item.Description.Trim() != "" ? 
                                      item.Description.Trim() : "N/A";
                }
            }
        }
    }
}
