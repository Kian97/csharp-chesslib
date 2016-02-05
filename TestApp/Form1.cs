using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

using Chess;
using Chess.Peices;

namespace TestApp
{
    public partial class Form1 : Form
    {
        private void Form1_Load(object sender, EventArgs e)
        {
            //handle chess picturebox events
            PboxChess.Paint += PboxChess_Paint;
            PboxChess.MouseClick += OnClick; 

            PBoxBlack.Paint += PboxBlack_Paint;
            PBoxWhite.Paint += PboxWhite_Paint;

            //handle chess library events
            myGame.GetPieceTransform += PromptForPeice;
            myGame.OnPieceMove += OnMove;
            myGame.OnEndGame += OnEndGame;
            myGame.OnPieceTaken += OnTake;

            PboxChess.Invalidate(); //invalidate for initial draw
        } //Hook events
        public Form1()
        {
            InitializeComponent();
            //Misc images
            game_images[0] = Image.FromFile("images/selected.png");
            game_images[1] = Image.FromFile("images/checkglow.png");
            game_images[2] = Image.FromFile("images/selectglow.png");
            //White images
            peice_images[0, 0] = Image.FromFile("images/king_w.png");
            peice_images[0, 1] = Image.FromFile("images/queen_w.png");
            peice_images[0, 2] = Image.FromFile("images/rook_w.png");
            peice_images[0, 3] = Image.FromFile("images/bishop_w.png");
            peice_images[0, 4] = Image.FromFile("images/knight_w.png");
            peice_images[0, 5] = Image.FromFile("images/pawn_w.png");
            //Black images
            peice_images[1, 0] = Image.FromFile("images/king_b.png");
            peice_images[1, 1] = Image.FromFile("images/queen_b.png");
            peice_images[1, 2] = Image.FromFile("images/rook_b.png");
            peice_images[1, 3] = Image.FromFile("images/bishop_b.png");
            peice_images[1, 4] = Image.FromFile("images/knight_b.png");
            peice_images[1, 5] = Image.FromFile("images/pawn_b.png");
            //Sounds
            game_sounds[0] = new SoundPlayer() { SoundLocation = "sounds/move.wav" };
            game_sounds[1] = new SoundPlayer() { SoundLocation = "sounds/transform.wav" };
            game_sounds[2] = new SoundPlayer() { SoundLocation = "sounds/endgame.wav" };
            game_sounds[3] = new SoundPlayer() { SoundLocation = "sounds/take.wav" };
        } //Load assets

        ChessGame myGame = new ChessGame(100, true); //Create game

        //Resources
        public static Image[,] peice_images = new Image[2, 6];
        public static Image[] game_images = new Image[3];
        public static SoundPlayer[] game_sounds = new SoundPlayer[4];

        public enum Sounds { move, change, endgame, take }
        public void PlaySound(Sounds sound)
        {
            foreach (SoundPlayer sound_ in game_sounds) { sound_.Stop(); }
            game_sounds[(int)sound].Play();
        }

        public enum Images { select, check, selbox}


        //Chess Event handlers
        public PType PromptForPeice()
        {
            PlaySound(Sounds.change); return PType.Queen;
        }
        public void OnMove(Tuple<Peice, Point> moveData)
        {
            PlaySound(Sounds.move);
            if (myGame.CanDraw()) { btn_draw.Enabled = true; } else { btn_draw.Enabled = false; }
        }
        public void OnEndGame(PSide side, ChessGame.EndGames endType)
        {
            PlaySound(Sounds.endgame);
            switch(endType)
            {
                case (ChessGame.EndGames.Checkmate): { MessageBox.Show(null, side.ToString() + " has been checkmated!", "Game over", MessageBoxButtons.OK, MessageBoxIcon.Information); break; }
                case (ChessGame.EndGames.Draw): { MessageBox.Show(null, "Game drawn, 50/50", "Game over", MessageBoxButtons.OK, MessageBoxIcon.Information); break; }
                case (ChessGame.EndGames.Stalemate): { MessageBox.Show(null, "StaleMate, 50/50", "Game over", MessageBoxButtons.OK, MessageBoxIcon.Information); break; }
            }

            btn_reset.Enabled = true;
        }
        public void OnTake(Peice peice)
        { PlaySound(Sounds.take); PBoxWhite.Invalidate(); PBoxBlack.Invalidate(); }


        //Form control event handlers
        private void OnClick(object sender, MouseEventArgs e)
        {
            //get 0-7 grid location of click
            Point loc = new Point((int)Math.Floor((e.X / (float)PboxChess.Width) * 8), 7 - (int)Math.Floor((e.Y / (float)PboxChess.Width) * 8));


            if(!myGame.MakeMove(loc))
            {
                myGame.SelectPeice(loc);
            }

            //if (myGame.SelectedPiece == null) { myGame.SelectPeice(loc); } //attempt to select piece at loc
            //else { myGame.MakeMove(loc); } //attempt to make move to selected loc


            PboxChess.Invalidate(); //redraw board
        }
        private void btn_reset_Click(object sender, EventArgs e)
        {
            myGame.ResetBoard();
            PboxChess.Invalidate();
            PBoxBlack.Invalidate();
            PBoxWhite.Invalidate();
            btn_reset.Enabled = false;
        }

        //Draw
        private void PboxChess_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //draw pieces
            foreach (Peice peice in myGame.PieceList)
            {
                if (peice != null)
                {
                    Point peiceLoc = peice.MyLocation; //get board location of piece

                    if (peice.MyType == PType.King && myGame.IsInCheck(peice.MySide)) { Piece_Paint(g, game_images[(int)Images.check], peiceLoc); } //piece king in check, draw red aura
                    if (myGame.SelectedPiece == peice) { Piece_Paint(g, game_images[(int)Images.selbox], peiceLoc); } //currently selected piece, draw selection box

                    Piece_Paint(g, peice_images[(int)peice.MySide, (int)peice.MyType], peiceLoc); //draw piece onto board
                }
            }

            //draw selections piece
            if (myGame.SelectedPiece != null)
            {
                foreach (Point movePoint in myGame.GetSelectedMoves())
                {
                    Piece_Paint(g, game_images[(int)Images.select], movePoint);
                }
            }
        }
        private void Piece_Paint(Graphics g, Image img, Point peiceLoc)
        {
            g.DrawImage(img, peiceLoc.X * (PboxChess.Width / 8f), (7 - peiceLoc.Y) * (PboxChess.Width / 8f));
        } //draw piece at grid loc

        private void PboxWhite_Paint(object sender, PaintEventArgs e)
        {
            Taken_Paint(e, PSide.White);
        }
        private void PboxBlack_Paint(object sender, PaintEventArgs e)
        {
            Taken_Paint(e, PSide.Black);
        }
        public void Taken_Paint(PaintEventArgs e, PSide mySide)
        {
            Graphics g = e.Graphics;
            int count_y = 0; int count_x = 0;
            foreach (Peice peice in myGame.TakenList)
            {
                if (peice.MySide == mySide)
                {
                    g.DrawImage(peice_images[(int)peice.MySide, (int)peice.MyType], new Point(count_x * 55, count_y * 55));
                    count_y++; if (count_y > 8) { count_y = 0; count_x++; }
                }
            }
        }



    }
}
