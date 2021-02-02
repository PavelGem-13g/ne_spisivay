using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;

namespace MnogugolnikiShapeLibrary.Data
{
    public abstract class ShapeData 
    {
        public static void SaveFile(ref List<Shape> shapes, ref string fileName, ref bool isChanged)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            binaryFormatter.Serialize(fileStream, shapes);
            binaryFormatter.Serialize(fileStream, Shape.R);
            binaryFormatter.Serialize(fileStream, Shape.FillColor);
            binaryFormatter.Serialize(fileStream, Shape.LineColor);
            fileStream.Close();
        }
        public static void LoadFile(ref List<Shape> shapes, ref string fileName, ref bool isChanged)
        {
            if (isChanged)
            {
                if (MessageBox.Show("Save file?", "Error", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Save(ref shapes,ref fileName,ref isChanged);
                }
            }
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "poly files (*.poly)|*poly";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                FileStream fileStream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read);
                shapes = (List<Shape>)binaryFormatter.Deserialize(fileStream);
                Shape.R = (int)binaryFormatter.Deserialize(fileStream);
                Shape.FillColor = (Color)binaryFormatter.Deserialize(fileStream);
                Shape.LineColor = (Color)binaryFormatter.Deserialize(fileStream);
                fileStream.Close();
                fileName = openFileDialog.FileName;
                isChanged = false;
            }
        }
        public static void Save(ref List<Shape> shapes, ref string fileName, ref bool isChanged)
        {
            if (fileName.Length > 0)
            {
                SaveFile(ref shapes,ref fileName,ref isChanged);
            }
            else
            {
                SaveAsFile(ref shapes,ref fileName,ref isChanged);
            }
            isChanged = false;
        }
        public static void SaveAsFile(ref List<Shape> shapes, ref string fileName, ref bool isChanged)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "poly files (*.poly)|*poly";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog.FileName.Contains(".poly"))
                {
                    fileName = saveFileDialog.FileName;
                }
                else
                {
                    fileName = saveFileDialog.FileName + ".poly";
                }
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                binaryFormatter.Serialize(fileStream, shapes);
                binaryFormatter.Serialize(fileStream, Shape.R);
                binaryFormatter.Serialize(fileStream, Shape.FillColor);
                binaryFormatter.Serialize(fileStream, Shape.LineColor);
            }
            isChanged = false;
        }
        public static void New(ref List<Shape> shapes, ref string fileName, ref string Text) 
        {
            shapes = new List<Shape>();
            Shape.FillColor = Color.Black;
            Shape.LineColor = Color.Black;
            Shape.R = 50;
            fileName = "";
            Text = "Mnogugolniki";
        }
    }
}
