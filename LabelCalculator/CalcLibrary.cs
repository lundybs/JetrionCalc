using System;

namespace LabelCalculator
{
    class CalcLibrary
    {
        private double labelQuantity, labelImages, pixelSize, eyeMarks, fiftyFeetImages, itemFootage;

        public double CalculateItemFootage(string totalLabels)
        {
            return itemFootage = Math.Round(((pixelSize / 360) * double.Parse(totalLabels)), 2);
        }

        /// <summary>
        /// This function deals with calculations that need to show up in the textbox when the textboxes are filled in for 50' stop
        /// </summary>
        public string FiftyFootStop(string pixels, string currentLabelQuantity, string printedLabelsQuantity)
        {
            pixelSize = double.Parse(pixels);
            double currentLabel = double.Parse(currentLabelQuantity);
            double printedLabels = double.Parse(printedLabelsQuantity);

            CalcuateFiftyFeetImages();
            int newQuantityOfLabels = (int)((currentLabel - printedLabels) + fiftyFeetImages);
            return newQuantityOfLabels.ToString();
        }

        private void CalcuateFiftyFeetImages()
        {
            fiftyFeetImages = ((50 * 12) / (pixelSize / 360)) + 1;
        }

        /// <summary>
        /// This function takes the values that are passed is from the upper left textboxes and then uses them for various calcutions
        /// throughout the class file
        /// </summary>
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

