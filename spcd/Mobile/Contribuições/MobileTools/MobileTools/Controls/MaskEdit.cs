using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace MobileTools.Controls
{
    /// <summary>
    /// Author		: Gangadhara BD.<BR>
    /// Description : This control is a attemp to simulate the Maked Edit control available in VB 6.0<BR>
    /// MaskEdit control extends the System.Windows.Forms.TextBox control available in MicroSoft .NEt library.<BR>
    /// 
    /// <B>Addtional propeties</B>
    /// -MaskFormat : Accepts string to define the display mask <BR>
    /// Following are the format characters.<BR>
    /// #	- Digits.<BR>
    /// 9	- optional digits<BR>
    /// A	- Alphanumerals<BR>
    /// a	- optional Alphanumerals<BR>
    /// &	- Characters<BR>
    /// ?	- Alpha<BR>
    /// All other characters are displayed as is.<BR>
    /// 
    /// <B>Usage</B>
    /// Consumer has to set the MaskFormat and PrompChar property(Default).Refer format charcters above.
    /// 
    /// Before losing the focus control fires validationError event if their are any mismatch in the characters eneterd as per the mask.
    /// </summary>
    /// 

    /*
    public class MaskEdit : System.Windows.Forms.TextBox
    {

        /// <summary>
        /// 
        /// </summary>

        private System.ComponentModel.Container components = null;
        /// <summary>
        /// String with the format chars replaced with prompt character
        /// </summary>
        private string m_strMaskWithPromptChar;  //String with the format chars replaced with prompt characterd
        /// <summary>
        /// String contains the format enterd by the user.
        /// </summary>
        private string m_strUserMask;			 //String contains the format enterd by the user.
        /// <summary>
        /// Stores the promp charcter defualts to "-"
        /// </summary>
        private string m_strPromptChar;			 //Stores the promp charcter defualts to "-"
        /// <summary>
        /// String displayed in the text box at any point of time with prompt chars
        /// </summary>
        private string m_strDisplayText;		 //String displayed in the text box at any point of time with prompt chars
        /// <summary>
        /// Text without prompt and format.	
        /// </summary>
        private string m_strText;				 //Text without prompt and format.	
        /// <summary>
        /// Last Key keyed in
        /// </summary>
        private string m_strLastKey;			 //Last Key keyed in



        /// <summary>
        /// Event defination which will be fired when the eneterd text doesn't satify the format
        ///e - specify the position at which miss match is occurring
        /// </summary>
        public delegate void ValidateEventHandler(object sender, int e);
        public event ValidateEventHandler ValidationError;


        public MaskEdit()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // 
            // MaskEdit
            // 
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MaskEdit_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MaskEdit_KeyPress);
            this.Validated += new System.EventHandler(this.MaskEdit_Validated);

        }
        #endregion

        #region("Code")

        /// <summary>
        /// Hides the text property of base class and expose new readonly text property
        /// </summary>
        public new string Text
        {
            get { return m_strText; }
        }


        /// <summary>
        /// SelText propety gives the text enterd without format if valid text is entered.
        /// </summary>
        public string SelText
        {
            get { return m_strText; }
            set
            {
                int intIndex;
                string strTemp;
                m_strText = value;
                base.SelectionStart = 0;
                if (m_strText != null)
                {
                    strTemp = m_strMaskWithPromptChar;
                    for (intIndex = 0; intIndex < m_strText.Length; intIndex++)
                    {

                        if (ValidChracter(m_strUserMask.Substring(strTemp.IndexOf(m_strPromptChar, 0), 1), m_strText.Substring(intIndex, 1)))
                        {
                            strTemp = strTemp.Substring(0, intIndex) + strTemp.Substring(3, 1) + strTemp.Substring(intIndex + 1);
                            strTemp = strTemp.Substring(0, intIndex) + m_strPromptChar + strTemp.Substring(intIndex + 1);

                        }
                        else
                        {
                            m_strText = "";
                            onValidationError(intIndex);
                        }
                        base.Text = strTemp;
                    }
                }
            }
        }


        /// <summary>
        /// MaskFormat accepts and returns the display mask.
        /// </summary>
        public string MaskFormat
        {
            get { return m_strUserMask; }
            set
            {
                m_strUserMask = value;
                GetMaskWithPrompt();
            }
        }
        /// <summary>
        /// PromptChar accepts and returns the display promp character.
        /// </summary>
        public string PromptChar
        {
            get { return m_strPromptChar; }
            set
            {
                if (value == null)
                {
                    m_strPromptChar = "_";
                }
                else
                {
                    m_strPromptChar = value;
                }
                GetMaskWithPrompt();
            }
        }

        /// <summary>
        /// Method for raising the ValidateError Event.
        /// </summary>
        /// <param name="e">Position of the mismatched character</param>
        protected virtual void onValidationError(int e)
        {
            if (this.ValidationError != null)
                this.ValidationError(this, e);
        }

        #region("Private functions")
        /// <summary>
        /// Replaces the mask characters in the MaskFormat string.
        /// </summary>
        private void GetMaskWithPrompt()
        {
            if (m_strPromptChar == null)
            {
                m_strPromptChar = "_";
            }
            m_strMaskWithPromptChar = m_strUserMask.Replace("#", m_strPromptChar);
            m_strMaskWithPromptChar = m_strMaskWithPromptChar.Replace("A", m_strPromptChar);
            m_strMaskWithPromptChar = m_strMaskWithPromptChar.Replace("9", m_strPromptChar);
            m_strMaskWithPromptChar = m_strMaskWithPromptChar.Replace("a", m_strPromptChar);
            m_strMaskWithPromptChar = m_strMaskWithPromptChar.Replace("&", m_strPromptChar);

            m_strDisplayText = m_strMaskWithPromptChar;
            base.Text = m_strDisplayText;

        }

        /// <summary>
        /// Inserts  the supplied charcter in appropriate postion.
        /// </summary>
        /// <param name="KeyId">-1 Represent the back space operation
        ///						 1 Represents the delete operation
        ///						 0 For all other keys
        /// </param>
        /// <param name="strChar">
        ///		Charcter keyed in.
        /// </param>
        private void Mask(int KeyId, string strChar)
        {
            int intPromptPos, intCurrentPos, intNextPos;
            intCurrentPos = base.SelectionStart;  //Get the cursor position.

            //If MaskEdit don't have focus return without processing the char.
            if (intCurrentPos < 0)
            {
                return;
            }

            //When backspce is pressed
            //At the position previous to the current replace the charcter with prompt chracter.
            if (KeyId == -1)
            {
                if (intCurrentPos > 0)
                {
                    if (m_strMaskWithPromptChar.Substring(intCurrentPos - 1, 1) == m_strPromptChar)
                    {
                        m_strDisplayText = m_strDisplayText.Substring(0, intCurrentPos - 1) + m_strPromptChar + m_strDisplayText.Substring(intCurrentPos);

                    }
                    if (intCurrentPos > 0)
                        base.Text = m_strDisplayText;
                    base.SelectionStart = intCurrentPos - 1;
                }

            }
            else if (KeyId == 1)
            {
                //When Del is pressed
                //At the position next to the current replace the charcter with prompt chracter.

                if (intCurrentPos < m_strMaskWithPromptChar.Length)
                {
                    if (m_strMaskWithPromptChar.Substring(intCurrentPos, 1) == m_strPromptChar)
                        m_strDisplayText = m_strDisplayText.Substring(0, intCurrentPos) + m_strPromptChar + m_strDisplayText.Substring(intCurrentPos + 1);
                }
                base.Text = m_strDisplayText;
                //this.Text =m_strText;
                base.SelectionStart = intCurrentPos;
            }
            else if (KeyId == 0)
            {
                //When any other valid character
                //At the current replace the  prompt chracter with the keyed in charcter.

                intPromptPos = m_strDisplayText.IndexOf(m_strPromptChar, intCurrentPos); //Get the propmt character next to the current position

                if (intPromptPos > -1) //If ther exist a prompt char
                {
                    if (intPromptPos > intCurrentPos)
                    {
                        //If prompt position is not same as the current position, means iser is trying to insert the chracter between alredy eneterd charcters.
                        //To make user to feel that the character is getting inserted move all the chracters after the current position by one position.

                        int intCharPos, intBackPos;
                        string strTemp, strTemp1;
                        intBackPos = 1;

                        strTemp = m_strDisplayText;

                        //Start at the last position of the prompt chracter and move each chracter by one till the current position.
                        //Before moving check if that position takes the charcter as per the mask.
                        for (intCharPos = intPromptPos; intCharPos > intCurrentPos; intCharPos--)
                        {
                            if (m_strMaskWithPromptChar.Substring(intCharPos, 1) == m_strPromptChar)
                            {

                                strTemp1 = m_strMaskWithPromptChar.Substring(0, intCharPos - 1);
                                intBackPos = m_strMaskWithPromptChar.LastIndexOf(m_strPromptChar, intCharPos - 1);
                                if (intBackPos > -1)
                                {
                                    if (ValidChracter(m_strUserMask.Substring(intCharPos, 1), m_strDisplayText.Substring(intBackPos, 1)))
                                    {
                                        strTemp = strTemp.Substring(0, intCharPos) + strTemp.Substring(3, 1) + strTemp.Substring(intCharPos + 1);
                                        strTemp = strTemp.Substring(0, intBackPos) + m_strPromptChar + strTemp.Substring(intBackPos + 1);


                                    }
                                    else
                                    {
                                        //If at any point validation fails leave the display as it is 
                                        return;
                                    }
                                }
                                else
                                {
                                    return;
                                }
                            }
                            else
                            {
                                intBackPos++;  //Not necessary at this point
                            }
                        }
                        //If all the character are moved successfully to the next position insert the keted in charcter at the current position.
                        strTemp = strTemp.Substring(0, intCurrentPos) + strChar + strTemp.Substring(intCharPos + 1);
                        m_strDisplayText = strTemp;
                    }
                    else
                    {
                        //If prompt position is t same as the current position, append the enterd chracter.
                        m_strDisplayText = m_strDisplayText.Substring(0, intPromptPos) + strChar + m_strDisplayText.Substring(intPromptPos + 1);
                    }
                }
                base.Text = m_strDisplayText;
                //Position the cursor to the next promt char.
                intNextPos = m_strDisplayText.IndexOf(m_strPromptChar, intCurrentPos);

                if (intNextPos > -1)
                    base.SelectionStart = intNextPos;
                else
                    base.SelectionStart = intCurrentPos;
            }
        }

        /// <summary>
        /// Validates the enters text as per the mask and raises the validation erroe event if the validation fails. 
        /// </summary>
        private void ValidateText()
        {
            int intLenght;
            m_strText = "";
            for (intLenght = 0; intLenght < m_strUserMask.Length; intLenght++)
            {
                if (m_strMaskWithPromptChar.Substring(intLenght, 1) == m_strPromptChar)
                {
                    if (m_strDisplayText.Substring(intLenght, 1) == m_strPromptChar)
                    {
                        if (m_strUserMask.Substring(intLenght, 1) == "#" || m_strUserMask.Substring(intLenght, 1) == "A"
                            || m_strUserMask.Substring(intLenght, 1) == "?")
                        {
                            onValidationError(intLenght);
                        }
                        else
                        {
                            m_strText = m_strText + " ";
                        }
                    }
                    else
                    {
                        m_strText = m_strText + m_strDisplayText.Substring(intLenght, 1);
                    }
                }
            }

        }
        #endregion
        /// <summary>
        /// In this event keyed in chracter is validated against the mask and if the keyed charcter is valid it is appended to
        /// the appropriate position.
        /// </summary>

        private void MaskEdit_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            int intCurrentPos = base.SelectionStart;
            string strInputChar;
            //If the curposr position is within the allowed length
            if (intCurrentPos < m_strUserMask.Length)
            {
                //Validate the character as per the mask
                strInputChar = m_strUserMask.Substring(intCurrentPos, 1);
                if (!ValidChracter(strInputChar, e.KeyChar.ToString()))
                {
                    e.Handled = true;
                    return;
                }
            }

            //If the key is Back space
            if (m_strLastKey != "BS")
            {
                if (m_strUserMask != null)
                {
                    if (m_strUserMask.Trim().Length != 0)
                    {
                        this.Mask(0, e.KeyChar.ToString());
                        e.Handled = true;
                    }
                }
            }
            else
            {
                //If the key is any other than Back space
                m_strLastKey = "CHR";
                base.Text = m_strDisplayText;
                base.SelectionStart = intCurrentPos;
                e.Handled = true;
            }


        }

        /// <summary>
        /// Validates if the charcter keyed in at the current position is valid as per the mask.
        /// </summary>
        /// <param name="strMask">Mask character at the current position.</param>
        /// <param name="strInput">Chracter keyed in</param>
        /// <returns>True if valid else false</returns>

        private bool ValidChracter(string strMask, string strInput)
        {
            switch (strMask)
            {
                case "#":  //Digit
                case "9":  //Optinal digit
                    if (!Char.IsDigit(strInput, 0))
                    {
                        return false;

                    }
                    break;
                case "A":  //Alphanumeric
                case "a":  //Optional Alphanumeric
                    if (!Char.IsLetter(strInput, 0) && !Char.IsDigit(strInput, 0))
                    {
                        return false;
                    }
                    break;
                case "?": //Alpha
                    if (!Char.IsLetter(strInput, 0))
                    {
                        return false;
                    }
                    break;
                case "&": //Optional Charcter
                    return false;
                //break;
            }
            return true;
        }
        #endregion
        /// <summary>
        /// In this event any non key which doesn't map to charcter or digit is caught.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaskEdit_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            if (m_strUserMask != null)
            {
                if (m_strUserMask.Trim().Length != 0)
                {

                    if (e.KeyCode == Keys.Back)
                    {
                        //When BackSpace is pressed
                        this.Mask(-1, "");
                        m_strLastKey = "BS";
                        e.Handled = true;

                    }
                    else if (e.KeyCode == Keys.Delete)
                    {
                        //When Delete is pressed
                        this.Mask(1, "");
                        m_strLastKey = "DEL";
                        e.Handled = true;
                    }
                }
            }
        }
        /// <summary>
        /// Validates the text entered against the mask.
        /// </summary>

        private void MaskEdit_Validated(object sender, System.EventArgs e)
        {
            //Validate the text before losing the focus.
            ValidateText();
        }
    }
*/
    #region Antigo

    public partial class MaskEdit : TextBox
    {
        #region Variáveis Locais

        /// <summary>
        /// Mascara do campo de texto.
        /// </summary>
        private string _mask;

        #endregion

        #region Construtores

        public MaskEdit()
        {
            this.SelectionLength = 1;

        }

        public MaskEdit(IContainer container)
        {
            container.Add(this);
         
        }

        #endregion

        #region Propriedades

        /// <summary>
        /// Mascara a ser utilizada
        /// </summary>
        public string Mask
        {
            get { return _mask; }
            set
            {
                _mask = value;

                if (value != null)
                {
                    string t = "";

                    for (int i = 0; i < _mask.Length; i++)
                        t += "_";

                    Text = t;

                    this.MaxLength = _mask.Length;
                }
                else
                    this.MaxLength = 0;
            }
        }

        #endregion

        #region Métodos Sobrecarregados

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            UpdateText(ref e);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (((Keys)e.KeyChar) == Keys.Back)
                e.Handled = true;
            else
                base.OnKeyPress(e);
        }

        /// <summary>
        /// Trava selection lenght
        /// </summary>
        public override int SelectionLength
        {
            get
            {
                return 1;
            }
            set
            {
                base.SelectionLength = 1;
            }
        }       

        #endregion

        #region Métodos Privados

        private bool IsValidPos()
        {
            char target = GetTextChar(SelectionStart);
            switch(GetMaskChar(SelectionStart))
            {
                case '0':
                    return char.IsNumber(target);
                case 'A':
                    return char.IsLetterOrDigit(target);
                default:
                    return false;
            }
        }

        private bool IsValidCharToPos(char keyChar, int pos)
        {
            switch (GetMaskChar(pos))
            {
                case '0':
                    return char.IsNumber(keyChar);
                case 'A':
                    return char.IsLetterOrDigit(keyChar);
                default:
                    return false;
            }
        }

        private char GetDefaultChar()
        {
            return GetMaskChar(this.SelectionStart);
        }

        private char GetMaskChar(int pos)
        {
            if (pos >= this._mask.Length)
                pos = this._mask.Length - 1;
            return this._mask[pos];
        }

        private char GetTextChar(int pos)
        {
            if (pos >= this.Text.Length && pos != 0)
                pos = this.Text.Length - 1;
            return this.Text[pos];
        }

        private void SetValidPos(KeyEventArgs e)
        {
            if (Text.Length == 0) return;

            switch (e.KeyCode)
            {
                case Keys.Left:
                case Keys.Back:
                    while (!IsValidPos()) this.SelectionStart--;
                    break;
                default:
                    while (!IsValidPos()) this.SelectionStart++;
                    break;
            }
        }

        private void InsertChar(char arg, int pos)
        {
            int stPos = this.SelectionStart;
            char[] aux = this.Text.ToCharArray();
            if (pos >= aux.Length)
                pos = aux.Length - 1;
            aux[pos] = arg;
            this.Text = new string(aux);
            this.SelectionStart = stPos;
        }

        private void UpdateText(ref KeyEventArgs e)
        {
            int pos = this.SelectionStart;
            switch (e.KeyCode)
            {
                case Keys.Back:
                    if (pos > 0)
                    {
                        this.SelectionStart--;
                        SetValidPos(e);
                        pos = this.SelectionStart;
                        InsertChar(GetDefaultChar(), pos);
                        this.SelectionStart = pos;
                    }
                    break;
                case Keys.Right:
                    this.SelectionStart++;
                    break;
                case Keys.Left:
                    if (this.SelectionStart>0) this.SelectionStart--;
                    break;
                default:
                    if (UpdateChar(e))
                        this.SelectionStart = pos + 1;
                    break;
            }
            SetValidPos(e);
            e.Handled = true;
        }

        private bool UpdateChar(KeyEventArgs e)
        {
            SetValidPos(e);
            int pos = this.SelectionStart;
            if (IsValidCharToPos((char)e.KeyValue, pos))
                InsertChar((char)e.KeyValue, pos);
            else
                return false;
            return true;
        }

        #endregion
    }

#endregion
}