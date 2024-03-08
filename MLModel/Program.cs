// See https://aka.ms/new-console-template for more information

using MLModel;


//Load sample data
var imageBytes = File.ReadAllBytes(@"C:\Users\Asus\Documents\CoffeePlant\Berry Borrer\IMG_0476.JPG");
MLModel1.ModelInput sampleData = new MLModel1.ModelInput()
{
    ImageSource = imageBytes,
};

//Load model and predict output
var result = MLModel1.Predict(sampleData);

Console.WriteLine(result.PredictedLabel);


