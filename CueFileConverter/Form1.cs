using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio;
using NAudio.Codecs;
using NAudio.Wave;

namespace CueFileConverter
{
    public partial class Form1 : Form
    {
        public string cueFile;
        public string flacFile;
        public string dumpPath;
        AudioFileReader audioFileReader;
        IWavePlayer auPlayer;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            string selectedFile = openFileDialog1.FileName;

            if (result == DialogResult.OK)
            {
                label1.Text = selectedFile;
                cueFile = selectedFile;
            }
            addConsoleText(".cue file: " + result);            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "pick a .cue file";
            label2.Text = "pick a .flac file";
            cueFile = "woihef";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog2.ShowDialog();
            string selectedFile = openFileDialog2.FileName;

            if (result == DialogResult.OK)
            {
                label2.Text = selectedFile;
                flacFile = selectedFile;
            }
            addConsoleText(".flac file: " + result);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            string selectedFolder = folderBrowserDialog1.SelectedPath;

            if(result == DialogResult.OK)
            {
                label3.Text = selectedFolder;
                dumpPath = selectedFolder;
            }
            addConsoleText("dump folder: " + result);
        }

        public void addConsoleText(string t)
        {
            consoleBox.AppendText(t + "\r\n");
        }

        public void setConsoleText(string t)
        {
            consoleBox.Text = t + "\r\n";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(cueFile == null || flacFile == null || dumpPath == null)
            {
                addConsoleText("Some of the files or paths were not selected correctly. Please check again.");
            }
            else
            {

                try
                {
                    audioFileReader = new AudioFileReader(flacFile);
                    addConsoleText("loaded audio file");

                }
                catch
                {
                    addConsoleText("failed loading audio file");
                }
                TimeSpan start = new TimeSpan(0,0,1,1,20);
                TimeSpan stop = new TimeSpan(0,0,13,6,19);
                WavFileUtils.audioTrim(flacFile, dumpPath, start, stop);
            }

        }

        private void consoleBox_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
