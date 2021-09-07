using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using SummerTask_RadkevichMarsell.tokenization.tokens;
using SummerTask_RadkevichMarsell.blockScheme.blocks;
using System;

namespace SummerTask_RadkevichMarsell.blockScheme
{
    public class SchemeArea
    {
        public PictureBox Canvas { get; private set; }

        private Dictionary<BlockTemplate, BlockBlueprint> dict;

        private int totalHeight = 10;
        private const int VERTICAL_DISTANCE = 40;
        private const int HORIZONTAL_DISTANCE = 50;

        private bool isMouseHold = false;
        private Point prevMousePos;

        public SchemeArea(PictureBox canvas)
        {
            Canvas = canvas;            
            dict = new Dictionary<BlockTemplate, BlockBlueprint>();
            Canvas.MouseDown += OnMouseDownEvent;
            Canvas.MouseMove += OnMouseMoveEvent;
            Canvas.MouseUp += OnMouseUpEvent;
        }

        public void DrawBlocks(BlockTemplate[] blocks)
        {
            for (int i = 0; i < blocks.Length; i++)
                DrawBlock(blocks[i]);
            Canvas.Size = new Size(Canvas.Width, totalHeight);

            var bmp = new Bitmap(Canvas.Size.Width, Canvas.Size.Height);
            var graphics = Graphics.FromImage(bmp);
            var pen = new Pen(Color.Black, 2);


            var visitedBlocks = new HashSet<BlockTemplate>();
            var currentBlock = blocks[0];
            LinkBlockWithNeigbours(graphics, currentBlock, visitedBlocks);
                

            Canvas.Image = bmp;
            Canvas.Refresh();
        }

        private void LinkBlockWithNeigbours(Graphics graphics, BlockTemplate current, HashSet<BlockTemplate> visited)
        {
            visited.Add(current);
            var currentBlueprint = dict[current];

            if (current.Links is null || current.Links.Length == 0)
                return;

            for (int i = 0; i < current.Links.Length; i++)
            {
                var neighbourBlock = current.Links[i].To;
                var neighbourBlueprint = dict[neighbourBlock];

                if (IsCurrentBelowThanNeighbour(currentBlueprint, neighbourBlueprint))
                    DrawReverseArrow(graphics, currentBlueprint, neighbourBlueprint);

                else if (IsOneOrMoreBlocksBetween(currentBlueprint, neighbourBlueprint))
                {
                    if (current.Type == BlockType.Question)
                    {
                        if (i == 1)
                            DrawLongQuestionArrow(graphics, currentBlueprint, neighbourBlueprint);
                    }
                    else
                        DrawLongArrow(graphics, currentBlueprint, neighbourBlueprint);
                }

                else
                    DrawStraightArrow(graphics, currentBlueprint, neighbourBlueprint);
                if (!visited.Contains(neighbourBlock))
                    LinkBlockWithNeigbours(graphics, neighbourBlock, visited);
              
            }
        }

        private void DrawBlock(BlockTemplate block)
        {
            BlockBlueprint blueprint = null;
            switch (block.Type)
            {
                case BlockType.StartEnd:
                    blueprint = new StartEndBlueprint(block);
                    dict.Add(block, blueprint);
                    AddBlueprintToCanvas(blueprint);
                    break;

                case BlockType.Operation:
                    blueprint = new OperationBlueprint(block);
                    dict.Add(block, blueprint);
                    AddBlueprintToCanvas(blueprint);
                    break;

                case BlockType.Question:
                    blueprint = new QuestionBlueprint(block);
                    dict.Add(block, blueprint);
                    AddBlueprintToCanvas(blueprint);
                    break;

                default:
                    throw new Exception();
            }
        }

        private void AddBlueprintToCanvas(BlockBlueprint blueprint)
        {
            if (Canvas.Height - (totalHeight + blueprint.Height + VERTICAL_DISTANCE) <= 100)
                Canvas.Size = new Size(Canvas.Width, (int)(Canvas.Height * 1.5));

            blueprint.SetLocation((Canvas.Width - blueprint.Width) / 2, totalHeight);
            blueprint.Draw();

            

            totalHeight += blueprint.Height + VERTICAL_DISTANCE;

            Canvas.Controls.Add(blueprint);
        }

        private bool IsCurrentBelowThanNeighbour(BlockBlueprint current, BlockBlueprint neighbour)
        {
            return current.Location.Y > neighbour.Location.Y;
        }

        private bool IsOneOrMoreBlocksBetween(BlockBlueprint current, BlockBlueprint neighbour)
        {
            int distance = neighbour.Location.Y - (current.Location.Y + current.Height);
            return distance > current.Height + VERTICAL_DISTANCE;
        }

