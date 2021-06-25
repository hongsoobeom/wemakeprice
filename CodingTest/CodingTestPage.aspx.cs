using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CodingTest
{
    public partial class CodingTestPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_Run_Click(object sender, EventArgs e)
        {
            string inputValue = string.Empty;
            string alphaValue = string.Empty;
            string numberValue = string.Empty;
            string mixValue = string.Empty;
            string[] outputValue = new string[2];

            try
            {
                txt_Value.InnerText = "";
                txt_Other.InnerText = "";

                inputValue = GetHtmlString(txt_URL.Value, cmb_Type.SelectedIndex);
                //inputValue = "김#z0Aaa17bBZA?";
                alphaValue = GetAlphabet(inputValue);
                numberValue = GetNumber(inputValue);
                mixValue = MixText(AlignText(alphaValue), AlignText(numberValue));

                outputValue = UnitOutput(mixValue, txt_Unit.Value);

                txt_Value.InnerText = outputValue[0];
                txt_Other.InnerText = outputValue[1];
            }
            catch (Exception ex)
            {
                //MessageBox.Show("오류가 발생 하였습니다. \n" + ex.Message);
                txt_Value.InnerHtml = "오류가 발생 하였습니다. <br>" + ex.Message;
            }
        }

        private string GetHtmlString(string url, int type)
        {
            string strHtml = string.Empty;

            try
            {
                HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
                HtmlAgilityPack.HtmlDocument htmldoc = web.Load(CheckURL(url));

                // HTML 제외
                if (type == 0) strHtml = htmldoc.DocumentNode.InnerText;
                // 전체
                else if (type == 1) strHtml = htmldoc.DocumentNode.OuterHtml;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (string.IsNullOrWhiteSpace(strHtml))
            {
                throw new Exception("비어있는 HTML 입니다.");
            }

            return strHtml;
        }

        private string CheckURL(string URL)
        {
            try
            {
                if (!Uri.IsWellFormedUriString(URL, UriKind.Absolute))
                {
                    throw new Exception("URL을 확인해주세요");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return URL;
        }


        private string GetAlphabet(string value)
        {
            return Regex.Replace(value, @"[^a-zA-Z]", "");
        }

        private string GetNumber(string value)
        {
            return Regex.Replace(value, @"[^0-9]", "");
        }

        private string AlignText(string value)
        {
            string returnValue = string.Concat(value.Select(x => x.ToString())
                                       .OrderBy(x => x, StringComparer.OrdinalIgnoreCase)
                                       .ThenBy(x => x, StringComparer.Ordinal));

            return returnValue;
        }

        private string MixText(string alphabet, string number)
        {
            string returnValue = string.Empty;
            int index = 0;
            bool endAlpha = false;
            bool endNum = false;

            try
            {
                while (true)
                {
                    if (alphabet.Length > index)
                        returnValue += alphabet[index];
                    else endAlpha = true;

                    if (number.Length > index)
                        returnValue += number[index];
                    else endNum = true;

                    if (endAlpha && endNum) break;

                    index++;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return returnValue;
        }

        private string[] UnitOutput(string mixValue, string unitCnt)
        {
            //0 : 몫, 1 : 나머지
            string[] returnValue = new string[2];
            int unit = 0;
            int splitCnt = 0;

            try
            {
                unit = CheckNumber(unitCnt);
                splitCnt = mixValue.Length / unit * unit;
                returnValue[0] = mixValue.Substring(0, splitCnt);
                returnValue[1] = (mixValue.Length > splitCnt) ? mixValue.Substring(splitCnt, mixValue.Length - splitCnt) : "";
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return returnValue;
        }

        private int CheckNumber(string value)
        {
            int returnValue = 0;

            try
            {
                returnValue = int.Parse(GetNumber(value));
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return returnValue;
        }
    }
}