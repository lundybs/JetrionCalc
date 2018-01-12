using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabelCalculator
{
    class CalcLibrary
    {
        private double labelQuantity, labelImages, pixelSize, eyeMarks, fiftyFeetImages, itemFootage;

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
            fiftyFeetImages = ((50 * 12) / (pixelSize / 360)) + 1;
        }

        public void LabelInfo(string quantity, string pixel, string imageQuantity, string eyeMark)
        {
            labelQuantity = double.Parse(quantity);
            labelImages = double.Parse(imageQuantity);
            pixelSize = double.Parse(pixel);
            eyeMarks = double.Parse(eyeMark);
        }

        public string ThirtyTwoPitchCalculation()
        {
            int thirtyTwoPitch = (int)((((pixelSize / 360)) * (32 / Math.PI) / eyeMarks) + 1);
            return thirtyTwoPitch.ToString();
        }

        public string EighthPitchCalculation()
        {
            int eighthPitch = (int)((((pixelSize / 360) / .125) / eyeMarks) + 1);
            return eighthPitch.ToString();
        }

        public int LabelTotals(double overs, double extra)
        {
            double overPercentage = overs;
            double embossOrHotStampExtra = extra * fiftyFeetImages;
            double labelTotal = ((labelQuantity / labelImages) * overPercentage + fiftyFeetImages + embossOrHotStampExtra);
            return (int)labelTotal + 1;
        }

        public string TailCalculation()
        {
            int tail = (int)((960 / (pixelSize / 360)) + 1);
            return tail.ToString();
        }

        public string LeaderCalculation()
        {
            int leader = (int)((2700 / (pixelSize / 360)) + 1);
            return leader.ToString();
        }

        public string ItemBlankCalculation()
        {
            int itemBlank = (int)((84 / (pixelSize / 360)) + 1);
            return itemBlank.ToString();
        }

        public string FiftyFootCalculation()
        {
            int fiftyFoot = (int)fiftyFeetImages;
            return fiftyFoot.ToString();
        }

        public string OneHundredFootCalculation()
        {
            int oneHundredFoot = (int)(fiftyFeetImages * 2);
            return oneHundredFoot.ToString();
        }

        public string ThreeHundredFootCalcation()
        {
            int threeHundredFoot = (int)(fiftyFeetImages * 6);
            return threeHundredFoot.ToString();
        }
    }
}
