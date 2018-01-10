using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabelCalculator
{
    class CalcLibrary
    {
        private double labelQuantity, labelImages, pixelSize, labelTotal, tail, leader, itemBlank,
                       eyeMarks, fiftyFeetImages, oneHundredFeet, itemFootage, addedTotalFootage;

        public double CalculateItemFootage(string totalLabels)
        {
            return itemFootage = Math.Round(((pixelSize / 360) * double.Parse(totalLabels)), 2);
        }

        public double FiftyFootStop(string pixels)
        {
            pixelSize = double.Parse(pixels);
            return CalcuateFiftyFeetImages();
        }

        private double CalcuateFiftyFeetImages()
        {
            return fiftyFeetImages = ((50 * 12) / (pixelSize / 360));
        }
    }
}
