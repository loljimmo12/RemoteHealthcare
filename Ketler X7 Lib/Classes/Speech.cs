using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kettler_X7_Lib.Classes
{
    public class Speech
    {
        /// <summary>
        /// Convert text to speech and plays it directly
        /// Will not block caller thread
        /// </summary>
        /// <param name="strText"></param>
        public static void textToSpeech(string strText)
        {
            System.Threading.ThreadPool.QueueUserWorkItem(delegate
            {
                using (System.Net.WebClient pWebClient = new System.Net.WebClient())
                {
                    using (System.IO.MemoryStream pMemoryStream = new System.IO.MemoryStream())
                    {
                        byte[] byData = null;

                        try
                        {
                            byData = pWebClient.DownloadData("http://translate.google.com/translate_tts?tl=nl&q=" + System.Web.HttpUtility.UrlEncode(strText));
                        }
                        catch
                        {
                        }

                        if (byData == null)
                        {
                            return;
                        }

                        pMemoryStream.Write(byData, 0, byData.Length);
                        pMemoryStream.Position = 0;

                        /*using (NAudio.Wave.WaveStream pWaveStream = new NAudio.Wave.BlockAlignReductionStream(
                            NAudio.Wave.WaveFormatConversionStream.CreatePcmStream(new NAudio.Wave.Mp3FileReader(pMemoryStream))))
                        {
                            using (NAudio.Wave.WaveOut pWaveOut = new NAudio.Wave.WaveOut(NAudio.Wave.WaveCallbackInfo.FunctionCallback()))
                            {
                                pWaveOut.Init(pWaveStream);
                                pWaveOut.Play();

                                while (pWaveOut.PlaybackState == NAudio.Wave.PlaybackState.Playing)
                                {
                                    System.Threading.Thread.Sleep(100);
                                }
                            }
                        }*/
                    }
                }
            });
        }
    }
}
