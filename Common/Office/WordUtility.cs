using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Office.Interop.Word;
using NPOI.XWPF.UserModel;

namespace Common.Office
{
    public class WordUtility
    {
        /// <summary>
        /// 输出模板docx文档(使用字典)
        /// </summary>
        /// <param name="tempFilePath">docx文件路径</param>
        /// <param name="outPath">输出文件路径</param>
        /// <param name="data">字典数据源</param>
        public static void Export(string tempFilePath, string outPath, Dictionary<string, string> data, Dictionary<string, List<string>> tabledata=null)
        {
            using (FileStream stream = File.OpenRead(tempFilePath))
            {
                XWPFDocument doc = new XWPFDocument(stream); 
                //遍历段落                  
                foreach (var para in doc.Paragraphs)
                {
                    ReplaceKey(para, data);
                }
                //遍历表格      
                foreach (var table in doc.Tables)
                {
                    foreach (var row in table.Rows)
                    {
                        foreach (var cell in row.GetTableCells())
                        {
                            foreach (var para in cell.Paragraphs)
                            {
                                ReplaceKey(para, data);
                            }
                        }
                    }
                }
                if(tabledata!=null)
                {
                    int rowindex = 0;
                    foreach (var table in doc.Tables)
                    {
                        for (var j=0;j< table.Rows.Count; j++)
                        {
                            var row = table.Rows[j];
                            var cells = row.GetTableCells();
                            for (var k = 0;k< cells.Count;k++)
                            {
                                var cell = cells[k];
                                foreach (var para in cell.Paragraphs)
                                {
                                    foreach (var run in para.Runs)
                                    {
                                       var text = run.ToString();
                                        if(tabledata.ContainsKey(text))
                                        {
                                            var trow = tabledata[text];
                                            foreach(var tinfos in trow)
                                            {
                                                var infos = tinfos.Split(','); 
                                                XWPFTableRow ntr = table.CreateRow();   //获得要复制的表格
                                               
                                                for (var i=0;i< infos.Length;i++)
                                                {
                                                    var info = infos[i]; 
                                                    ntr.GetCell(i).SetText(info);
                                                }

                                                
                                                //for (var s = 0; s < ntr.GetTableCells().Count; s++)
                                                //{
                                                //    if (ntr.GetCell(s).GetText().IsNullOrEmpty())
                                                //    {
                                                //        ntr.MergeCells(s - 1, s);
                                                //    }
                                                //}


                                                table.AddRow(ntr, rowindex+1); //添加上去 
                                                table.RemoveRow(table.Rows.Count - 1);

                                                int c = 0;
                                                for (var s = 0; s < infos.Length; s++)
                                                {
                                                    if (infos[s].IsNullOrEmpty())
                                                    {
                                                        ntr.MergeCells(s - 1-c, s-c);
                                                        c++;
                                                    }
                                                }


                                                //rowindex++;
                                            }
                                        }
                                    }
                                }
                            }
                            rowindex++;
                        }
                    }


                }


                //写文件
                FileStream outFile = new FileStream(outPath, FileMode.Create);
                doc.Write(outFile);
                outFile.Close();
            }
        }
        private static void ReplaceKey(XWPFParagraph para, Dictionary<string, string> data)
        {
            string text = "";
           
            int index = 0; int rnum = 0;
            int fontsize = 9;
            for (int x=0;x < para.Runs.Count;x++)
            {
                var run = para.Runs[x];
                text = run.ToString();
                int index1 = 0;
                int start = 0;
               
                foreach (var key in data.Keys)
                {
                     
                    //$$模板中数据占位符为$KEY$
                    if (text.Contains($"$"+key))
                    {
                        if (data[key].Contains("{v}"))
                        {
                            var vals = Regex.Split(data[key], "{v}");
                            for (var i = 0; i < vals.Length; i++)
                            {
                                if (i != 0)
                                {
                                    var r = para.CreateRun(); 
                                    r.AddBreak(BreakClear.ALL); 
                                    start += 1; rnum++;
                                }
                                if (i == 0)
                                {
                                    var v  = text.Replace($"$" + key, vals[i]);
                                    fontsize = run.FontSize;
                                    run.SetText(v);
                                    start = v.Length;
                                }
                                else if (i == vals.Length - 1)
                                {
                                    text = vals[i];
                                }
                                else
                                {
                                    var r = para.CreateRun(); r.FontSize = fontsize;
                                    r.SetText("   " + vals[i]);
                                    start += vals[i].Length; rnum++;
                                }
                            }
                        }
                        else
                        {
                            text = text.Replace($"$" + key, data[key].Replace(",", "，"));
                        } 
                    }
                    else if( text.Contains(key))
                    {
                        if(data[key].Contains("{v}"))
                        {
                            var vals = Regex.Split(data[key], "{v}");
                            for(var i=0;i< vals.Length;i++)
                            {
                                if(i!=0)
                                {
                                    var r = para.CreateRun();
                                    r.AddBreak(BreakClear.ALL); start += 1; rnum++;
                                }
                                if(i==0)
                                {
                                    var v = text.Replace(key, vals[i]);
                                    run.SetText(v); fontsize = run.FontSize;
                                    start += v.Length;
                                }
                                else if (i == vals.Length - 1)
                                {
                                    text = vals[i];
                                }
                                else
                                {
                                    var r = para.CreateRun();
                                    r.FontSize = fontsize;
                                    r.SetText(vals[i]);
                                    start += vals[i].Length; rnum++;
                                }
                            }
                        }
                        else
                        {
                            text = text.Replace(key, data[key].Replace(",", "，"));
                        } 
                    }
                    else if(text.Contains("$"))
                    {
                        text = text.Replace("$", "");
                    }
                    index1++;
                }
               if(start!=0)
                {
                    var r = para.CreateRun(); r.FontSize = fontsize; 
                    r.SetText(text); 
                }
                else
                {
                    run.SetText(text, start);
                }
                x = x + rnum;
                index++;
            }
        }


