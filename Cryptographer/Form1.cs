using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cryptographer
{
	public partial class Form1 : Form
	{
		string _alphabet = "abcdefghijklmnopqrstuvwxyz.,!?+-=@: абвгдеёжзийклмнопрстуфхцчшщъыьэюя1234567890";

		string _mainKey;

		string _textForEncryption;
		string _textForDecryption;

		string _finalResult;

		private string Encryption(string _currText, string _currKey)
		{
			
			_currText = _currText.ToLower();

			char[] _charsChange = _currText.ToCharArray();

			for (int i = 0; i < _currText.Length; i++)
			{
				int _fNum = _alphabet.IndexOf(_charsChange[i]) + 1;
				int _sNum = _alphabet.IndexOf(_currKey[i % _currKey.Length]) + 1;
				int _preNum = ((_fNum + _sNum) % _alphabet.Length);
				if(_preNum == 0)
				{
					_preNum = _alphabet.Length;
				}

				_charsChange[i] = _alphabet[_preNum - 1];
			}

			string _output = new string(_charsChange);

			return _output;
		}

		private string Decryption(string _currText, string _currKey)
		{
			_currText = _currText.ToLower();

			char[] _charsChange = _currText.ToCharArray();

			for (int i = 0; i < _currText.Length; i++)
			{
				int _fNum = _alphabet.IndexOf(_charsChange[i]) + 1;
				int _sNum = _alphabet.IndexOf(_currKey[i % _currKey.Length]) + 1;
				int _preNum;
				if(_fNum - _sNum > 0)
				{
					_preNum = _fNum - _sNum;
				}
				else if(_fNum - _sNum == 0)
				{
					_preNum = _alphabet.Length;
				}
				else
				{
					_preNum = _alphabet.Length + _fNum - _sNum;
				}

					//_preNum = (_alphabet.Length + _fNum - _sNum) % (_alphabet.Length);

					_charsChange[i] = _alphabet[_preNum - 1];
			}

			string _output = new string(_charsChange);

			return _output;
		}

		public Form1()
		{
			InitializeComponent();
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			_textForEncryption = textBox1.Text;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			_finalResult = Encryption(_textForEncryption, _mainKey);
			textBox8.Text = _finalResult;
		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{
			_textForDecryption = textBox2.Text;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			_finalResult = Decryption(_textForDecryption, _mainKey);
			textBox8.Text = _finalResult;
		}

		private void textBox3_TextChanged(object sender, EventArgs e)
		{

		}

		private void textBox4_TextChanged(object sender, EventArgs e)
		{

		}

		private void textBox5_TextChanged(object sender, EventArgs e)
		{

		}

		private void textBox6_TextChanged(object sender, EventArgs e)
		{
			_mainKey = textBox6.Text;
		}

		private void textBox8_TextChanged(object sender, EventArgs e)
		{
			
		}

		private void textBox7_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
