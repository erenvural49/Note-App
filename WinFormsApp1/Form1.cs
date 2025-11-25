namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        //asdaskdasdas
        private string currentFilePath = null!;
        private RichTextBox richTextBox1 = null!;
        private RichTextBox richTextBox2 = null!;
        private bool isDirty = false;
        public Form1()
        {
            InitializeComponent();
            this.FormClosing += Form1_FormClosing;
            //How form understand is there any changes in the text?
            //windows forms detects user input,richtexbox updates its text,richtexbox automatically calls TextChanged event.
            //
            //"When richTextBox1's text changes, call my richTextBox_TextChanged method"
            richTextBox1.TextChanged += RichTextBox_TextChanged;
            richTextBox2.TextChanged += RichTextBox_TextChanged;
            
           //ASDASLDKASLASDAS
           //fsddsaokdsa
            
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                string extension = Path.GetExtension(filePath);

                if (extension.ToLower() == ".txt")
                {
                    richTextBox1.LoadFile(filePath, RichTextBoxStreamType.PlainText);
                }
                else if (extension.ToLower() == ".rtf")
                {
                    richTextBox1.LoadFile(filePath, RichTextBoxStreamType.RichText);
                }
                currentFilePath = filePath;

            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //You should show dialog both .txt and .rtf files.
            DialogResult result = saveFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                string filePath = saveFileDialog1.FileName;
                string extension = Path.GetExtension(filePath);

                if (extension.ToLower() == ".txt")
                {
                    richTextBox1.SaveFile(filePath, RichTextBoxStreamType.PlainText);
                }

                else if (extension.ToLower() == ".rtf")
                {
                    richTextBox1.SaveFile(filePath, RichTextBoxStreamType.RichText);
                }
                currentFilePath = filePath;

            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string extension = string.IsNullOrEmpty(currentFilePath) 
            ? "" : Path.GetExtension(currentFilePath);

            if (extension.ToLower() == "")
            {
                saveAsToolStripMenuItem_Click(sender, e);

            }

            if (extension.ToLower() == ".txt")
                richTextBox1.SaveFile(currentFilePath, RichTextBoxStreamType.PlainText);
            else if (extension.ToLower() == ".rtf")
                richTextBox1.SaveFile(currentFilePath, RichTextBoxStreamType.RichText);

        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string extension = string.IsNullOrEmpty(currentFilePath) 
            ? "" : Path.GetExtension(currentFilePath);

            if (extension.ToLower() == ".rtf")
            {
                //You should only show dialog .rtf files.
                DialogResult result = colorDialog1.ShowDialog();
                if (result == DialogResult.OK)
                    richTextBox1.SelectionColor = colorDialog1.Color;

            }
        }
        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string extension = string.IsNullOrEmpty(currentFilePath) 
            ? "" : Path.GetExtension(currentFilePath);

            if (extension.ToLower() == ".rtf")
            {
                DialogResult result = fontDialog1.ShowDialog();
                if (result == DialogResult.OK)
                    richTextBox1.SelectionFont = fontDialog1.Font;
            }
            else
            {
                MessageBox.Show("You didn't open any file or you are in a text file.");

            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TabControl full page
            tabControl1.Dock = DockStyle.Fill;

            // Create richTextBox1
            richTextBox1 = new RichTextBox();
            richTextBox1.Dock = DockStyle.Fill;
            richTextBox1.Name = "richTextBox1";
            //add RichTextBox1 to tabPage1
            tabPage1.Controls.Add(richTextBox1);

            // Create richTextBox2
            richTextBox2 = new RichTextBox();
            richTextBox2.Dock = DockStyle.Fill;
            richTextBox2.Name = "richTextBox2";
            // and add RichTextBox2 to tabPage2
            tabPage2.Controls.Add(richTextBox2);
        }
        private void RichTextBox_TextChanged(object sender, EventArgs e){
            isDirty = true;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e){
    
    if (isDirty == true)
    {
        
        MessageBox.Show("You have unsaved changes. Do you want to save before closing?", "Unsaved Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

        DialogResult result = MessageBox.Show(
            "You have unsaved changes. Do you want to save before closing?",
            "Unsaved Changes",
            MessageBoxButtons.YesNoCancel,
            MessageBoxIcon.Question
        );
        
        if (result == DialogResult.Yes)
        {
            saveToolStripMenuItem_Click(sender,e);
            isDirty= false;

        }
        else if (result == DialogResult.Cancel)
        {
            //dont close the form
            e.Cancel = true;
        }
        else if (result == DialogResult.No)
        {
            e.Cancel = false;
            //close the form
            //default olarak da false zaten.
        }
    }
}
    }
}