        /// <summary>
        /// 输出模板docx文档(使用反射)
        /// </summary>
        /// <param name="tempFilePath">docx文件路径</param>
        /// <param name="outPath">输出文件路径</param>
        /// <param name="data">对象数据源</param>
        public static void ExportObjet(string tempFilePath, string outPath, object data)
        {
            using (FileStream stream = File.OpenRead(tempFilePath))
            {
                XWPFDocument doc = new XWPFDocument(stream);
                //遍历段落                  
                foreach (var para in doc.Paragraphs)
                {
                    ReplaceKeyObjet(para, data);
                }
                //遍历表格      
                foreach (var table in doc.Tables)
                {
                    foreach (var row in table.Rows)
                    {
                        foreach (var cell in row.GetTableCells())
                        {
                            foreach (var para in cell.Paragraphs)
                            {
                                ReplaceKeyObjet(para, data);
                            }
                        }
                    }
                }
                //写文件
                FileStream outFile = new FileStream(outPath, FileMode.Create);
                doc.Write(outFile);
                outFile.Close();
            }
        }
        private static void ReplaceKeyObjet(XWPFParagraph para, object model)
        {
            string text = "";
            Type t = model.GetType();
            PropertyInfo[] pi = t.GetProperties();
            foreach (var run in para.Runs)
            {
                text = run.ToString();
                foreach (PropertyInfo p in pi)
                {
                    //$$模板中数据占位符为$KEY$
                    string key = $"${p.Name}$";
                    if (text.Contains(key))
                    {
                        try
                        {
                            text = text.Replace(key, p.GetValue(model, null).ToString());
                        }
                        catch (Exception ex)
                        {
                            //可能有空指针异常
                            text = text.Replace(key, "");
                        }
                    }
                }
                run.SetText(text, 0);
            }
        }
    }
}