        /// <summary>
        /// This is to calculate the number of images that will need to be printed to fullfil customers ordered quantity
        /// </summary>
        public string LabelTotals(double overs, double extra)
        {
            double overPercentage = overs;
            double embossOrHotStampExtra = extra * fiftyFeetImages;
            int labelTotal = (int)((labelQuantity / labelImages) * overPercentage + fiftyFeetImages + embossOrHotStampExtra) + 1;
            return labelTotal.ToString();
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
            CalcuateFiftyFeetImages();
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


        /// <summary>
        /// The fucntions below are for the PD Off Set tab to calculate every row for each print head in the press.
        /// Instead of passing in 20+ parameters, each row and print head is broken down to their own function that returns a string
        /// for the textboxes
        /// </summary>
        public string White1R1PDOffSet(string w1R1, double resolution)
        {
            double newW1R1 = (double.Parse(w1R1) * resolution) / 360;
            return newW1R1.ToString("F");
        }

        public string White1R2PDOffSet(string w1R2, double resolution)
        {
            double newW1R2 = (double.Parse(w1R2) * resolution) / 360;
            return newW1R2.ToString("F");
        }

        public string White2R1PDOffSet(string w2R1, double resolution)
        {
            double newW2R1 = (double.Parse(w2R1) * resolution) / 360;
            return newW2R1.ToString("F");
        }

        public string White2R2PDOffSet(string w2R2, double resolution)
        {
            double newW2R2 = (double.Parse(w2R2) * resolution) / 360;
            return newW2R2.ToString("F");
        }

        public string White3R1PDOffSet(string w3R1, double resolution)
        {
            double newW3R1 = (double.Parse(w3R1) * resolution) / 360;
            return newW3R1.ToString("F");
        }

        public string White3R2PDOffSet(string w3R2, double resolution)
        {
            double newW3R2 = (double.Parse(w3R2) * resolution) / 360;
            return newW3R2.ToString("F");
        }

        public string Cyan1R1PDOffSet(string c1R1, double resolution)
        {
            double newC1R1 = (double.Parse(c1R1) * resolution) / 360;
            return newC1R1.ToString("F");
        }

        public string Cyan1R2PDOffSet(string c1R2, double resolution)
        {
            double newC1R2 = (double.Parse(c1R2) * resolution) / 360;
            return newC1R2.ToString("F");
        }

        public string Cyan2R1PDOffSet(string c2R1, double resolution)
        {
            double newC2R1 = (double.Parse(c2R1) * resolution) / 360;
            return newC2R1.ToString("F");
        }

        public string Cyan2R2PDOffSet(string c2R2, double resolution)
        {
            double newC2R2 = (double.Parse(c2R2) * resolution) / 360;
            return newC2R2.ToString("F");
        }

        public string Cyan3R1PDOffSet(string c3R1, double resolution)
        {
            double newC3R1 = (double.Parse(c3R1) * resolution) / 360;
            return newC3R1.ToString("F");
        }

        public string Cyan3R2PDOffSet(string c3R2, double resolution)
        {
            double newC3R2 = (double.Parse(c3R2) * resolution) / 360;
            return newC3R2.ToString("F");
        }

        public string Magenta1R1PDOffSet(string m1R1, double resolution)
        {
            double newM1R1 = (double.Parse(m1R1) * resolution) / 360;
            return newM1R1.ToString("F");
        }

        public string Magenta1R2PDOffSet(string m1R2, double resolution)
        {
            double newM1R2 = (double.Parse(m1R2) * resolution) / 360;
            return newM1R2.ToString("F");
        }

        public string Magenta2R1PDOffSet(string m2R1, double resolution)
        {
            double newM2R1 = (double.Parse(m2R1) * resolution) / 360;
            return newM2R1.ToString("F");
        }

        public string Magenta2R2PDOffSet(string m2R2, double resolution)
        {
            double newM2R2 = (double.Parse(m2R2) * resolution) / 360;
            return newM2R2.ToString("F");
        }

        public string Magenta3R1PDOffSet(string m3R1, double resolution)
        {
            double newM3R1 = (double.Parse(m3R1) * resolution) / 360;
            return newM3R1.ToString("F");
        }

        public string Magenta3R2PDOffSet(string m3R2, double resolution)
        {
            double newM3R2 = (double.Parse(m3R2) * resolution) / 360;
            return newM3R2.ToString("F");
        }

        public string Yellow1R1PDOffSet(string y1R1, double resolution)
        {
            double newY1R1 = (double.Parse(y1R1) * resolution) / 360;
            return newY1R1.ToString("F");
        }

        public string Yellow1R2PDOffSet(string y1R2, double resolution)
        {
            double newY1R2 = (double.Parse(y1R2) * resolution) / 360;
            return newY1R2.ToString("F");
        }

        public string Yellow2R1PDOffSet(string y2R1, double resolution)
        {
            double newY2R1 = (double.Parse(y2R1) * resolution) / 360;
            return newY2R1.ToString("F");
        }

        public string Yellow2R2PDOffSet(string y2R2, double resolution)
        {
            double newY2R2 = (double.Parse(y2R2) * resolution) / 360;
            return newY2R2.ToString("F");
        }

        public string Yellow3R1PDOffSet(string y3R1, double resolution)
        {
            double newY3R1 = (double.Parse(y3R1) * resolution) / 360;
            return newY3R1.ToString("F");
        }

        public string Yellow3R2PDOffSet(string y3R2, double resolution)
        {
            double newY3R2 = (double.Parse(y3R2) * resolution) / 360;
            return newY3R2.ToString("F");
        }

        public string Black1R1PDOffSet(string k1R1, double resolution)
        {
            double newK1R1 = (double.Parse(k1R1) * resolution) / 360;
            return newK1R1.ToString("F");
        }

        public string Black1R2PDOffSet(string k1R2, double resolution)
        {
            double newK1R2 = (double.Parse(k1R2) * resolution) / 360;
            return newK1R2.ToString("F");
        }

        public string Black2R1PDOffSet(string k2R1, double resolution)
        {
            double newK2R1 = (double.Parse(k2R1) * resolution) / 360;
            return newK2R1.ToString("F");
        }

        public string Black2R2PDOffSet(string k2R2, double resolution)
        {
            double newK2R2 = (double.Parse(k2R2) * resolution) / 360;
            return newK2R2.ToString("F");
        }

        public string Black3R1PDOffSet(string k3R1, double resolution)
        {
            double newK3R1 = (double.Parse(k3R1) * resolution) / 360;
            return newK3R1.ToString("F");
        }

        public string Black3R2PDOffSet(string k3R2, double resolution)
        {
            double newK3R2 = (double.Parse(k3R2) * resolution) / 360;
            return newK3R2.ToString("F");
        }
    }
}