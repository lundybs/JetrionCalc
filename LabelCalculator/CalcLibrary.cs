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

        public double FiftyFootStop(string pixels, string currentLabelQuantity, string printedLabelsQuantity)
        {
            pixelSize = double.Parse(pixels);
            double currentLabel = double.Parse(currentLabelQuantity);
            double printedLabels = double.Parse(printedLabelsQuantity);
            
            CalcuateFiftyFeetImages();
            double newQuantityOfLabels = (currentLabel - printedLabels) + fiftyFeetImages;
            return newQuantityOfLabels = ((int)newQuantityOfLabels + 1);
        }

        private void CalcuateFiftyFeetImages()
        {
           fiftyFeetImages = ((50 * 12) / (pixelSize / 360));
        }
    }
}
