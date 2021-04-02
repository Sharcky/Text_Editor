using Stripe.Terminal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Text_Editor
{
    public partial class Form_txt : Form
    {
        public Form_txt()
        {
            InitializeComponent();
            VisiblePanel();
        }
        private void VisiblePanel()
        {
            Panel_File.Visible = false;
            Panel_Edit.Visible = false;
            Panel_Tools.Visible = false;
            Panel_Help.Visible = false;
        }
        private void HidePanel()
        {
            if (Panel_File.Visible == true)
                Panel_File.Visible = false;
            if (Panel_Edit.Visible == true)
                Panel_Edit.Visible = false;
            if (Panel_Tools.Visible == true)
                Panel_Tools.Visible = false;
            if (Panel_Help.Visible == true)
                Panel_Help.Visible = false;
        }

        private void ShowPanel(Panel SubMenu)
        {
            if(SubMenu.Visible ==false)
            {
                HidePanel();
                SubMenu.Visible = true;
            }
            else
            {
                SubMenu.Visible = false;
            }
        }




        private void button8_Click(object sender, EventArgs e)
        {
            ShowPanel(Panel_File);
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            ShowPanel(Panel_Edit);
        }

        private void btn_tools_Click(object sender, EventArgs e)
        {
            ShowPanel(Panel_Tools);
        }

        private void btn_help_Click(object sender, EventArgs e)
        {
            ShowPanel(Panel_Help);
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to save this document?", "Save", MessageBoxButtons.YesNo);
            {
                //Apaga o conteiner de texto
                txt_box.Clear();
            }
            if (dialogResult == DialogResult.Yes)
            {
                using (var dialog = new System.Windows.Forms.SaveFileDialog())
                {
                    dialog.DefaultExt = "*.txt";
                    dialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                    DialogResult result = dialog.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        string filename = dialog.FileName;
                        // Save here
                    }
                }
            }
            HidePanel();
        }

        private void btn_open_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Title = "My open file dialog";
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                Form_txt.ActiveForm.Text = "H.S Text Editor - " + openfile.FileName;
                txt_box.Clear();
                using (StreamReader sr = new StreamReader(openfile.FileName))
                {
                    txt_box.Text = sr.ReadToEnd();
                    sr.Close();
                }
            }
            HidePanel();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Title = "Save file as..";
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                StreamWriter txtoutput = new StreamWriter(savefile.FileName);
                txtoutput.Write(txt_box.Text);
                txtoutput.Close();
            }
            HidePanel();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            txt_box.Undo();
            HidePanel();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            txt_box.Redo();
            HidePanel();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            txt_box.Cut();
            HidePanel();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            txt_box.Copy();
            HidePanel();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            txt_box.Paste();
            HidePanel();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            txt_box.SelectAll();
            HidePanel();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            HidePanel();
        }

        private void Form_txt_Load(object sender, EventArgs e)
        {
            foreach(FontFamily font in FontFamily.Families)
            {
                cb_font.Items.Add(font.Name.ToString());
            }
        }

        private void cb_font_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txt_box.Font = new Font(cb_font.Text, txt_box.Font.Size);
            }
            catch { }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txt_box.Font = new Font(txt_box.Font.FontFamily, float.Parse(cb_numero.SelectedItem.ToString()));
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txt_box.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txt_box.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            txt_box.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (txt_box.ZoomFactor == 63)
            {

                return;

            }
            else
                txt_box.ZoomFactor = txt_box.ZoomFactor + 1;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (txt_box.ZoomFactor == 1)
            {

                return;


            }
            else
                txt_box.ZoomFactor = txt_box.ZoomFactor - 1;
        }

        private void txt_box_TextChanged(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {
            HidePanel();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            HidePanel();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            HidePanel();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            HidePanel();
        }
    }

}

