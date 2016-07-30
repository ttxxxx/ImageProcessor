﻿namespace ImageProcessorCore.Benchmarks.Image
{
    using System.Drawing;

    using BenchmarkDotNet.Attributes;

    using CoreColor = ImageProcessorCore.Color;
    using CoreImage = ImageProcessorCore.Image;
    using SystemColor = System.Drawing.Color;

    public class GetSetPixel
    {
        [Benchmark(Baseline = true, Description = "System.Drawing GetSet Pixel")]
        public SystemColor ResizeSystemDrawing()
        {
            using (Bitmap source = new Bitmap(400, 400))
            {
                source.SetPixel(200, 200, SystemColor.White);
                return source.GetPixel(200, 200);
            }
        }

        [Benchmark(Description = "ImageProcessorCore GetSet Pixel")]
        public CoreColor ResizeCore()
        {
            CoreImage image = new CoreImage(400, 400);
            using (IPixelAccessor<CoreColor, uint> imagePixels = image.Lock())
            {
                imagePixels[200, 200] = CoreColor.White;
                return imagePixels[200, 200];
            }
        }
    }
}
