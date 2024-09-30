using CefSharp;
using CefSharp.WinForms;
using System.Net;
using System.Net.Http;

namespace DownLoad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int a = 0;
        private async void button1_Click(object sender, EventArgs e)
        {
            CefSettings settings = new CefSettings();
            await Cef.InitializeAsync(settings);
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "All Files|*.*";
            if (save.ShowDialog() == DialogResult.OK)
            {
                string path = save.FileName;
                bool folderExists = Directory.Exists(path);
                if (!folderExists)
                    Directory.CreateDirectory(path);
                for (int i = int.Parse(from.Value.ToString()); i <= int.Parse(to.Value.ToString()); i++)
                {
                    ChromiumWebBrowser browser = new ChromiumWebBrowser($"{link.Text}/chuong-{i}")
                    {
                        Dock = DockStyle.Fill,
                    };
                    this.Controls.Add(browser);
                    browser.Show();
                    await WaitForBrowserReady(browser);
                    await WaitForPageToLoad(browser);
                    await FindElementInBrowser(browser, save);
                    a++;
                }
                MessageBox.Show("Tải xong!!!!!");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn đường dẫn lưu ảnh");
            }

        }
        private async Task WaitForBrowserReady(ChromiumWebBrowser browser)
        {
            while (!browser.IsBrowserInitialized)
            {
                await Task.Delay(100); // Đợi một chút trước khi kiểm tra lại
            }
        }
        private async Task WaitForPageToLoad(ChromiumWebBrowser browser)
        {
            while (true)
            {
                var result = await browser.GetMainFrame().EvaluateScriptAsync("document.readyState");
                if (result.Success && result.Result.ToString() == "complete")
                {
                    break; // Trang đã tải xong
                }
                await Task.Delay(100); // Đợi một chút trước khi kiểm tra lại
            }
        }
        private async Task FindElementInBrowser(ChromiumWebBrowser browser, SaveFileDialog save)
        {
            var test = await browser.GetMainFrame().EvaluateScriptAsync("document.readyState");
            await Task.Delay(3000);
            var script = @"
                            var images = document.getElementsByClassName('image');
                            var srcList = [];
                            for (var i = 0; i < images.length; i++) {
                                var src = images[i].outerHTML;
                                if (src) {
                                    srcList.push(src);
                                }
                            }
                            srcList;
                        ";
            while (true)
            {
                var result = await browser.GetMainFrame().EvaluateScriptAsync(script);
                if (result.Success && result.Result != null)
                {
                    var srcList = (List<object>)result.Result;

                    try
                    {
                        string pathchapter = $@"{save.FileName}\chapter {a + 1}";
                        bool folderChapterExists = Directory.Exists(pathchapter);
                        if (!folderChapterExists)
                            Directory.CreateDirectory(pathchapter);
                        for (int k = 0; k < srcList.Count; k++)
                        {

                            string imageUrl = srcList[k].ToString();

                            string filePath = $@"{pathchapter}\{k}.jpg";

                            var imageBytes = await convertImg(imageUrl, browser);

                            await File.WriteAllBytesAsync(filePath, imageBytes);

                            Console.WriteLine("Tải ảnh thành công và lưu tại: " + filePath);
                        }

                    }
                    catch (Exception e)
                    {

                        throw e;
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Không thể lấy số lượng phần tử.");
                }
            }
        }
        private async Task<byte[]> convertImg(string imgTag, ChromiumWebBrowser browser)
        {
            var script = $@"
            var img = document.createElement('div');
            img.innerHTML = `{imgTag}`;
            var canvas = document.createElement('canvas');
            var context = canvas.getContext('2d');
            var imgElement = img.querySelector('img');
            canvas.width = imgElement.width;
            canvas.height = imgElement.height;
            context.drawImage(imgElement, 0, 0);
            canvas.toDataURL('image/png');";

            var result = await browser.GetMainFrame().EvaluateScriptAsync<string>(script);

            if (result != null)
            {
                // Chuyển đổi Data URL thành byte[]
                var imageData = result.Replace("data:image/png;base64,", "");
                var imageBytes = Convert.FromBase64String(imageData);
                return imageBytes;
            }
            else
            {
                Console.WriteLine("Không thể chuyển đổi thẻ img thành ảnh.");
                return new byte[0];
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Cef.Shutdown();
            base.OnFormClosing(e);
        }
    }
}
