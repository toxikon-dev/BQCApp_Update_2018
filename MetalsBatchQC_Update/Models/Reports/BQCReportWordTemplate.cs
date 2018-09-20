using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Toxikon.BatchQC.Models.Reports
{
    public class BQCReportWordTemplate
    {
        private BQCReport report;
        private object TemplateObject;
        private string DestinationFolder;
        private object DestinationObject;

        public BQCReportWordTemplate()
        {
            report = BQCReport.GetInstance();
            TemplateObject = @"\\toxx\toxxShared\templates\BQCReport.docx";
            DestinationFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + 
                                "\\BQCApp\\";
            DestinationObject = DestinationFolder + report.ProjectNumber + report.Method + "_" +
                                DateTime.Now.ToString("yyyyMMddHHmmss") + ".docx";
        }

        public void Create()
        {
            if (!Directory.Exists(DestinationFolder))
            {
                Directory.CreateDirectory(DestinationFolder);
            }
            Microsoft.Office.Interop.Word._Application wordApp = 
                            new Microsoft.Office.Interop.Word.Application();
            object MissingObject = System.Reflection.Missing.Value;
            object ReadOnly = true;
            try
            {
                File.Copy(TemplateObject.ToString(), DestinationObject.ToString());

                Microsoft.Office.Interop.Word._Document document =
                        wordApp.Documents.Add(ref DestinationObject, ref MissingObject,
                        ref MissingObject, ref MissingObject);

                SearchAndReplaceBookmarks(document);
                SetBatchQCStatus(document);

                document.SaveAs(DestinationObject, MissingObject, MissingObject, MissingObject, 
                                MissingObject, MissingObject, ReadOnly);
                document.PrintPreview();
                wordApp.PrintPreview = true;
                wordApp.Visible = true;
            }
            catch (Exception e)
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
            Dictionary<string, string> keyValues = new Dictionary<string, string>();
            keyValues.Add("BatchNumbers", this.BatchNumbersStringBuilder());
            keyValues.Add("ProjectNumber", report.ProjectNumber);
            keyValues.Add("Method", report.Method);
            keyValues.Add("Matrix", report.Matrix);
            keyValues.Add("AnalyticalInstrument", report.AnalyticalInstrument);
            keyValues.Add("BQCSampleTypes", report.BQCSampleTypes);
            keyValues.Add("BQCComment", report.BQCComment);
            keyValues.Add("SampleID", report.SampleID);
            keyValues.Add("RunID", report.RunID);
            keyValues.Add("Exceptions", report.Exceptions);
            keyValues.Add("RunComment", report.RunComment);
            keyValues.Add("Analyst", report.Analyst);
            keyValues.Add("StudyDirector", report.StudyDirector);
            return keyValues;
        }

        private string BatchNumbersStringBuilder()
        {
            string result = "";
            foreach (string batchNumber in report.BatchNumbers)
            {
                result += batchNumber + "\v";
            }
            return result;
        }

        private void SetBatchQCStatus(_Document document)
        {
            object acceptObject = "Accept";
            Bookmark acceptBookmark = document.Bookmarks[ref acceptObject];
            if(report.BQCStatus == "Reject")
            {
                acceptBookmark.Range.Font.Bold = 1;
                acceptBookmark.Range.Font.StrikeThrough = 1;
            }
            object rejectObject = "Reject";
            Bookmark rejectBookmark = document.Bookmarks[ref rejectObject];
            if (report.BQCStatus == "Accept")
            {
                rejectBookmark.Range.Font.Bold = 1;
                rejectBookmark.Range.Font.StrikeThrough = 1;
            }
        }
    }
}
