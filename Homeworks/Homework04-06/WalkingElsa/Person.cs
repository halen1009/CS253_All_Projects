﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WalkingElsa
{
    internal class Person
    {
        #region 宣告Person的欄位: Name, Velovity, StartPosition, Endposition, Position, elsaImagePictureBox, animationTimer, elsaTrack

        private String name;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        private float velocity;

        public float Velocity
        {
            get { return velocity; }
            set
            {
                if (value < 0) velocity = 0;
                else if (value > 1000) velocity = 1000;
                else velocity = value;
            }
        }

        private Position startPosition;

        public Position StartPosition
        {
            get { return startPosition; }
            set { startPosition = value; }
        }

        private Position endPosition;

        public Position EndPosition
        {
            get { return endPosition; }
            set { endPosition = value; }
        }

        private Position position;

        public System.Windows.Forms.PictureBox elsaImagePictureBox;

        public System.Windows.Forms.Timer animationTimer;

        public Track elsaTrack;

        #endregion 宣告Person的欄位: Name, Velovity, StartPosition, Endposition, Position, elsaImagePictureBox, animationTimer, elsaTrack

        public Person()
        {
            this.startPosition = new Position() { X = 12, Y = 12 };
            this.position = new Position() { X = startPosition.X, Y = startPosition.Y };
            this.endPosition = new Position();
            this.elsaImagePictureBox = new System.Windows.Forms.PictureBox()

            #region elsaImagePictureBox的初始值

            {
                Image = global::WalkingElsa.Properties.Resources.tumblr_muexn83y6t1s0h0fgo1_500,
                Location = new System.Drawing.Point(startPosition.X, startPosition.Y),
                Margin = new System.Windows.Forms.Padding(4, 4, 4, 4),
                Name = "elsaImagePictureBox",
                Size = new System.Drawing.Size(80, 111),
                SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage,
                TabIndex = 0,
                TabStop = false
            };

            #endregion elsaImagePictureBox的初始值

            this.elsaTrack = new Track();
            this.animationTimer = new Timer();
        }

        public Position Moveforward(float dx, float dy)
        {
            this.position.X += (int)dx;
            this.position.Y += (int)dy;
            return this.position;
        }

        public Position UpdateElsaPosition()
        {
            float dx = velocity * animationTimer.Interval / 1000.0f;
            float dy = velocity * animationTimer.Interval / 1000.0f;
            return Moveforward(position.X + dx > endPosition.X ? 0 : dx, position.Y + dy > endPosition.Y ? 0 : dy);
        }

        public void animationTimer_Tick(object sender, EventArgs e)
        {
            UpdateElsaPosition();
            elsaImagePictureBox.Location = new Point(position.X, position.Y);
            elsaTrack.points.Add(elsaImagePictureBox.Location);

            //Form1.messageRichTextBox.Text = string.Format("Elsa的位置x = {0}, y = {1}", position.GetX(), position.Y);
        }

        //public void InitializeImage()
        //{
        //    elsaImagePictureBox.Image = global::WalkingElsa.Properties.Resources.tumblr_muexn83y6t1s0h0fgo1_500;
        //    elsaImagePictureBox.Location = new System.Drawing.Point(12, 12);
        //    elsaImagePictureBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
        //    elsaImagePictureBox.Name = "elsaImagePictureBox";
        //    elsaImagePictureBox.Size = new System.Drawing.Size(80, 111);
        //    elsaImagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        //    elsaImagePictureBox.TabIndex = 0;
        //    elsaImagePictureBox.TabStop = false;
        //    //Form1.Controls.Add(elsaImagePictureBox);
        //}
    }
}