        private void DrawLongQuestionArrow(Graphics graphics, BlockBlueprint from, BlockBlueprint to)
        {
            var random = new Random();

            var pen = new Pen(Color.Black, 2);

            var firstJoint = new Point(
                from.RightOutput.X + from.Width / 2 + HORIZONTAL_DISTANCE + random.Next(35,50),
                from.RightOutput.Y);
            graphics.DrawLine(pen, from.RightOutput, firstJoint);

            var secondJoint = new Point(
                firstJoint.X,
                to.TopInput.Y - 15
                );

            graphics.DrawLine(pen, firstJoint, secondJoint);

            var thirdJoint = new Point(to.TopInput.X, secondJoint.Y);
            graphics.DrawLine(pen, secondJoint, thirdJoint);

            graphics.DrawLine(pen, thirdJoint, to.TopInput);

            graphics.DrawLine(pen,
                to.TopInput,
                new Point(
                    to.TopInput.X - 10,
                    to.TopInput.Y - 5)
                );

            graphics.DrawLine(pen,
                to.TopInput,
                new Point(
                    to.TopInput.X + 10,
                    to.TopInput.Y - 5)
                );
        }

        private void DrawStraightArrow(Graphics graphics, BlockBlueprint from, BlockBlueprint to)
        {
            var pen = new Pen(Color.Black, 2);

            graphics.DrawLine(pen, from.DownOutput, to.TopInput);

            graphics.DrawLine(pen,
                to.TopInput,
                new Point(to.TopInput.X - 10, to.TopInput.Y - 10));

            graphics.DrawLine(pen,
                to.TopInput,
                new Point(to.TopInput.X + 10, to.TopInput.Y - 10));
        }

        private void DrawReverseArrow(Graphics graphics, BlockBlueprint from, BlockBlueprint to)
        {
            var pen = new Pen(Color.Black, 2);

            var firstJoint = new Point(from.DownOutput.X, from.DownOutput.Y + 5);
            graphics.DrawLine(pen, from.DownOutput, firstJoint);

            var secondJoint = new Point(
                firstJoint.X - (from.Width / 2 + to.Width / 2 + HORIZONTAL_DISTANCE),
                firstJoint.Y
                );

            graphics.DrawLine(pen, firstJoint, secondJoint);

            var thirdJoint = new Point(secondJoint.X, to.LeftInput.Y);
            graphics.DrawLine(pen, secondJoint, thirdJoint);

            graphics.DrawLine(pen, thirdJoint, to.LeftInput);

            graphics.DrawLine(pen,
                to.LeftInput,
                new Point(
                    to.LeftInput.X - 10,
                    to.LeftInput.Y - 5)
                );

            graphics.DrawLine(pen,
                to.LeftInput,
                new Point(
                    to.LeftInput.X - 10,
                    to.LeftInput.Y + 5)
                );
        }

        private void DrawLongArrow(Graphics graphics, BlockBlueprint from, BlockBlueprint to)
        {
            var random = new Random();

            var pen = new Pen(Color.Black, 2);

            var firstJoint = new Point(from.DownOutput.X, from.DownOutput.Y + 5);
            graphics.DrawLine(pen, from.DownOutput, firstJoint);

            var secondJoint = new Point(
                firstJoint.X + (from.Width / 2 + to.Width / 2 + HORIZONTAL_DISTANCE + random.Next(5, 30)),
                firstJoint.Y
                );

            graphics.DrawLine(pen, firstJoint, secondJoint);

            var thirdJoint = new Point(secondJoint.X, to.TopInput.Y - 15);
            graphics.DrawLine(pen, secondJoint, thirdJoint);

            var fourthJoint = new Point(to.TopInput.X, thirdJoint.Y);
            graphics.DrawLine(pen, thirdJoint, fourthJoint);

            graphics.DrawLine(pen, fourthJoint, to.TopInput);

            graphics.DrawLine(pen,
                to.TopInput,
                new Point(
                    to.TopInput.X - 10,
                    to.TopInput.Y - 5)
                );

            graphics.DrawLine(pen,
                to.TopInput,
                new Point(
                    to.TopInput.X + 10,
                    to.TopInput.Y - 5)
                );
        }

        private void OnMouseDownEvent(object sender, MouseEventArgs e)
        {
            prevMousePos = Cursor.Position;
            Cursor.Current = Cursors.Hand;
            isMouseHold = true;
        }

        private void OnMouseMoveEvent(object sender, MouseEventArgs e)
        {
            if (isMouseHold)
            {
                int mousePosY = Cursor.Position.Y;

                int diffY = mousePosY - prevMousePos.Y;

                Canvas.Location = new Point(Canvas.Location.X, Canvas.Location.Y + diffY);

                prevMousePos.Y = mousePosY;
            }
        }

        private void OnMouseUpEvent(object sender, MouseEventArgs e)
        {
            isMouseHold = false;
        }
    }
}
