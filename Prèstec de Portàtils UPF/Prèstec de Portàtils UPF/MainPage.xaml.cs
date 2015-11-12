using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

using System.Text.RegularExpressions;
// Codi idea de: http://mobiforge.com/developing/story/web-access-windows-phone-7-apps
namespace Prèstec_de_Portàtils_UPF
{
    public partial class MainPage : PhoneApplicationPage
    {
         WebClient client = new WebClient();
 
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            client.Encoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(client_DownloadStringCompleted);
            client.DownloadStringAsync(new Uri("https://fluvia.upf.edu/cuaportatil/cua.php"), "pompeu");
        }
        
        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            if (e.UserState as string == "pompeu")
            {
                //txtStatus.Text = e.BytesReceived.ToString() + " bytes received.";
            }
        }

        void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null && !e.Cancelled)
            {//MessageBox.Show(e.Result);
                string fixedString = "";

                // Remove HTML tags and newline characters from the text, and decode HTML encoded characters. 
                // This is a basic method. Additional code would be needed to more thoroughly  
                // remove certain elements, such as embedded Javascript. 

                // Remove HTML tags. 
                fixedString = Regex.Replace(e.Result.ToString(), "<[^>]+>", string.Empty);

                // Remove newline characters.
                fixedString = fixedString.Replace("\r", "");//.Replace("\n", "");

                // Remove encoded HTML characters.
                fixedString = HttpUtility.HtmlDecode(fixedString);

                fixedString = fixedString.Remove(0,626);

                fixedString = fixedString.Replace("\n\n", "\n");

                //fixedString = fixedString.Replace("a", "").Replace("e", "").Replace("i", "").Replace("o", "").Replace("u", "");

                /*int i = 0;
                int uni = 0;
                String ciutadella = "";
                String aranyo = "";
                String mar = "";

                while (i < fixedString.Length)
                {
                    portatils.Text = "hola";
                    if (fixedString.ElementAt(i).Equals("0"))
                    {
                        if (uni < 2)
                        {
                            ciutadella += "0";
                            uni++;
                        }
                        if (uni >= 2 && uni < 4)
                        {
                            aranyo += "0";
                            uni++;
                        }
                        if (uni >= 4)
                        {
                            mar += "0";
                            uni++;
                        }
                    }

                    if (fixedString.ElementAt(i).Equals("1"))
                    {
                        if (uni < 2)
                        {
                            ciutadella += "1";
                            uni++;
                        }
                        if (uni >= 2 && uni < 4)
                        {
                            aranyo += "1";
                            uni++;
                        }
                        if (uni >= 4)
                        {
                            mar += "1";
                            uni++;
                        }
                    }

                    if (fixedString.ElementAt(i).Equals("2"))
                    {
                        if (uni < 2)
                        {
                            ciutadella += "2";
                            uni++;
                        }
                        if (uni >= 2 && uni < 4)
                        {
                            aranyo += "2";
                            uni++;
                        }
                        if (uni >= 4)
                        {
                            mar += "2";
                            uni++;
                        }
                    }

                    if (fixedString.ElementAt(i).Equals("3"))
                    {
                        if (uni < 2)
                        {
                            ciutadella += "3";
                            uni++;
                        }
                        if (uni >= 2 && uni < 4)
                        {
                            aranyo += "3";
                            uni++;
                        }
                        if (uni >= 4)
                        {
                            mar += "3";
                            uni++;
                        }
                    }

                    if (fixedString.ElementAt(i).Equals("4"))
                    {
                        if (uni < 2)
                        {
                            ciutadella += "4";
                            uni++;
                        }
                        if (uni >= 2 && uni < 4)
                        {
                            aranyo += "4";
                            uni++;
                        }
                        if (uni >= 4)
                        {
                            mar += "4";
                            uni++;
                        }
                    }

                    if (fixedString.ElementAt(i).Equals("5"))
                    {
                        if (uni < 2)
                        {
                            ciutadella += "5";
                            uni++;
                        }
                        if (uni >= 2 && uni < 4)
                        {
                            aranyo += "5";
                            uni++;
                        }
                        if (uni >= 4)
                        {
                            mar += "5";
                            uni++;
                        }
                    }

                    if (fixedString.ElementAt(i).Equals("6"))
                    {
                        if (uni < 2)
                        {
                            ciutadella += "6";
                            uni++;
                        }
                        if (uni >= 2 && uni < 4)
                        {
                            aranyo += "6";
                            uni++;
                        }
                        if (uni >= 4)
                        {
                            mar += "6";
                            uni++;
                        }
                    }

                    if (fixedString.ElementAt(i).Equals("7"))
                    {
                        if (uni < 2)
                        {
                            ciutadella += "7";
                            uni++;
                        }
                        if (uni >= 2 && uni < 4)
                        {
                            aranyo += "7";
                            uni++;
                        }
                        if (uni >= 4)
                        {
                            mar += "7";
                            uni++;
                        }
                    }

                    if (fixedString.ElementAt(i).Equals("8"))
                    {
                        if (uni < 2)
                        {
                            ciutadella += "8";
                            uni++;
                        }
                        if (uni >= 2 && uni < 4)
                        {
                            aranyo += "8";
                            uni++;
                        }
                        if (uni >= 4)
                        {
                            mar += "8";
                            uni++;
                        }
                    }

                    if (fixedString.ElementAt(i).Equals("9"))
                    {
                        if (uni < 2)
                        {
                            ciutadella += "9";
                            uni++;
                        }
                        if (uni >= 2 && uni < 4)
                        {
                            aranyo += "9";
                            uni++;
                        }
                        if (uni >= 4)
                        {
                            mar += "9";
                            uni++;
                        }
                    }


                }*/

                //portatils.Text = ciutadella + " " + aranyo + " " + mar;
                portatils.Text = fixedString;

               // MessageBox.Show(fixedString);
            }

        }

        private void btnDownload_Click(object sender, RoutedEventArgs e)
        {
            client.DownloadStringAsync(new Uri("https://fluvia.upf.edu/cuaportatil/cua.php"), "pompeu");
        }
    }
}