using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFLearn
{
    public partial class NedoWikiForm : Form
    {
        string lstbx1 = "0";
        string lstbx2 = "0";
        Obj[] objs = new Obj[] {
            new Obj("Button",
                new Dictionary<string, string>() {
                    ["Anchor"] = "Определяет, как элемент будет растягиваться",
                    ["BackColor"] = "Определяет фоновый цвет элемента",
                    ["BackgroundImage"] = "Определяет фоновое изображение элемента",
                    ["ContextMenu"] = "Контекстное меню, которое открывается при нажатии на элемент правой кнопкой мыши. Задается с помощью элемента ContextMenu",
                    ["Cursor"] = "Представляет, как будет отображаться курсор мыши при наведении на элимент",
                    ["Dock"] = "Задает расположение элемента на форме",
                    ["Enabled"] = "Определяет, будет ли доступен элемент для использования. Если это свойство имеет значение False, то элемент блокируется",
                    ["Font"] = "Устанавливает шрифт текста для элимента",
                    ["ForeColor"] = "Определяет цвет шрифта",
                    ["Location"] = "Определяет координаты верхнего левого угла элемента управления",
                    ["Name"] = "Имя элемента",
                    ["Size"] = "Размер элемента",
                    ["Width"] = "Ширина элемента",
                    ["Height"] = "Высота элемента",
                    ["TabIndex"] = "Определяет порядок обхода элемента по нажатию клавишы Tab",
                    ["Tag"] = "вешать тэги"
                },
                new Dictionary<string, string>() {
                    ["Click"] = "Срабатывает при нажатии на элемент",
                    ["LOL"] = "Что-нибудь крутое"
                }),
            new Obj("TextBox",
                new Dictionary<string, string>()
                {
                    ["Text"] = "Текст в текстбоксе",
                    ["LEL"] = "Всякая чепуха"
                },
                new Dictionary<string, string>()
                {
                    ["Test"] = "тест",
                    ["prekl"] = "Mega prekl"
                })
        };

        public NedoWikiForm(MB9 mb)
        {
            InitializeComponent();

            foreach(var obj in objs)
            {
                listBox1.Items.Add(obj.obj);
            }

            listBox1.KeyUp += so;
            listBox2.KeyUp += os;
        }

        private void os(object? sender, KeyEventArgs e)
        {
            lstbx2 = listBox2.Items[listBox2.SelectedIndex].ToString();
            if (lstbx2 == "--Свойства")
                textBox1.Text = "Свойства объекта "+lstbx1;
            if (lstbx2 == "--Методы")
                textBox1.Text = "Методы объекта "+lstbx1;
            foreach(var obj in objs)
            {
                if (obj.obj != lstbx1)
                    continue;
                foreach(var prop in obj.prop)
                {
                    if (prop.Key != lstbx2)
                        continue;
                    textBox1.Text = prop.Value;
                }
                foreach (var mets in obj.mets)
                {
                    if (mets.Key != lstbx2)
                        continue;
                    textBox1.Text = mets.Value;
                }
            }
        }

        private void so(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;
            listBox2.Items.Clear();
            lstbx1 = listBox1.Items[listBox1.SelectedIndex].ToString();
            foreach (var obj in objs)
            {
                if (obj.obj != lstbx1)
                    continue;
                listBox2.Items.Add("--Свойства");
                foreach (var props in obj.prop)
                {
                    listBox2.Items.Add(props.Key);
                }
                listBox2.Items.Add("--Методы");
                foreach (var mets in obj.mets)
                {
                    listBox2.Items.Add(mets.Key);
                }
            }
            listBox2.Visible = true;
        }
    }

    class Obj
    {
        public string obj;
        public Dictionary<string,string> prop;
        public Dictionary<string,string> mets;

        public Obj(string obj, Dictionary<string,string> prop, Dictionary<string,string> mets)
        {
            this.obj = obj;
            this.prop = prop;
            this.mets = mets;
        }
    }
}
