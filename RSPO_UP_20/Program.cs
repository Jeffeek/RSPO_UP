using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using ImageMagick;
using RSPO_UP_20.Animals;

namespace RSPO_UP_20
{
    class Program
    {
        static void Main(string[] args)
        {
            var dog = new Dog(3.5, "Dog", "Wide", 12, "Pride");
            var dog2 = new Dog(-3.5, "Log", "Wide", 12, "Pride");
            Validate(dog);
            Validate(dog2);
        }

        private static void Validate(Animal animal)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(animal);

            if (!Validator.TryValidateObject(animal, context, results, true))
            {
                foreach (var error in results)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }
            else
                Console.WriteLine("Животное прошло валидацию");
        }

        private static void ImageGrayScale()
        {
            var inputPath = $"{Directory.GetCurrentDirectory()}\\initImage.jpg";
            var outputPath = $"{Directory.GetCurrentDirectory()}\\output.jpg";
            var outputHistogramPath = $"{Directory.GetCurrentDirectory()}\\histogram.txt";
            using var image = new MagickImage(inputPath);
            image.Grayscale();
            image.AutoGamma();
            var histogram = image.Histogram().Select(x => $"{x.Key}:{x.Value}");
            File.WriteAllLines(outputHistogramPath, histogram);
            image.Write(outputPath);
        }
    }
}
