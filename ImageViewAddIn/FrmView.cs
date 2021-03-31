using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Rectangle = System.Drawing.Rectangle;

namespace ImageViewAddIn
{
    public partial class FrmView : Form
    {
        private string _strCol = "";
        private Worksheet _sheet = null;
        private Dictionary<string, byte[]> dicImageData = new Dictionary<string, byte[]>();
        private Dictionary<string, string> dicImageCache = new Dictionary<string, string>();
        private bool _caching = false;

        public FrmView()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void FrmView_Load(object sender, EventArgs e)
        {
            dicImageCache = LoadCacheInfo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_sheet != null)
            {
                try
                {
                    _sheet.SelectionChange -= Sheet_SelectionChange;
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            }

            _strCol = txtCol.Text.Trim().ToUpper();
            _sheet = Globals.ThisAddIn.Application.ActiveSheet;
            _sheet.SelectionChange += Sheet_SelectionChange;
        }

        private void Sheet_SelectionChange(Range Target)
        {
            if (Target.Rows.Count == 1)
            {
                string url = _sheet.Range[$"{_strCol}{Target.Row}"].Text;
                if (IsValidUrl(url))
                {
                    if (dicImageCache.ContainsKey(url))
                    {
                        if (File.Exists(dicImageCache[url]))
                        {
                            if (!dicImageData.ContainsKey(url))
                                dicImageData.Add(url, File.ReadAllBytes(dicImageCache[url]));
                        }
                        else
                            dicImageCache.Remove(url);
                    }
                    if (!dicImageData.ContainsKey(url))
                    {
                        dicImageData.Add(url, LoadImage(url));
                    }


                    Image img = Image.FromStream(new MemoryStream(dicImageData[url]));
                    pictureBox1.Image = img;
                }
            }
        }

        private bool IsValidUrl(string strUrl)
        {
            Uri uri;
            return Uri.TryCreate(strUrl, UriKind.Absolute, out uri);
        }

        private byte[] LoadImage(string strUrl)
        {
            WebClient webClient = new WebClient();
            return webClient.DownloadData(strUrl);
        }

        private void btnCache_Click(object sender, EventArgs e)
        {
            if (_strCol == "")
            {
                MessageBox.Show("还没有设置图片在哪一列");
                return;
            }

            if (_caching)
            {
                MessageBox.Show("正在缓存中，等当前缓存完成后再试");
                return;
            }

            Task.Factory.StartNew(() =>
            {
                _caching = true;
                Range usedRange = _sheet.UsedRange;
                int row = usedRange.Rows.Count;
                for (int i = 1; i <= row; i++)
                {
                    string fileName = usedRange.Range[$"A{i}"].Text;
                    lblCacheInfo.Text = $"{i}/{row}";
                    string url = usedRange.Range[$"{_strCol}{i}"].Text;
                    if (!IsValidUrl(url))
                        continue;
                    if (dicImageCache.ContainsKey(url))
                        continue;

                    string file = "";
                    if (dicImageData.ContainsKey(url))
                    {
                        file = CreateCachePicture(fileName, dicImageData[url]);
                    }
                    else
                    {
                        file = CreateCachePicture(fileName, LoadImage(url));
                    }

                    if (File.Exists(file))
                        dicImageCache.Add(url, file);
                }

                WriteCacheInfoFile(dicImageCache);
                lblCacheInfo.Text = "";
                _caching = false;
            });

        }

        private string CreateCachePicture(string fileName, byte[] data)
        {
            string file = $@"{GetCacheFolder()}\{fileName}.png";
            int index = 1;
            while (File.Exists(file))
            {
                file = $@"{GetCacheFolder()}\{fileName}({index}).png";
                index++;
            }
            File.WriteAllBytes(file, data);
            return file;
        }

        private void btnmOpenCacheDir_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(GetCacheFolder());
        }

        private string GetCacheDataFilePath()
        {
            return $@"{GetCacheFolder()}\cache.txt";
        }

        private Dictionary<string, string> LoadCacheInfo()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            string strCacheFile = GetCacheDataFilePath();
            if (!File.Exists(strCacheFile))
                return dic;

            var lines = File.ReadAllLines(strCacheFile, Encoding.UTF8);
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line) || !line.Contains('\t'))
                    continue;

                var splits = line.Split('\t');
                dic.Add(splits[0], splits[1]);
            }

            return dic;
        }

        private void WriteCacheInfoFile(Dictionary<string, string> dicInfo)
        {
            string strCacheFile = GetCacheDataFilePath();
            var lines = dicInfo.Select(d => $"{d.Key}\t{d.Value}").ToArray();
            File.WriteAllLines(strCacheFile, lines, Encoding.UTF8);
        }

        private string GetCacheFolder()
        {
            string folder = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            folder += @"\ImageViewAddInCache";
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);
            return folder;
        }
    }
}
