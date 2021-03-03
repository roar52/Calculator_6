using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        private bool _flag;
        private bool _firstSymbol;
        private bool _pointFlag;
        private bool _divFlag;
        private bool _mulFlag;
        private bool _sumFlag;
        private bool _minFlag;
        private bool _powFlag;
        private bool _sqrtFlag;
        private bool _negative;
        private double _firstCount;
        private double _secondCount;
        private double res;
        public Form1()
        {
            InitializeComponent();
            mainTable.Text = "0";
            _firstSymbol = true;
            _flag = false;
            _divFlag = false;
            _mulFlag = false;
            _sumFlag = false;
            _minFlag = false;
            _powFlag = false;
            _sqrtFlag = false;
            _pointFlag = false;
            _negative = false;
        }

        private void countButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (_firstSymbol)
            {
                mainTable.Text = $"{btn.Text}";
                _firstSymbol = false;
            }
            else
            {
                mainTable.Text += $"{btn.Text}";
            }
        }

        private void divBtn_Click(object sender, EventArgs e)
        {
            _firstCountFill();
            _divFlag = true;
        }

        private void minBtn_Click(object sender, EventArgs e)
        {
            _firstCountFill();
            _minFlag = true;
        }

        private void mulBtn_Click(object sender, EventArgs e)
        {
            _firstCountFill();
            _mulFlag = true;
        }

        private void sumBtm_Click(object sender, EventArgs e)
        {
            _firstCountFill();
            _sumFlag = true;
        }

        private void resBtn_Click(object sender, EventArgs e)
        {
            if (_flag)
            {
                _secondCount = Convert.ToDouble(mainTable.Text);
                if (_divFlag && _secondCount != 0)
                {
                    res = _firstCount / _secondCount;
                    _divFlag = false;
                }
                else if (_sumFlag)
                {
                    res = _firstCount + _secondCount;
                    _sumFlag = false;
                }
                else if (_minFlag)
                {
                    res = _firstCount - _secondCount;
                    _minFlag = false;
                }
                else if (_mulFlag)
                {
                    res = _firstCount * _secondCount;
                    _mulFlag = false;
                }
                else if (_powFlag)
                {
                    res = Math.Pow(_firstCount, _secondCount);
                    _powFlag = false;
                }
                else if (_sqrtFlag)
                {
                    res = Math.Pow(_firstCount, (1 / _secondCount));
                    _sqrtFlag = false;
                }
            }
            mainTable.Text = $"{res}";
            _flag = false;
            _firstCount = res;
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            mainTable.Text = "0";
            _firstCount = 0;
            _secondCount = 0;
            _firstSymbol = true;
        }

        private void powBtn_Click(object sender, EventArgs e)
        {
            _firstCountFill();
            _powFlag = true;
        }

        private void pointBtn_Click(object sender, EventArgs e)
        {
            if (!_pointFlag)
            {
                mainTable.Text += ',';
                _pointFlag = true;
                if (mainTable.Text == "0,") 
                {
                    _firstSymbol = false;
                }
            }
        }

        private void _firstCountFill()
        {
            if (!_flag)
            {
                _firstCount = Convert.ToDouble(mainTable.Text);
                mainTable.Text = "0";
                _flag = true;
                _firstSymbol = true;
                _pointFlag = false;
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (mainTable.Text.Length != 0)
            {
                mainTable.Text = mainTable.Text.Remove(mainTable.Text.Length - 1, 1);
                if (!mainTable.Text.Contains(',')) 
                {
                    _pointFlag = false;
                }
            }
        }

        private void sqrtBtn_Click(object sender, EventArgs e)
        {
            _firstCountFill();
            _sqrtFlag = true;
        }

        private void inversionBtn_Click(object sender, EventArgs e)
        {
            if (_negative)
            {
                mainTable.Text = mainTable.Text.Remove(0, 1);
                _negative = false; 
            }
            else 
            {
                mainTable.Text=mainTable.Text.Insert(0, "-");
                _negative = true;
            }
        }
    }
}
