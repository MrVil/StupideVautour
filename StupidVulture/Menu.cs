﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StupidVulture.GameCore.Players;
using StupidVulture.GameCore;
using StupidVulture.Properties;


namespace StupidVulture
{
    public partial class Menu : Form {

        private Bitmap _human = Resources.Human;
        private Bitmap _easy = Resources.Easy;
        private Bitmap _medium = Resources.Medium;
        private Bitmap _hard = Resources.Hard;
        private Bitmap _none = Resources.None;

        public Menu()
        {
            InitializeComponent();
            LaunchButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(0, 255, 255, 255); //Transparent
            ExitButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(0, 255, 255, 255);
            LaunchButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(0, 255, 255, 255);
            ExitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(0, 255, 255, 255);
            LaunchButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 255, 255, 255);
            ExitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(0, 255, 255, 255);

        }


        /// <summary>
        /// Create players according to the selected PictureBox's
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LaunchButton_Click(object sender, EventArgs e)
        {

            List<Player> players = new List<Player>();
            PictureBox[] pictures = { joueur1, joueur2, joueur3, joueur4, joueur5 };

            int i = 0; GameCore.Color gc = GameCore.Color.Red;
            foreach (PictureBox picture in pictures)
            {
                if (i == 1) { gc = GameCore.Color.Blue; }
                else if (i == 2) { gc = GameCore.Color.Green; }
                else if (i == 3) { gc = GameCore.Color.Yellow; }
                else if (i == 4) { gc = GameCore.Color.Purple; }

                if(picture.Image == _human) {
                    Human h = new Human(gc);
                    players.Add(h);
                }
                else if (picture.Image == _easy) {
                    AI easy = new AI(gc, Difficulty.EASY);
                        players.Add(easy);
                }
                else if (picture.Image == _medium) {
                    AI medium = new AI(gc, Difficulty.MEDIUM);
                       players.Add(medium);
                }
                else if (picture.Image == _hard) {
                    AI hard = new AI(gc, Difficulty.HARD);
                       players.Add(hard);
                }
                
                i++;
            }


            foreach (Player pl in players)
            {
                if (pl is AI) {
                    AI plAI = (AI)pl;
                    foreach(Player op in players){
                        if(op != pl){
                            plAI.Opponent.Add(op);
                        }
                    }
                }
            }

            players.Reverse();
            Engine engine = new Engine(players);
            Game form = new Game(engine);
            this.Hide();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void Menu_Load(object sender, EventArgs e) {   
            joueur1.Image = _human;
            joueur2.Image = _easy;
            joueur3.Image = _none;
            joueur4.Image = _none;
            joueur5.Image = _none;

        }

        private void joueurX_Click(object sender, EventArgs e) {
            PictureBox picture = (PictureBox)sender;
            if (picture.Image == _human)
                picture.Image = _easy;
            else if (picture.Image == _easy)
                picture.Image = _medium;
            else if (picture.Image == _medium)
                picture.Image = _hard;
            else if (picture.Image == _hard && picture == joueur1)
                picture.Image = _human;
            else if (picture.Image == _hard && picture == joueur2)
                picture.Image = _easy;
            else if (picture.Image == _hard)
                picture.Image = _none;
            else if (picture.Image == _none)
                picture.Image = _easy;

            picture.Invalidate();
            picture.Update();  
        }
    }     
}
