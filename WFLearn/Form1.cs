using System.Text.RegularExpressions;

namespace WFLearn
{
    public partial class MB9 : Form
    {
        private bool lol = true;
        private bool lol2 = true;
        public MB9()
        {
            InitializeComponent();

            label1.MouseClick += LC;
            button1.Click += BC;
            button2.Click += PG;
            textBox1.TextChanged += TBTSC;
            maskedTextBox1.TextChanged += MTBTC;
            radioButton1.Click += RBCCO;
            radioButton2.Click += RBCCO;
            checkBox1.Click += CBC;
            listBox1.SelectedIndexChanged += LBSIC;
            numericUpDown1.ValueChanged += NUDC;
            dateTimePicker1.ValueChanged += DTPVC;
            pictureBox1.Click += PBC;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            button3.Click += OPN;
            button4.Click += SVE;
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";

            button5.Click += testus;
            button6.Click += NedoWiki;

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Columns.Add("First","First");
            dataGridView1.Columns.Add("Second", "Two");
            dataGridView1.Rows.Add(6);
            for(int i=0;i<dataGridView1.Columns.Count;i++)
            {
                for(int j=0;j<dataGridView1.Rows.Count;j++)
                    dataGridView1.Rows[j].Cells[i].Value = (i+1).ToString()+(j+1).ToString();
            }

        }

        private void oll(object? sender, EventArgs e)
        {
            MessageBox.Show("cock");
        }

        private void NedoWiki(object? sender, EventArgs e)
        {
            NedoWikiForm form = new NedoWikiForm(this);
            form.ShowDialog();

        }

        private void testus(object? sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.Cancel)
            {
                MessageBox.Show("лови прекл");
            }
        }

        private void SVE(object? sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                MessageBox.Show("Вы отменили операцию");
                return;
            }
            System.IO.File.WriteAllText(saveFileDialog1.FileName, textBox3.Text);

        }

        private void OPN(object? sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                MessageBox.Show("Вы отменили операцию");
                return;
            }
            string fname = openFileDialog1.FileName;
            string ftext = System.IO.File.ReadAllText(fname);

            textBox2.Text = fname;
            textBox3.Text = ftext;
            saveFileDialog1.FileName = fname;
        }

        private void PBC(object? sender, EventArgs e)
        {
            MessageBox.Show("Это картиночка");
        }

        private void PG(object? sender, EventArgs e)
        {
            progressBar1.Visible = true;
            Task.Run(PGCange);
        }
        async private void PGCange()
        {
            progressBar1.Value = 95;
            while(progressBar1.Value != 100)
            {
                progressBar1.Value += 1;
                await Task.Delay(1000);
            }
            progressBar1.Visible = false;
            progressBar1.Value = 0;
            MessageBox.Show("Бу");
        }

        private void DTPVC(object? sender, EventArgs e)
        {
            MessageBox.Show("Что-то вроде маскед текст бокса, но с интерактивным содержанием, но для выбора дат");
        }

        private void NUDC(object? sender, EventArgs e)
        {
            MessageBox.Show("Что-то вроде маскед текст бокса, но с интерактивным содержанием для выбора чисел");
        }

        private void LBSIC(object? sender, EventArgs e)
        {
            MessageBox.Show("Аля радиобаттон, в виде списка");
        }

        private void CBC(object? sender, EventArgs e)
        {
            if (!checkBox1.Checked)
                return;
            MessageBox.Show("зажимающаяся кнопка, позволяет выбрать сразу несколько таких");
        }

        private void RBCCO(object? sender, EventArgs e)
        {
            MessageBox.Show("зажимающаяся кнопка, не позволяет выбрать сразу несколько таких");
        }

        private void MTBTC(object? sender, EventArgs e)
        {
            lol = false;
            Regex rex = new Regex(@"\d");
            MatchCollection matchCollection = rex.Matches(maskedTextBox1.Text);
            if (matchCollection.Count == 10)
                textBox1.Text = "Текстовое поле с масками, позволяет получить от пользователя только то, что нужно.";
            lol = true;
        }

        private void TBTSC(object? sender, EventArgs e)
        {
            if(lol)
                textBox1.Text = "Текстовое поле, максимально удобное для лббой деятельности, но не подходит для названий.";
        }

        private void BC(object? sender, EventArgs e)
        {
            lol = false;
            textBox1.Text = "Обычная кнопка, на нее можно нажимать.";
            lol = true;
        }

        private void LC(object? sender, EventArgs e)
        {
            lol = false;
            textBox1.Text = "Текстовое поле, не рекомендую изменять его динамически, у нее размер не фиксирован.";
            lol = true;
        }
    }
}